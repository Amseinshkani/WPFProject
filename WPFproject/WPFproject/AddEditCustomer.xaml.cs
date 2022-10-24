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
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private readonly SCustomer _SC;
        private readonly Customer _Customer;
        private bool isEdit = false;

        public AddEditCustomer(SCustomer SC)
        {
            InitializeComponent();
            _SC = SC;
        }
        public AddEditCustomer(SCustomer SC, Customer C)
        {
            InitializeComponent();
            _SC = SC;
            _Customer = C;
            isEdit = true;
            TBFirstName.Text = _Customer.FirstName;
            TBLastName.Text = _Customer.LastName;
            TBPhoneNumber.Text = _Customer.PhoneNumber.ToString();
            TBAddress.Text = _Customer.Address;

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

                if (isEdit)
                {
                    Customer customer = new Customer()
                    {
                        Id = _Customer.Id,
                        FirstName = TBFirstName.Text,
                        LastName = TBLastName.Text,
                        PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                        Address = TBAddress.Text,
                    };
                    _SC.EditCustomer(customer);
                    this.Close();
                }
                else
                {
                    Customer customer = new Customer()
                    {
                        Id = _SC.GetNextId(),
                        FirstName = TBFirstName.Text,
                        LastName = TBLastName.Text,
                        PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                        Address = TBAddress.Text,
                    };
                    _SC.AddCustomer(customer);
                    this.Close();
                }
            }
        }
        private bool checkEmployeeValidity() 
        {
            bool IsValid = true;

            string FirstName = TBFirstName.Text.Trim().ToLower();
            string LastName = TBLastName.Text.Trim().ToLower();
            string PhoneNumber = TBPhoneNumber.Text.Trim().ToLower();
            string Address = TBAddress.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(FirstName))
            {
                IsValid = false;
                lblError.Content = "First Name is Empty OR invalid";

            }
            else if (string.IsNullOrEmpty(LastName))
            {
                IsValid = false;
                lblError.Content = "Last Name is Empty OR invalid";
            }
            else if (!UInt64.TryParse(PhoneNumber, out ulong p))
            {
                IsValid = false;
                lblError.Content = "PhoneNumber is Empty OR invalid";
            }
            else if (string.IsNullOrEmpty(Address))
            {
                IsValid = false;
                lblError.Content = "Address is Empty OR invalid";
            }
            else
            {
                lblError.Content = "";
            }

            return IsValid;
        }

        private void TBPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string PhoneNumber = TBPhoneNumber.Text.Trim().ToLower();
            if (!UInt64.TryParse(PhoneNumber, out ulong p))
            {
                lblError.Content = "*PhoneNumber is Empty OR invalid*";
            }
            else
            {
                lblError.Content = "";
            }
        }
    }
}
