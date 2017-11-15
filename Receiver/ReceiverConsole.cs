using Microsoft.ServiceBus.Messaging;
using System;

namespace SimpleBrokeredMessaging.Receiver
{
    class ReceiverConsole
    {
        static string ConnectionString = "";// Connection String present in Service Bus
        static string QueuePath = "demoqueue";

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            // Create a queue client
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);

            // Create a message pump to receive and process messages.
            queueClient.OnMessage(msg => ProcessMessage(msg));

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();

            queueClient.Close();
        }

        private static void ProcessMessage(BrokeredMessage msg)
        {
            var text = msg.GetBody<string>();
            Console.WriteLine("Received:    " + text);
        }
    }
}
