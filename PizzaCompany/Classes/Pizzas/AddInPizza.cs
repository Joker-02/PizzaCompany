using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PizzaCompany.Classes.abstracts;

namespace Pizza_Company.Classes.Pizzas
{
    public class AddInPizza : Pizza
    {

        private double price;
        public AddInPizza(string description,double price)
        {
            base.description = description.Trim();
            this.price = price;
        }
        public override double Price { get => price; set => price=value; }
        public override string Description { get => base.description;  }
    }
}
