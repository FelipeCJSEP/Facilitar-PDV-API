using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class UserCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public UserCommandResult() { }

        public UserCommandResult(Guid id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
