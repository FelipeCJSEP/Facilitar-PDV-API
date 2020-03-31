using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> Get();
        Customer Get(Guid id);
        void Insert(Customer customer);
        void Update(Guid id, Customer customer);
        void Delete(Guid id);
    }
}
