using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using HB;
using HB.Models;

namespace ShopManagementApp01
{
    /// <summary>
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private CustomerDataAccess customerDataAccess;
        private Customer editingCustomer;
        private bool isEditing = false;
        public AddEditCustomer(CustomerDataAccess cusDataAccess)
        {
            InitializeComponent();
            customerDataAccess = cusDataAccess;

        }

        public AddEditCustomer(CustomerDataAccess cusDataAccess, Customer cus)
        {
            InitializeComponent();
            customerDataAccess = cusDataAccess;
            editingCustomer = cus;
            isEditing = true;
            TxtCustomerFirstName.Text = editingCustomer.FirstName;
            TxtCustomerLastName.Text = editingCustomer.LastName;
            TxtCustomerPhoneNumber.Text = editingCustomer.PhoneNumber;
            TxtCustomerAddress.Text = editingCustomer.Address;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool isValid;
            isValid = CheckCustomerValidation();

            if (isValid)
            {
                if (isEditing)
                {
                    Customer customer = new Customer()
                    {
                        Id = editingCustomer.Id,
                        FirstName = TxtCustomerFirstName.Text,
                        LastName = TxtCustomerLastName.Text,
                        PhoneNumber = TxtCustomerPhoneNumber.Text,
                        Address = TxtCustomerAddress.Text
                    };

                    customerDataAccess.EditCustomer(customer);
                }
                else
                {
                    Customer customer = new Customer()
                    {
                        Id = customerDataAccess.GetNextId(),
                        FirstName = TxtCustomerFirstName.Text,
                        LastName = TxtCustomerLastName.Text,
                        PhoneNumber = TxtCustomerPhoneNumber.Text,
                        Address = TxtCustomerAddress.Text
                    };

                    customerDataAccess.AddCustomer(customer);
                }
                Close();
            }
            else
            {

            }
            
        }

        private bool CheckCustomerValidation()
        {
            bool isValid = true;

            string firstName = TxtCustomerFirstName.Text.Trim();
            string lastName = TxtCustomerLastName.Text.Trim();
            string phoneNumber = TxtCustomerPhoneNumber.Text.Trim();
            string address = TxtCustomerAddress.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || firstName.Contains(";"))
            {
                isValid = false;
                LblCustomerError.Content = "*Firstname is invalid!*";
            }
            else if (string.IsNullOrEmpty(lastName) || lastName.Contains(";"))
            {
                isValid = false;
                LblCustomerError.Content = "*Lastname is invalid!*";
            }
            else if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Contains(";"))
            {
                isValid = false;
                LblCustomerError.Content = "*Phonenumber is invalid!*";
            }
            else if (string.IsNullOrEmpty(address) || address.Contains(";"))
            {
                isValid = false;
                LblCustomerError.Content = "*Address is invalid!*";
            }
            else
            {
                isValid = true;
                LblCustomerError.Content = "";
            }

            return isValid;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxtCustomerFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string firstName = TxtCustomerFirstName.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || firstName.Contains(";"))
            {
                TxtCustomerFirstName.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtCustomerFirstName.BorderBrush = Brushes.Green;
            }
        }

        private void TxtCustomerLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string lastName = TxtCustomerLastName.Text.Trim();

            if (string.IsNullOrEmpty(lastName) || lastName.Contains(";"))
            {
                TxtCustomerLastName.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtCustomerLastName.BorderBrush = Brushes.Green;
            }
        }

        private void TxtCustomerPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string phoneNumber = TxtCustomerPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Contains(";"))
            {
                TxtCustomerPhoneNumber.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtCustomerPhoneNumber.BorderBrush = Brushes.Green;
            }
        }

        private void TxtCustomerAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            string address = TxtCustomerAddress.Text.Trim();

            if (string.IsNullOrEmpty(address) || address.Contains(";"))
            {
                TxtCustomerAddress.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtCustomerAddress.BorderBrush = Brushes.Green;
            }
        }
    }
}
