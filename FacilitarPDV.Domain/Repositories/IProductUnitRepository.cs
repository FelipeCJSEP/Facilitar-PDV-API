using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface IProductUnitRepository
    {
        List<ProductUnit> Get();
        ProductUnit Get(Guid id);
        void Insert(ProductUnit productUnit);
        void Update(Guid id, ProductUnit productUnit);
        void Delete(Guid id);
    }
}
