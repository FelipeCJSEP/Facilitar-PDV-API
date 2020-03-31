using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("Category");
        }

        public List<Category> Get() => _context.Get().ConvertAll(x => (Category)x);

        public Category Get(Guid id) => (Category)_context.Get(id);

        public void Insert(Category category) => _context.Insert(category);

        public void Update(Guid id, Category category) => _context.Update(id, category);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
