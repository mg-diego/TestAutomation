using System;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;
using RestSharp;

namespace US.EndPointTests.Steps
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [Binding]
    public class BarcodeSteps: StepsBase
    {
        public string microservice = "barcodes";

        public string barcode_id = "-1";
        public string ClinicId = "0c6d644f-3f7e-4218-b7b6-a8b60a3636cf";

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


		#region .: REGISTRATION controller :.	

		/// <summary>
		/// #POST /registration (barcode)
		/// </summary>
		[Given(@"request to register barcode")]
		[When(@"request to register barcode")]
		[When(@"request to register same barcode")]
		public void WhenRequestToRegisterNewBarcode()
		{
			//barcode_id = RandomString(10);
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/registration");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"{{\n\t\"BarcodeId\": \"{barcode_workflow_notification}\",\n\t\"ClinicId\": \"{ClinicId}\"\n}}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// #POST /registration (barcode)
		/// </summary>
		[Given(@"request to register barcode '(.*)'")]
		[When(@"request to register barcode '(.*)'")]
		public void WhenRequestToRegisterNewBarcode(string barcode)
		{
			barcode_id = RandomString(10);
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/registration");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"{{\n\t\"BarcodeId\": \"{barcode}\",\n\t\"ClinicId\": \"{ClinicId}\"\n}}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// #POST /registration (barcode)
		/// </summary>
		[Given(@"request to register new barcode without token")]
		[When(@"request to register new barcode without token")]
		[When(@"request to register same barcode without token")]
		public void WhenRequestToRegisterNewBarcodeWithoutToken()
		{
			barcode_id = RandomString(10);
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/registration");
			request = new RestRequest(Method.POST);
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"{{\n\t\"BarcodeId\": \"{barcode_id}\",\n\t\"ClinicId\": \"{ClinicId}\"\n}}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		#endregion

		#region .: BARCODES controller :.

		/// <summary>
		/// #GET /barcodes
		/// </summary>
		[Given(@"request to get registered barcodes")]
		[When(@"request to get registered barcodes")]
		public void WhenRequestToGetRegisteredBarcodes()
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/barcodes");
			request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");

			response = client.Execute(request);
		}

		/// <summary>
		/// #GET /barcodes
		/// </summary>
		[When(@"request to get registered barcodes without token")]
		public void WhenRequestToGetRegisteredBarcodesWithoutToken()
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/barcodes");
			request = new RestRequest(Method.GET);
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");

			response = client.Execute(request);
		}

		/// <summary>
		/// #GET /barcodes
		/// </summary>
		[When(@"request to get registered barcodes with invalid token")]
		public void WhenRequestToGetRegisteredBarcodesWithInvalidToken()
		{
			ScenarioContext.Current.Pending();
		}

		#endregion

		#region .: THEN methods :.

		[Given(@"the response contains '(.*)' barcode")]
        [Then(@"the response contains '(.*)' barcode")]
        public void ThenTheResponseContainsBarcode(string expected_barcode)
        {
            bool IsBarcodeShown = response.Content.Contains(expected_barcode);
            Assert.IsTrue(IsBarcodeShown, $"Response content does not contain barcode: {expected_barcode}" +
				$"\n - Response: {response.Content}");

        }

        [Given(@"the response does not contain '(.*)' barcode")]
        [Then(@"the response does not contain '(.*)' barcode")]
        public void ThenTheResponseDoesNotContainBarcode(string expected_barcode)
        {
            bool IsBarcodeShown = response.Content.Contains(expected_barcode);
            Assert.IsTrue(!IsBarcodeShown, $"Response content does not contain barcode: {expected_barcode}"+
				$"\n - Response: {response.Content}");

        }

        [Then(@"The reponse contains error code '(.*)'")]
        public void ThenTheReponseContainsErrorCode(string errorCodeExpected)
        {
            bool IsErrorCodeShown = response.Content.Contains(errorCodeExpected);
            Assert.IsTrue(IsErrorCodeShown, $"Expected error code not retrieved \n - Response: {response.Content}");
        }

		#endregion

	}
}
