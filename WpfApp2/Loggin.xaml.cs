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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Loggin.xaml
    /// </summary>
    public partial class Loggin : Window
    {
        
        
        public Loggin()
        {
            InitializeComponent();
        }

        private void ButtonCLick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkWindow workWindow = new WorkWindow();;
            workWindow.Show();

            Close();
        }
    }
}
