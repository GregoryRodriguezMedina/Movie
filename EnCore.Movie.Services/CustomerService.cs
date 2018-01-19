using EnCore.Movie.Data;
using EnCore.Movie.Core;
using System.Collections.Generic;
namespace EnCore.Movie.Services
{
    public partial class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IPhoneRepository phoneRepository;

        public CustomerService(ICustomerRepository customerRepository, IPhoneRepository phoneRepository)
        {
            this.customerRepository = customerRepository;
            this.phoneRepository = phoneRepository;
        }

        public IEnumerable<Phone> GetPhone(int customerId)
        {
            return this.phoneRepository.GetByCustomer(customerId);
        }

        public void AddPhone(Phone phone)
        {
            this.phoneRepository.Insert(phone);           
        }

        public Core.Customer GetCustomer(int id)
        {
            return this.customerRepository.GetById(id);
        }

        public EnCore.Core.IQueryResponse<Movie.Core.Customer> GetCustomers(EnCore.Core.QueryRequest queryRequest)
        {
            return this.customerRepository.Get(queryRequest);
        }      

        public void AddCustomer(Movie.Core.Customer Customer)
        {
            this.customerRepository.Insert(Customer);
        }

        public void ModCustomer(Movie.Core.Customer Customer)
        {
            this.customerRepository.Update(Customer);
        }

        public void DelCustomer(int id)
        {
            var customer = this.customerRepository.GetById(id);

            this.customerRepository.Delete(customer);
        }
    }
}
