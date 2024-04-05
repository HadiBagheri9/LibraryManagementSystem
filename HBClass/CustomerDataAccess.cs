using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;
using HB.Models;

namespace HB
{
    public class CustomerDataAccess
    {
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        private string path = @"./DemoDBCustomers.csv";

        public CustomerDataAccess()
        {
            ReadCustomers();
        }

        private void ReadCustomers()
        {
            using(var reader = new StreamReader(path))
            {
                Customers.Clear();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    Customer customer = new Customer()
                    {
                        Id = Convert.ToUInt32(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        PhoneNumber = values[3],
                        Address = values[4]
                    };

                    Customers.Add(customer);
                }
            }
        }

        private void SaveCustomer()
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (Customer customer in Customers)
                {
                    string id = customer.Id.ToString();
                    string firstName = customer.FirstName;
                    string lastName = customer.LastName;
                    string phoneNumber = customer.PhoneNumber;
                    string address = customer.Address;
                    string line = string.Format("{0};{1};{2};{3};{4}",
                        id, firstName, lastName, phoneNumber, address);
                    writer.WriteLine(line);
                }
            }
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            SaveCustomer();
        }

        public void RemoveCustomer(uint id)
        {
            Customer temp = Customers.First(x => x.Id == id);
            Customers.Remove(temp);
            SaveCustomer();
        }

        public void EditCustomer(Customer customer)
        {
            Customer temp = Customers.First(x => x.Id == customer.Id);
            int index = Customers.IndexOf(temp);
            Customers[index] = customer;
            SaveCustomer();
        }

        public uint GetNextId()
        {
            uint index = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
            return index;
        }
    }
}
