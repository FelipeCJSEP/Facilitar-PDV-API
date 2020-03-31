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
    public class CashMovementHandler : ICommandHandler<CashMovementCommandHandler>
    {
        private readonly ICashMovementRepository _repository;
        public List<string> Notifications = new List<string>();

        public CashMovementHandler(ICashMovementRepository repository) => _repository = repository;

        private CashMovement SetCashMovement(CashMovementCommandHandler command)
        {
            User closingUser, user;
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

            if (command.User != null)
            {
                user = new User(command.User.Id, command.User.Username);
                Notifications.AddRange(user.Notifications);
            }
            else
                user = null;

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

            CashMovement cashMovement = new CashMovement(
                command.Value,
                command.Hour,
                command.Type,
                command.Remark,
                cash,
                user,
                paymentMethod
            );

            Notifications.AddRange(cashMovement.Notifications);

            return cashMovement;
        }

        public ICommandResult Handl(CashMovementCommandHandler command)
        {
            try
            {
                CashMovement cashMovement = SetCashMovement(command);

                if (Notifications.Count == 0)
                    _repository.Insert(cashMovement);

                return new CashMovementCommandResult(cashMovement.Id, cashMovement.Cash.Id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashMovementCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, CashMovementCommandHandler command)
        {
            try
            {
                CashMovement cashMovement = SetCashMovement(command);
                cashMovement.Id = id;

                if (Notifications.Count == 0)
                    _repository.Update(id, cashMovement);

                return new CashMovementCommandResult(cashMovement.Id, cashMovement.Cash.Id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashMovementCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new CashMovementCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashMovementCommandResult();
            }
        }
    }
}
