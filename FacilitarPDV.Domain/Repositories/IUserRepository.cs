using FacilitarPDV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> Get();
        User Get(Guid id);
        User GetByUsername(string username);
        void Insert(User user);
    }
}
