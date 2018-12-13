using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using US.EndPointTests.AdditionalFunctionalities;
using US.EndPointTests.AdditionalFunctionalities.Handlers;

namespace US.EndPointTests.Steps
{
    [Binding]
    public class NoficationWorkflowSteps : StepsBase
    {
        [Then(@"request to rabbit a new '(.*)' message")]
        public async Task WhenRequestToRabbitANewMessage(string expected_barcode)
        {
            BarcodeProcesedEventHandler.ExpectedBarcode = expected_barcode;

            await Task.Run(()=> BarcodeProcesedEventHandler.manualResetEventSlim.Wait(60000)).ConfigureAwait(false);

            Assert.IsTrue(BarcodeProcesedEventHandler.EventReceived, "Barcode message not received during 60 seconds");
        }


        [Then(@"request to rabbit message for 3 days notification message")]
        public async Task ThenRequestToRabbitMessageForDaysNotficationMessageANewMessage()
        {
            ResultFollowUpNotificationEventHandler.ExpectedBarcode = EpisodeNumber_workflow_notification;

            await Task.Run(() => ResultFollowUpNotificationEventHandler.manualResetEventSlim.Wait(150000)).ConfigureAwait(false);

            Assert.IsTrue(ResultFollowUpNotificationEventHandler.EventReceived, "3 days notification not received after 4 minute");
        }

        [Then(@"request to rabbit message for 2 weeks notification message")]
        public async Task ThenRequestToRabbitMessageForWeeksNotficationMessage()
        {
            ResultsOverdueEventHandler.ExpectedBarcode = EpisodeNumber_workflow_notification;

            await Task.Run(() => ResultsOverdueEventHandler.manualResetEventSlim.Wait(300000)).ConfigureAwait(false);

            Assert.IsTrue(ResultsOverdueEventHandler.EventReceived, "2 weeks notification not received after 6 minutes");
        }


        [Then(@"request to rabbit message for 7 weeks notification message")]
        public async Task ThenRequestToRabbitMessageForSevenWeeksNotficationMessageANewMessage()
        {
            ClinicFollowUpNotificationEventHandler.ExpectedBarcode = EpisodeNumber_workflow_notification;

            await Task.Run(() => ClinicFollowUpNotificationEventHandler.manualResetEventSlim.Wait(480000)).ConfigureAwait(false);

            Assert.IsTrue(ClinicFollowUpNotificationEventHandler.EventReceived, "7 weeks notification not received after 9 minutes");
         
        }

        [Then(@"request to rabbit message to not expect a 3 days notification message")]
        public async Task ThenRequestToRabbitMessageToNotExpectThreeDaysNotficationMessage()
        {
            ResultFollowUpNotificationEventHandler.ExpectedBarcode = EpisodeNumber_workflow_notification;

            await Task.Run(() => ResultFollowUpNotificationEventHandler.manualResetEventSlim.Wait(150000)).ConfigureAwait(false);

            Assert.IsFalse(ResultFollowUpNotificationEventHandler.EventReceived, "3 days notification received after 4 minute");

        }

        [Then(@"request to rabbit message to not expect a 2 weeks notification message")]
        public async Task ThenRequestToRabbitMessageToNotExpectATwoWeeksNotficationMessage()
        {
            ResultsOverdueEventHandler.ExpectedBarcode = EpisodeNumber_workflow_notification;

            await Task.Run(() => ResultsOverdueEventHandler.manualResetEventSlim.Wait(300000)).ConfigureAwait(false);

            Assert.IsFalse(ResultsOverdueEventHandler.EventReceived, "2 weeks notification received after 6 minutes");
        }


        [Then(@"request to rabbit message to not expect a 7 weeks notification message")]
        public async Task ThenRequestToRabbitMessageToNotExpectForSevenWeeksNotficationMessage()
        {
            ClinicFollowUpNotificationEventHandler.ExpectedBarcode = EpisodeNumber_workflow_notification;

            await Task.Run(() => ClinicFollowUpNotificationEventHandler.manualResetEventSlim.Wait(480000)).ConfigureAwait(false);

            Assert.IsFalse(ClinicFollowUpNotificationEventHandler.EventReceived, "7 weeks notification received after 9 minutes");

        }


        [Then(@"request to rabbit message for fully notified message")]
        public async Task ThenRequestToRabbitMessageForFullyNotifiedMessageWithBarcode()
        {
            BarcodeFullyNotifiedEventHandler.ExpectedBarcode = barcode_workflow_notification;

            await Task.Run(() => BarcodeFullyNotifiedEventHandler.manualResetEventSlim.Wait(150000)).ConfigureAwait(false);

            Assert.IsTrue(BarcodeFullyNotifiedEventHandler.EventReceived, "Fully notified not received during 45 seconds");
        }


        [Then(@"DB for Push notifications does not contain an entry")]
        public void ThenDBForPushNotificationsDoesNotContainAnEntryForWithBarcode()
        {
            DB_queries a = new DB_queries();
            bool isBarcodeEntryDeleted= !a.CheckBarcodeEntry(barcode_workflow_notification);

            Assert.IsTrue(isBarcodeEntryDeleted, $"Barcode entry:'{barcode_workflow_notification}' is still in Push notification DB");
        }
    }
}
