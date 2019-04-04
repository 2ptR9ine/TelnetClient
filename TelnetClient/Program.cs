using MinimalisticTelnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelnetClient
{
    class Program
    {
        private const string HOSTNAME = "192.168.1.127";
        private const int PORT = 23;

        private const string LOGIN = "root";
        private const string PASSWORD = "1";

        private const string COMMAND = "shutdown";

        static void Main(string[] args)
        {
            //create a new telnet connection to hostname "gobelijn" on port "23" 
            TelnetConnection tc = new TelnetConnection(HOSTNAME, PORT);

            //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
            string s = tc.Login(LOGIN, PASSWORD, 500);
            Console.Write(s);

            // server output should end with "$" or ">", otherwise the connection failed
            string prompt = s.TrimEnd();
            prompt = s.Substring(prompt.Length - 1, 1);
            if (prompt != "$" && prompt != ">" && prompt!= "#")
                throw new Exception("Connection failed");

            prompt = "";

            tc.WriteLine(COMMAND);
            Console.WriteLine(COMMAND + "\n");

           // Console.ReadKey();
        }
    }
}
