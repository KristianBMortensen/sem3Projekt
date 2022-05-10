using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDP_broadcaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (UdpClient udpClient = new())
            {
                while (true)
                {
                    Console.ReadKey();
                    byte[] data = Encoding.UTF8.GetBytes("");
                    udpClient.Send(data, data.Length, "127.0.0.1", 5005);
                }
            }
        }
    }
}
