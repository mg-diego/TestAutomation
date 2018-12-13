using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using RestSharp;
using Roche.Rmdd.HivMonitor.Reporting.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Roche.Rmdd.HivMonitor.ResultRegister.DTO;
using US.EndPointTests.AdditionalFunctionalities;
using Roche.Rmdd.HivMonitor.Utils;

namespace US.EndPointTests.Steps
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
	using System.Text.RegularExpressions;

	[Binding]
    public class ResultsSteps : StepsBase
    {
        private class DataForAppToken
        {
            public string clientId;
            public string clientSecret;
            public string[] scopes;
        }

		StepsBase baseSteps = new StepsBase();

		TokenStore tokenStore;
        public string microservice = "results";
        public string appToken = "NotGenerated";
        private Dictionary<string, DataForAppToken> data = new Dictionary<string, DataForAppToken>
            {
                { "ExportClient", new DataForAppToken {
                    clientId = "ExportClient",
                    clientSecret = "nKa5$a59ByXHLLBS",
                    scopes = new[] { "exportdata" }
                } },
                { "ReportingApi", new DataForAppToken{
                    clientId= "ReportingApi",
                    clientSecret = "J@mp.9J[hT.FMYxT",
                    scopes = new[] { "scim_read", "testresult_read", "barcode_read" }
                } }
            };

        [Given(@"App token is generated for '(.*)' client")]
        public async Task GivenAppTokenIsGenerated(string clientId)
        {
            appToken = await generateAppToken(data[clientId]);
        }


        async Task<string> generateAppToken(DataForAppToken dataForAppToken)
        {
			string environment = "";

			if (baseSteps.site == "staging") { environment = "staging"; }
			if (baseSteps.site == "bcn") { environment = "staging"; }
			if (baseSteps.site == "demo") { environment = "staging"; }

			tokenStore = new TokenStore(dataForAppToken.clientId, dataForAppToken.clientSecret, $"{protocol}uma{environment}{server}");
			var token = await tokenStore.GetToken(dataForAppToken.scopes).ConfigureAwait(false);

            return token.AccessToken;
        }


		#region .: Playground Controller :.

		/// <summary>
		/// GET /playground/results
		/// </summary>
		[When(@"request to get unreleased results")]
        public void WhenRequestToGetTheUnreleasedResults()
        {
            var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/results");
            request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
            request.AddHeader("cache-control", "no-cache");

            response = client.Execute(request);
        }

		/// <summary>
		/// GET //playground/results/{barcode}
		/// </summary>
		[Given(@"request to get playground result from barcode '(.*)'")]
		[When(@"request to get playground result from barcode '(.*)'")]
        public void WhenRequestGetResultConcreteBarcode(string expected_barcode)
        {
			expected_barcode = "en_" + expected_barcode;

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/results/{expected_barcode}");
            request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            response = client.Execute(request);
        }


        //REVISAR
        /// <summary>
        /// POST //playground/results/release (barcode)
        /// </summary>
        [When(@"request to release results for barcode")]
        public void WhenRequestToReleaseResultsForBarcode()
        {
            var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/results/release");
            request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", $"[ \"{EpisodeNumber_workflow_notification}\"]", ParameterType.RequestBody);

            response = client.Execute(request);
        }

    
        //playground/results/release
        [When(@"request to release results for barcode '(.*)'")]        
        public void WhenRequestToReleaseResultsForBarcode(string expected_barcode)
		{
			expected_barcode = "en_" + expected_barcode;

            var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/results/release");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"[ \"{expected_barcode}\"]", ParameterType.RequestBody);

			response = client.Execute(request);
		}

    

		/// <summary>
		/// POST //playground/results/unrelease/{barcode}
		/// </summary>
		[When(@"request to unrelease results for barcode '(.*)'")]
		public void WhenRequestToUnreleaseResultsForBarcode(string expected_barcode)
		{
			expected_barcode = "en_" + expected_barcode;

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/results/unrelease/{expected_barcode}");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			response = client.Execute(request);
		}

		/// <summary>
		/// GET //playground/results (barcode)
		/// </summary>
		[Given(@"request to get results for barcode '(.*)'")]
		public void GivenRequestToGetResultsForBarcode(string expected_barcode)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/results");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"[ \"{expected_barcode}\"]", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// GET /playground/search/{barcode_id}+query
		/// </summary>
		[When(@"request to search for barcode '(.*)'")]
		public void GivenRequestToSearchForBarcode(string expected_barcode)
		{
			expected_barcode = "en_" + expected_barcode;

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/search/{expected_barcode}?page=1&pagesize=30");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");

			response = client.Execute(request);
		}

        /// <summary>
        /// POST /playground/results/changebarcode (barcode)
        /// </summary>
        [When(@"request to change barcode '(.*)' to barcode '(.*)'")]
		public void GivenRequestToGetChangeBarcode(string oldBarcode, string newBarcode)
		{
			oldBarcode = "en_" + oldBarcode;
			newBarcode = "en_" + newBarcode;

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/playground/results/changebarcode");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", "{\n  \"oldBarcode\": \""+oldBarcode+"\",\n  \"newBarcode\": \""+newBarcode+"\"\n}\n", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		#endregion

		#region .: Results Controller :.

		/// <summary>
		/// GET /results/all
		/// </summary>
		[When(@"request to get all read results")]
		public void WhenRequestToGetTheAllReadResults()
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/results/all");
			request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", $"Bearer {appToken}");
			request.AddHeader("cache-control", "no-cache");

			response = client.Execute(request);
		}

		/// <summary>
		/// POST /results/search (searchFilter)
		/// </summary>
		[When(@"request to post results search")]
		public void WhenRequestToPostResultSearch()
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/results/search");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {appToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", "{\n  \"deviceType\": \"CAPCTM\",\n  \"sites\": [ \"Unknown\"  ],\n  \"testTypes\": [ \"HI2QLD\" ],\n  \"from\": \"2016-01-01T00:00:00.000Z\",\n  \"to\": \"2018-04-26T23:59:59.999Z\"\n}\n", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// GET /results/barcode (barcode)
		/// </summary>
		[When(@"request to get barcode '(.*)'")]
		public void WhenRequestToGetBarcode(string expected_barcode)
		{
			expected_barcode = "en_" + expected_barcode;

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/results/barcode?={expected_barcode}");
			request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", $"Bearer {appToken}");
			request.AddHeader("cache-control", "no-cache");

			response = client.Execute(request);
		}

		/// <summary>
		/// POST /results (result)
		/// </summary>
		[When(@"request to get results from barcode '(.*)'")]
		public void WhenRequestToRegisterDefaultResult(string expected_barcode)
		{
			if (expected_barcode == "random")
			{
				expected_barcode =  barcode_workflow_notification;
			}

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/results");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			var barcodes = new[] { "en_"+ expected_barcode };
			request.AddJsonBody(barcodes);

			response = client.Execute(request);
		}



		#endregion

		#region .: Register Controler :.

		/// <summary>
		/// POST /register (result)
		/// </summary>
		[Given(@"request to register result with value '(.*)' for barcode '(.*)'")]
		[When(@"request to register result with value '(.*)' for barcode '(.*)'")]
		public void WhenRequestToRegisterResultWithValueForBarcode(int expected_value, string expected_barcode)
		{
			ViralLoadInfoDTO default_result = new ViralLoadInfoDTO()
			{
				Barcode = expected_barcode,
				DeviceId = "400299",
				DeviceType = "CAPCTM",
				Flags = new[] { "TM40-2", "TM42-2" },
				IcValue = 0,
				//Id = "Z25VEGJN-ZWZ9-R5F6-MJFB-ZJAWCU57V01I",
				Interpretation = "Not Detected DBS",
				LabName = "Unknown",
				ResultReleased = DateTime.UtcNow,
				SampleLoaded = DateTime.UtcNow,
				SamplePrepEnd = DateTime.UtcNow,
				SamplePrepStart = DateTime.UtcNow,
				SampleProcessingEnd = DateTime.UtcNow,
				SampleProcessingStart = DateTime.UtcNow,
				Test = "TID.HI2QLD96",
				Unit = "0",
				Value = expected_value,
				Released = false
			};

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/register");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {appToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddJsonBody(default_result);

			response = client.Execute(request);
		}

        [Given(@"request to register result with '(.*)' as value")]
        [When(@"request to register result with '(.*)' as value")]
        public void WhenRequestToRegisterResultWithValue(int expected_value)
        {
            WhenRequestToRegisterResultWithValueForBarcode(expected_value, EpisodeNumber_workflow_notification);
			
        }

        /// <summary>
        /// POST /register (result)
        /// </summary>
        [When(@"request to register second result for barcode '(.*)'")]
		public void WhenRequestToRegisterSecondResultForBarcode(string expected_barcode)
		{
			ViralLoadInfoDTO default_result = new ViralLoadInfoDTO()
			{
				Barcode = expected_barcode,
				DeviceId = "400299",
				DeviceType = "CAPCTM",
				Flags = new[] { "TM40-2", "TM42-2" },
				IcValue = 0,
				Id = "Z25VEGJN-ZWZ9-R5F6-MJFB-ZJAWCU57V01I",
				Interpretation = "Not Detected DBS",
				LabName = "Unknown",
				ResultReleased = DateTime.UtcNow,
				SampleLoaded = DateTime.UtcNow,
				SamplePrepEnd = DateTime.UtcNow,
				SamplePrepStart = DateTime.UtcNow,
				SampleProcessingEnd = DateTime.UtcNow,
				SampleProcessingStart = DateTime.UtcNow,
				Test = "TID.HI2QLD96",
				Unit = "0",
				Value = 1,
				Released = true
			};

			var client = new RestClient($"{protocol}{site}-{microservice}{server}/register");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {appToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddJsonBody(default_result);

			response = client.Execute(request);
		}

		#endregion


		#region .: Then methods :.
		[Then(@"the results are retrieved")]
		public void ThenTheResultsAreRetrieved()
		{
			var dynJson = JsonConvert.DeserializeObject<JObject[]>(response.Content);

			int lenght = dynJson.Length;
			bool isNotEmpty = dynJson.Length != 0 ? true : false;
			Assert.IsTrue(isNotEmpty, $"Response content is empty: {response.Content}");
		}

		[Then(@"the response contains result for barcode '(.*)'")]
        public void ThenTheResponseContainsResult(string expected_barcode)
        {
			expected_barcode = "en_" + expected_barcode;

			var dynJson = JsonConvert.DeserializeObject<JObject[]>(response.Content);

            bool isNotEmpty = dynJson.Length != 0 ? true : false;
            Assert.IsTrue(isNotEmpty, $"Response content is empty: {response.Content}");
			bool isSameBarcodeID = dynJson[0]["barcode"].ToString().Equals(expected_barcode) ? true : false;
            Assert.IsTrue(isSameBarcodeID, $"Response does not contain a result with expected barcode: {dynJson[0]["barcode"]}"+
								" \n -Response Content: " + response.Content);
        }

        [Then(@"response contains the result '(.*)'")]
        public void ThenResponseContainsResult(string expected_result)
        {
            bool IsBarcodeShown = response.Content.Contains(expected_result);
            Assert.IsTrue(IsBarcodeShown, $"Response content does not contain expected result: {expected_result}"+
				" \n -Response Content: "+ response.Content);
        }

		[Then(@"response contains already released '(.*)' for barcode '(.*)'")]
		public void ThenResponseContainsTheResultForBarcode(string expected_result, string barcode)
		{
			bool IsBarcodeShown = response.Content.Contains(expected_result) && response.Content.Contains(barcode);
			Assert.IsTrue(IsBarcodeShown, $"Response content does not contain expected result / barcode: {expected_result}" +
				" | "+barcode+ " \n -Response Content: " + response.Content);
		}
		
		[Then(@"the response contains a list of unreleased results")]
		public void TheRequestContainsListOfUnreleasedResults()
		{
			DB_queries a = new DB_queries();
			Assert.IsTrue(Regex.Matches(response.Content.ToString(), "barcode").Count == a.GetUnreleasedResultsCountInDB(),
				" - Expected results: "+ a.GetUnreleasedResultsCountInDB()+"\n - Response results: "+ Regex.Matches(response.Content.ToString(), "barcode").Count);
		}

		[Then(@"the response contains a list of all results")]
		public void TheRequestContainsListOfAllResults()
		{
			DB_queries a = new DB_queries();
			Assert.IsTrue(Regex.Matches(response.Content.ToString(), "barcode").Count == a.GetAllResultsCountInDB(),
				" - Expected results: " + a.GetAllResultsCountInDB() + "\n - Response results: " + Regex.Matches(response.Content.ToString(), "barcode").Count);
		}


		[Then(@"The response contains results search")]
		public void TheResponseContainsResultsSearch()
		{
			string[] expected_string_list = new string[] { "cobas 4800", "HIV Viral Load", "Chris Hani Baragwanath" };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains (item);
				Assert.IsFalse(IsShown, $"Response content does contains quality control: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}

		#endregion
	}
}
