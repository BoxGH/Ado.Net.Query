using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlqBranchDomain
{
    public class CustomerSbd
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
    }

    public class OrderSbd
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DateOperation { get; set; }
        public decimal Amount { get; set; }
    }

    public class ProductOrderSbd
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductSbd
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class CustomerOrdersProducts
    {
        public string CustorerName { get; set;  }
        public int OrderId { get; set; }
        public DateTime OrderDateOperation { get; set; }
        public decimal OrderAmount { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductOrderQuantity { get; set; }
    }

    public class DescriptProduct
    {
        public int ProductId { get; set; }
        public string NameProduct { get; set; }
        public int QuantityProduct { get; set; }
        public decimal PriceProduct { get; set; }
    }
    public class AddJsonOrder
    {
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public List<DescriptProduct> ProductsDescript { get; set; }
    }
}
