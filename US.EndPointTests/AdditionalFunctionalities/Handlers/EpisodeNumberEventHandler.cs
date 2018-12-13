using Mira;
using Mira.Events;
using Roche.Rmdd.HivMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using US.EndPointTests.Steps;

namespace US.EndPointTests.AdditionalFunctionalities.Handlers
{
    public class EpisodeNumberEventHandler : EventHandlerBase<EpisodeNumberUpdated>
    {
        public static string ExpectedBarcode = "To be set";
        public static bool EventReceived = false;
        public static ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim();

        protected override Task HandleInternal(EpisodeNumberUpdated domainEvent, IMessageHeaders headers, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (domainEvent.Barcode == ExpectedBarcode)
            {
                EventReceived = true;
                manualResetEventSlim.Set();
            }

            return Task.CompletedTask;
        }
    }
}
