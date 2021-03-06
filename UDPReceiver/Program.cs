using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;

namespace UDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Server");
            StartListener();
        }

        /// <summary>
        /// Starts to listen to UDP broadcasts and forwards received data to the Api method.
        /// </summary>
        public static void StartListener()
        {
            using (UdpClient socket = new UdpClient())
            {
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 10100));

                while (true)
                {
                    IPEndPoint from = null;
                    byte[] data = socket.Receive(ref from);
                    string recieved = Encoding.UTF8.GetString(data);
                    Console.WriteLine(recieved);
                    PostToAPI(recieved);
                }
            }
        }

        /// <summary>
        /// Method to post data to and API by URL.
        /// </summary>
        /// <param name="recieved">Data to be posted.</param>
        public static async void PostToAPI(string recieved)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpContent content = new StringContent(recieved, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("http://parkingsensor-api.azurewebsites.net/api/parkings/", content);
                    Console.WriteLine(result.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
