using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingRequest
    {
        public ClientRequest ClientRequest { get; set; }
        public RoomRequest RoomRequest { get; set; }
        public AvailableDateRequest AvailableDateRequest { get; set; }
    }
    public class ClientRequest
    {
        [Required(ErrorMessage = "The field Passaport is required")]
        [StringLength(6, ErrorMessage = "The maximum number of characters is 6")]
        public string Passport { get; set; }
        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "The maximum number of characters is 10")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field LastName is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage ="The maximun number of character is 20")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The field Email is required")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "The email is not valid")]
        //[RegularExpression(@"\w + ([-+.’]\w +)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "The email is not valid")]
        //[RegularExpression(@"\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "The email is not valid")]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The email is not valid")]

        public string Email { get; set; }
        [Required(ErrorMessage = "The field CellPhoneNumber is required")]
        [Phone(ErrorMessage = "The CellPhoneNumber is not valid")]
        [StringLength(11, ErrorMessage = "The CellPhoneNumber is not valid. The maximum number of characters is 11")]
        public string CellPhoneNumber { get; set; }
    }
    public class RoomRequest
    {
        [Required(ErrorMessage = "The field PriceNight is required")]
        [Range(450, 1000, ErrorMessage = "The PriceNight for {0} must be between {1} and {2}")]
        public decimal PriceNight { get; set; }
        [Required(ErrorMessage = "The field Capacity is required")]
        [Range(2, 7, ErrorMessage = "The Capacity for {0} must be between {1} and {2}.")]
        public int Capacity { get; set; }
    }
    public class AvailableDateRequest
    {
        [Range(typeof(DateTime), "4/16/2021", "5/16/2021", ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string CheckIn { get; set; }
        [Range(typeof(DateTime), "4/16/2021", "5/16/2021", ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string CheckOut { get; set; }
    }
}
