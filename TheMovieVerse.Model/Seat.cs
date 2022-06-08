using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheMovieVerse.Model
{
    public class Seat
    {
        [Key]
        [Required]
        public long Id {get; set;}
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string SeatNo {get; set;}
        public bool IsOccupied {get; set;}
        public long TheatreId { get; set; }
        //public List<MovieBooking> MovieBookings { get; set; } = new List<MovieBooking>();
    }
}
