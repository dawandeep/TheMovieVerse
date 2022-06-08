using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using TheMovieVerse.DB.Interface;
using TheMovieVerse.Model;
using TheMovieVerse.Services.Interface;
using TheMovieVerse.ViewModel;
using System.Threading.Tasks;
using TheMovieVerse.DB;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
namespace TheMovieVerse.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _movieDbContext;
        private readonly IMapper _mapper;

        public MovieService(MovieDbContext movieDbContext, IMapper mapper)
        {
            this._movieDbContext = movieDbContext;

            this._mapper = mapper;
        }
        public async Task<MovieView> DeleteMovie(long id)
        {
            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (movie==null)
            {
                return null;
            }
            _movieDbContext.Movies.Remove(movie);
            await _movieDbContext.SaveChangesAsync();
            var MovieList = _mapper.Map<MovieView>(movie);
            return MovieList;
        }
        public async Task<List<MovieView>> GetAll()
        {
            var moviesModel=await _movieDbContext.Movies
                .Include(x=>x.Actors)
                .ToListAsync();
            var MovieList = _mapper.Map<List<MovieView>>(moviesModel);
            return MovieList;
        }
        public async Task<List<MovieTitleView>> GetMovieByLanguage(string MovieLanguage)
        {
            var movie = await _movieDbContext.Movies
                 .Where(x => x.MovieLanguage == MovieLanguage)
                 .Select(x => new MovieTitleView { MovieTitle = x.MovieTitle})
                .ToListAsync();
            
            var MovieList = _mapper.Map<List<MovieTitleView>>(movie);
            return MovieList;
        }
        public async Task<List<MovieTitleView>> GetMovieByGenre(string MovieGenre)
        {
            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Where(x => x.MovieGenre == MovieGenre)
                .ToListAsync();
            var MovieList = _mapper.Map<List<MovieTitleView>>(movie);
            return MovieList;
        }
        public async Task<List<MovieDetailView>> GetMovieByName(string MovieTitle){
           var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Where(x => x.MovieTitle == MovieTitle)
                .ToListAsync();
            var MovieList = _mapper.Map<List<MovieDetailView>>(movie);
            return MovieList;

        }
        public async Task<List<MovieDetailView>>GetMovieById(long movieId)
        {
              var movie = await _movieDbContext.Movies
                    .Include(x => x.Actors)
                    .Where(x => x.Id == movieId)
                    .ToListAsync();
                var MovieList = _mapper.Map<List<MovieDetailView>>(movie);
                return MovieList;
        }
        
        public async Task<Movie> PostMovie(MovieView movie)
        {
            var doesMovieExist = await _movieDbContext.Movies
                             .Where(x => x.MovieTitle == movie.MovieTitle)
                             .ToListAsync();
           if(doesMovieExist.Count==0)
            {
                var movieModel = _mapper.Map<Movie>(movie);
                _movieDbContext.Movies.Add(movieModel);
                await _movieDbContext.SaveChangesAsync();
                return movieModel;
            }
            else
            {
                return null;
            }
        }
        
        public async Task<long> PutMovie(EditMovieView movie)
        {
            var movieModel = _mapper.Map<Movie>(movie);
            _movieDbContext.Movies.Update(movieModel);
            return await _movieDbContext.SaveChangesAsync();
        }
        public async Task<long>Putt(long id,Movie movie)
        {
            var existingStudent = _movieDbContext.Movies.Where(x=>x.Id == id)
                                                    .FirstOrDefault<Movie>();

            if (existingStudent != null)
            {
                existingStudent.MovieTitle = movie.MovieTitle;
                existingStudent.MovieDirector = movie.MovieDirector;

              return  await _movieDbContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        } 
        public async Task<List<MovieDetailView>> GetUpcomingMovies()
        {
            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Where(x => x.IsUpcoming == true)
                .ToListAsync();
            var MovieList = _mapper.Map<List<MovieDetailView>>(movie);
            return MovieList;
        }
    }
}
