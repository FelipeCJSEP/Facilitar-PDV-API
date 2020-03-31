using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Commands.Results;
using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Handlers
{
    public class CashHandler : ICommandHandler<CashCommandHandler>
    {
        private readonly ICashRepository _repository;
        public List<string> Notifications = new List<string>();

        public CashHandler(ICashRepository cashRepository) => _repository = cashRepository;

        private Cash SetCash(CashCommandHandler command)
        {
            User openingUser, closingUser;

            if (command.OpeningUser != null)
            {
                openingUser = new User(command.OpeningUser.Id, command.OpeningUser.Username);
                Notifications.AddRange(openingUser.Notifications);
            }
            else
                openingUser = null;

            if (command.ClosingUser != null)
            {
                closingUser = new User(command.ClosingUser.Id, command.ClosingUser.Username);
                Notifications.AddRange(closingUser.Notifications);
            }
            else
                closingUser = null;

            Cash cash = new Cash(
                command.Number,
                command.Status,
                command.Opening,
                command.Closing,
                command.OpeningRemark,
                command.ClosingRemark,
                openingUser,
                closingUser
            );

            Notifications.AddRange(cash.Notifications);

            return cash;
        }

        public ICommandResult Handl(CashCommandHandler command)
        {
            try
            {
                Cash cash = SetCash(command);

                if (Notifications.Count == 0)
                    _repository.Insert(cash);

                return new CashCommandResult(cash.Id, cash.Number);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, CashCommandHandler command)
        {
            try
            {
                Cash cash = SetCash(command);
                cash.Id = id;

                if (Notifications.Count == 0)
                    _repository.Update(id, cash);

                return new CashCommandResult(cash.Id, cash.Number);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new CashCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CashCommandResult();
            }
        }
    }
}
