using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TjAppUI.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;
using TjAppUI.ViewModel;
using System.Data.SqlClient;
using SlqBranchDomain;

namespace TjAppUI.Controllers
{
    public class CommutatorController : Controller
    {
        //private AppDbContext context;

        //public CommutatorController(AppDbContext _context)
        //{
        //    context = _context;
        //}
        static string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db-tjApp-CustomerProduct;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IActionResult Start()
        {
            List<CustomerSbd> customer = new List<CustomerSbd>();
            List<ProductSbd> product = new List<ProductSbd>();
            QueryUtilities.CustomerProductJacket(connStr, customer, product);

            CustomerProductShell shell = new CustomerProductShell
            {
                Customers = customer,
                Products = product
            };

            return View(shell);
        }
        public IActionResult SetOrder(AddJsonOrder products)
        {
            QueryUtilities.CreateOrder(connStr, products);
            return Json("Qwerty");
            //DateTime dt = new DateTime();
            //dt = DateTime.Now;
            //    //context.Orders.Add(new Order
            //    //{
            //    //    CustomerId = products.CustomerId,
            //    //    DateOperation = dt,
            //    //    Amount = products.TotalPrice,
            //    //    CustomerName = products.CustomerName
            //    //});
            //    //await context.SaveChangesAsync();
            //    //Order order = context.Orders.FirstOrDefault(x => x.CustomerId == products.CustomerId && x.DateOperation == dt);
            //    //if (order == null)
            //    //    return HttpBadRequest();
            //    //foreach (var pkt in products.ProductsDescript)
            //    //{
            //    //    context.ProductOrder.Add(new ProductOrder
            //    //    {
            //    //        OrderId = order.Id,
            //    //        ProductId = pkt.ProductId,
            //    //        Quantity = pkt.QuantityProduct
            //    //    });
            //    //}
            //    //await context.SaveChangesAsync();  
        }
        public IActionResult CustomerWithWithoutBuy(bool flag)
        {
            //    //if( flag )
            //    //return View(context.Customers.Where(x => x.Orders.Count > 0).Include(y=>y.Orders));
            //    //else
            //    //    return View(context.Customers.Where(x => x.Orders.Count == 0));
            List<CustomerSbd> customers = new List<CustomerSbd>();
            QueryUtilities.CustomerSetNotOrder(connStr, flag, customers);
            return View(customers);
        }
    }
}
