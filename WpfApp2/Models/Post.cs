using System;
using System.Collections.Generic;

namespace WpfApp2;

public partial class Post
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public List<Employee> Employees { get; set; } = new List<Employee>();
}
