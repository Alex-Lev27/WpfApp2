using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public  List<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

    public  List<SupplierOrder> SupplierOrders { get; set; } = new List<SupplierOrder>();
}
