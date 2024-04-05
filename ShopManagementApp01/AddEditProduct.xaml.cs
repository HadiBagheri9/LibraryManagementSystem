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
    /// Interaction logic for AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        private ProductDataAccess productDataAccess;
        private Product editingProduct;
        private bool isEditing;
        public AddEditProduct(ProductDataAccess proDataAccess)
        {
            InitializeComponent();
            productDataAccess = proDataAccess;
        }

        public AddEditProduct(ProductDataAccess proDataAccess, Product pro)
        {
            InitializeComponent();
            productDataAccess = proDataAccess;
            editingProduct = pro;
            isEditing = true;
            TxtProductName.Text = editingProduct.Name;
            TxtProductAuthor.Text = editingProduct.Author;
            TxtProductPrice.Text = editingProduct.Price.ToString();
            TxtProductAvailableCount.Text = editingProduct.AvailableCount.ToString();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool isValid;
            isValid = CheckProductValidition();

            if (isValid)
            {
                if (isEditing)
                {
                    Product product = new Product()
                    {
                        Id = editingProduct.Id,
                        Name = TxtProductName.Text,
                        Author = TxtProductAuthor.Text,
                        Price = Convert.ToDecimal(TxtProductPrice.Text),
                        AvailableCount = Convert.ToInt16(TxtProductAvailableCount.Text)
                    };

                    productDataAccess.EditProduct(product);
                }
                else
                {
                    Product product = new Product()
                    {
                        Id = productDataAccess.GetNextId(),
                        Name = TxtProductName.Text,
                        Author = TxtProductAuthor.Text,
                        Price = Convert.ToDecimal(TxtProductPrice.Text),
                        AvailableCount = Convert.ToInt16(TxtProductAvailableCount.Text)
                    };

                    productDataAccess.AddProduct(product);
                }
                Close();
            }
            else
            {

            }
        }

        private bool CheckProductValidition()
        {
            bool isValid = true;

            string name = TxtProductName.Text.Trim();
            string author = TxtProductAuthor.Text.Trim();
            string price = TxtProductPrice.Text.Trim();
            string availableCount = TxtProductAvailableCount.Text.Trim();

            if (string.IsNullOrEmpty(name) || name.Contains(";"))
            {
                isValid = false;
                LblProductError.Content = "*Name is invalid!*";
            }
            else if (string.IsNullOrEmpty(author) || author.Contains(";"))
            {
                isValid = false;
                LblProductError.Content = "*Author is invalid!*";
            }
            else if (!decimal.TryParse(price, out decimal p) || price.Contains(";"))
            {
                isValid = false;
                LblProductError.Content = "*Price is invalid!*";
            }
            else if (!short.TryParse(availableCount, out short aC) || availableCount.Contains(";"))
            {
                isValid = false;
                LblProductError.Content = "*Available Count is invalid!*";
            }
            else
            {
                isValid = true;
                LblProductError.Content = "";
            }

            return isValid;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = TxtProductName.Text.Trim();

            if (string.IsNullOrEmpty(name) || name.Contains(";"))
            {
                TxtProductName.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtProductName.BorderBrush = Brushes.Green;
            }
        }

        private void TxtProductAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            string author = TxtProductAuthor.Text.Trim();

            if (string.IsNullOrEmpty(author) || author.Contains(";"))
            {
                TxtProductAuthor.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtProductAuthor.BorderBrush = Brushes.Green;
            }
        }

        private void TxtProductPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            string price = TxtProductPrice.Text.Trim();

            if (!decimal.TryParse(price, out decimal p) || price.Contains(";"))
            {
                TxtProductPrice.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtProductPrice.BorderBrush = Brushes.Green;
            }
        }

        private void TxtProductAvailableCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            string availableCount = TxtProductAvailableCount.Text.Trim();

            if (!short.TryParse(availableCount, out short aC) || availableCount.Contains(";"))
            {
                TxtProductAvailableCount.BorderBrush = Brushes.Red;
            }
            else
            {
                TxtProductAvailableCount.BorderBrush = Brushes.Green;
            }
        }
    }
}
