using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes.Drinks
{
    public class AddInDrinks : Drink
    {
        private double price;
        public override double Price { get => price; set =>price=value; }
        public AddInDrinks()
        {

        }
        public AddInDrinks(string description,double price,byte[] Picture)
        {
            base.description = description;
            this.price = price;
            base.Picture = Picture;
        }
    }
}
