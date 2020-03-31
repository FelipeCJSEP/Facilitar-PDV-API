using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class UserCommandHandler : ICommand
    {
        public class NameInfo
        {
            public string FirstName;
            public string LastName;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public NameInfo Name { get; set; }
    }
}
