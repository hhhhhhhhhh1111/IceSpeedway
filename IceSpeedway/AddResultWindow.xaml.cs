using IceSpeedway.Models;
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
    /// Логика взаимодействия для AddResultWindow.xaml
    /// </summary>
    public partial class AddResultWindow : Window
    {
        private Result editingResult;
        public AddResultWindow(Result result = null)
        {
            InitializeComponent();
            if (result != null)
            {
                Title = "Редактировать результат";
                editingResult = result;
                LastNameBox.Text = result.LastName;
                FirstNameBox.Text = result.FirstName;
                PatronymicBox.Text = result.Patronymic;
                CityBox.Text = result.City;
                Tour1Box.SelectedIndex = result.Tour1 - 0;
                Tour2Box.SelectedIndex = result.Tour2 - 0;
                Tour3Box.SelectedIndex = result.Tour3 - 0;
                Tour4Box.SelectedIndex = result.Tour4 - 0;
                Tour5Box.SelectedIndex = result.Tour5 - 0;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ParsePoints(ComboBox box)
                {
                    return box.SelectedItem is ComboBoxItem item ? int.Parse(item.Content.ToString()) : 0;
                }
                using (var db = new ApplicationContext())
                {
                    if (editingResult == null)
                    {
                        var result = new Result
                        {
                            LastName = LastNameBox.Text,
                            FirstName = FirstNameBox.Text,
                            Patronymic = PatronymicBox.Text,
                            City = CityBox.Text,
                            Tour1 = ParsePoints(Tour1Box),
                            Tour2 = ParsePoints(Tour2Box),
                            Tour3 = ParsePoints(Tour3Box),
                            Tour4 = ParsePoints(Tour4Box),
                            Tour5 = ParsePoints(Tour5Box),
                        };

                        db.Results.Add(result);
                    }
                    else
                    {
                        var result = db.Results.Find(editingResult.Id);
                        if (result != null)
                        {
                            result.LastName = LastNameBox.Text;
                            result.FirstName = FirstNameBox.Text;
                            result.Patronymic = PatronymicBox.Text;
                            result.City = CityBox.Text;
                            result.Tour1 = ParsePoints(Tour1Box);
                            result.Tour2 = ParsePoints(Tour2Box);
                            result.Tour3 = ParsePoints(Tour3Box);
                            result.Tour4 = ParsePoints(Tour4Box);
                            result.Tour5 = ParsePoints(Tour5Box);
                        }
                    }
                    db.SaveChanges();
                }
                MessageBox.Show("Результат сохранён");
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}