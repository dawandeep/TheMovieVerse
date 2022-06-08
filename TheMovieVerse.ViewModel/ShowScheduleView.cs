using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class ShowScheduleView
    {
        public double TicketPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShowDate { get; set; }
        [MaxLength(50)]
        public string TimeSlot { get; set; }

       // public List<MovieBookingView> MovieBookings { get; set; } = new List<MovieBookingView>();
    }
}
