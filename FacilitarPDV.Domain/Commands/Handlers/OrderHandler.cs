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
    public class OrderHandler : ICommandHandler<OrderCommandHandler>
    {
        private readonly IOrderRepository _repository;
        public List<string> Notifications;

        private Order SetOrder(OrderCommandHandler command)
        {
            List<OrderItem> items = new List<OrderItem>();

            if (command.Items != null && command.Items.Count > 0)
            {
                foreach (var item in command.Items)
                {
                    ProductUnit sellingUnit = new ProductUnit(
                        item.Product.SellingUnit.Id,
                        item.Product.SellingUnit.Initials,
                        item.Product.SellingUnit.Fracionable
                    );

                    TaxInformation taxInformation = new TaxInformation(
                        new TaxInformationOrigin(item.Product.TaxInformation.OriginCode),
                        new TaxInformationCstIcms(item.Product.TaxInformation.CstIcmsCode),
                        new TaxInformationCsosn(item.Product.TaxInformation.CsosnCode),
                        new TaxInformationCstPisCofins(item.Product.TaxInformation.CstPisCode),
                        new TaxInformationCstPisCofins(item.Product.TaxInformation.CstCofinsCode),
                        new TaxInformationNcm(item.Product.TaxInformation.NcmCode),
                        new TaxInformationCest(item.Product.TaxInformation.CestCode),
                        new TaxInformationCfop(item.Product.TaxInformation.CfopCode),
                        item.Product.TaxInformation.MunicipalTaxRate,
                        item.Product.TaxInformation.StateTaxRate,
                        item.Product.TaxInformation.NationalTaxRate,
                        item.Product.TaxInformation.InternationalTaxRate
                    );

                    Product product = new Product(
                        item.Product.Id,
                        item.Product.Name,
                        item.Product.SalePrice,
                        sellingUnit,
                        taxInformation
                    );

                    Notifications = sellingUnit.Notifications;
                    Notifications.AddRange(taxInformation.Notifications);
                    Notifications.AddRange(product.Notifications);

                    items.Add(new OrderItem(product, item.Quantity, item.Discount));
                }
            }
            else
            {
                Notifications = new List<string>() { "A venda deve possuir pelo menos 1 item" };
                return null;
            }

            Order order = new Order(command.Number, items, command.Remark, command.Release);
            Notifications.AddRange(order.Notifications);

            return order;
        }

        public ICommandResult Handl(OrderCommandHandler command)
        {
            try
            {
                Order order = SetOrder(command);

                if (Notifications.Count == 0)
                    _repository.Insert(order);

                return new OrderCommandResult(order.Id, order.Number);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new OrderCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, OrderCommandHandler command)
        {
            try
            {
                Order order = SetOrder(command);
                order.Id = id;

                if (Notifications.Count > 0)
                    _repository.Update(id, order);

                return new OrderCommandResult(id, order.Number);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new OrderCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new OrderCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new OrderCommandResult();
            }
        }
    }
}
