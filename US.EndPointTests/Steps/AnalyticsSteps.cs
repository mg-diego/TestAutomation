using TechTalk.SpecFlow;
using RestSharp;
using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace US.EndPointTests.Steps
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [Binding]
    class AnalyticsSteps: StepsBase
    {
        public string microservice = "analytics";


		#region .: POST event :.

		/// <summary>
		/// #POST /events
		/// </summary>
		[When(@"request to send new event is called")]
        public void WhenRequestToSendNewEventIsCalled()
        {
            var client = new RestClient($"{protocol}{site}-{microservice}{server}/events");
            request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "[{\"$id\":\"1\",\"$type\":\"Roche.Rmdd.HivMonitor.Events.UserLoggedIn, roche.rmdd.hivmonitor.events\",\"UserId\":\"a036e5b3-2199-43a2-854e-e4755106cfc9\",\"Source\":\"a036e5b3-2199-43a2-854e-e4755106cfc9\",\"TimeStamp\":\"2018-09-14T16:04:24.754809+02:00\"}]", ParameterType.RequestBody);
            response = client.Execute(request);
        }

		/// <summary>
		/// #POST /events
		/// </summary>
		[When(@"request to send new event with source_id '(.*)'")]
		public void WhenRequestToSendNewEventWithSource_Id(string expected_sourceId)
		{
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/events");
			request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", $"[{{\"$id\":\"1\",\"$type\":\"Roche.Rmdd.HivMonitor.Events.UserLoggedIn, roche.rmdd.hivmonitor.events\",\"UserId\":\"a036e5b3-2199-43a2-854e-e4755106cfc9\",\"Source\":\"{expected_sourceId}\",\"TimeStamp\":\"2018-09-14T16:04:24.754809+02:00\"}}]", ParameterType.RequestBody);
			response = client.Execute(request);
		}

		#endregion

		#region .: SEARCH event :.

		/// <summary>
		/// #GET /events/search (dates)
		/// </summary>
		[When(@"resquest to search for date from '(.*)' to '(.*)'")]
        public void WhenResquestToSearchForDateFromTo(string dateFrom, string dateTo)
        {
            DateTime date_from = DateTime.ParseExact($"{dateFrom} 00:00:00", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime date_to = DateTime.ParseExact($"{dateTo} 23:59:59", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

            int unixTimestampFrom = (int)(date_from.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            int unixTimestampTo = (int)(date_to.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            string unixTimestamp_From = unixTimestampFrom.ToString();
            string unixTimestamp_To = unixTimestampTo.ToString();

            var client = new RestClient($"{protocol}{site}-{microservice}{server}/events/search?dateFrom={unixTimestamp_From}&dateTo={unixTimestamp_To}");
            request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
            request.AddHeader("cache-control", "no-cache");
            response = client.Execute(request);
        }

		/// <summary>
		/// #GET /events/search (dates)
		/// </summary>
		[When(@"resquest to search using wrong dates format")]
		public void WhenResquestToSearchUsingWrongDatesFormat()
		{
			var wrong_dateFrom = "2018/01/22";
			var wrong_dateTo = "2018/10/22";
			var client = new RestClient($"{protocol}{site}-{microservice}{server}/events/search?dateFrom={wrong_dateFrom}&dateTo={wrong_dateTo}");
			request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
			request.AddHeader("cache-control", "no-cache");
			response = client.Execute(request);
		}

		#endregion

		#region .: THEN methods :.

		[Then(@"the events are inside the search range from '(.*)' to '(.*)'")]
        public void ThenTheEventsAreInsideTheSearchRangeFromTo(string dateFrom, string dateTo)
        {
            DateTime date_from = DateTime.ParseExact($"{dateFrom} 00:00:00", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime date_to = DateTime.ParseExact($"{dateTo} 23:59:59", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

            int unixTimestampFrom = (int)(date_from.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            int unixTimestampTo = (int)(date_to.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var dynJson = JsonConvert.DeserializeObject<JObject[]>(response.Content);
            
            bool isInsideRanges = false;
            foreach (var item in dynJson)
            {
                DateTime current = DateTime.Parse($"{item["payload"]["timeStamp"]}", CultureInfo.InvariantCulture);
                int unixTimestampCurrent = (int)(current.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                if (unixTimestampFrom <= unixTimestampCurrent && unixTimestampCurrent <= unixTimestampTo)
                {
                    isInsideRanges = true;
                }

                Assert.IsTrue(isInsideRanges, $"Current date out of ranges:{current.ToString()}");
            }
        }


        [Then(@"response contains an event with source_id '(.*)'")]
        public void ThenResponseContainsAnEventWithSource_Id(string expected_sourceId)
        {
            var dynJson = JsonConvert.DeserializeObject<JObject[]>(response.Content);

            bool isShown = false;
            foreach (var item in dynJson)
            {
                string source = (string)item["payload"]["source"];
                if (source.Contains(expected_sourceId))
                {
                    isShown = true;
                    break;
                }
            }
            Assert.IsTrue(isShown, $"Current source_id not found in the response");
        }

		#endregion

    }

}
