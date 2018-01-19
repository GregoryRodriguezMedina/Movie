using EnCore.Core;
using EnCore.Movie.Core;
using EnCore.Movie.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnCore.Movie.Services
{
    public partial class RentalService
    {
        private readonly IRentalRepository rentalRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IMovieRepository movieRepository;
        private readonly decimal LateReturnedTax;

        public RentalService(IRentalRepository rentalRepository, ICustomerRepository customerRepository, IMovieRepository movieRepository)
        {
            this.rentalRepository = rentalRepository;
            this.customerRepository = customerRepository;
            this.movieRepository = movieRepository;
            this.LateReturnedTax = 5; //TODO: buscar en archivo de configuracion.
        }

        public RentalResponse GetRental(int rentaId)
        {
            var rental = this.rentalRepository.GetById(rentaId);

            return ToResponse(rental);
        }

        public IQueryResponse<RentalResponse> GetRentals(QueryRequest queryRequest)
        {
            var query = this.rentalRepository.Get(queryRequest);

            var result = new List<RentalResponse>();
            foreach (var item in query.Items)
            {
                result.Add(ToResponse(item));
            }
            return new QueryResponse<RentalResponse>
            {
                ItemCount = query.ItemCount,
                Items = result
            };
        }

        private RentalResponse ToResponse(Rental rental) {
            var cust = rental.Customer;
            var customer = new CustomerResponse
            {
                Address = cust.Address,
                Customer = cust.FirstName + " " + cust.LastName,
                MobilPhone = cust.MobilPhone
            };
            var movies = new List<KeyNamePair>();
            foreach (var row in rental.RentalDetails)
            {
                var movie = this.movieRepository.GetById(row.MovieId);

                movies.Add(new KeyNamePair
                {
                    Key = row.MovieId,
                    Name = movie.Title
                });
            }
            //TODO: esto deberia ser un job de base de datos, pero por cuestion de tiempo lo defeniremos asi lol
            if (DateTime.Now > rental.DateTo && !rental.Penalty.HasValue)
            {
                //aumentara en 5% la renta al momento de  consulta la renta, para recibir las peliculas.                
                rental.Penalty = rental.Total * this.LateReturnedTax / 100;

                this.rentalRepository.Update(rental);

                this.rentalRepository.SaveChanges();
            }

            string status = string.Empty;
            switch ((StatusRental)rental.Status)
            {
                case StatusRental.Devuelta:
                    status = "Devuelta";
                    break;
                case StatusRental.Rentada:
                    status = "Rentada";
                    break;
                case StatusRental.Investigacion:
                    status = "Investigación";
                    break;
            }
            return new RentalResponse
            {
                DateFrom = rental.DateFrom,
                DateTo = rental.DateTo,
                Movies = movies,
                Customer = customer,
                Penalty = rental.Penalty,
                Total = rental.Total,
                Status = status,
                Id = rental.RentalId,
                StatusId = rental.Status
            };
        }

        public bool Rental(RentalRequest rental)
        {
            if (!this.customerRepository.Exists(rental.CustomerId))
                throw new BusinessException("El cliente no fue identificado.");
            var dateTo = DateTime.Parse(rental.DateTo).AddDays(1);
            var now = DateTime.Now;
            if (dateTo.Date < now.Date)
                throw new BusinessException("La fecha hasta desde ser mayor o igual a la fecha actual.");

            var movies = rental.Movies;
            if (movies == null || movies.Count() < 1)
                throw new BusinessException("Debe agregar por lo menos una pelicula a al carrito.");


            var send = new Rental();

            send.CustomerId = rental.CustomerId;
            send.DateFrom = now; // rental.DateFrom;
            send.DateTo = dateTo;

            decimal total = 0;
            int dayReturned = (int)(dateTo.Date - now.Date).TotalDays;

            foreach (var movieId in movies)
            {
                var movie = this.movieRepository.GetById(movieId);
                int available = movie.QuantityAvailable;

                if (available < 0)
                    throw new BusinessException("La pelicula no tiene inventario en almacen.");

                if (available - movie.QuantityRented <= 0)
                    throw new BusinessException("La pelicula no tiene disponibilidad.");

                decimal price = movie.RentalPrice;
                if (price <= 0)
                    throw new BusinessException("El precio de alquiler no se ha establecido.");

                total += (price * dayReturned);

                //Disminuir el inventario
                movie.QuantityRented += 1;
                               
                this.movieRepository.Update(movie);

                send.RentalDetails.Add(new RentalDetail {
                    MovieId = movie.MovieId
                });
            }

            send.Status = (int)StatusRental.Rentada;
            send.CreatedOn = now;
            send.Total = total;

            this.rentalRepository.Insert(send);

            return this.rentalRepository.SaveChanges() > 0;
        }

        public bool Returned(int id)
        {

            var rental = this.rentalRepository.GetById(id);

            if (rental == null)
                throw new BusinessException("La renta suministrada no fue encontrada.");
           
            foreach (var details in rental.RentalDetails)
            {
                var movie = this.movieRepository.GetById(details.MovieId);
               
                //Aumentar el inventario
                movie.QuantityRented -= 1;

                this.movieRepository.Update(movie);               
            }

            rental.Status = (int)StatusRental.Devuelta;
            rental.Returned = DateTime.Now;

            this.rentalRepository.Update(rental);

            return this.rentalRepository.SaveChanges() > 0;
        }

    }
}
