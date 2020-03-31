using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FacilitarPDV.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
            _context.SetCollection("User");
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            List<object> user = _context.Collection
                .Find("{Username:\"" + username + "\"}")
                .Limit(1)
                .ToList();

            return user.Count == 1 ? (User)user[0] : null;
        }

        public void Insert(User user) => _context.Insert(user);
    }
}
