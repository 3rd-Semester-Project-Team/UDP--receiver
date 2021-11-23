using System;
using System.Net;
using System.Net.Http;
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

                    PostToAPI(recieved);

                }
            }

        }


        public static void PostToAPI(string recieved)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Console.WriteLine(recieved);
                    //var result = client.PostAsJsonAsync("uri goes here", recieved); use this line when we have the URI to use
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }

    }
}
