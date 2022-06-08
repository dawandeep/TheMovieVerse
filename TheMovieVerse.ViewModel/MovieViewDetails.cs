using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class MovieViewDetails
    {
        public MovieViewDetails()
        {
            this.MovieActors = new HashSet<MovieActorView>();
        }

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

        public virtual ICollection<MovieActorView> MovieActors { get; set; }

    }
}

