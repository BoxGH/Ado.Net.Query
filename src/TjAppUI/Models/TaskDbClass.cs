 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TjAppUI.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public Order()
        {
            Products = new HashSet<ProductOrder> ();
        }
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DateOperation { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductOrder> Products { get; set; }
    }

    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
    }

    public class Product
    {
        public Product()
        {
            Orders = new HashSet<ProductOrder>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ProductOrder> Orders { get; set; }
    }
}
