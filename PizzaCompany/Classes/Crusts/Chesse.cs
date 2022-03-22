
using Pizza_Company.Decorator;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Classes.Crusts
{
    public class Chesse : Crust
    {
    
        private string crust="Chesse(2.99)";
    
        public Chesse(Pizza pizza):base(pizza)
        {
            
        }
        public override string Description => base.Description+", "+crust;
        public override double Price { get => base.Price+2.99; }
    }
}
