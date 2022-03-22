using PizzaCompany.Classes.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCompany.Classes.Employees
{
    public class Staff : Employee
    {

        public override string Position => base.position;
        public Staff()
        {
            base.position = "Staff";
        }
        public Staff(string Id,string Name,string Email,string Password,byte[] Picture) : base(Id, Name, Email, Password, Picture)
        {
            base.position = "Staff";
        }

        public override void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public override void RemoveEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public override Employee GetEmployee(int index)
        {
            throw new NotImplementedException();
        }

        public override List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public override void ClearEmployee()
        {
            throw new NotImplementedException();
        }

        public override int EmployeeCount()
        {
            throw new NotImplementedException();
        }
    }
}
