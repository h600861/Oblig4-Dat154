using System;
using System.Collections.Generic;

namespace WebAppOblig4.Models;

public partial class Room
{
    public int Id { get; set; }

    public int RoomNumber { get; set; }

    public RoomType roomType { get; set; }

    public int NumBeds { get; set; }

    public int RoomSize { get; set; }

    public decimal PricePerNight { get; set; }



public Room()
    {

    }

    public Room(RoomType roomType, decimal PricePerNight,int NumBeds)
    {
        this.roomType = roomType;
        this.NumBeds = NumBeds;
        this.PricePerNight = PricePerNight;
    }
    public enum RoomType
    {
        SingelRom,
        Dobbeltrom,
        Suite
    }
}

