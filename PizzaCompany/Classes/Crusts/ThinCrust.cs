
using Pizza_Company.Decorator;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Classes.Crusts
{
    internal class ThinCrust : Crust
    {

        private string crust = "Thin Crust";

        public override string Description => base.Description + ", " + crust;
        public override double Price { get => base.Price + 2.99; }
        public ThinCrust(Pizza pizza) : base(pizza)
        {

        }
    }
}
