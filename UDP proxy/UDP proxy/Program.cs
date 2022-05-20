using System;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
                    UDPClient.Client.Bind(new IPEndPoint(IPAddress.Any, 6969));
                    IPEndPoint iPEndPoint = null;
                    int i = 1;
                    Encoding utf8 = Encoding.UTF8;
                    while (true)
                    {

                        byte[] recived = UDPClient.Receive(ref iPEndPoint);
                        int data = int.Parse(Encoding.UTF8.GetString(recived));

                        Console.WriteLine(i + ". " + data);
                        i++;
                        if (data > 0)
                            Httpclient.PostAsync("https://localhost:44323/api/GreenDays", null);
                    }
                }
            }
        }
    }
}
