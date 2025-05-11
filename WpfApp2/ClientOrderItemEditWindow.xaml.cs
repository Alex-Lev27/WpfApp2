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
    /// Логика взаимодействия для ClientOrderItemEditWindow.xaml
    /// </summary>
    public partial class ClientOrderItemEditWindow : Window
    {
        public ClientOrderList ClientOrderList { get; set; }
        public List<Product> Products { get; set; }
        public List<ClientOrder> ClientOrders { get; set; }
        public ICommand SaveCommand { get; }
        public ClientOrderItemEditWindow
            (ClientOrderList clientOrderList, 
            List<Product> products, 
            List<ClientOrder> clientOrders)
        {
            InitializeComponent();

            ClientOrderList = new ClientOrderList
            {
                ClientOrderId = clientOrderList.ClientOrderId,
                ProductId = clientOrderList.ProductId,
                Quantity = clientOrderList.Quantity,
                PurchasePrice = clientOrderList.PurchasePrice
            };

            ClientOrders = clientOrders;
            
            Products = products;
            SaveCommand = new RelayCommand(_ =>
            {
                DialogResult = true;
                Close();
            });

            DataContext = this;
        }
    }
}
