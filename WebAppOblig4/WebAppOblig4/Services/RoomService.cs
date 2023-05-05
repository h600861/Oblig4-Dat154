using Microsoft.AspNetCore.Mvc;
using WebAppOblig4.Models;
using WebAppOblig4.HelpingMethods;
using WebAppOblig4.Repositories;

namespace WebAppOblig4.Services
{

    public interface IRoomService
    {
      //  public IEnumerable<Room> getRooms();
      //  public IEnumerable<Room> getAvailableRoom(DateTime checkinDate, DateTime checkoutDate, int numBeds);

    }
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo roomRepo;
        public RoomService(IRoomRepo roomRepo)
        {
            this.roomRepo = roomRepo;
        }
        /* public IEnumerable<Room> getRooms()
         {
             return roomRepo.GetAllrooms();
         }
         public IEnumerable<Room> getAvailableRoom(DateTime checkinDate, DateTime checkoutDate, int numBeds)
         {
             var Rooms = getRooms();
             var AvailableRooms = Rooms.Where(r => r.NumBeds >=  numBeds && r.Bookings.All(p => p.IsRoomAvailable(checkinDate, checkoutDate)));
             return AvailableRooms;
         }
        */

    }

}
