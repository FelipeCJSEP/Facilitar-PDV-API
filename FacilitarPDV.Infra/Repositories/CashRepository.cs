using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FacilitarPDV.Infra.Repositories
{
    public class CashRepository : ICashRepository
    {
        private readonly DataContext _context;

        public CashRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("Cash");
        }

        public List<Cash> Get() => _context.Get().ConvertAll(x => (Cash)x);

        public Cash Get(Guid id) => (Cash)_context.Get(id);

        public List<Cash> Get(DateTime initialDate, DateTime finalDate)
        {
            string filter = "{Opening: {" +
                $"$gte: ISODate(\"{initialDate.ToString("yyyy-MM-dd")}T00:00:00:000Z\")," +
                $"$lte: ISODate(\"{finalDate.ToString("yyyy-MM-dd")}T23:59:59:999Z\")" +
                "}}";

            return _context.Collection
                .Find(filter)
                .ToList()
                .ConvertAll(x => (Cash)x);
        }

        public void Insert(Cash cash) => _context.Insert(cash);

        public void Update(Guid id, Cash cash) => _context.Update(id, cash);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
