using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace tbClientThreads
{
    class Program
    {
        private static readonly Socket ClientSocket =
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 65002;

        static void Main()
        {
            Console.Title = "Klient";
            ConnectToServer();
            RequestLoop();
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }

        private static void ConnectToServer()
        {
            int attempts = 0;
            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    ClientSocket.Connect(IPAddress.Parse("127.0.0.1"), Port);
                }
                catch (SocketException)
                {
                    Console.Clear();
                }
            }
            Console.Clear();
            Console.WriteLine("Connected");
        }

        public static void ReadServer()
        {
            ReceiveResponse();
        }

        private static void RequestLoop()
        {
            Thread readServerThread = new Thread(new ThreadStart(ReadServer));

            readServerThread.Start();

            Console.WriteLine("Skriv disconnect för att koppla från servern");
            string message = string.Empty;
            try
            {
                while (message.ToLower() != "disconnect")
                {
                    message = Console.ReadLine();
                    ClientSocket.Send(Encoding.UTF8.GetBytes(message), SocketFlags.None);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error! - Lost server.");
                Console.ReadLine();
            }
        }
        private static void ReceiveResponse()
        {
            var buffer = new byte[4096]; //2048
            try
            {
                int received = ClientSocket.Receive(buffer, SocketFlags.None);

                if (received == 0)
                    return;

                string message = Encoding.UTF8.GetString(buffer, 0, received);
                Console.WriteLine(message);
                if (message == "sendingimage")
                {
                    Console.WriteLine("Tar emot bild från servern...");
                    received = ClientSocket.Receive(buffer, SocketFlags.None);

                    string path = "C:/temp/sentimg.jpg";
                    Console.WriteLine("Bild mottagen. Sparar bilden till " + path);
                    //Konvertera buffer-arrayen till en bild
                    ImageConverter convertData = new ImageConverter();
                    Image image = (Image)convertData.ConvertFrom(buffer);

                    //Spara bilden till hårddisk
                    image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                
                ReceiveResponse();
            }
            catch(System.Net.Sockets.SocketException)
            {
                Console.WriteLine("Frånkopplar från server...");
                return;
            }
            
        }
    }
}