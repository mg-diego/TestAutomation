using RestSharp;
using System.Threading.Tasks;
using SimpleIdentityServer.Core.Common.DTOs.Responses;
using US.EndPointTests.AdditionalFunctionalities;
using Mira;

namespace US.EndPointTests.Steps
{


    public class StepsBase
    {
        public static RestRequest request;
        public static IRestResponse response;
        public static GrantedTokenResponse _tokenResponse;
        public static RabbitManager rabbit;
        public static IWorkflow rabbitWorkflow;
        public static string barcode_workflow_notification = "223344";
        public string server = $".projectschweitzer.net";
        public string site = "staging";
        public string protocol = "https://";

        public static string EpisodeNumber_workflow_notification => $"en_{barcode_workflow_notification}";

    }
}
