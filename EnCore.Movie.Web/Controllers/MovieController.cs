using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnCore.Movie.Services;
using EnCore.Core;
using Microsoft.AspNetCore.Cors;

namespace EnCore.Movie.Web.Controllers
{

    [Produces("application/json")]
    //[Route("api/[controller]")]
     [EnableCors("AllwAnyOrigin")]
    [Route("api/movie")]
    public class MovieController : BaseApiController
    {
        private readonly MovieService MovieService;

        public MovieController(MovieService MovieService)
        {
            this.MovieService = MovieService;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult Get(QueryRequest query)
        {
            return this.GetHttpResponse(() =>
            {
                var pagingResult = this.MovieService.GetMovies(query);

                return Ok(pagingResult);
                    /// System.Web.HttpContext.Current.Response.Headers.Add("Total-Count", total.ToString());

                    // Response.Headers.Add("Total-Count", pagingResult.ItemCount.ToString());


                    // return Ok(pagingResult.Items);
                });
        }

        //*
        // GET: api/Movies/5
        // [HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.GetHttpResponse(() =>
            {
                var result = this.MovieService.GetMovie(id);

                return Ok(result);
            });
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult Post([FromBody]Core.Movie Movie)
        {
            return this.GetHttpResponse(() =>
            {
                this.MovieService.AddMovie(Movie);

                return Ok(Movie);
            });
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Core.Movie Movie)
        {
            return this.GetHttpResponse(() =>
            {
                Movie.MovieId = id;

                MovieService.ModMovie(Movie);

                return Ok(Movie);
            });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.GetHttpResponse(() =>
            {
                this.MovieService.DelMovie(id);

                return Ok(id);
            });
        }
    }
}