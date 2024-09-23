using System.Net.Sockets;
using System.Text;

namespace Messeaging_app
{
    internal class Program
    {

        static UdpClient udpClient;
        static string ipAddress = "192.168.1.1";
        static int recieverPort = 11000;
        static bool pleaseLoopThis = true;
        static bool isConnectionStarted = false;

        static void Main(string[] args)
        {
            while (pleaseLoopThis)
            {
                startScreenDisplay();
                choiceHandling();
                Console.Clear();
            }
        }

        //TODO: App is kind of finished but recieving and sending messeages needs total rework, probably rewrite from scratch.  

        private static void sendMesseage()
        {
            try
            {
                Console.Write("Inser your messeage here: ");
                string messeage = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(messeage);
                udpClient.Send(data, data.Length, ipAddress, recieverPort);
                Console.WriteLine("Messeage sent!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                pleaseLoopThis = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("An error occured! Press any key to continue");
                Console.ReadKey();
            }

        }

        private static void startConnection()
        {
            try
            {
                udpClient = new UdpClient();
                isConnectionStarted = true;
                Console.WriteLine("Connection started: " + isConnectionStarted);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("An error occured! Press any key to continue");
                Console.ReadKey();
            }

        }

        private static void closeConnection()
        {
            if (!isConnectionStarted)
            {
                Console.WriteLine("There is no connection to close!");

            }
            else
            {
                try
                {
                    udpClient.Close();
                    isConnectionStarted = false;

                    Console.WriteLine($"Connection closed!");

                    if (isConnectionStarted = false)
                    {
                        Console.WriteLine($"Connection status: closed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("An error occured! Press any key to continue");
                    Console.ReadKey();
                }

            }
        }

        private static void startScreenDisplay()
        {
            Console.WriteLine("======SUPER MESSEAGING APP======");
            Console.WriteLine("Options: ");
            Console.WriteLine("[1] - Start Connection");
            Console.WriteLine("[2] - View Contantcs list");
            Console.WriteLine("[3] - View Connection status");
            Console.WriteLine("[4] - Close existing connection");
            Console.Write("Choose: ");
        }

        private static void choiceHandling()
        {
            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    startConnection();
                    pleaseLoopThis = false;
                    sendMesseage();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("This is under construction sir. ");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    pleaseLoopThis = true;
                }
                else if (choice == 3)
                {
                    string connectionClosed = "Closed";
                    string connectionOpened = "Opened";

                    if (isConnectionStarted)
                    {
                        Console.WriteLine($"Connection status: {connectionOpened}");
                    }
                    else
                    {
                        Console.WriteLine($"Connection status:  {connectionClosed}");
                    }
                    Console.ReadKey();

                }
                else if (choice == 4)
                {
                    closeConnection();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("An error occured! Press any key to continue");
                Console.ReadKey();

            }
        }
    }
}
