using System;
using System.IO;
using Entities;

namespace Teste_arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string inPath = @"c:\temp\sales";
            string outPath = inPath + @"\out";

            try
            {
                if (!Directory.Exists(outPath))
                    Directory.CreateDirectory(outPath);

                using (StreamReader sr = new StreamReader(inPath+ @"\sales.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] product = sr.ReadLine().Split(",");
                        Console.WriteLine("\nProduct:");
                        Console.WriteLine("Name: " + product[0]);
                        Console.WriteLine("Price: " + product[1]);
                        Console.WriteLine("Quantity: " + product[2]);
                    }
                }

                using (StreamWriter sw = new StreamWriter(outPath+ @"\summary.csv"))
                {
                    // Salvar summary no arquivo "\out\summary.csv"
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An IO error occurred: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            Console.ReadLine();
        }
 
    }
}
