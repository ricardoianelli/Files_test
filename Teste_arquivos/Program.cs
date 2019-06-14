using System;
using System.Globalization;
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
            Sale sale = new Sale();

            try
            {
                if (!Directory.Exists(outPath))
                    Directory.CreateDirectory(outPath);

                using (StreamReader sr = new StreamReader(inPath+ @"\sales.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] product = sr.ReadLine().Split(",");
                        ProductSale currentSale = new ProductSale(new Product(product[0], double.Parse(product[1], CultureInfo.InvariantCulture)), int.Parse(product[2]));
                        sale.addSale(currentSale);
                    }
                }

                using (StreamWriter sw = new StreamWriter(outPath+ @"\summary.csv"))
                {
                    foreach(string s in sale.generateSummary())
                    {
                        sw.WriteLine(s);
                    }
                }
                Console.WriteLine("Summary.csv generated successfully at " + outPath + ".");
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
