using System.IO;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using HB.Models;

namespace HB
{
    public class EmployeeDataAccess
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        private string path = @"./DemoDBEmployees.csv";

        public EmployeeDataAccess()
        {
            ReadEmployees();
        }

        private void ReadEmployees()
        {
            using(var reader = new StreamReader(path))
            {
                Employees.Clear();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    Enum.TryParse(values[5], out Department dprt);

                    Employee employee = new Employee()
                    {
                        Id = Convert.ToUInt32(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        PhoneNumber = values[3],
                        Address = values[4],
                        Department = dprt,
                        BaseSalary = Convert.ToDecimal(values[6])
                    };

                    Employees.Add(employee);
                }
            }
        }

        private void SaveEmployee()
        {
            using(var writer = new StreamWriter(path))
            {
                foreach (Employee employee in Employees)
                {
                    string id = employee.Id.ToString();
                    string firstName = employee.FirstName;
                    string lastName = employee.LastName;
                    string phoneNumber = employee.PhoneNumber;
                    string address = employee.Address;
                    string department = employee.Department.ToString();
                    string baseSalary = employee.BaseSalary.ToString();
                    string line = string.Format("{0};{1};{2};{3};{4};{5};{6}",
                        id, firstName, lastName, phoneNumber, address, department, baseSalary);
                    writer.WriteLine(line);
                }
            }
        }


        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            SaveEmployee();
        }

        public void RemoveEmployee(uint id)
        {
            Employee temp = Employees.First(x => x.Id == id);
            Employees.Remove(temp);
            SaveEmployee();
        }

        public void EditEmployee(Employee employee)
        {
            Employee temp = Employees.First(x => x.Id == employee.Id);
            int index = Employees.IndexOf(temp);
            Employees[index] = employee;
            SaveEmployee();
        }

        public uint GetNextId()
        {
            uint index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
            return index;
        }
    }
}
