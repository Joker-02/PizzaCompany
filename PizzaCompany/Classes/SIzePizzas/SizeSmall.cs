
using Pizza_Company.Decorator;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Classes.PizzaSize
{
    public class SizeSmall : SizePizza
    {
     
        private string size="small";
        public string Size { get => size;  }
        public override string Description => base.Description+$", {size}";
        public override double Price { get => base.Price;}
        public SizeSmall(Pizza pizza):base(pizza)
        {
         
        }

    }
}
