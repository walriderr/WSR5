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
using WSR5.Pages;

namespace WSR5.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();

            frmMain.Navigate(new ProductPage());
        }

        private void frmMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (frmMain.Content.GetType().Name == "ProductPage")
                btnBack.Visibility = Visibility.Hidden;
            else
                btnBack.Visibility = Visibility.Visible;
        }

        private void btnFAQ_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new FAQPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmMain.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();

            this.Close();
        }
    }
}
