using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface IOrderRepository
    {
        List<Order> Get();
        Order Get(Guid id);
        Order Get(string number);
        List<Order> Get(DateTime initialDate, DateTime finalDate);
        void Insert(Order order);
        void Update(Guid id, Order order);
        void Delete(Guid id);
    }
}
