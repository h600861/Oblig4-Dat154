using Microsoft.AspNetCore.Mvc;
using WebAppOblig4.Models;
using WebAppOblig4.Repositories;

namespace WebAppOblig4.Services
{
   public interface IBookingService
    {
        public void addBooking(Booking booking);
    }
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo bookingRepo;

        public BookingService(IBookingRepo bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public void addBooking(Booking booking)
        {
            bookingRepo.addBooking(booking);
        }
    }
}
