using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        UInt64 PhoneNumber { get; set; }
        string Address { get; set; }

        string GetBasicInfo();
    }
}
