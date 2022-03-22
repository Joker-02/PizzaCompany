
using Pizza_Company.Decorator;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Classes.PizzaSize
{
    public class SizeLarge : SizePizza
    {
        private string size="Large";
        public string Size { get => size="Large"; }

        public override string Description => base.Description+$", {size}";
        public override double Price { get => base.Price+(base.Price*0.5); }
        public SizeLarge(Pizza pizza):base(pizza)
        {
         
        }

    }
}
