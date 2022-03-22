using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes.Composite
{
    public class Manager : Employee
    {
        private List<Employee> employees = new List<Employee>();
        public override string Position => base.position;
        public Manager()
        {
            base.position = "Manager";
        }
        public Manager(string Id, string Name, string Email, string Password, byte[] Picture) : base(Id, Name, Email, Password, Picture) { base.position = "Manager"; }

        public override void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public override void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public override Employee GetEmployee(int index)
        {
           return employees[index];
        }

        public override List<Employee> GetEmployees()
        {
            return employees;
        }

        public override void ClearEmployee()
        {
            employees.Clear();
        }

        public override int EmployeeCount()
        {
            return employees.Count;
        }
    }
}
