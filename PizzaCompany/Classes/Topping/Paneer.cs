
using Pizza_Company.Classes.Topping;
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Topping
{
    public class Paneer:Toppings
    {
        public Paneer(Pizza pizza) : base(pizza) { }

        public override string Description { get => base.Description+", Paneer(2.99$)";  }
        public override double Price { get => base.Price + 2.99; }
    }
}
