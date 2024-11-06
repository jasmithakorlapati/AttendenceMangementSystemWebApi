using System;
using System.Collections.Generic;

namespace DeptEmpExample.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } 

    public string DeptLoc { get; set; }

    public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();
}
