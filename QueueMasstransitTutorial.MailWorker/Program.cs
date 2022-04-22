using MassTransit;
using Microsoft.Extensions.Hosting;
using QueueMasstransitTutorial.MailWorker.Consumers;
using System.Threading.Tasks;

namespace QueueMasstransitTutorial.MailWorker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => 
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<AddedUserConsumer>();
                        x.SetKebabCaseEndpointNameFormatter();
                        x.UsingRabbitMq((context, cfg) => 
                        {
                            //TODO: get connection string from appsettings.json
                            cfg.Host("rabbitmq://localhost", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                })
                .Build()
                .RunAsync();
        }
    }
}
