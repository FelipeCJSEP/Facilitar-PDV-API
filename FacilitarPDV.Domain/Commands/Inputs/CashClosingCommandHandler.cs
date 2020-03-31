using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class CashClosingCommandHandler : ICommand
    {
        public class CashInformation
        {
            public class UserInformation
            {
                public Guid Id;
                public string Username;
            }

            public Guid Id;
            public int Number;
            public UserInformation ClosingUser;
        }

        public class PaymentMethodInformation
        {
            public Guid Id;
            public string Description;
            public string Cmp;
        }

        public CashInformation Cash { get; set; }
        public PaymentMethodInformation PaymentMethod { get; set; }
        public decimal Value { get; set; }
    }
}
