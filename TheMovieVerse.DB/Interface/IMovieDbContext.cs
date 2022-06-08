using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheMovieVerse.Model;

namespace TheMovieVerse.DB.Interface
{
    public interface IMovieDbContext:IDisposable,IDbContext
    {
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ShowSchedule> ShowSchedules { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieBooking> MovieBookings { get; set; }
    }
}
