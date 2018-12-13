using System.Net;
using TechTalk.SpecFlow;
using US.EndPointTests.AdditionalFunctionalities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace US.EndPointTests.Steps
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimpleIdentityServer.Core.Common.DTOs.Responses;
    using US.EndPointTests.AdditionalFunctionalities.Handlers;

    [Binding]
    public class CommonSteps : StepsBase
    {
        public string barcode_id = "555555";
		public string episodeNumber_id = "en_555555";

		public string old_barcode_id = "777777";
		public string old_episodeNumber_id = "en_777777";

		public string new_barcode_id = "888888";
		public string new_episodeNumber_id = "en_888888";

		//public string barcode_workflow_notification = "666666";
		private readonly TokenService _tokenService;

		public object ResultReleasedEventHandler { get; private set; }

		public CommonSteps()
        {
            _tokenService = new TokenService();
        }

        [Given(@"a successful login")]
        public async Task GivenASuccessfulLogin()
        {
            _tokenResponse = await _tokenService.GetAuthToken("doctor", "password").ConfigureAwait(false);
        }


		[Given(@"the user noScim login")]
		public async Task GivenUserNoScimSuccessfulLogin()
		{
			_tokenResponse = await _tokenService.GetAuthToken("noScim", "noScim").ConfigureAwait(false);
		}

		[Given(@"an unsuccessful login")]
        public async Task GivenAnUnsuccessfulLogin()
        {
            _tokenResponse = await _tokenService.GetAuthToken("blah", "blah").ConfigureAwait(false);
        }

		[Given(@"an invalid login")]
		public async Task GivenAnInvalidLogin()
		{
			_tokenResponse = await _tokenService.GetAuthToken("doctor", "password").ConfigureAwait(false);

			_tokenResponse.AccessToken = "invalid";
			_tokenResponse.IdToken = "invalid";
			_tokenResponse.TokenType = "Bearer";
			_tokenResponse.ExpiresIn = 3600;
			_tokenResponse.RefreshToken = "invalid";
			_tokenResponse.Scope = new string[] { "a", "b", "c" };
		}

		[Given(@"The status code is '(.*)'")]
		[When(@"The status code is '(.*)'")]
		[Then(@"The status code is '(.*)'")]
        public void ThenTheResponseIs(int expected_status_code)
        {
            var a = response.Content;

            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;

            Assert.AreEqual(expected_status_code, numericStatusCode, "Status code is not " + expected_status_code+ "\n - Response: "+response.Content);
        }


        [Given(@"the response is empty")]
        [Then(@"the response is empty")]
        public void GivenTheResponseIsEmpty()
        {
            bool IsEmpty = response.Content.Equals("[]");
            Assert.IsTrue(IsEmpty, $"Response content is not empty: {response.Content}");

            var dynJson = JsonConvert.DeserializeObject<JObject[]>(response.Content);

            int lenght = dynJson.Length;
            bool isEmpty = dynJson.Length == 0 ? true : false;
            Assert.IsTrue(isEmpty, $"Response content is not empty: {response.Content}");
        }

        [Given(@"Rabbit queue is started")]
        public async void StartRabbitQueue()
        {
            StepsBase.rabbit = new RabbitManager();
            StepsBase.rabbitWorkflow = await StepsBase.rabbit.Start().ConfigureAwait(false);

        }

		[AfterScenario("After_Scenario_StopRabbitQueue")]
		public void StopRabbitQueue()
		{
			StepsBase.rabbitWorkflow.Dispose();
		}

        [When(@"Wait EpisodeNumberUpdated event rabbit message")]
        public async Task GivenWaitForMicroserviceToAddEpisodeNumber()
        {
            EpisodeNumberEventHandler.ExpectedBarcode = barcode_workflow_notification;

            await Task.Run(() => EpisodeNumberEventHandler.manualResetEventSlim.Wait(5000)).ConfigureAwait(false);

			Assert.IsTrue(EpisodeNumberEventHandler.EventReceived, "EpisodeNumberUpdated event did not arrive");
		}

		[Given(@"Wait for '(.*)' seconds")]
		[When(@"Wait for '(.*)' seconds")]
		[Then(@"Wait for '(.*)' seconds")]
		public void WaitForSeconds(int seconds)
		{
			Thread.Sleep(seconds);
		}

		#region .: Before Scenario :.

		[BeforeScenario("Before_Scenario_clean_DB")]
        public void Clean_db()
        {
            DB_queries a = new DB_queries();
            a.DeleteBarcodeInDB(barcode_id);
            a.UnreleaseResultFromBarcodeInDB(episodeNumber_id);
        }

		[BeforeScenario("before_clean_result_from_db")]
		public void Clean_result_DB()
		{
			DB_queries a = new DB_queries();
			a.DeleteResultFromBarcodeInDB("NEW_RESULT_ENDPOINT");
		}

		[BeforeScenario("Before_Scenario_release_a_result_DB")]
		public void Release_result_DB()
		{
			DB_queries a = new DB_queries();
			a.ReleaseResultFromBarcodeInDB(episodeNumber_id);
		}

		[BeforeScenario("Before_Scenario_unrelease_a_result_DB")]
		public void Unrelease_result_DB()
		{
			DB_queries a = new DB_queries();
			a.UnreleaseResultFromBarcodeInDB(episodeNumber_id);
		}

		[BeforeScenario("Before_scenario_complete_whatsapp_groups")]
		public void Complete_groups_DB()
		{
			DB_queries a = new DB_queries();
			a.CompleteWhatsappGroupsInDB();
		}

		[BeforeScenario("Before_scenario_complete_first_whatsapp_groups")]
		public void Complete_first_groups_DB()
		{
			DB_queries a = new DB_queries();
			a.CompleteFirstWhatsappGroupsInDB();
		}

		#endregion

		[Given(@"Clean up Notification Workflow")]
        public void GivenCleanUpNotificationWorkflow()
        {
            DB_queries a = new DB_queries();
            a.DeleteBarcodeInDB(barcode_workflow_notification);
            a.DeleteResultFromBarcodeInDB(EpisodeNumber_workflow_notification);
            a.DeleteBarcodeFromPushNotificationDB(barcode_workflow_notification);
            a.CleanupNotificationWorkflowDB(barcode_workflow_notification);
        }



		[AfterScenario("After_Scenario_change_result_barcode_DB")]
		public void Change_result_barcode_in_DB()
		{
			DB_queries a = new DB_queries();
			a.ChangeResultBarcodeInDB(old_episodeNumber_id, new_episodeNumber_id);
		}


		//ReferenceData
		[BeforeScenario("Before_scenario_empty_whatsapp_groups")]
		[AfterScenario("After_scenario_empty_whatsapp_groups")]
		public void Empty_groups_DB()
		{
			DB_queries a = new DB_queries();
			a.EmptyWhatsappGroupsInDB();
		}


        [Given(@"Barcode id '(.*)'")]
        public void GivenBarcodeId(string barcode)
        {
            barcode_workflow_notification = barcode;
        }

        [Given(@"Barcode id randomly generated")]
        public void GivenBarcodeIdRandomlyGenerated()
        {
            Random random = new Random();// DateTime.Now.Ticks;
            //public static string RandomString(int length)
            const string chars = "0123456789";
            barcode_workflow_notification = $"66{new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray())}";
			Console.WriteLine("- Random barcode generated:\n  --Barcode: " + barcode_workflow_notification+"\n  --EpisodeNumber: "+ EpisodeNumber_workflow_notification);
		}

		public static long ConvertToEpoch(string date)
		{
			var dateTime = new DateTime(
				Int32.Parse(date.Substring(0, "yyyy".Length)),
				Int32.Parse(date.Substring("yyyy-".Length, "MM".Length)),
				Int32.Parse(date.Substring("yyyy-MM-".Length, "dd".Length)));
			var dateTimeOffset = new DateTimeOffset(dateTime);
			var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();

			return unixDateTime;
		}
	}
}
