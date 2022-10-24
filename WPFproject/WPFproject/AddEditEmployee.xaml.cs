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
using static Infrastructure.Models.Employee;

namespace WPFproject
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private readonly SEmployee employee;
        private readonly Employee _emp;
        private bool isedit = false;
        public AddEditEmployee(SEmployee s)
        {
            InitializeComponent();
            employee = s;
        }
        public AddEditEmployee(SEmployee s, Employee emp)
        {
            InitializeComponent();
            employee = s;
            _emp = emp;
            isedit = true;
            TBFirstName.Text = _emp.FirstName;
            TBLastName.Text = _emp.LastName;
            TBPhoneNumber.Text = _emp.PhoneNumber.ToString();
            TBAddress.Text = _emp.Address;
            TBBaseSalary.Text = _emp.BaseSalary.ToString();
            ComboDepartment.SelectedIndex = (int)_emp.department;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool Isvalid = true;
            Isvalid = checkEmployeeValidity();

            if (Isvalid)
            {
                if (isedit)
                {
                    Employee emp = new Employee()
                    {
                        Id = _emp.Id,
                        FirstName = TBFirstName.Text,
                        LastName = TBLastName.Text,
                        PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                        Address = TBAddress.Text,
                        BaseSalary = Convert.ToDecimal(TBBaseSalary.Text),
                        department = (Department)ComboDepartment.SelectedIndex
                    };
                    employee.EditEmployees(emp);
                    this.Close();
                }
                else
                {
                    Employee emp = new Employee()
                    {
                        Id = employee.GetNextId(),
                        FirstName = TBFirstName.Text,
                        LastName = TBLastName.Text,
                        PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                        Address = TBAddress.Text,
                        BaseSalary = Convert.ToDecimal(TBBaseSalary.Text),
                        department = (Department)ComboDepartment.SelectedIndex
                    };
                    employee.AddEmployee(emp);
                    this.Close();
                }
            }
        }
        private bool checkEmployeeValidity() 
        {
            bool Isvalid = true;

            string FirstName = TBFirstName.Text.Trim().ToLower();
            string LastName = TBLastName.Text.Trim().ToLower();
            string PhoneNumber = TBPhoneNumber.Text.Trim().ToLower();
            string Address = TBAddress.Text.Trim().ToLower();
            int department = ComboDepartment.SelectedIndex;
            string BaseSalary = TBBaseSalary.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(FirstName))
            {
                Isvalid = false;
                lblError.Content="First Name is Empty OR invalid";

            }
            else if(string.IsNullOrEmpty(LastName))
            {
                Isvalid = false;
                 lblError.Content="Last Name is Empty OR invalid";
            }
            else if (!UInt64.TryParse(PhoneNumber, out ulong p))
            {
                Isvalid = false;
                 lblError.Content="PhoneNumber is Empty OR invalid";
            }
            else if (string.IsNullOrEmpty(Address))
            {
                Isvalid = false;
                 lblError.Content="Address is Empty OR invalid";
            }
            else if (department < 0)
            {
                Isvalid = false;
                 lblError.Content="Select department";

            }
            else if (!Decimal.TryParse(BaseSalary, out Decimal d) && d > 4000 )
            {
                Isvalid = false;
                 lblError.Content="salary is invorrect!";
            }
            else
            {
                lblError.Content = "";
            }
            return Isvalid;
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
