using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMovieVerse.DB;
using TheMovieVerse.Model;
using TheMovieVerse.Services.Interface;
using TheMovieVerse.ViewModel;

namespace TheMovieVerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MoviesController(MovieDbContext context, IMapper mapper, IMovieService movieService)
        {
            _context = context;
            this._mapper = mapper;
            this._movieService = movieService;
        }


        
        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<List<MovieView>>> GetMovies()
        {
            try
            {
                return await _movieService.GetAll();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }
         }

        
        [HttpGet("GetMovieByLanguage/{MovieLanguage}")]
        public async Task<ActionResult<List<MovieTitleView>>> GetMovieByLanguage(string MovieLanguage)
        {
            try
            {
                var MovieData = await _movieService.GetMovieByLanguage(MovieLanguage);
                if (MovieData.Count == 0)
                {
                    return StatusCode(StatusCodes.Status201Created, $"Movie with {MovieLanguage} Language does not exist");
                }
                return MovieData;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }
        }

        [HttpGet("GetMovieByGenre/{MovieGenre}")]
        public async Task<ActionResult<List<MovieTitleView>>> GetMovieByGenre(string MovieGenre)
        {
            try
            {
                var MovieData = await _movieService.GetMovieByGenre(MovieGenre);
                if (MovieData.Count == 0)
                {
                    return StatusCode(StatusCodes.Status201Created, $"Movie with {MovieGenre} Genre does not exist");
                }
                return MovieData;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }
            
        }

        [HttpGet("GetMovieByName/{MovieTitle}")]
        public async Task<ActionResult<List<MovieDetailView>>> GetMovieByName(string MovieTitle)
        {
            try
            {
                var MovieData = await _movieService.GetMovieByName(MovieTitle);
                if (MovieData.Count == 0)
                {
                    return StatusCode(StatusCodes.Status201Created, $"Movie with {MovieTitle} Name does not exist");
                }
                return MovieData;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }
            
        }

        [HttpGet("GetMovieById{movieId}")]
        public async Task<ActionResult<List<MovieDetailView>>> GetMovieById(long movieId)
        {
            try
            {
                var MovieData = await _movieService.GetMovieById(movieId);
                if (MovieData.Count == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"A Movie with movieid {movieId} is not found");
                }
                else
                {
                    return MovieData;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }
        }
        [HttpPut("UpdateMovieUsingId{id}")]
        public async Task<long> PutMovie(EditMovieView movie)
        {
            long mid = await _movieService.PutMovie(movie);
            return mid;
        }
        [HttpPost("AddMovies")]
        public async Task<ActionResult<List<Movie>>> PostMovie(MovieView movie)
        {
            try
            {
                var MovieData= await _movieService.PostMovie(movie);
                if (MovieData == null)
                {
                    return StatusCode(StatusCodes.Status201Created, $"Movie {movie.MovieTitle} already exist");
                }
                else
                {
                    return StatusCode(StatusCodes.Status201Created, $"Movie {movie.MovieTitle} added successfully");
                }
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }

        }

        [HttpDelete("DeleteAMovie{id}")]
        public async Task<ActionResult<MovieView>> DeleteMovie(long id)
        {
            try
            {
                MovieView tempId = await _movieService.DeleteMovie(id);

                if (tempId == null)
                {
                    return StatusCode(StatusCodes.Status201Created, $"Movie with ID={id} does not exist");
                }
                else
                {
                    return StatusCode(StatusCodes.Status201Created, $"The Movie {tempId.MovieTitle} with ID={id} deleted successfully");
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }
}




        [HttpGet("GetUpcomingMovies")]
        public async Task<ActionResult<List<MovieDetailView>>> GetUpcomingMovies()
        {
            try
            {
                var MovieList=await _movieService.GetUpcomingMovies();
                if(MovieList.Count==0)
                {
                    return StatusCode(StatusCodes.Status201Created, $"There is no upcoming movie");
                }
                else
                {
                    return MovieList;
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while connecting to the database");
            }
            
        }
       
    }
}
