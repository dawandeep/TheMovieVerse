using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMovieVerse.Model
{
    public class Cinema
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(150)]
        public string CinemaName { get; set; }

        [MaxLength(300)]
        public string CinemaLocation { get; set; }
        public List <Theatre> Theatres { get; set; } = new List<Theatre>();

        //public List<Seat> Seats { get; set; } = new List<Seat>();
        //public List<MovieBooking> MovieBookings { get; set; } = new List<MovieBooking>();


    }
}
