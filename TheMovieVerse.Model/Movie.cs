using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheMovieVerse.Model
{
    public class Movie
    {
        public Movie()
        {
            this.MovieActors = new HashSet<MovieActor>();
        }

        [Key]
        [Required]
        public long MovieId { get; set; }

        [MaxLength(150)]
        [Required]
        public string MovieTitle { get; set; }

        [MaxLength(50)]
        [Required]
        public string MovieDirector { get; set; }

        [MaxLength(50)]
        [Required]
        public string MovieProducer { get; set; }

        [MaxLength(50)]
        [Required]
        public string MovieLanguage { get; set; }

        [MaxLength(50)]
        [Required]
        public string MovieGenre { get; set; }

        [Required]
        public int MovieRating { get; set; }

        [Required]
        public bool IsUpcoming { get; set; }

        [Required]
        public string MovieDuration { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; }

        public List<ShowSchedule> ShowSchedules { get; set; } = new List<ShowSchedule>();

    }
}
