using System;
using System.Collections.Generic;

namespace Entities
{
    class Sale
    {
        public List<ProductSale> sales = new List<ProductSale>();
        public double totalValue { get; private set; }

        public Sale()
        {}

        public void addSale(ProductSale sale)
        {
            sales.Add(sale);
            totalValue += sale.totalValue();
        }

        public void removeSale(ProductSale sale)
        {
            sales.Remove(sale);
            totalValue -= sale.totalValue();
        }

        public List<string> generateSummary()
        {
            List<string> summary = new List<string>();
            summary.Add("SUMMARY:");
            foreach (ProductSale p in sales)
            {
                summary.Add(p.product.name + ", $" + p.totalValue().ToString("F2"));
            }
            summary.Add("Total value: $" + totalValue.ToString("F2"));
            return summary;
        }

        public void printSummary()
        {
            foreach (string s in generateSummary())
            {
                Console.WriteLine(s);
            }
        }
    }
}
