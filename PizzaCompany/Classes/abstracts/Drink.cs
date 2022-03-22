using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes.abstracts
{
    public abstract class Drink
    {
        private static int type = 1;
        public int Type { get => type; }
        protected string description = "Unknown Drink";
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual string Description { get => description; }
        public byte[] Picture { get; set; }
        public abstract double Price { get; set; }

    }
}
