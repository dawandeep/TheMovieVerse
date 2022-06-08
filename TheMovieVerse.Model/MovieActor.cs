using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieVerse.Model
{
    public class MovieActor
    {
        public long MovieActorId { get; set; }

        public long MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public long ActorId { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
