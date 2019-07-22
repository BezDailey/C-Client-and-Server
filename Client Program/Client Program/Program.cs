using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Client_Program
{
    public class clnt
    {

        public static void Main()
        {

            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect("10.108.71.40", 8001);
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                Console.Write("Enter Full Name : ");

                String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

    }
}
