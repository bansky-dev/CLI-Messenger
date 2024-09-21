using System.Net.Sockets;
using System.Text;

namespace Messeaging_app
{
    internal class Program
    {

        static UdpClient udpClient;
        static string ipAddress = "192.168.1.1";
        static int recieverPort = 11000;
        static string recieverID = "daro";
        static bool pleaseLoopThis = true;

        static void Main(string[] args)
        {
            while (pleaseLoopThis)
            {
                startScreenDisplay();
                choiceHandling();
            }




        }

        private static void sendMesseage()
        {
            Console.Write("Inser your messeage here: ");
            string messeage = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(messeage);
            udpClient.Send(data, data.Length, ipAddress, recieverPort);
        }

        private static void startConnection()
        {
            UdpClient udpClient = new UdpClient();
            bool isConnectionStarted = true;
        }

        private static void startScreenDisplay()
        {
            Console.WriteLine("======SUPER MESSEAGING APP======");
            Console.WriteLine("Options: ");
            Console.WriteLine("[1] - Start Connection");
            Console.WriteLine("[2] - View Contantcs list");
            Console.Write("Choose: ");


        }
        private static void choiceHandling()
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
                pleaseLoopThis = true;
            }
        }
    }
}
