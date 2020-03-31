using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("Customer");
        }

        public List<Customer> Get() => _context.Get().ConvertAll(x => (Customer)x);

        public Customer Get(Guid id) => (Customer)_context.Get(id);

        public void Insert(Customer customer) => _context.Insert(customer);

        public void Update(Guid id, Customer customer) => _context.Update(id, customer);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
