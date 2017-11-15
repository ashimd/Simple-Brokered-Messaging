using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAzureRacingGame
{
    public class LapDataSender
    {
        public void ConnectAndSendLapData(LapData lapData)
        {
            if (WorkshopSettings.SendLapData)
            {
                Debug.WriteLine("LapDataSender.ConnectAndSendLapData");
                try
                {
                    Stopwatch watch = Stopwatch.StartNew();
                    TopicClient topicClient = TopicClient.CreateFromConnectionString
                        (WorkshopSettings.LapDataConnectionString,
                        WorkshopSettings.LapDataTopicName);
                    BrokeredMessage message = new BrokeredMessage(lapData);
                    topicClient.Send(message);
                    topicClient.Close();
                    watch.Stop();
                    Debug.WriteLine("ConnectAndSendLapData: " + (int)watch.ElapsedMilliseconds);
                }
                catch
                {
                    
                    throw;
                }
            }
        }
    }
}
