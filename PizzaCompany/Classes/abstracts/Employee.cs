using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes.abstracts
{
    public abstract class Employee
{
      
        public string Id { get; set; }
        public string Name { get; set; }
        protected string position="Unknown Position";
        public abstract string Position { get; }
        public abstract void AddEmployee(Employee employee);
        public abstract void RemoveEmployee(Employee employee);
        public abstract Employee GetEmployee(int index);
        public abstract List<Employee> GetEmployees();
        public abstract void ClearEmployee();
        public abstract int EmployeeCount();
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Picture { get; set; }
        public Employee()
        {

        }
        public Employee(string Id, string Name, string Email, string Password, byte[] Picture)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Picture = Picture;
        }
}
}
