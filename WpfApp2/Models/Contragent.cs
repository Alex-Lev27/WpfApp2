using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class Contragent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? PhoneNum { get; set; }

    public string? Comment { get; set; }

    public List<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

    public List<SupplierOrder> SupplierOrders { get; set; } = new List<SupplierOrder>();
}
