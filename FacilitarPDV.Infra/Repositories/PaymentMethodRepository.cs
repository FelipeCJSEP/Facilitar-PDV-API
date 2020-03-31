using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Infra.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly DataContext _context;

        public PaymentMethodRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("PaymentMethod");
        }

        public List<PaymentMethod> Get() =>  _context.Get().ConvertAll(x => (PaymentMethod)x);

        public PaymentMethod Get(Guid id) => (PaymentMethod)_context.Get(id);

        public void Insert(PaymentMethod paymentMethod) => _context.Insert(paymentMethod);

        public void Update(Guid id, PaymentMethod paymentMethod) => _context.Update(id, paymentMethod);

        public void Delete(Guid id) => _context.Delete(id);
    }
}
