
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Decorator
{
    public class Crust:Pizza
    {
        private Pizza _pizza;

        public Crust(Pizza pizza)

        {

            _pizza = pizza;

        }
        public override string Description { get => _pizza.Description;  }
        public override double Price { get => _pizza.Price; set => _pizza.Price = value; }
    }
}
