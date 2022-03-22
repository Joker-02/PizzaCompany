
using Pizza_Company.Decorator;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Classes.Crusts
{
    public class HotDog : Crust
    {

        private string crust = "Hot Dog";

        public override string Description => base.Description + ", " + crust+("(2.99$)");
        public override double Price { get => base.Price+2.99;}
        public HotDog(Pizza pizza) : base(pizza)
        {

        }

    }
}
