using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Udemy1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:\Users\Lopezadri\Documents\Archivos\Maestros";

            

            List<string> list = Directory.EnumerateFiles(ruta).ToList();


            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
           
            Console.ReadKey();
           
        }  
    }
}
