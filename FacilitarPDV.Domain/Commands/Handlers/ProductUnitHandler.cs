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
    public class ProductUnitHandler : ICommandHandler<ProductUnitCommandHandler>
    {
        private readonly IProductUnitRepository _repository;
        public List<string> Notifications;

        private ProductUnit SetProductUnit(ProductUnitCommandHandler command)
        {
            ProductUnit productUnit = new ProductUnit(
                command.Initials,
                command.Description,
                command.Fracionable
            );

            Notifications = productUnit.Notifications;
            return productUnit;
        }

        public ICommandResult Handl(ProductUnitCommandHandler command)
        {
            try
            {
                ProductUnit productUnit = SetProductUnit(command);

                if (Notifications.Count == 0)
                    _repository.Insert(productUnit);

                return new ProductUnitCommandResult(productUnit.Id, productUnit.Initials);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new ProductUnitCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, ProductUnitCommandHandler command)
        {
            try
            {
                ProductUnit productUnit = SetProductUnit(command);
                productUnit.Id = id;

                if (Notifications.Count == 0)
                    _repository.Update(id, productUnit);

                return new ProductUnitCommandResult(id, productUnit.Initials);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new ProductUnitCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new ProductUnitCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new ProductUnitCommandResult();
            }
        }
    }
}
