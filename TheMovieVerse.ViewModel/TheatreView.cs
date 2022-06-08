using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TheMovieVerse.Model;

namespace TheMovieVerse.ViewModel
{
    public class TheatreView
    {
        [MaxLength(60)]
        public string TheatreName { get; set; }

        public long TotalSeats { get; set; }

        public bool IsBooked { get; set; }

        public List<SeatView> Seats { get; set; } = new List<SeatView>();

        public List<MovieBookingView> MovieBookings { get; set; } = new List<MovieBookingView>();
    }
}
