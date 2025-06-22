using IceSpeedway.Models;
using IceSpeedway.utils;
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

namespace IceSpeedway
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка "Назад"
        /// </summary> 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        /// <summary>
        /// Кнопка "Зарегистрироваться" 
        /// </summary> 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            string password2 = textBox3.Text;
            if (!email.IsValidEmail())
            {
                MessageBox.Show("Неверный формат почты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!InputValidator.IsValidPassword(password))
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (password != password2)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (var db = new ApplicationContext())
            {
                if (db.Users.Any(u => u.Login == email))
                {
                    MessageBox.Show("Email уже зарегистрирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var user = new User
                {
                    Login = email,
                    Password = password
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
            MessageBox.Show("Регистрация прошла успешно!");
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        private void TextBox_TextChanged1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateWatermark1();
        }
        private void UpdateWatermark1()
        {
            watermark1.Visibility = string.IsNullOrWhiteSpace(textBox1.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void TextBox_TextChanged2(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateWatermark2();
        }
        private void UpdateWatermark2()
        {
            watermark2.Visibility = string.IsNullOrWhiteSpace(textBox2.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void TextBox_TextChanged3(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateWatermark3();
        }
        private void UpdateWatermark3()
        {
            watermark3.Visibility = string.IsNullOrWhiteSpace(textBox3.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}