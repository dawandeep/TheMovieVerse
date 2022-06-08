using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovieVerse.Model;
using TheMovieVerse.ViewModel;

namespace TheMovieVerse.Services.Interface
{
    public interface IMovieService
    {
        public Task<List<MovieDetailView>> GetMovieById(long movieId);
        public Task<List<MovieViewDetails>> GetAll();
        public Task<List<MovieTitleView>> GetMovieByLanguage(string MovieLanguage);
        public Task<List<MovieTitleView>> GetMovieByGenre(string MovieGenre);
        public Task<List<MovieDetailView>> GetMovieByName(string MovieTitle);
        public Task<Movie> PostMovie(MovieView movie);
        public Task<long> PutMovie(EditMovieView movie);
        public Task<MovieView> DeleteMovie(long id);
        public Task<List<MovieDetailView>> GetUpcomingMovies();
        public Task<List<MovieScheduleView>> GetMovieSchedule();




    }
}
