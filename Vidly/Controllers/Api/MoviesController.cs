using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        protected readonly IMapper _mapper;
        private readonly MapperConfiguration config;
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
            config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }
        //GET /api/movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
               .Include(m => m.Genre)
               .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }
            var movieDtos = moviesQuery
               .ToList()
               .Select(_mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }
        //GET /api/movies/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.ToList().Select(_mapper.Map<Movie, MovieDto>);
            if (movie == null)
            {
                NotFound();
            }
            return Ok(_context.Movies.SingleOrDefault(m => m.Id == id));
        }
        //POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                NotFound();
            }
            _mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult RemoveMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                NotFound();
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
