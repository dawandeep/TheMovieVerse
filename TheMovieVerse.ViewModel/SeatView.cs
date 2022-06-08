using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class SeatView
    {
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string SeatNo { get; set; }

        public bool IsOccupied { get; set; }

        //public List<MovieBookingView> MovieBookings { get; set; } = new List<MovieBookingView>();
    }
}
