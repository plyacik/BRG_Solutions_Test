using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRG_Solutions_Test.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryProductId { get; set; }
        public CategoryProduct Category { get; set; }
    }

    public class CategoryProduct
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class AddProductModel
    {
        public string ProductName { get; set; }
        public int CategoryProductId { get; set; }
    }

    public class ProductList
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}
