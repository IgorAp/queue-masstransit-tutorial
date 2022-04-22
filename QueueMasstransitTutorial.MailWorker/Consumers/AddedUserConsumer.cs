using MassTransit;
using QueueMasstransitTutorial.Shared.Events;
using System;
using System.Threading.Tasks;

namespace QueueMasstransitTutorial.MailWorker.Consumers
{
    public class AddedUserConsumer : IConsumer<AddedUserEvent>
    {
        public Task Consume(ConsumeContext<AddedUserEvent> context)
        {
            var AddedUser = context.Message;
            Console.WriteLine($"User email: {AddedUser.Email}");

            return Task.CompletedTask;
        }
    }
}
