using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class EditMovieView
    {
        public long MovieId { get; set; }

        [MaxLength(150)]

        public string MovieTitle { get; set; }

        [MaxLength(50)]

        public string MovieDirector { get; set; }

        [MaxLength(50)]

        public string MovieProducer { get; set; }

        [MaxLength(50)]

        public string MovieLanguage { get; set; }

        [MaxLength(50)]

        public string MovieGenre { get; set; }


        public int MovieRating { get; set; }


        public bool IsUpcoming { get; set; }


        public string MovieDuration { get; set; }
    }
}
