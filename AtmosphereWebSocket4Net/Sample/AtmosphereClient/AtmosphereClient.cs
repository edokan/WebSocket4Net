using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

using WebSocket4Net;
using AtmosphereWebSocket4Net;

namespace AtmosphereClient
{
    class AtmosphereClient
    {
        

        static void Main(string[] args)
        {
            AutoResetEvent closeEvent = new AutoResetEvent(false);

            AtmosphereWebSocket webSocketClient = new AtmosphereWebSocket("ws://127.0.0.1:30222/notification/ksspush");
            webSocketClient.MessageReceived += new EventHandler<MessageReceivedEventArgs>(webSocketClient_MessageReceived);
            webSocketClient.Open();

            closeEvent.WaitOne();
            
        }

        protected static void webSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Message Received: " + e.Message);
        }

        protected static void webSocketClient_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Socket Closed.");
        }

        protected static void webSocketClient_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Socket Opened.");
        }

        protected static void webSocketClient_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("Data Recieved: " + Encoding.UTF8.GetString(e.Data));
        }
    }
}