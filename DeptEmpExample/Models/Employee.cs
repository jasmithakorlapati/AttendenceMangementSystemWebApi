using System;
using System.Collections.Generic;

namespace DeptEmpExample.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public int DeptId { get; set; }

    public int LibId { get; set; }

    public virtual Department? Dept { get; set; } = null!;

    public virtual Library? Lib { get; set; } = null!;
}
