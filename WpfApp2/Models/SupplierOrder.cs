using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class SupplierOrder
{
    public int Id { get; set; }

    public int ContragentId { get; set; }

    public DateOnly CreationDate { get; set; }

    public DateOnly? ExecutionDate { get; set; }

    public int EmployeeId { get; set; }

    public int StatusId { get; set; }

    public string? Comment { get; set; }

    public  Contragent Contragent { get; set; } = null!;

    public  Employee Employee { get; set; } = null!;

    public Status Status { get; set; } = null!;

    public List<SupplierOrderList> SupplierOrderLists { get; set; } = new List<SupplierOrderList>();
}
