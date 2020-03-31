using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class ProductUnitRepository : IProductUnitRepository
    {
        private readonly DataContext _context;

        public ProductUnitRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("ProductUnit");
        }

        public List<ProductUnit> Get() => _context.Get().ConvertAll(x => (ProductUnit)x);

        public ProductUnit Get(Guid id) => (ProductUnit)_context.Get(id);

        public void Insert(ProductUnit productUnit) => _context.Insert(productUnit);

        public void Update(Guid id, ProductUnit productUnit) => _context.Update(id, productUnit);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
