
using WebAppOblig4.Models;
using WebAppOblig4.Repositories;

namespace WebAppOblig4.Services

{
    public interface ICustomerService
    {
        public Customer GetCustomerByEmail (string email);
        public bool ValidCustomer (Customer customer);

        public bool validatePassword(string password, Customer customer);
        public void AddCustomer (Customer customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo customerRepo;

        public CustomerService (ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        
        public Customer GetCustomerByEmail(string email)
        {
            return customerRepo.getCustomer(email);
        }
    public bool ValidCustomer(Customer customer)
        {
            if (customer == null || customer.Email == null || customer.Password == null || customer.Name == null || GetCustomerByEmail(customer.Email) != null) 
            {
                return false;
            }

            return true;
        }

        public void AddCustomer (Customer customer)
        {
            customerRepo.addCustomer (customer);
        }

        public bool validatePassword (string password, Customer customer)
        {
            return password != null && customer != null && password == customer.Password;
        }
    }
}
