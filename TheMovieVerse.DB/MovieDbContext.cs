using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovieVerse.Model;

namespace TheMovieVerse.DB
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Theatre> Theatres { get; set; }
        //public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ShowSchedule> ShowSchedules { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieBooking> MovieBookings { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }


    }
}
