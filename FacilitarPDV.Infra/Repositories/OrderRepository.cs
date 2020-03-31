using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("Order");
        }

        public List<Order> Get() => _context.Get().ConvertAll(x => (Order)x);

        public Order Get(Guid id) => (Order)_context.Get(id);

        public Order Get(string number)
        {
            throw new NotImplementedException();
        }

        public List<Order> Get(DateTime initialDate, DateTime finalDate)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order order) => _context.Insert(order);

        public void Update(Guid id, Order order) => _context.Update(id, order);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
