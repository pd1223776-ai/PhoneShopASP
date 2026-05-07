using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShopMVC.Model.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product>? ProductList { get; set; }
        public IEnumerable<Category>? CategoryList { get; set; }
    }
}
