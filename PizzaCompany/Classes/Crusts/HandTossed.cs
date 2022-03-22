
using Pizza_Company.Decorator;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Classes.Crusts
{
    public class HandTossed : Crust
    {

        private string crust="Hand Tossed";

        public override string Description => base.Description +", "+crust;

        public HandTossed(Pizza pizza):base(pizza)
        {
            
        }
    }
}
