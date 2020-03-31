using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class CashClosingRepository : ICashClosingRepository
    {
        private readonly DataContext _context;

        public CashClosingRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("CashClosing");
        }

        public List<CashClosing> Get() => _context.Get().ConvertAll(x => (CashClosing)x);

        public CashClosing Get(Guid id) => (CashClosing)_context.Get(id);

        public void Insert(CashClosing cashClosing) => _context.Insert(cashClosing);

        public void Update(Guid id, CashClosing cashClosing) => _context.Update(id, cashClosing);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
