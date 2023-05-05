
using Microsoft.EntityFrameworkCore;
using WebAppOblig4.Models;

namespace WebAppOblig4.Repositories
{
   public interface ICustomerRepo
    {
        void addCustomer(Customer customer);
        Customer getCustomer(string email);
    }
    public class CustomerRepo : ICustomerRepo
    {
        private readonly H600861Context dx = new();
       public void addCustomer(Customer customer) { 
        
            dx.Customers.Add(customer);
            dx.SaveChanges();
        }
    public Customer ? getCustomer(string email)
        {
            return dx.Customers.Include(p => p.Bookings).SingleOrDefault(p => p.Email == email);
        }
    }
}
