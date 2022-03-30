using System;
using System.Security.Cryptography;
using System.Text;

namespace SeguridadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Simulacion login hashing");
            Console.ReadLine();

            // Introducir pass-to-hash
            String to_hash = "blanco";

            String result = Md5(to_hash);

            String answer = "6403558c0e945a72056d09ac3281f964";

            Console.WriteLine("### Dato a hashear: ");
            Console.WriteLine("### toHash " + to_hash);
            Console.WriteLine("### Answer " + answer);
            Console.WriteLine("### Resultado " + result);

            // Check the pass wiht the hashing algo
            if (answer.Equals(result))
            {
                Console.WriteLine("### CORRECT!");
            }
            else
            {
                Console.WriteLine("### INCORRECT!");
            }

            // Gain access
            Console.ReadLine();

        }

        /// <summary>
        /// Funcion hash obtenida de, https://developpaper.com/encryption-algorithms-md5-sha1/
        /// </summary>
        /// <param name="str"> String to be hashed</param>
        /// <returns>Returns the hashed string</returns>
        public static string Md5(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(buffer);

            var sb = new StringBuilder();
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
    }
}
