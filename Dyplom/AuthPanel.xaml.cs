using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MainApp.Models;
using System.Data.Entity;

namespace MainApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelContext db;
        public MainWindow()
        {

            InitializeComponent();
        }

        private void OpenMenu()
        {
            Hide();
            Window1 w1 = new Window1();
            w1.Owner = this;
            w1.Show();
        }

        private void OpenUsersPanel()
        {
            Hide();
            Window2 w2 = new Window2();
            w2.Owner = this;
            w2.Show();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            db = new ModelContext();

            if (!String.IsNullOrWhiteSpace(loginTextBox.Text) && !String.IsNullOrWhiteSpace(passTextBox.Password))
            {
                if ((bool)cbLeadTeachers.IsChecked)
                {
                    LeadTeachers leadTeachers = db.LeadTeachers.Where(p => p.teacherlogin == loginTextBox.Text).SingleOrDefault();
                    if (leadTeachers != null)
                        if (leadTeachers.teacherpassword == passTextBox.Password.ToString())
                        {
                            OpenMenu();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный пароль", "Ошибка авторизации");
                        }
                    else
                    {
                        MessageBox.Show("Неправильный логин", "Ошибка авторизации");
                    }
                    db.Dispose();
                }
                else
                {
                    Management management = db.Management.Where(p => p.ManagementLogin == loginTextBox.Text).SingleOrDefault();
                    if (management != null)
                        if (management.ManagementPassword == passTextBox.Password.ToString())
                        {
                            OpenUsersPanel();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный пароль", "Ошибка авторизации");
                        }
                    else
                    {
                        MessageBox.Show("Неправильный логин", "Ошибка авторизации");
                    }
                    db.Dispose();
                }
        }


            /*private void TbLogin_KeyDown(object sender, KeyEventArgs e)
            {
                if (Keyboard.IsKeyDown(Key.Enter))
                {
                    passTextBox.Focus();
                }
            }

            private void TbPassword_KeyDown(object sender, KeyEventArgs e)
            {
                if (Keyboard.IsKeyDown(Key.Enter) && enterButton.IsEnabled)
                {
                    Button_Login_Click(enterButton, new RoutedEventArgs());
                }
            }*/
        }
    }

}