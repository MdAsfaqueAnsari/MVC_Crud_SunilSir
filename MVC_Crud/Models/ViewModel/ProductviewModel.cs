using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Crud.Models.ViewModel
{
    public class ProductviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int category { get; set; }
    }
}