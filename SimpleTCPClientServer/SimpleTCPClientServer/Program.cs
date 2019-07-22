using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SimpleTCPClientServer
{
    class serv
    {
        static void Main()
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("10.108.71.40");
                string inputString = String.Empty;
                string[] peopleWithAccess = { "dailey", "bess" };
                bool access = false;
                // use Local m/c IP address, and
                // use the same in the client

                //Initializes the Listener
                TcpListener myList = new TcpListener(ipAd, 8001);

                //Starts Listning at the specified port 
                myList.Start();

                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is   :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                Socket s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = s.Receive(b);
                Console.WriteLine("Recieved...");
                for (int i = 0; i < k; i++)
                {
                    inputString += Convert.ToString((Convert.ToChar(b[i])));
                   
                }
                string result = inputString.ToLower();
                Console.WriteLine(result + ", Has entered the server -- Determining Access");
                string[] name = result.Split(' ');
                ASCIIEncoding asen = new ASCIIEncoding();
                //s.Send(asen.GetBytes("The string was recieved by the server."));
                for (int i = 0; i < peopleWithAccess.Length; i++)
                {
                    if (name[1] == peopleWithAccess[i])
                    {
                        Console.WriteLine("Access granted to " + result);
                        access = true;
                        
                    }
                }
                if (access == false)
                {
                    s.Send(asen.GetBytes("Access Denied"));
                    s.Close();
                    myList.Stop();
                }
                if (access == true)
                {
                    s.Send(asen.GetBytes("Welcome " + result + ", Access Granted"));
                }

               
               
                Console.WriteLine("\nSent Acknowledgement");
                /* clean up */
                s.Close();
                myList.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

    }
}