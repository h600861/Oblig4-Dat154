using WebAppOblig4.Models;

namespace WebAppOblig4.HelpingMethods
{
    public static class Methods 
    {
      public static int CalcPrice (this Room room)

        {
            return room.roomType switch
            {
                Room.RoomType.SingelRom => 400 + Math.Min(0, (room.NumBeds - 1))*100,
                Room.RoomType.Dobbeltrom => 600 + Math.Min(0, (room.NumBeds - 1))*100,
                Room.RoomType.Suite => 1000 + Math.Min(0, (room.NumBeds - 1))*100,
                _=>0,

            };
        }
        public static bool IsRoomAvailable(this Booking booking, DateTime startDate, DateTime endDate)
        {
            return !((startDate.CompareTo(booking.CheckinDate) >= 0 && startDate.CompareTo(booking.CheckoutDate) < 0)
                      || (endDate.CompareTo(booking.CheckinDate) > 0 && endDate.CompareTo(booking.CheckoutDate) <= 0)
                      || (booking.CheckinDate.CompareTo(startDate) >= 0 && booking.CheckinDate.CompareTo(endDate) < 0));
        }
    }
}
