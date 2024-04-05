using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HB.Models;
using HB;
using System.Collections.ObjectModel;

namespace ShopManagementApp01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        ProductDataAccess productDataAccess = new ProductDataAccess();

        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        ObservableCollection<Product> products = new ObservableCollection<Product>();

        public Employee currentEmployee { get; set; } = new Employee();
        public Customer currentCustomer { get; set; } = new Customer();
        public Product currentProduct { get; set; } = new Product();

        public MainWindow()
        {
            InitializeComponent();
            FillData();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DgEmployees.ItemsSource = employees;
            DgCustomers.ItemsSource = customers;
            DgProducts.ItemsSource = products;
        }

        private void FillData()
        {
            employees = employeeDataAccess.Employees;
            customers = customerDataAccess.Customers;
            products = productDataAccess.Products;
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            PnlHome.Visibility = Visibility.Visible;
            PnlEmployees.Visibility = Visibility.Collapsed;
            PnlCustomers.Visibility = Visibility.Collapsed;
            PnlProducts.Visibility = Visibility.Collapsed;
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            PnlHome.Visibility = Visibility.Collapsed;
            PnlEmployees.Visibility = Visibility.Visible;
            PnlCustomers.Visibility = Visibility.Collapsed;
            PnlProducts.Visibility = Visibility.Collapsed;
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            PnlHome.Visibility = Visibility.Collapsed;
            PnlEmployees.Visibility = Visibility.Collapsed;
            PnlCustomers.Visibility = Visibility.Visible;
            PnlProducts.Visibility = Visibility.Collapsed;
        }

        private  void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            PnlHome.Visibility = Visibility.Collapsed;
            PnlEmployees.Visibility = Visibility.Collapsed;
            PnlCustomers.Visibility = Visibility.Collapsed;
            PnlProducts.Visibility = Visibility.Visible;
        }

        private void DgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgEmployees.SelectedIndex >= 0)
            {
                currentEmployee = DgEmployees.SelectedItem as Employee;
                LblEmployee.Content = currentEmployee.GetBasicInfo();
            }
        }

        private void DgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgCustomers.SelectedIndex >= 0)
            {
                currentCustomer = DgCustomers.SelectedItem as Customer;
                LblCustomer.Content = currentCustomer.GetBasicInfo();
            }
        }

        private void DgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgProducts.SelectedIndex >= 0)
            {
                currentProduct = DgProducts.SelectedItem as Product;
                LblProduct.Content = currentProduct.GetBasicInfo();
            }
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addEmployee = new AddEditEmployee(employeeDataAccess);
            addEmployee.ShowDialog();
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (DgEmployees.SelectedIndex >= 0)
            {
                currentEmployee = DgEmployees.SelectedItem as Employee;
                AddEditEmployee EditEmployee = new AddEditEmployee(employeeDataAccess, currentEmployee);
                EditEmployee.ShowDialog();
            }
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (DgEmployees.SelectedIndex >= 0)
            {
                currentEmployee = DgEmployees.SelectedItem as Employee;
                employeeDataAccess.RemoveEmployee(currentEmployee.Id);
                LblEmployee.Content = "---";
            }
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomer addCustomer = new AddEditCustomer(customerDataAccess);
            addCustomer.ShowDialog();
        }

        private void BtnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (DgCustomers.SelectedIndex >= 0)
            {
                currentCustomer = DgCustomers.SelectedItem as Customer;
                AddEditCustomer editCustomer = new AddEditCustomer(customerDataAccess, currentCustomer);
                editCustomer.ShowDialog();
            }
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (DgCustomers.SelectedIndex >= 0)
            {
                currentCustomer = DgCustomers.SelectedItem as Customer;
                customerDataAccess.RemoveCustomer(currentCustomer.Id);
                LblCustomer.Content = "---";
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addProduct = new AddEditProduct(productDataAccess);
            addProduct.ShowDialog();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (DgProducts.SelectedIndex >= 0)
            {
                currentProduct = DgProducts.SelectedItem as Product;
                AddEditProduct editProduct = new AddEditProduct(productDataAccess, currentProduct);
                editProduct.ShowDialog();
            }
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (DgProducts.SelectedIndex >= 0)
            {
                currentProduct = DgProducts.SelectedItem as Product;
                productDataAccess.RemoveProduct(currentProduct.Id);
                LblProduct.Content = "---";
            }
        }
    }
}
