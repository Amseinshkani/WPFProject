using Infrastructure.Models;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFproject
{
    /// <summary>
    /// Interaction logic for AddEditProducts.xaml
    /// </summary>
    public partial class AddEditProducts : Window
    {
        private readonly SProduct _SProduct;
        private readonly Products _products;
        private bool IsEdit = false;
        public AddEditProducts(SProduct SP)
        {
            InitializeComponent();
            _SProduct = SP;
        }

        public AddEditProducts(SProduct SP, Products pro)
        {
            InitializeComponent();
            _SProduct = SP;
            _products = pro;
            IsEdit = true;
            TBName.Text = _products.Name;
            TBAuthor.Text = _products.Author;
            TBPrice.Text = _products.Price.ToString();
            TBAvailableCount.Text = _products.AvailableCount.ToString();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

            bool IsValid = true;
            IsValid = checkEmployeeValidity();

            if (IsValid)
            {

                if (IsEdit)
                {
                    Products Pro = new Products()
                    {
                        Id = _products.Id,
                        Name = TBName.Text,
                        Author = TBAuthor.Text,
                        Price = Convert.ToDecimal(TBPrice.Text),
                        AvailableCount = Convert.ToDecimal(TBAvailableCount.Text)
                    };
                    _SProduct.EditProduct(Pro);
                    this.Close();
                }
                else
                {
                    Products Pro = new Products()
                    {
                        Id = _SProduct.GetNextId(),
                        Name = TBName.Text,
                        Author = TBAuthor.Text,
                        Price = Convert.ToDecimal(TBPrice.Text),
                        AvailableCount = Convert.ToDecimal(TBAvailableCount.Text)
                    };
                    _SProduct.AddProduct(Pro);
                    this.Close();
                }
            }
        }
        private bool checkEmployeeValidity() 
        {
            bool IsValid = true;

            string Name = TBName.Text.Trim().ToLower();
            string Author = TBAuthor.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(Name))
            {
                IsValid = false;
                lblError.Content = "Name is Empty OR invalid";

            }
            else if (string.IsNullOrEmpty(Author))
            {
                IsValid = false;
                lblError.Content = "Last Name is Empty OR invalid";
            }
            else
            {
                lblError.Content = "";
            }
            return IsValid;
        }

        private void TBPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Price = TBPrice.Text.Trim().ToLower();
            if (!decimal.TryParse(Price, out decimal p))
            {
                lblError.Content = " Price is Empty OR invalid ";
            }
            else
            {
                lblError.Content = "";
            }
        }

        private void TBAvailableCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            string AvailableCount = TBAvailableCount.Text.Trim().ToLower();
            if (!decimal.TryParse(AvailableCount, out decimal a))
            {
                lblError.Content = " AvailableCount is Empty OR invalid ";
            }
            else
            {
                lblError.Content = "";
            }
        }
    }
}
