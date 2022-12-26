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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSR5.AppDataFiles;

namespace WSR5.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();

            LoadData();

            UpdateData();
        }
        private void LoadData()
        {
          

            var products = ConnectOdb.wsr5bd.Product.ToList();

            ListProduct.ItemsSource = products;

            var types = ConnectOdb.wsr5bd.ProductCategory.ToList();

           

            cbType.SelectedIndex = 0;

            cbType.ItemsSource = types;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        { 
                ConnectOdb.wsr5bd.Product.Remove(((Button)sender).DataContext as Product);
                ConnectOdb.wsr5bd.SaveChanges();

                var products = ConnectOdb.wsr5bd.Product.ToList();

                ListProduct.ItemsSource = products;
            
        }
        private void UpdateData()
        {
            var products = ConnectOdb.wsr5bd.Product.ToList();

            
           
        }
    }
   
}
