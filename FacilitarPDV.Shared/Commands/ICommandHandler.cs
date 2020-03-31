using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handl(T command); // INSERT
        ICommandResult Handl(Guid id, T command); // UPDATE
        ICommandResult Handl(Guid id); // DELETE
    }
}
