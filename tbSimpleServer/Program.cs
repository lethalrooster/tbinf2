using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace tbSimpleServer
{
    class Program
    {
        private static Socket _serverSocket;
        private const int BufferSize = 2048;
        private const int Port = 65002;
        private static readonly byte[] Buffer = new byte[BufferSize];
        private static bool _closing;
        static void Main()
        {
            Console.Title = "Server";
            Console.WriteLine("Sätter upp server...");
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
            _serverSocket.Listen(5);
            Console.WriteLine("Väntar på anslutningar...");
            var clientSocket = _serverSocket.Accept();
            Console.WriteLine("Klient ansluten, väntar på förfrågan...");
            clientSocket.BeginReceive(Buffer, 0, BufferSize, SocketFlags.None, ReceiveCallback, clientSocket);
            
            // Vänta här!
            Console.ReadLine();
            _closing = true;
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            _serverSocket.Close();
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            if (_closing)
                return;

            Socket current = (Socket)ar.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(ar);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                current.Close();
                return;
            }

            string text = Encoding.UTF8.GetString(Buffer, 0, received);
            Console.WriteLine("Received Text: " + text);

            switch (text.ToLower())
            {
                case "get time":
                    Console.WriteLine("Text is a get time request");
                    current.Send(Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString()));
                    Console.WriteLine("Time sent to client");
                    break;
                case "exit":
                    current.Shutdown(SocketShutdown.Both);
                    current.Close();
                    Console.WriteLine("Client disconnected");
                    return;
                default:
                    Console.WriteLine("Text is an invalid request");
                    current.Send(Encoding.UTF8.GetBytes("Invalid request"));
                    Console.WriteLine("Warning Sent");
                    break;
            }

            current.BeginReceive(Buffer, 0, BufferSize, SocketFlags.None, ReceiveCallback, current);
        }
    }
}