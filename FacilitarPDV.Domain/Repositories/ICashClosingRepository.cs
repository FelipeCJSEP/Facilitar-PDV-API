using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface ICashClosingRepository
    {
        List<CashClosing> Get();
        CashClosing Get(Guid id);
        void Insert(CashClosing cashClosing);
        void Update(Guid id, CashClosing cashClosing);
        void Delete(Guid id);
    }
}
