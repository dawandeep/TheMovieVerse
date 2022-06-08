using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieVerse.ViewModel
{
    public class MovieScheduleView
    {

        public string MovieTitle { get; set; }
        public List<ShowScheduleView> ShowSchedules { get; set; } = new List<ShowScheduleView>();
    }
}
