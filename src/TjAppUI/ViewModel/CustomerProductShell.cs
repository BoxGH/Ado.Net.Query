using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TjAppUI.Models;
using SlqBranchDomain;
namespace TjAppUI.ViewModel
{
    public class CustomerProductShell
    {
       public IEnumerable<CustomerSbd> Customers { get; set; }
       public IEnumerable<ProductSbd> Products { get; set; }
    }
}
