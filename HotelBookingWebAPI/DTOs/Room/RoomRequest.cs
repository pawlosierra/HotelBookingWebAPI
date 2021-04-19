using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI.DTOs.Room
{
    public class RoomRequest
    {
        [Required(ErrorMessage = "The field PriceNight is required")]
        [Range(450, 1000, ErrorMessage = "The PriceNight for {0} must be between {1} and {2}")]
        public decimal PriceNight { get; set; }
        [Required(ErrorMessage = "The field RoomArea is required")]
        [Range(807, 2745, ErrorMessage = "The RoomArea for {0} must be between {1} and {2} sq ft.")]
        public int RoomArea { get; set; }
        [Required(ErrorMessage = "The field PeoplePerRoom is required")]
        [Range(1, 7, ErrorMessage = "The PeoplePerRoom for {0} must be between {1} and {2}")]
        public int PeoplePerRoom { get; set; }
        [Required(ErrorMessage = "The field NumberOfBeds is required")]
        [Range(1, 3, ErrorMessage = "The NumberOfBeds for {0} must be between {1} and {2}")]
        public int NumberOfBeds { get; set; }
        [Required(ErrorMessage = "The field NumberOfBeds is required")]
        public bool OceanView { get; set; }
        [Required(ErrorMessage = "The field NumberOfBeds is required")]
        public bool FreeWiFi { get; set; }
        [Required(ErrorMessage = "The field AirConditioning is required")]
        public bool AirConditioning { get; set; }
        [Required(ErrorMessage = "The field PetFriendly is required")]
        public bool PetFriendly { get; set; }
        [Required(ErrorMessage = "The field ParkingIncluded is required")]
        public bool ParkingIncluded { get; set; }
    }
}
