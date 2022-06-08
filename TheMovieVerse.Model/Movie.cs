using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheMovieVerse.Model
{
    public class Movie
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public List<Actor> Actors { get; set; } = new List<Actor>();

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

    }
}
