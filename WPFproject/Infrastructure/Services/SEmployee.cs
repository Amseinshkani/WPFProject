using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class SEmployee
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public SEmployee()
        {
            ReadEmployees();
        }

        private void ReadEmployees()
        {
            Employee E1 = new Employee()
            {
                Id = 1,
                FirstName = "ALI",
                LastName = "ALII",
                PhoneNumber = 0123456789,
                Address = "Tehran",
                department = Employee.Department.Production,
                BaseSalary = 2500,

            };
            Employee E2 = new Employee()
            {
                Id = 2,
                FirstName = "ALI",
                LastName = "ALII",
                PhoneNumber = 0123456789,
                Address = "Tehran",
                department = Employee.Department.Sales,
                BaseSalary = 2500,
            };
            Employees.Add(E1);
            Employees.Add(E2);

        }
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployees(int Id)
        {
            Employee Temp = Employees.First(a => a.Id == Id);
            Employees.Remove(Temp);
        }

        public void EditEmployees(Employee employee)
        {
            Employee Temp = Employees.First(a => a.Id == employee.Id);
            int Index = Employees.IndexOf(Temp);
            Employees[Index] = employee;
        }

        public int GetNextId()
        {
            int index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
            return index;
        }

    }
}
