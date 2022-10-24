using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Address { get; set; }

        public string GetBasicInfo()
        {
            string FinalStr = FirstName + " " + LastName +
            "\nTell: " + PhoneNumber +
            "\nAddress: " + Address;
            return FinalStr;
        }
    }
}
