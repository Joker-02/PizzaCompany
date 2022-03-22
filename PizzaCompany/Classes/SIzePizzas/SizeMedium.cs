
using Pizza_Company.Decorator;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Classes.PizzaSize
{
    internal class SizeMedium : SizePizza
    {

        private string size = "Medium";
        public string Size { get => size; }

        public override string Description => base.Description +$", {size}";

        public override double Price { get => base.Price+(base.Price*0.3);  }
        public SizeMedium(Pizza pizza):base(pizza)
        {
           
        }
    }
}
