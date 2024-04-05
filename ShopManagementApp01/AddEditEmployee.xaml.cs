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
using HB.Models;
using HB;

namespace ShopManagementApp01
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess employeeDataAccess;
        private Employee editingEmployee;
        private bool isEditing = false;
        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
        }

        public AddEditEmployee(EmployeeDataAccess empDataAccess, Employee emp)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
            editingEmployee = emp;
            isEditing = true;
            TxtEmployeeFirstName.Text = editingEmployee.FirstName;
            TxtEmployeeLastName.Text = editingEmployee.LastName;
            TxtEmployeePhoneNumber.Text = editingEmployee.PhoneNumber;
            TxtEmployeeAddress.Text = editingEmployee.Address;
            CmbDepartment.SelectedIndex = (int) editingEmployee.Department;
            TxtEmployeeBaseSalary.Text = editingEmployee.BaseSalary.ToString();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool isValid;
            isValid = CheckEmployeeValidation();

            if (isValid)
            {
                if (isEditing)
                {
                    Employee employee = new Employee()
                    {
                        Id = editingEmployee.Id,
                        FirstName = TxtEmployeeFirstName.Text,
                        LastName = TxtEmployeeLastName.Text,
                        PhoneNumber = TxtEmployeePhoneNumber.Text,
                        Address = TxtEmployeeAddress.Text,
                        Department = (Department)CmbDepartment.SelectedIndex,
                        BaseSalary = Convert.ToDecimal(TxtEmployeeBaseSalary.Text)
                    };

                    employeeDataAccess.EditEmployee(employee);
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        Id = employeeDataAccess.GetNextId(),
                        FirstName = TxtEmployeeFirstName.Text,
                        LastName = TxtEmployeeLastName.Text,
                        PhoneNumber = TxtEmployeePhoneNumber.Text,
                        Address = TxtEmployeeAddress.Text,
                        Department = (Department)CmbDepartment.SelectedIndex,
                        BaseSalary = Convert.ToDecimal(TxtEmployeeBaseSalary.Text)
                    };

                    employeeDataAccess.AddEmployee(employee);
                }
                Close();
            }
            else
            {

            }
            
        }

        private bool CheckEmployeeValidation()
        {
            bool isValid = true;

            string firstName = TxtEmployeeFirstName.Text.Trim();
            string lastName = TxtEmployeeLastName.Text.Trim();
            string phoneNumber = TxtEmployeePhoneNumber.Text.Trim();
            string address = TxtEmployeeAddress.Text.Trim();
            int department = CmbDepartment.SelectedIndex;
            string baseSalary = TxtEmployeeBaseSalary.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || firstName.Contains(";"))
            {
                isValid = false;
                LblEmployeeError.Content = "*Firstname is invalid!*";
            }
            else if (string.IsNullOrEmpty(lastName) || lastName.Contains(";"))
            {
                isValid = false;
                LblEmployeeError.Content = "*Lastname is invalid!*";
            }
            else if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Contains(";"))
            {
                isValid = false;
                LblEmployeeError.Content = "*Phonenumber is invalid!*";
            }
            else if (string.IsNullOrEmpty(address) || address.Contains(";"))
            {
                isValid = false;
                LblEmployeeError.Content = "*Address is invalid!*";
            }
            else if (department < 0)
            {
                isValid = false;
                LblEmployeeError.Content = "*Department is invalid!*";
            }
            else if (!decimal.TryParse(baseSalary, out decimal bS) || baseSalary.Contains(";"))
            {
                isValid = false;
                LblEmployeeError.Content = "*Base salary is invalid!*";
            }
            else
            {
                isValid = true;
                LblEmployeeError.Content = "";
            }

            return isValid;
        }

        private void TxtEmployeeFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string firstName = TxtEmployeeFirstName.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || firstName.Contains(";"))
            {
                TxtEmployeeFirstName.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtEmployeeFirstName.BorderBrush = Brushes.Green;
            }
        }

        private void TxtEmployeeLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string lastName = TxtEmployeeLastName.Text.Trim();

            if (string.IsNullOrEmpty(lastName) || lastName.Contains(";"))
            {
                TxtEmployeeLastName.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtEmployeeLastName.BorderBrush = Brushes.Green;
            }
        }

        private void TxtEmployeePhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string phoneNumber = TxtEmployeePhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Contains(";"))
            {
                TxtEmployeePhoneNumber.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtEmployeePhoneNumber.BorderBrush = Brushes.Green;
            }
        }

        private void TxtEmployeeAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            string address = TxtEmployeeAddress.Text.Trim();

            if (string.IsNullOrEmpty(address) || address.Contains(";"))
            {
                TxtEmployeeAddress.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtEmployeeAddress.BorderBrush = Brushes.Green;
            }
        }

        private void TxtEmployeeBaseSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            string baseSalary = TxtEmployeeBaseSalary.Text.Trim();

            if (!decimal.TryParse(baseSalary, out decimal bS) || baseSalary.Contains(";"))
            {
                TxtEmployeeBaseSalary.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtEmployeeBaseSalary.BorderBrush = Brushes.Green;
            }
        }
    }
}
