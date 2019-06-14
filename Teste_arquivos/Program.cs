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

            try{
                if (!Directory.Exists(outPath)){
                    Directory.CreateDirectory(outPath);
                }

                using (StreamReader reader = new StreamReader(inPath+ @"\sales.csv")){
                    while (!reader.EndOfStream){
                        string[] product = reader.ReadLine().Split(",");
                        ProductSale currentSale = new ProductSale(new Product(product[0], double.Parse(product[1], CultureInfo.InvariantCulture)), int.Parse(product[2]));
                        sale.addSale(currentSale);
                    }
                }

                using (StreamWriter writer = new StreamWriter(outPath+ @"\summary.csv")){
                    foreach (string saleString in sale.generateSummary()){
                        writer.WriteLine(saleString);
                    }
                }
                Console.WriteLine("Summary.csv generated successfully at " + outPath + ".");
            }
            catch (IOException exception){
                Console.WriteLine("An IO error occurred: " + exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred: " + exception.Message);
            }
            Console.ReadLine();
        }
 
    }
}
