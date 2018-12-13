using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using RestSharp;
using Roche.Rmdd.HivMonitor.Reporting.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Roche.Rmdd.HivMonitor.ResultRegister.DTO;
using US.EndPointTests.AdditionalFunctionalities;

namespace US.EndPointTests.Steps
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Collections.Generic;

	[Binding]
	class IdentityServerProfileSteps : StepsBase
	{
		public string microservice = "profile";

		/// <summary>
		/// #GET /profile
		/// </summary>
		[When(@"request to get profile")]
		public void WhenRequestToGetProfile()
		{
			var client = new RestClient($"{protocol}{microservice}{site}{server}/profiles");
			request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");

			response = client.Execute(request);
		}



		[Then(@"The response contains the profile info of the user")]
		public void ThenTheResponseContainsTheCurrentTestTypes()
		{
			DB_queries a = new DB_queries();
			var result = a.CheckUserScimId("doctor");

			string[] expected_string_list = new string[] { result["userId"] };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains(item);
				Assert.IsTrue(IsShown, $"Response content does not contain user's profile info: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}
	}
}



