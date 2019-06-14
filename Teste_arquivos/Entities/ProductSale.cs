using System;

namespace Entities
{
    class ProductSale
    {
        public Product product { get; set; }
        public double quantity { get; set; }

        public ProductSale(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public double totalValue()
        {
            return product.price * quantity;
        }
    }
}
