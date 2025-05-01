using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class ClientOrderList
{
    public int ClientOrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public ClientOrder ClientOrder { get; set; } = null!;

    public Product Product { get; set; } = null!;
}
