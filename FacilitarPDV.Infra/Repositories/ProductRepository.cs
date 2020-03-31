using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("Product");
        }

        public List<Product> Get() => _context.Get().ConvertAll(x => (Product)x);

        public Product Get(Guid id) => (Product)_context.Get(id);

        public void Insert(Product product) => _context.Insert(product);

        public void Update(Guid id, Product product) => _context.Update(id, product);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
