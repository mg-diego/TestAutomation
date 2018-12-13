using TechTalk.SpecFlow;
using RestSharp;
using US.EndPointTests.Steps;
using US.EndPointTests.AdditionalFunctionalities;
using System.Diagnostics;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Threading;

namespace US.AcceptanceTests.Steps.EndPoints
{
    [Binding]
    public class PushNotifications : StepsBase
    {
        public string microservice = "pushnotifications";


        [When(@"request to registration codes is called")]
        public void WhenRequestToRegistrationCodesIsCalled()
        {
            var client = new RestClient($"{protocol}{site}-{microservice}{server}/RegistrationCodes");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n  \"code\":\"444\",\n  \"barcode\":\"5555\",\n  \"phoneNumber\": \"+34652703816\"\n}\n", ParameterType.RequestBody);

            response = client.Execute(request);
        }

        [Given(@"request to register barcode with code '(.*)' to push notifications")]
        [When(@"request to register barcode with code '(.*)' to push notifications")]
        public void GivenRequestToRegisterBarcodeWithCodeToPushNotifications(string expected_code)
        {
            var client = new RestClient($"{protocol}{site}-{microservice}{server}/RegistrationCodes");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {_tokenResponse.AccessToken}");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", $"{{\n  \"code\":\"{expected_code}\",\n  \"barcode\":\"{barcode_workflow_notification}\",\n  \"phoneNumber\": \"+34652703816\"\n}}\n", ParameterType.RequestBody);

            response = client.Execute(request);
        }
    }
}
