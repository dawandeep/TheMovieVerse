using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.Model
{
    public class Theatre
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(60)]
        public string TheatreName { get; set; }

        public int TotalSeats { get; set; }

        public bool IsBooked { get; set; }

        public List<Seat> Seats { get; set; } = new List<Seat>();

        public long CinemaId { get; set; }

        public List<MovieBooking> MovieBookings { get; set; } = new List<MovieBooking>();
    }
}
