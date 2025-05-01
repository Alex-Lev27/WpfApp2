using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public List<Product> Products { get; set; } = new List<Product>();
}
