using Microsoft.AspNetCore.Mvc;
using WebAppOblig4.Models;

namespace WebAppOblig4.Repositories
{
   public interface IBookingRepo
    {
        public void addBooking(Booking booking);
    }
    public class BookingRepo : IBookingRepo
    {
        private H600861Context dx = new();

        public void addBooking (Booking booking)
        {
            dx.Bookings.Add(booking);
            dx.SaveChanges();
        }
    }
}
