using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> Get();
        PaymentMethod Get(Guid id);
        void Insert(PaymentMethod paymentMethod);
        void Update(Guid id, PaymentMethod paymentMethod);
        void Delete(Guid id);
    }
}
