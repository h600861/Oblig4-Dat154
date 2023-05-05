using System;
using System.Collections.Generic;

namespace WebAppOblig4.Models;

public partial class Booking
{
    public int Id { get; set; }

    public string RoomType { get; set; } = null!;

    public DateOnly CheckinDate { get; set; }

    public DateOnly CheckoutDate { get; set; }

    public string CustomersEmail { get; set; } = null!;

    public int RomId { get; set; }

    public virtual Customer CustomersEmailNavigation { get; set; } = null!;

    public Booking()
    {

    }
    public Booking (int RomId,  string RoomType, DateOnly CheckinDate, DateOnly CheckoutDate, string CustomersEmail)
    {
        this.RomId = RomId;
        this.RoomType = RoomType;
        this.CheckinDate = CheckinDate;
        this.CheckoutDate = CheckoutDate;
        this.CustomersEmail = CustomersEmail;

    }
}
