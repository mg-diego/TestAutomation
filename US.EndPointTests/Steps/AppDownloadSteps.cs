using TechTalk.SpecFlow;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace US.EndPointTests.Steps
{

	[Binding]
	public class AppDownloadSteps : StepsBase
	{
		public string microservice = "appdownload";
		public string valid_code = "63432";
		public string invalid_code = "-1";

		/// <summary>
		/// POST /home
		/// </summary>
		[When(@"request to post valid code")]
		public void WhenRequestToPostValidCode()
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/Home");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddParameter("undefined", "{\n  \"code\": \""+valid_code+"\"\n}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// POST /home
		/// </summary>
		[When(@"request to post invalid code")]
		public void WhenRequestToPostInvalidCode()
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/Home");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddParameter("undefined", "{\n  \"code\": \"" + invalid_code + "\"\n}", ParameterType.RequestBody);

			response = client.Execute(request);
		}



		[Then(@"the response contains the code entered is wrong")]
		public void TheRequestContainsCodeIsWrong()
		{
			Assert.IsTrue(response.Content.Contains("The code entered is wrong, please try again"),
				" - Response does not contain THE CODE IS WRONG.\n"+response.Content);
		}

		[Then(@"the response does not contain the code entered is wrong")]
		public void TheRequestDoesNotContainCodeIsWrong()
		{
			Assert.IsFalse(response.Content.Contains("The code entered is wrong, please try again"),
				" - Response does not contain THE CODE IS WRONG.\n" + response.Content);
		}
	}
}
