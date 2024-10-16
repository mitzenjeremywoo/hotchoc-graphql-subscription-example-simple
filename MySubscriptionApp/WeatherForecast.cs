using HotChocolate.Subscriptions;

namespace MySubscriptionApp
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }


    public class Subscription
    {
        [Subscribe]
        public Task<Message> OnMessageReceived([EventMessage] Message message)
        {
            Console.WriteLine("OnMessageReceived - received");
            return Task.FromResult(message);
        }
    }

    public class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
    }

    public class Mutation
    {
        public async Task<Message> SendMessage(string name, string content, [Service] ITopicEventSender eventSender)
        {
            var message = new Message {  Sender = name, Content = content };
            Console.WriteLine("onsend - sending message to the subscriptions");
            await eventSender.SendAsync("OnMessageReceived", message);
            return message;
        }
    }
    public class Query
    {
        public string HelloWorld()
        {
            return "Hello, from GraphQL!";
        }
    }

}
