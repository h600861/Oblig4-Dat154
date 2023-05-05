using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppOblig4.Models;
using WebAppOblig4.Services;
using static WebAppOblig4.Models.Room;

namespace WebAppOblig4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService customerService;
        private readonly IBookingService bookingService;
       
        public HomeController(ILogger<HomeController> logger, ICustomerService customerService, IBookingService bookingService)
        {
            _logger=logger;
            this.customerService = customerService;
            this.bookingService = bookingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoomSearch(DateTime checkinDate, DateTime checkoutDate, Room.RoomType roomType)
        {
            var room = new Room { roomType = roomType };
            ViewBag.CheckinDate = checkinDate;
            ViewBag.CheckoutDate = checkoutDate;
            return View(room);
        }


        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Customer customer)
        {
            Customer cust1 = customerService.GetCustomerByEmail(customer.Email);
            if (customerService.validatePassword(customer.Password, cust1))
            {
                HttpContext.Response.Cookies.Append("user_email", cust1.Email);
               return  RedirectToAction("RoomSearch", "Home");
            }
            return View(customer);
        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Customer customer)
        {
            if (customerService.ValidCustomer(customer))
            {

                customerService.AddCustomer(customer);
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }

    
        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Booking(Booking model)
        {
            Booking booking = new Booking
            {
                RomId = 2,
                RoomType = model.RoomType,
                CheckinDate = model.CheckinDate,
                CheckoutDate = model.CheckoutDate,
                CustomersEmail = HttpContext.Request.Cookies["user_email"]!
        };
           
                bookingService.addBooking(booking);
               
                return RedirectToAction("ShowBooking", "Home");
            
        }
        public IActionResult ShowBooking()
        {
            if (HttpContext.Request.Cookies["user_email"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            Customer cust = customerService.GetCustomerByEmail(HttpContext.Request.Cookies["user_email"]);

            return View(cust);
                
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
       
}