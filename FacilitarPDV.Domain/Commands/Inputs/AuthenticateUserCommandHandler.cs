using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class AuthenticateUserCommandHandler
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
