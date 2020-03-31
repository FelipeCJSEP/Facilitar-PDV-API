using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product Get(Guid id);
        void Insert(Product product);
        void Update(Guid id, Product product);
        void Delete(Guid id);
    }
}
