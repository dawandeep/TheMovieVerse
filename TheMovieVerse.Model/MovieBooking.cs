using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.Model
    {
        public class MovieBooking
        {
            [Key]
            [Required]
            public long Id { get; set; }
            [MaxLength(50)]
            public string FirstName { get; set; }
            [MaxLength(50)]
            public string LastName { get; set; }
            public int Age { get; set; }
            public int NoOfTickets { get; set; }
            public long MovieId { get; set; }      
            public List<Seat> Seats { get; set; }=new List<Seat>();

        //  public long CinemaId { get; set; }
            public long TheatreId { get; set; }
            // public long ShowScheduleId { get; set; }
            //public long SeatId { get; set; }
        }
    }
