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
    public class CustomerHandler : ICommandHandler<CustomerCommandHandler>
    {
        private readonly ICustomerRepository _repository;
        public List<string> Notifications;

        public CustomerHandler(ICustomerRepository repository) => _repository = repository;

        private Customer SetCustomer(CustomerCommandHandler command)
        {
            Document principalDocument = command.PrincipalDocument != null ?
                new Document(command.PrincipalDocument.Value, command.PrincipalDocument.Type) : null;

            Document secundaryDocument = command.SecundaryDocument != null ?
                new Document(command.SecundaryDocument.Value, command.SecundaryDocument.Type) : null;

            Name name = command.Name != null ?
                new Name(command.Name.FirstName, command.Name.LastName) : null;

            Address address = command.Address != null ?
                new Address(
                    command.Address.ZipCode,
                    command.Address.PublicPlace,
                    command.Address.Number,
                    command.Address.Complement,
                    command.Address.Neighborhood,
                    command.Address.State,
                    command.Address.County,
                    command.Address.Country
                ) : null;

            Customer customer = new Customer(
                principalDocument,
                secundaryDocument,
                name,
                address,
                command.Email,
                command.Remark
            );

            Notifications = customer.Notifications;

            return customer;
        }

        public ICommandResult Handl(CustomerCommandHandler command)
        {
            try
            {
                Customer customer = SetCustomer(command);

                if (Notifications.Count == 0)
                    _repository.Insert(customer);

                return new CustomerCommandResult(customer.Id, customer.Name.FullName());
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CustomerCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, CustomerCommandHandler command)
        {
            try
            {
                Customer customer = SetCustomer(command);
                customer.Id = id;

                if (Notifications.Count == 0)
                    _repository.Update(id, customer);

                return new CustomerCommandResult(id, customer.Name.FullName());
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CustomerCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new CustomerCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CustomerCommandResult();
            }
        }
    }
}
