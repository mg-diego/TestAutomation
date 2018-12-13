using TechTalk.SpecFlow;
using RestSharp;

namespace US.EndPointTests.Steps
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Text.RegularExpressions;

	[Binding]
	class ReferenceDataSteps : StepsBase
	{
		public string microservice = "referencedata";

		[When(@"request to get the groups for gender '(.*)' and clinic '(.*)'")]
		public void WhenRequestToSendNewEventIsCalled(string gender, string clinic)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/whatsapp?gender={gender}&clinic={clinic}");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			response = client.Execute(request);
		}

		[Then(@"the response contains groups for gender '(.*)' and clinic '(.*)'")]
		public void ThenTheResponseContainsGroupsForGenderClinic(string gender, string clinic)
		{
			Assert.IsTrue(Regex.Matches(response.Content.ToString(), "id").Count == 2, " - Response does not have 2 groups");
			Assert.IsTrue(Regex.Matches(response.Content.ToString(), gender).Count == 1, " - Response does not have a group for " + gender +
					"\n - Response content: " + response.Content.ToString());
			Assert.IsTrue(Regex.Matches(response.Content.ToString(), clinic).Count == 2, " - Response does not have 2 groups for " + clinic +
					"\n - Response content: " + response.Content.ToString());
		}

		[Then(@"the response contains the next group available")]
		public void ThenTheResponseContainsSecondGroupsAvailable()
		{
			Assert.IsTrue(Regex.Matches(response.Content.ToString(), "\\(2\\)").Count == 2, " - Response does not have second groups"+
				"\n - Response content: " + response.Content.ToString());
		}
		
	}
}
