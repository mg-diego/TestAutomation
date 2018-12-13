using Mira;
using Mira.Autofac.MassTransit.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using US.EndPointTests.AdditionalFunctionalities.Handlers;
using US.EndPointTests.Steps;

namespace US.EndPointTests.AdditionalFunctionalities
{
    using Autofac.Core;
    using Mira.Autofac;

    public class RabbitManager
    {
        Workflow workflow;

		StepsBase baseSteps = new StepsBase();

		public Task<IWorkflow> Start()
        {
			string ip = "";
			if (baseSteps.site == "staging") { ip = "40.113.145.68"; }
			if (baseSteps.site == "bcn") { ip = "13.94.168.16"; }
			if (baseSteps.site == "demo") { ip = "40.68.203.169"; }

			var configuration = new DeploymentConfiguration()
            {
                //QueueName = "notificationwf",
                //TenantPrefix = "NotificationWf",

				QueueName = "Tester",
                TenantPrefix = "Tester",

				ServiceBus = new Uri("rabbitmq://"+ip+"/hivmonitor"),
                ServiceBusUsername = "hivm",
                ServiceBusPassword = "hivm",
                Services = new Dictionary<Regex, Uri>()
            };

            workflow = Workflow.From(configuration)
                .DefinedIn(typeof(BarcodeProcesedEventHandler).Assembly)
                .UsingMassTransitOverRabbitMq()
                .CreateWorkflow();

            return workflow.Start();
        }
    }

    internal static class TestExtensions
    {
        public static Workflow CreateWorkflow(this Workflow workflow)
        {
            return workflow.UsingCustomBuilder((c, a) => new AutofacWorkflow(c, workflow.GetModules(c, a).ToArray()));
        }
    }
}
