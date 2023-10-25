using System;
using System.Collections.Generic;

namespace UserMvcApp.Data;

public partial class Student
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public virtual User? User { get; set; }
}
