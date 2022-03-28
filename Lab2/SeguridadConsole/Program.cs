using System;
using System.Security.Cryptography; 

namespace SeguridadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Simulacion login hashing");
            Console.ReadLine();

            // Introducir pass-to-hash

            // Check the pass wiht the hashing algo

            // Gain access

            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
            mD5.Initialize();
        }
    }
}
