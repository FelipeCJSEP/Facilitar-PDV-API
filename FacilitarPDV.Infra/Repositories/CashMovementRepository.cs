using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class CashMovementRepository : ICashMovementRepository
    {
        private readonly DataContext _context;

        public CashMovementRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("CashMovement");
        }

        public List<CashMovement> Get() => _context.Get().ConvertAll(x => (CashMovement)x);

        public CashMovement Get(Guid id) => (CashMovement)_context.Get(id);

        public List<CashMovement> GetByCashId(Guid cashId)
        {
            throw new NotImplementedException();
        }

        public void Insert(CashMovement cashMovement) => _context.Insert(cashMovement);

        public void Update(Guid id, CashMovement cashMovement) => _context.Update(id, cashMovement);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
