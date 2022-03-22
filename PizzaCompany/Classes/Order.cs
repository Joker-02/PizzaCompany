using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}
