using AutoMapper;
using TheMovieVerse.Model;
using TheMovieVerse.ViewModel;

namespace TheMovieVerse.AutoMapper
{
    public class AppProfile: Profile
    {
        public AppProfile()
        {
            CreateMap<MovieView, Movie>().ReverseMap();
            CreateMap<MovieTitleView, Movie>().ReverseMap();
            CreateMap<MovieDetailView, Movie>().ReverseMap();
            CreateMap<EditMovieView, Movie>().ReverseMap();
            CreateMap<TheatreView, Theatre>().ReverseMap();
            CreateMap<SeatView, Seat>().ReverseMap();
            CreateMap<MovieBookingView, MovieBooking>().ReverseMap();
            CreateMap<ActorView, Actor>().ReverseMap();
            CreateMap<CinemaView, Cinema>().ReverseMap();
            CreateMap<ShowScheduleView, ShowSchedule>().ReverseMap()
                .ForMember(x => x.ShowDate, opt => opt.MapFrom(o => o.ShowDate.Date));
            

        }
    }
}
