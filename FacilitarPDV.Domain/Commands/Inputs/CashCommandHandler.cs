using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class CashCommandHandler : ICommand
    {
        public class User
        {
            public Guid Id { get; set; }
            public string Username { get; set; }
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public ECashStatus Status { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
        public string OpeningRemark { get; set; }
        public string ClosingRemark { get; set; }
        public User OpeningUser { get; set; }
        public User ClosingUser { get; set; }
    }
}
