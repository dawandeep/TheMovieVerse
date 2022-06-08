using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace TheMovieVerse.ViewModel
{
    public class CinemaView
    {
        [MaxLength(150)]
        public string CinemaName { get; set; }

        [MaxLength(300)]
        public string CinemaLocation { get; set; }

        public List<TheatreView> Theatres { get; set; } = new List<TheatreView>();

        public List<SeatView> Seats { get; set; } = new List<SeatView>();

       // public List<MovieBookingView> MovieBookings { get; set; } = new List<MovieBookingView>();
    }
}
