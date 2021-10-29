using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class HotelRoom
    {
        // Composite Key = HotelId + RoomNumber
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }

        [Column(TypeName = "money")] // Default is decimal(18,2)
        public decimal Price { get; set; }


        // Navigation Property
        public Hotel Hotel { get; set; }
    }

    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
