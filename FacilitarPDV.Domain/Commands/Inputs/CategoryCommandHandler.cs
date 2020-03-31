using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class CategoryCommandHandler : ICommand
    {
        public class CategoryInfo
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public string Name { get; set; }
        public CategoryInfo ParentCategory { get; set; }
    }
}
