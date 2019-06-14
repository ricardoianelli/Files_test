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
            try{

                Sale sale = new Sale();
                Console.WriteLine("Enter the source csv file path: ");
                string inPath = Console.ReadLine();
                string inFolder = Path.GetDirectoryName(inPath);

                if (!Directory.Exists(inFolder)){
                    throw new IOException("The file path does not exist!");
                }

                string outFolder = inFolder + @"\out";
                if (!Directory.Exists(outFolder)){
                    Directory.CreateDirectory(outFolder);
                }

                using (StreamReader reader = new StreamReader(inPath)){
                    while (!reader.EndOfStream){
                        string[] product = reader.ReadLine().Split(",");
                        ProductSale currentSale = new ProductSale(new Product(product[0], double.Parse(product[1], CultureInfo.InvariantCulture)), int.Parse(product[2]));
                        sale.addSale(currentSale);
                    }
                }

                using (StreamWriter writer = new StreamWriter(outFolder + @"\summary.csv")){
                    foreach (string saleString in sale.generateSummary()){
                        writer.WriteLine(saleString);
                    }
                }
                Console.WriteLine("Summary.csv generated successfully at " + outFolder + ".");
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
