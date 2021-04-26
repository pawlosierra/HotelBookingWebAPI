using HotelBookingWebAPI.DTOs.Client;
using HotelBookingWebAPI.DTOs.Room;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Reservation
{
    public class BookingRequest
    {
        [Required(ErrorMessage ="The field ChechIn is required")]
        [RegularExpression(@"^(19|20)\d\d-(0[1-9]|1[012])-([012]\d|3[01])T([01]\d|2[0-3]):([0-5]\d):([0-5]\d)$", ErrorMessage = "Invalid date format. Requested format is: YYYY-MM-DDTHH:MM:SS")]
        public string CheckIn { get; set; }
        [Required(ErrorMessage = "The field ChechOut is required")]
        [RegularExpression(@"^(19|20)\d\d-(0[1-9]|1[012])-([012]\d|3[01])T([01]\d|2[0-3]):([0-5]\d):([0-5]\d)$", ErrorMessage = "Invalid date format. Requested format is: YYYY-MM-DDTHH:MM:SS")]
        public string CheckOut { get; set; }
        [Required(ErrorMessage ="The field Traverllers is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Travellers { get; set; }
        [Required(ErrorMessage = "The field ClientId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "The field RoomdId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int RoomId { get; set; }
    }
}
