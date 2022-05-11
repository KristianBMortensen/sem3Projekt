using System;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;

namespace UDP_proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var Httpclient = new HttpClient())
            {
                using (var UDPClient = new UdpClient())
                {
                    UDPClient.Client.Bind(new IPEndPoint(IPAddress.Any, 5005));
                    IPEndPoint iPEndPoint = null;
                    while (true)
                    {
                        byte[] recived = UDPClient.Receive(ref iPEndPoint);
                        Console.WriteLine("Recived something");
                        Httpclient.PostAsync("https://localhost:44323/api/GreenDays", null);
                    }
                }
            }
        }
    }
}
