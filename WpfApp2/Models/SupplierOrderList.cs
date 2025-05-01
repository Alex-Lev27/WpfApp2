using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class SupplierOrderList
{
    public int SupplierOrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal SalePrice { get; set; }

    public Product Product { get; set; } = null!;

    public SupplierOrder SupplierOrder { get; set; } = null!;
}
