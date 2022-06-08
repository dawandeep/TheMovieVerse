using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheMovieVerse.Model
{
    public class Actor
    {
        public Actor()
        {
            this.MovieActors = new HashSet<MovieActor>();
        }

        [Key]
        [Required]
        public long ActorId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
