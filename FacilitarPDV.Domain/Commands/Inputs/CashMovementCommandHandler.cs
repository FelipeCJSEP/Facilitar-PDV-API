using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class CashMovementCommandHandler : ICommand
    {
        public class UserInfo
        {
            public Guid Id { get; set; }
            public string Username { get; set; }
        }

        public class CashInfo
        {
            public Guid Id { get; set; }
            public int Number { get; set; }
            public UserInfo ClosingUser { get; set; }
        }

        public class PaymentMethodInfo
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
            public string Cmp { get; set; }
        }

        public decimal Value { get; set; }
        public DateTime Hour { get; set; }
        public ECashMovementType Type { get; set; }
        public string Remark { get; set; }
        public CashInfo Cash { get; set; }
        public UserInfo User { get; set; }
        public PaymentMethodInfo PaymentMethod { get; set; }
    }
}
