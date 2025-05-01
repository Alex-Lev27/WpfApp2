using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public int ManufacturerId { get; set; }

    public int CountryId { get; set; }

    public int Stock { get; set; }

    public  Category Category { get; set; } = null!;

    public  List<ClientOrderList> ClientOrderLists { get; set; } = new List<ClientOrderList>();

    public  Country Country { get; set; } = null!;

    public  Manufacturer Manufacturer { get; set; } = null!;

    public  List<SupplierOrderList> SupplierOrderLists { get; set; } = new List<SupplierOrderList>();
}
