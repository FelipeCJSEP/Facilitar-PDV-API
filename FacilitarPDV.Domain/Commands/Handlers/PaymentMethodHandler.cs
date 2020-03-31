using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Commands.Results;
using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Handlers
{
    public class PaymentMethodHandler : ICommandHandler<PaymentMethodCommandHandler>
    {
        private readonly IPaymentMethodRepository _repository;
        public List<string> Notifications;

        public PaymentMethodHandler(IPaymentMethodRepository repository) => _repository = repository;

        public ICommandResult Handl(PaymentMethodCommandHandler command)
        {
            try
            {
                PaymentMethod paymentMethod = new PaymentMethod(command.Description, command.Cmp);
                Notifications = paymentMethod.Notifications;

                if (Notifications.Count == 0)
                    _repository.Insert(paymentMethod);

                return new PaymentMethodCommandResult(paymentMethod.Id, paymentMethod.Description);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new PaymentMethodCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, PaymentMethodCommandHandler command)
        {
            try
            {
                PaymentMethod paymentMethod = new PaymentMethod(command.Description, command.Cmp, command.Active);
                Notifications = paymentMethod.Notifications;

                if (Notifications.Count > 0)
                    _repository.Update(id, paymentMethod);

                return new PaymentMethodCommandResult(paymentMethod.Id, paymentMethod.Description);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new PaymentMethodCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new PaymentMethodCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new PaymentMethodCommandResult();
            }
        }
    }
}
