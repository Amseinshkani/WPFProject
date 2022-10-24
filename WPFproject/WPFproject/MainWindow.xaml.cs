using Infrastructure.Models;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SEmployee SE = new SEmployee();
        SCustomer SC = new SCustomer();
        SProduct SP = new SProduct();

        ObservableCollection<Employee> LE = new ObservableCollection<Employee>();
        ObservableCollection<Customer> LC = new ObservableCollection<Customer>();
        ObservableCollection<Products> LP = new ObservableCollection<Products>();

        public Employee CurrentEmployee { get; set; } = new Employee();
        public Customer CurrentCustomer { get; set; } = new Customer();
        public Products CurrentProducts { get; set; } = new Products();

        public MainWindow()
        {
            InitializeComponent();
            FillData();
            EmpGrid.ItemsSource = LE;
            CustomersGrid.ItemsSource = LC;
            ProductsGrid.ItemsSource = LP;
        }

        private void FillData()
        {
            LE = SE.Employees;
            LC = SC.Customers;
            LP = SP.products;
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
        }




        /* Employee */
        private void EmpgSelection(object sender, SelectionChangedEventArgs e)
        {
            if (EmpGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = EmpGrid.SelectedItem as Employee;
                Employeelabel.Content = CurrentEmployee.GetBasicInfo();
            }
        }
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee AddWindow = new AddEditEmployee(SE);
            AddWindow.ShowDialog();
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmpGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = EmpGrid.SelectedItem as Employee;
                SE.RemoveEmployees(CurrentEmployee.Id);
                Employeelabel.Content = "this content deleted";
            }
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmpGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = EmpGrid.SelectedItem as Employee;
                AddEditEmployee editWindow = new AddEditEmployee(SE, CurrentEmployee);
                editWindow.ShowDialog();
            }
        }




        /* Customer */
        private void CustomersGSelection(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                Customerlabel.Content = CurrentCustomer.GetBasicInfo();
            }
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomer AddWindow = new AddEditCustomer(SC);
            AddWindow.ShowDialog();
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0 )
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                SC.RemoveCustomer(CurrentCustomer.Id);
                Customerlabel.Content= "this content deleted";
            }
        }

        private void BtnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >=0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                AddEditCustomer EditWindow = new AddEditCustomer(SC,CurrentCustomer);
                EditWindow.ShowDialog();
            }
        }



        



        /* Products */
        private void ProductsGSelection(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProducts = ProductsGrid.SelectedItem as Products;
                Productlabel.Content = CurrentProducts.GetBasicInfo();
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProducts AddWindow = new AddEditProducts(SP);
            AddWindow.ShowDialog();
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProducts = ProductsGrid.SelectedItem as Products;
                SP.RemoveProduct(CurrentProducts.Id);
                Productlabel.Content= "this content deleted";
            }
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProducts = ProductsGrid.SelectedItem as Products;
                AddEditProducts EditWindow = new AddEditProducts(SP, CurrentProducts);
                EditWindow.ShowDialog();
            }
        }
    }
}
