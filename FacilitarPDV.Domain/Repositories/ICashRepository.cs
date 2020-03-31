using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface ICashRepository
    {
        List<Cash> Get();
        Cash Get(Guid id);
        List<Cash> Get(DateTime InitialDate, DateTime FinalDate);
        void Insert(Cash cash);
        void Update(Guid id, Cash cash);
        void Delete(Guid id);
    }
}
