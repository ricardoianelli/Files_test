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

                using (StreamReader sr = new StreamReader(inPath))
                {
                    while (!sr.EndOfStream)
                    {
                        // ler produtos, criar produtos e vendas
                    }
                }

                using (StreamWriter sw = new StreamWriter(outPath))
                {
                    // Salvar summary no arquivo "\out\summary.csv"
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            Console.ReadLine();
        }
 
    }
}
