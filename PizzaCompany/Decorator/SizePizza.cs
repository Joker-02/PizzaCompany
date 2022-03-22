
using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Company.Decorator
{
    public class SizePizza : Pizza
    {
        protected Pizza _pizza;

        public SizePizza(Pizza pizza)

        {

            _pizza = pizza;

        }
        public override string Description { get => _pizza.Description; }
        public override double Price { get => _pizza.Price; set => _pizza.Price = value; }
    }
}
