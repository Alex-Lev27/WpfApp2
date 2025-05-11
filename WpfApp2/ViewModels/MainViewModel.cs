using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public ICommand AddItemInClientOrderCommand { get; }
        public ICommand AddClientOrderCommand { get; }
        public ICommand EditClientOrderCommand { get; }

        public ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories 
        { 
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<ClientOrder> _clientOrders;
        public ObservableCollection<ClientOrder> ClientOrders 
        { 
            get => _clientOrders;
            set
            {
                _clientOrders = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<ClientOrderList> _clientOrderLists;
        public ObservableCollection<ClientOrderList> ClientOrderLists 
        { 
            get => _clientOrderLists; 
            set
            {
                _clientOrderLists = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Contragent> _contragents;
        public ObservableCollection<Contragent> Contragents
        {
            get => _contragents;
            set
            {
                _contragents = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Country> _countries;
        public ObservableCollection<Country> Countries 
        { 
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged();
            } 
        }


        public ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees 
        { 
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Manufacturer> _manufacturer;
        public ObservableCollection<Manufacturer> Manufacturers
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Post> _post;
        public ObservableCollection<Post> Posts 
        { 
            get => _post;
            set
            {
                _post = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products 
        { 
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Status> _statuses;
        public ObservableCollection<Status>  Statuses 
        { 
            get => _statuses; 
            set
            {
                _statuses = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<SupplierOrder> _supplierOrders;
        public ObservableCollection<SupplierOrder> SupplierOrders 
        { 
            get => _supplierOrders;
            set
            {
                _supplierOrders = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<SupplierOrderList> _supplierOrderLists;
        public ObservableCollection<SupplierOrderList> SupplierOrderLists 
        { 
            get => _supplierOrderLists;
            set
            {
                _supplierOrderLists = value;
                OnPropertyChanged();
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel() 
        {
            LoadData();
            AddItemInClientOrderCommand = new RelayCommand(AddItemInClientOrder);
            AddClientOrderCommand = new RelayCommand(AddClientOrder);
            EditClientOrderCommand = new RelayCommand(EditClientOrder);
        }

        private void LoadData()
        {
            using (var context = new SkladDbContext())
            {
                Categories = new ObservableCollection<Category>(context.Categories.ToList());
                ClientOrders = new ObservableCollection<ClientOrder>(context.ClientOrders
                    .Include(e => e.Contragent)
                    .Include(e => e.Employee)
                    .Include(e => e.Status)
                    .ToList());
                ClientOrderLists = new ObservableCollection<ClientOrderList>(context.ClientOrderLists
                    .Include(e => e.ClientOrder)
                    .Include(e => e.Product)
                    .ToList());
                Contragents = new ObservableCollection<Contragent>(context.Contragents.ToList());
                Countries = new ObservableCollection<Country> (context.Countries.ToList());
                Employees = new ObservableCollection<Employee>(context.Employees
                    .Include(e => e.Post).ToList());
                Manufacturers = new ObservableCollection<Manufacturer>(context.Manufacturers.ToList());
                Posts = new ObservableCollection<Post> (context.Posts.ToList());
                Products = new ObservableCollection<Product> (context.Products
                    .Include(e => e.Category)
                    .Include(e => e.Country)
                    .Include(e => e.Manufacturer)
                    .ToList());
                Statuses = new ObservableCollection<Status> (context.Statuses.ToList());
                SupplierOrders = new ObservableCollection<SupplierOrder>(context.SupplierOrders
                    .Include(e => e.Contragent)
                    .Include(e => e.Employee)
                    .Include(e => e.Status)
                    .ToList());
                SupplierOrderLists = new ObservableCollection<SupplierOrderList>(context.SupplierOrderLists
                    .Include(e => e.Product)
                    .Include(e => e.SupplierOrder)
                    .ToList());
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddItemInClientOrder(object parameter)
        {
            var dialog = new ClientOrderItemEditWindow(new ClientOrderList(), Products.ToList(), ClientOrders.ToList());
            if (dialog.ShowDialog() == true)
            {
                using (var context = new SkladDbContext())
                {
                    context.ClientOrderLists.Add(dialog.ClientOrderList);
                    context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void AddClientOrder(object parameter)
        {
            var dialog = new ClientOrderEditWindow
            (
                new ClientOrder(),
                Contragents.ToList(),
                Employees.ToList(),
                Statuses.ToList(),
                ClientOrderLists.ToList()
            );
            if(dialog.ShowDialog() == true )
            {
                using (var context = new SkladDbContext())
                {
                    context.ClientOrders.Add(dialog.ClientOrder);
                    context.SaveChanges();
                    LoadData();
                }
            }             
        }

        private void EditClientOrder(object parameter)
        {
            if(parameter is  ClientOrder clientOrder)
            {
                var dialog = new ClientOrderEditWindow
                    (clientOrder, Contragents.ToList(), Employees.ToList(), Statuses.ToList(), ClientOrderLists.ToList());

                if (dialog.ShowDialog() == true )
                {
                    using (var context = new SkladDbContext())
                    {
                        context.ClientOrders.Update(dialog.ClientOrder);
                        context.SaveChanges();
                        LoadData();
                    }
                }
            }
        }

    }
}
