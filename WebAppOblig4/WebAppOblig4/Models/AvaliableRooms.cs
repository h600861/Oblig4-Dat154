using Microsoft.AspNetCore.Mvc;

namespace WebAppOblig4.Models
{
    public class AvaliableRooms
    {
   
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int RoomId { get; set; }

    }

}
