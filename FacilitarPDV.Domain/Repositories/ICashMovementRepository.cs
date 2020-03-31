using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface ICashMovementRepository
    {
        List<CashMovement> Get();
        CashMovement Get(Guid id);
        List<CashMovement> GetByCashId(Guid cashId);
        void Insert(CashMovement cashMovement);
        void Update(Guid id, CashMovement cashMovement);
        void Delete(Guid id);
    }
}
