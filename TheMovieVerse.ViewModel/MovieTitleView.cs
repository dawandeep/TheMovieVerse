using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.ViewModel
{

    public class MovieTitleView
    {
        [MaxLength(150)]
        [Required]
        public string MovieTitle { get; set; }
    }
}
