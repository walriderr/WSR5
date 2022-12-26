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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" &&
                tbName.Text != "" &&
                tbPassword.Text != "" &&
                tbPatronymic.Text != "" &&
                tbSurname.Text != "")
            {
                var users = ConnectOdb.wsr5bd.User.ToList();
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].UserLogin == tbLogin.Text)
                    {
                        MessageBox.Show("Такой пользователь уже существует!");
                        return;
                    }
                }

                User user = new User()
                {
                    UserLogin = tbLogin.Text,
                    UserName = tbName.Text,
                    UserPassword = tbPassword.Text,
                    UserPatronymic = tbPatronymic.Text,
                    UserSurname = tbSurname.Text,
                    UserRoleId = 3
                };

                ConnectOdb.wsr5bd.User.Add(user);

                try
                {
                    ConnectOdb.wsr5bd.SaveChanges();
                    

                    this.Close();
                }
                catch (Exception)
                {
                    
                }

            }
            else
                MessageBox.Show("Заполните все поля!!!");

            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
        }
    }
}
