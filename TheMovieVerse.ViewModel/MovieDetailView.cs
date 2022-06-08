using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class MovieDetailView
    {
      
        public string MovieTitle { get; set; }
        
        public List<ActorView> Actors { get; set; } = new List<ActorView>();
      
        public int MovieRating { get; set; }
      
     
        public string MovieDuration { get; set; }
    }
}
