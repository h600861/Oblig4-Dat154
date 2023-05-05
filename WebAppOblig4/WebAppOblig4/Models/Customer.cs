using System;
using System.Collections.Generic;

namespace WebAppOblig4.Models;

public partial class Customer
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public Customer() {
    }
    public Customer (string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
