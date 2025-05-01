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
using WpfApp2.ViewModels;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtLastname.IsEnabled = true;
            txtName.IsEnabled = true;
            txtPatronym.IsEnabled = true;
            txtPassword.IsEnabled = true;
            txtTabelbNumber.IsEnabled = true;
            txtPost.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtLastname.IsEnabled = false;
            txtName.IsEnabled = false;
            txtPatronym.IsEnabled = false;
            txtPassword.IsEnabled = false;
            txtTabelbNumber.IsEnabled = false;
            txtPost.IsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Loggin loggin = new Loggin();
            loggin.Show();

            Close();
        }
    }
}
