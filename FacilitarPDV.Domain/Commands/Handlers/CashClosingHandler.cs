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
    public class CashClosingHandler : ICommandHandler<CashClosingCommandHandler>
    {
        private readonly ICashClosingRepository _repository;
        public List<string> Notifications = new List<string>();

        public CashClosingHandler(ICashClosingRepository repository) => _repository = repository;

        private CashClosing SetCashClosing(CashClosingCommandHandler command)
        {
            User closingUser;
            Cash cash;
            PaymentMethod paymentMethod;

            if (command.Cash != null)
            {
                if (command.Cash.ClosingUser != null)
                {
                    closingUser = new User(command.Cash.ClosingUser.Id, command.Cash.ClosingUser.Username);
                    Notifications.AddRange(closingUser.Notifications);
                }
                else
                    closingUser = null;

                cash = new Cash(command.Cash.Id, command.Cash.Number, closingUser);
                Notifications.AddRange(cash.Notifications);
            }
            else
                cash = null;

            if (command.PaymentMethod != null)
            {
                paymentMethod = new PaymentMethod(
                    command.PaymentMethod.Id,
                    command.PaymentMethod.Description,
                    command.PaymentMethod.Cmp
                );

                Notifications.AddRange(paymentMethod.Notifications);
            }
            else
                paymentMethod = null;

            CashClosing cashClosing = new CashClosing(cash, paymentMethod, command.Value);
            Notifications.AddRange(cashClosing.Notifications);

            return cashClosing;
        }

        public ICommandResult Handl(CashClosingCommandHandler command)
        {
            try
            {
                CashClosing cashClosing = SetCashClosing(command);

                if (Notifications.Count == 0)
                    _repository.Insert(cashClosing);

                return new CashClosingCommandResult(cashClosing.Id, cashClosing.Cash.Id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashClosingCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, CashClosingCommandHandler command)
        {
            try
            {
                CashClosing cashClosing = SetCashClosing(command);

                if (Notifications.Count == 0)
                    _repository.Update(id, cashClosing);

                return new CashClosingCommandResult(cashClosing.Id, cashClosing.Cash.Id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashClosingCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new CashClosingCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashClosingCommandResult();
            }
        }
    }
}
