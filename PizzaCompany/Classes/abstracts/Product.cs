using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes.abstracts
{
    public class Product
    {
       
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] Picture { get; set; }
        public Product() { }
        public Product(Pizza pizza) { Id = pizza.Id; Name = pizza.Name; Picture = pizza.Picture; Price = pizza.Price; Description = pizza.Description;Type = pizza.Type; }
        public Product(Drink drink) { Id = drink.Id; Name = drink.Name; Picture = drink.Picture; Price = drink.Price; Description = drink.Description;Type = drink.Type; }
    }
}
