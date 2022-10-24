using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class Products : IProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public decimal AvailableCount { get; set; }

        public string GetBasicInfo()
        {
            string FinalStr = Name +
             "\nAuthor: " + Author +
              "\nPrice: " + Price +
               "\nAvailableCount: " + AvailableCount ;
            return FinalStr;
        }
    }
}
