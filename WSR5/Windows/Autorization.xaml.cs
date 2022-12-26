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
using WSR5.AppDataFiles;

namespace WSR5.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "")
            {
                var users = ConnectOdb.wsr5bd.User.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].UserLogin == tbLogin.Text && users[i].UserPassword == tbPassword.Text)
                    {
                        if (users[i].Role.RoleName == "Администратор")
                            Admin.isAdmin = true;

                        MainWin mainWin = new MainWin();
                        mainWin.Show();

                        this.Close();
                    }
                }
            }
            else
                MessageBox.Show("Заполните все поля!!!");

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
             Registration registration = new Registration();
             registration.Show();

            this.Close();
        }
    }
}
