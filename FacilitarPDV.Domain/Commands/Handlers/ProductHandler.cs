using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Commands.Results;
using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Entities.TaxInformations;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Domain.ValueObjects;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Handlers
{
    public class ProductHandler : ICommandHandler<ProductCommandHandler>
    {
        private readonly IProductRepository _repository;
        public List<string> Notifications = new List<string>();

        public ProductHandler(IProductRepository repository) => _repository = repository;

        private Product SetProduct(ProductCommandHandler command)
        {
            ProductUnit buyingUnit = new ProductUnit(
                command.BuyingUnit.Id,
                command.BuyingUnit.Initials,
                command.BuyingUnit.Fracionable
            );

            ProductUnit sellingUnit = new ProductUnit(
                command.SellingUnit.Id,
                command.SellingUnit.Initials,
                command.SellingUnit.Fracionable
            );

            TaxInformation taxInformation = new TaxInformation(
                command.TaxInformation.LastPriceUpdate,
                command.TaxInformation.LastInput,
                command.TaxInformation.LastOutput,
                new TaxInformationOrigin(command.TaxInformation.OriginCode),
                new TaxInformationCstIcms(command.TaxInformation.CstIcmsCode),
                new TaxInformationCsosn(command.TaxInformation.CsosnCode),
                new TaxInformationCstPisCofins(command.TaxInformation.CstPisCode),
                new TaxInformationCstPisCofins(command.TaxInformation.CstCofinsCode),
                new TaxInformationNcm(command.TaxInformation.NcmCode),
                new TaxInformationCfop(command.TaxInformation.CfopCode),
                command.TaxInformation.MunicipalTaxRate,
                command.TaxInformation.StateTaxRate,
                command.TaxInformation.NationalTaxRate,
                command.TaxInformation.InternationalTaxRate,
                command.TaxInformation.Type
            );

            List<Category> categories = new List<Category>();

            foreach (var category in command.Categories)
            {
                Category c = new Category(category.Id, category.Name);
                categories.Add(c);
                Notifications.AddRange(c.Notifications);
            }

            Product product = new Product(
                command.ReferenceCode,
                command.Name,
                command.BarCode,
                command.Quantity,
                command.MinQuantity,
                command.CostPrice,
                command.SalePrice,
                buyingUnit,
                sellingUnit,
                taxInformation,
                command.Description,
                categories
            );

            Notifications.AddRange(buyingUnit.Notifications);
            Notifications.AddRange(sellingUnit.Notifications);
            Notifications.AddRange(taxInformation.Notifications);
            Notifications.AddRange(product.Notifications);

            return product;
        }

        public ICommandResult Handl(ProductCommandHandler command)
        {
            try
            {
                Product product = SetProduct(command);

                if (Notifications.Count == 0)
                    _repository.Insert(product);

                return new ProductCommandResult(product.Id, product.ReferenceCode, product.Name);
            }
            catch (Exception ex)
            {
                Notifications.Add(ex.Message);
                return new ProductCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, ProductCommandHandler command)
        {
            try
            {
                Product product = SetProduct(command);
                product.Id = id;

                if (Notifications.Count == 0)
                    _repository.Update(id, product);

                return new ProductCommandResult(id, product.ReferenceCode, product.Name);
            }
            catch (Exception ex)
            {
                Notifications.Add(ex.Message);
                return new ProductCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                _repository.Delete(id);
                return new ProductCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications.Add(ex.Message);
                return new ProductCommandResult();
            }
        }
    }
}
