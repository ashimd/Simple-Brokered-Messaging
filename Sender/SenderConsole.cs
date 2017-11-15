using Microsoft.ServiceBus.Messaging;
using System;

namespace SimpleBrokeredMessaging.Sender
{
    class SenderConsole
    {
        static string ConnectionString = "";// Connection String present in Service Bus
        static string QueuePath = "demoqueue";

        static void Main(string[] args)
        {
            // Create a queue client
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);

            for (int i = 0; i < 10; i++)
            {
                var message = new BrokeredMessage("Message: " + i) ;
                queueClient.Send(message);
                Console.WriteLine("Sent:    " + i);
            }
            queueClient.Close();
        }
    }
}
