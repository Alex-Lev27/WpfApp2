using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ViewModels
{
    internal class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<ClientOrder> ClientOrders { get; set; }
        public ObservableCollection<ClientOrderList> ClientOrderLists { get; set; }
        public ObservableCollection<Contragent> Contragents { get; set; }
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Manufacturer> Manufacturers { get; set; }
        public ObservableCollection<Post> Posts { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Status>  Statuses { get; set; }
        public ObservableCollection<SupplierOrder> SupplierOrders { get; set; }
        public ObservableCollection<SupplierOrderList> SupplierOrderLists { get; set; }

        public MainViewModel() 
        {
            LoadData();
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
                    .ToList()
                    );
            }
        }


    }
}
