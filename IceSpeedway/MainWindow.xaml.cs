using IceSpeedway.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IceSpeedway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Result> Results { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Results = new ObservableCollection<Result>();
            LoadData();
            DataContext = this;
        }
        private void LoadData()
        {
            using (var db = new ApplicationContext())
            {
                var results = db.Results.ToList();
                Results.Clear();
                foreach (var result in results)
                {
                    Results.Add(result);
                }
            }
        }
        private void AddResult_Click(object sender, RoutedEventArgs e)
        {
            AddResultWindow window = new AddResultWindow();
            window.ShowDialog();
            LoadData();
        }
        private void ResultsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid grid && grid.SelectedItem is Result selectedResult)
            {
                var window = new AddResultWindow(selectedResult);
                window.ShowDialog();
                LoadData();
            }
        }

    }
}