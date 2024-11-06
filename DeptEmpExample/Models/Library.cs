using System;
using System.Collections.Generic;

namespace DeptEmpExample.Models;

public partial class Library
{
    public int LibId { get; set; }

    public string LibName { get; set; }

    public string LibAdress { get; set; }

    public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();
}
