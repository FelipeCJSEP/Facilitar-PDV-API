using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> Get();
        Category Get(Guid id);
        void Insert(Category category);
        void Update(Guid id, Category category);
        void Delete(Guid id);
    }
}
