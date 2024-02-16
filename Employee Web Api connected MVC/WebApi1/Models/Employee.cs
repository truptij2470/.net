using System;
using System.Collections.Generic;

namespace WebApi1.Models;

public partial class Employee
{
    public int EmpNo { get; set; }

    public string Name { get; set; } = null!;

    public decimal Basic { get; set; }

    public short DeptNo { get; set; }

    public virtual Department DeptNoNavigation { get; set; } = null!;
}
