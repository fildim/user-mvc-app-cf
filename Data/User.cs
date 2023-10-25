using System;
using System.Collections.Generic;

namespace UserMvcApp.Data;

public partial class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Institution { get; set; }
    public string? UserRole { get; set; }
    public virtual Student? Student { get; set; }
}
