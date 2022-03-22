using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes.abstracts
{
    public abstract class Pizza
    {
        private static int type = 2;
        public  int Type { get=>type; }
        protected string description="Unknown Pizza";
        public virtual string Description { get=>description; }
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public abstract double Price { get; set; }
    }
}
