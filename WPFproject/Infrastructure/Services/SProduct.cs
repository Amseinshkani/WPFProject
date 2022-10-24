using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class SProduct
    {

        public ObservableCollection<Products> products { get; set; } = new ObservableCollection<Products>();

        public SProduct()
        {
            ReadProducts();
        }

        private void ReadProducts()
        {
            Products P1 = new Products()
            {
                Id = 1,
                Name = "Animal Farm",
                Author = "George Orwel",
                Price = 17,
                AvailableCount = 12
            };

            Products P2 = new Products()
            {
                Id = 2,
                Name = "Brave bew World",
                Author = "Aldous huxley",
                Price = 34,
                AvailableCount = 5
            };
            products.Add(P1);
            products.Add(P2);
        }
        public void AddProduct(Products pro)
        {
            products.Add(pro);
        }

        public void RemoveProduct(int Id)
        {
            Products Temp = products.First(a => a.Id == Id);
            products.Remove(Temp);
        }

        public void EditProduct(Products p)
        {
            Products Temp = products.First(a => a.Id == p.Id);
            int Index = products.IndexOf(Temp);
            products[Index] = p;
        }

        public int GetNextId()
        {
            int index = products.Any() ? products.Max(x => x.Id) + 1 : 1;
            return index;
        }

    }
}
