using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IProducts
    {
        int Id { get; set; }
        string Name { get; set; }
        string Author { get; set; }
        decimal Price { get; set; }

        string GetBasicInfo();
    }
}
