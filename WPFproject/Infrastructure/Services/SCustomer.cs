using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class SCustomer
    {
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        public SCustomer()
        {
            ReadEmployees();
        }

        private void ReadEmployees()
        {
            Customer C1 = new Customer()
            {
                Id = 1,
                FirstName = "ALIs",
                LastName = "ALIIs",
                PhoneNumber = 0123456789,
                Address = "Tehran",
            };
            Customer C2 = new Customer()
            {
                Id = 2,
                FirstName = "ALIs",
                LastName = "ALIIs",
                PhoneNumber = 0123456789,
                Address = "Tehran",
            };
            Customers.Add(C1);
            Customers.Add(C2);
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void RemoveCustomer(int Id)
        {
            Customer Temp = Customers.First(a => a.Id == Id);
            Customers.Remove(Temp);
        }

        public void EditCustomer(Customer customer)
        {
            Customer Temp = Customers.First(a => a.Id == customer.Id);
            int Index = Customers.IndexOf(Temp);
            Customers[Index] = customer;
        }

        public int GetNextId()
        {
            int index = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
            return index;
        }

    }
}
