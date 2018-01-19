using Microsoft.AspNetCore.Mvc;
using EnCore.Core;
using Microsoft.AspNetCore.Cors;
using EnCore.Movie.Services;

namespace EnCore.Movie.Web.Controllers
{

    [Produces("application/json")]
    //[Route("api/[controller]")]
     [EnableCors("AllwAnyOrigin")]
    [Route("api/rental")]
    public class RentalController : BaseApiController
    {
        private readonly RentalService RentalService;

        public RentalController(RentalService RentalService)
        {
            this.RentalService = RentalService;
        }

        // GET: api/Rentals
        [HttpGet]
        public IActionResult Get(QueryRequest query)
        {
            return this.GetHttpResponse(() =>
            {
                var pagingResult = this.RentalService.GetRentals(query);

                return Ok(pagingResult);
                    /// System.Web.HttpContext.Current.Response.Headers.Add("Total-Count", total.ToString());

                    // Response.Headers.Add("Total-Count", pagingResult.ItemCount.ToString());


                    // return Ok(pagingResult.Items);
                });
        }

        //*
        // GET: api/Rentals/5
        // [HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.GetHttpResponse(() =>
            {
                var result = this.RentalService.GetRental(id);

                return Ok(result);
            });
        }

        // POST: api/Rentals
        [HttpPost]
        public IActionResult Post([FromBody]Core.RentalRequest Rental)
        {
            return this.GetHttpResponse(() =>
            {
                this.RentalService.Rental(Rental);

                return Ok(Rental);
            });
        }

        [HttpPost("returned/{id}")]
        public IActionResult Returned(int id)
        {
            return this.GetHttpResponse(() =>
            {
                this.RentalService.Returned(id);

                return Ok(id);
            });
        }
    }
}