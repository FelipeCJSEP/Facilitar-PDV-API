using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Commands.Results;
using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Handlers
{
    public class CategoryHandler : ICommandHandler<CategoryCommandHandler>
    {
        private readonly ICategoryRepository _repository;
        public List<string> Notifications = new List<string>();

        public CategoryHandler(ICategoryRepository repository) => _repository = repository;

        private Category SetCategory(CategoryCommandHandler command)
        {
            Category parentCategory;

            if (command.ParentCategory != null)
            {
                parentCategory = new Category(command.ParentCategory.Id, command.ParentCategory.Name);
                Notifications.AddRange(parentCategory.Notifications);
            }
            else
                parentCategory = null;

            Category category = new Category(command.Name, parentCategory);
            Notifications.AddRange(category.Notifications);

            return category;
        }

        public ICommandResult Handl(CategoryCommandHandler command)
        {
            try
            {
                Category category = SetCategory(command);

                if (Notifications.Count == 0)
                    _repository.Insert(category);

                return new CategoryCommandResult(category.Id, category.Name);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CategoryCommandResult();
            }
        }

        public ICommandResult Handl(Guid id, CategoryCommandHandler command)
        {
            try
            {
                Category category = SetCategory(command);
                category.Id = id;

                if (Notifications.Count == 0)
                    _repository.Update(id, category);

                return new CategoryCommandResult(id, category.Name);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CategoryCommandResult();
            }
        }

        public ICommandResult Handl(Guid id)
        {
            try
            {
                Notifications = new List<string>();
                _repository.Delete(id);
                return new CategoryCommandResult(id);
            }
            catch (Exception ex)
            {
                Notifications = new List<string>() { ex.Message };
                return new CategoryCommandResult();
            }
        }
    }
}
