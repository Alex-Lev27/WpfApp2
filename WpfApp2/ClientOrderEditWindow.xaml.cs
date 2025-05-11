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
    /// Логика взаимодействия для ClientOrderEditWindow.xaml
    /// </summary>
    public partial class ClientOrderEditWindow : Window
    {
        public ClientOrder ClientOrder { get; set; }
        public List<Contragent> Contragents { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Status> Statuses { get; set; }
        public ICommand SaveCommand { get; }
        public List<ClientOrderList> ClientOrderLists { get; set; }
        //public List<ClientOrderList>? FilteredClientOrderLists { get; set; } -----не работает
        public ClientOrderEditWindow
        (
            ClientOrder clientOrder, 
            List<Contragent> contragents, 
            List<Employee> employees, 
            List<Status> statuses,
            List<ClientOrderList> clientOrderLists
        )
        {
            InitializeComponent();

            ClientOrder = new ClientOrder
            {
                Id = clientOrder.Id,
                ContragentId = clientOrder.ContragentId,
                CreationDate = clientOrder.CreationDate,
                ExecutionDate = clientOrder.ExecutionDate,
                EmployeeId = clientOrder.EmployeeId,
                StatusId = clientOrder.StatusId,
                Comment = clientOrder.Comment
            };

            Contragents = contragents;
            Employees = employees;
            Statuses = statuses;
            ClientOrderLists = clientOrderLists;
            //FilteredClientOrderLists = (List<ClientOrderList>?)ClientOrderLists.Where(x => x.ClientOrderId == ClientOrder.Id); -----не работает

            SaveCommand = new RelayCommand(_ =>
            {
                DialogResult = true;
                Close();
            });

            DataContext = this;

        }
    }
}
