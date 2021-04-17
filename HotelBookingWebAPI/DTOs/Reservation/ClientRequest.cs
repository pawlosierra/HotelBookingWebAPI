using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class ClientRequest
    {
        [Required(ErrorMessage = "The field Passaport is required")]
        [StringLength(6, ErrorMessage = "The maximum number of characters is 6")]
        public string Passport { get; set; }
        
        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "The maximum number of characters is 10")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The field LastName is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The maximun number of character is 20")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "The field Email is required")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The field CellPhoneNumber is required")]
        [Phone(ErrorMessage = "The CellPhoneNumber is not valid")]
        [StringLength(11, ErrorMessage = "The CellPhoneNumber is not valid. The maximum number of characters is 11")]
        public string CellPhoneNumber { get; set; }
    }
}
