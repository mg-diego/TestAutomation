using TechTalk.SpecFlow;
using RestSharp;

namespace US.EndPointTests.Steps
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Linq;
	using System.Text.RegularExpressions;
	using US.EndPointTests.AdditionalFunctionalities;

	[Binding]
    public class ReportingSteps : StepsBase
    {
        public string microservice = "reporting";

		#region .: GET methods :.

		/// <summary>
		/// #GET /{endpoint}
		/// </summary>
		/// <param name="endpoint"></param>
		[When(@"request to get the '(.*)'")]
		public void WhenRequestToGetThe(string endpoint)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/{endpoint}");
			request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			response = client.Execute(request);
		}

		#endregion

		#region .: POST methods :. 

		/// <summary>
		/// #POST /{endpoint} + date range
		/// </summary>
		/// <param name="endpoint"> sitedata, qualitycontrol, processingtime, processingtimeweekly</param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		[When(@"request to post '(.*)' from '(.*)' to '(.*)'")]
		public void WhenRequestToPostEndpointDates(string endpoint, string from, string to)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/{endpoint}");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"{{\n\t\"deviceType\": \"CAPCTM\",\n\t\"sites\": [ \n\t],\n\t\"testTypes\": [ \"HI2QLD\" ],\n\t\"from\": \"{from}\",\n\t\"to\": \"{to}\"\n}}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// #POST /{endpoint} + deviceType
		/// </summary>
		/// <param name="endpoint"> sitedata, qualitycontrol, processingtime, processingtimeweekly</param>
		/// <param name="deviceType"> CAPCTM, cobas 6800/8800, cobas 4800</param>
		[When(@"request to post '(.*)' for device '(.*)'")]
		public void WhenRequestToPostEndpointDeviceType(string endpoint, string deviceType)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/{endpoint}");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"{{\n\t\"deviceType\": \"{deviceType}\",\n\t\"sites\": [ \n\t],\n\t\"testTypes\": [ \"HI2QLD\" ],\n\t\"from\": \"2015-01-01T00:00:00.000Z\",\n\t\"to\": \"2019-04-26T23:59:59.999Z\"\n}}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// #POST /{endpoint} + sites
		/// </summary>
		/// <param name="endpoint"> sitedata, qualitycontrol, processingtime, processingtimeweekly</param>
		/// <param name="sites"> Chris Hani Baragwanath, Unknown, CMJAH</param>
		[When(@"request to post '(.*)' for site '(.*)'")]
		public void WhenRequestToPostEndpointSites(string endpoint, string sites)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/{endpoint}");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"{{\n\t\"deviceType\": \"CAPCTM\",\n\t\"sites\": [\"{sites}\"],\n\t\"testTypes\": [ \"HI2QLD\" ],\n\t\"from\": \"2015-01-01T00:00:00.000Z\",\n\t\"to\": \"2019-04-26T23:59:59.999Z\"\n}}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		/// <summary>
		/// #POST /{endpoint} + sites
		/// </summary>
		/// <param name="endpoint"> sitedata, qualitycontrol, processingtime, processingtimeweekly</param>
		/// <param name="testType"> TBD </param>
		[When(@"request to post '(.*)' for testType '(.*)'")]
		public void WhenRequestToPostEndpointTesttype(string endpoint, string testType)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/{endpoint}");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"{{\n\t\"deviceType\": \"CAPCTM\",\n\t\"sites\": [\n\t],\n\t\"testTypes\": [ \"{testType}\" ],\n\t\"from\": \"2015-01-01T00:00:00.000Z\",\n\t\"to\": \"2019-04-26T23:59:59.999Z\"\n}}", ParameterType.RequestBody);

			response = client.Execute(request);
		}

		#endregion

		#region .: THEN methods :.

		[Then(@"The response contains the current test types")]
		public void ThenTheResponseContainsTheCurrentTestTypes()
		{
			string[] expected_string_list = new string[] { "[{\"category\":\"HIV Viral Load\",\"tests\":[\"HI2CAP\",\"HI2DFS\",\"HI2DIL\"]},{\"category\":\"HIV Qual\",\"tests\":[\"HI2QLD\",\"HIQCAP\"]},{\"category\":\"HCV Viral Load\",\"tests\":[\"HC2QTP\"]},{\"category\":\"CMV Viral Load\",\"tests\":[\"CMV\"]},{\"category\":\"HBV Viral Load\",\"tests\":[\"HB2CAP\"]}]" };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains(item);
				Assert.IsTrue(IsShown, $"Response content does not contain current test types: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}

		[Then(@"The response contains the current sites")]
		public void ThenTheResponseContainsTheCurrentSites()
		{
			string[] expected_string_list = new string[] { "[{\"name\":\"Chris Hani Baragwanath\"},{\"name\":\"Unknown\"},{\"name\":\"CMJAH\"}]" };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains(item);
				Assert.IsTrue(IsShown, $"Response content does not contain current sites: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}

		[Then(@"The response contains all the devices")]
		public void ThenTheResponseContainsAllTheDevices()
		{
			string[] expected_string_list = new string[] { "[{\"deviceType\":\"CAPCTM\"},{\"deviceType\":\"cobas 6800/8800\"},{\"deviceType\":\"cobas 4800\"}]" };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains(item);
				Assert.IsTrue(IsShown, $"Response content does not contain test type: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}

		[Then(@"The response contains the devices '(.*)'")]
		public void ThenTheResponseContainsTheDevices(string devices)
		{
			DB_queries a = new DB_queries();
			//Assert.IsTrue(Regex.Matches(response.Content.ToString(), "referenceDate").Count == a.GeResultsByDeviceType(devices),
				//" - Expected results: " + a.GetUnreleasedResultsCountInDB() + "\n - Response results: " + Regex.Matches(response.Content.ToString(), "referenceDate").Count);
		}

		[Then(@"The response contains the sitedata")]
		public void ThenTheResponseContainsTheSitedata()
		{
			string[] expected_string_list = new string[] { @"Invalid/Failed Results", "Successful Results" };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains(item);
				Assert.IsTrue(IsShown, $"Response content does not contain site data: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}

		[Then(@"The response contains the quality control")]
		public void ThenTheResponseContainsTheQualityControl()
		{
			string[] expected_string_list = new string[] { @"[]" };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains(item);
				Assert.IsTrue(IsShown, $"Response content does not contain quality control: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}


		[Then(@"The response contains the '(.*)' from '(.*)' to '(.*)'")]
		public void ThenTheResponseContainsTheProcessingTimeWeekly(string endpoint, string from, string to)
		{
			long unixDateTime_from = CommonSteps.ConvertToEpoch(from);
			long unixDateTime_to = CommonSteps.ConvertToEpoch(to);

			//Get all the matches from response.Content like "YYYY-MM-DD"
			var matches = Regex.Matches(response.Content, @"\d{4}-\d{2}-\d{2}");
			var list = matches.Cast<Match>().Select(match => match.Value).ToList();

			foreach (var item in list)
			{
				var unixDateTime_matchDate = CommonSteps.ConvertToEpoch(item);

				Assert.IsTrue((unixDateTime_matchDate >= unixDateTime_from && unixDateTime_matchDate <= unixDateTime_to),
					"Results date " + item + " is out of range (" + from + " - "+ to +")");
			}
			
		}

		[Then(@"The response contains the processing time")]
		public void ThenTheResponseContainsTheProcessingTime()
		{
			string[] expected_string_list = new string[] { "Pre Analytics", "Preparation", "Transit", "Processing", "Time To Release" };
			foreach (var item in expected_string_list)
			{
				bool IsShown = response.Content.Contains(item);
				Assert.IsTrue(IsShown, $"Response content does not contain processing time: {item}" +
					$" \n -Values returned: " + response.Content.ToString());
			}
		}
		#endregion

    }
}
