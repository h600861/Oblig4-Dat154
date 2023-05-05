using Microsoft.EntityFrameworkCore;
using WebAppOblig4.Models;

namespace WebAppOblig4.Repositories
{
    public interface IRoomRepo
    {
      //  public IEnumerable<Room> GetAllrooms();
       // public Room getRoomByRoomNumber (int num);
    }
    public class RoomRespo : IRoomRepo
    {
        private H600861Context dx = new();

       /* public IEnumerable<Room> GetAllrooms()
        {
            return dx.Rooms.Include(r => r.Bookings).AsNoTracking().AsEnumerable();
        }
        public Room getRoomByRoomNumber(int num)
        {
            return dx.Rooms.Find(num);
        }
       */
    }
}
