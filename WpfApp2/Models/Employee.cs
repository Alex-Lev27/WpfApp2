using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class Employee
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Password { get; set; } = null!;

    public int PostId { get; set; }

    public  List<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

    public  Post Post { get; set; } = null!;

    public  List<SupplierOrder> SupplierOrders { get; set; } = new List<SupplierOrder>();
}
