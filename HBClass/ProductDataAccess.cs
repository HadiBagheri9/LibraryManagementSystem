using System.Linq;
using System.Collections.Generic;
using HB.Models;
using System.Collections.ObjectModel;
using System.IO;
using System;

namespace HB
{
    public class ProductDataAccess
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private string path = @"./DemoDBProducts.csv";

        public ProductDataAccess()
        {
            ReadProducts();
        }

        private void ReadProducts()
        {
            using(var reader = new StreamReader(path))
            {
                Products.Clear();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    Product product = new Product()
                    {
                        Id = Convert.ToUInt32(values[0]),
                        Name = values[1],
                        Author = values[2],
                        Price = Convert.ToDecimal(values[3]),
                        AvailableCount = Convert.ToInt16(values[4])
                    };

                    Products.Add(product);
                }
            }
        }

        private void SaveProduct()
        {
            using(var writer = new StreamWriter(path))
            {
                foreach (Product product in Products)
                {
                    string id = product.Id.ToString();
                    string name = product.Name;
                    string author = product.Author;
                    string price = product.Price.ToString();
                    string availableCount = product.AvailableCount.ToString();
                    string line = string.Format("{0};{1};{2};{3};{4}",
                        id, name, author, price, availableCount);
                    writer.WriteLine(line);
                }
            }
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            SaveProduct();
        }

        public void RemoveProduct(uint id)
        {
            Product temp = Products.First(x => x.Id == id);
            Products.Remove(temp);
            SaveProduct();
        }

        public void EditProduct(Product product)
        {
            Product temp = Products.First(x => x.Id == product.Id);
            int index = Products.IndexOf(temp);
            Products[index] = product;
            SaveProduct();
        }

        public uint GetNextId()
        {
            uint index = Products.Any() ? Products.Max(x => x.Id) + 1 : 1;
            return index;
        }
    }
}
