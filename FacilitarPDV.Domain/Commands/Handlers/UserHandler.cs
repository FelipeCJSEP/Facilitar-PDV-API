using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Commands.Results;
using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Domain.ValueObjects;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Handlers
{
    public class UserHandler : ICommandHandler<UserCommandHandler>
    {
        private readonly IUserRepository _repository;
        public List<string> Notifications { get; private set; }

        public UserHandler(IUserRepository repository) => _repository = repository;

        private User SetUser(UserCommandHandler command)
        {
            User user = new User(
                command.Username,
                command.Password,
                new Name(command.Name.FirstName, command.Name.LastName)
            );

            Notifications = user.Notifications;

            return user;
        }

        public ICommandResult Handl(UserCommandHandler command)
        {
            try
            {
                User user = SetUser(command);

                if (Notifications.Count == 0)
                    _repository.Insert(user);

                return new UserCommandResult(user.Id, user.Username);
            }
            catch (Exception)
            {
                return new UserCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, UserCommandHandler command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handl(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
