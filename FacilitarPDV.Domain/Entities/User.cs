using FacilitarPDV.Domain.ValueObjects;
using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using MongoDB.Bson.Serialization.Attributes;

namespace FacilitarPDV.Domain.Entities
{
    public class User : Entity
    {
        [BsonIgnoreIfNull]
        public string Username { get; private set; }
        [BsonIgnoreIfNull]
        public string Password { get; private set; }
        [BsonIgnoreIfNull]
        public Name Name { get; private set; }
        [BsonIgnoreIfNull]
        public bool? Active { get; private set; }

        public User(string username, string password, Name name)
        {
            Username = username;
            Password = EncryptPassword(password);
            Name = name;
            Active = true;
        }

        public User(Guid id, string username)
        {
            Id = id;
            Username = username;
        }

        private string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            else
            {
                password += "|2e853662-f751-40f5-aa8b-b8d3aec207e9";
                byte[] data = MD5.Create().ComputeHash(Encoding.Default.GetBytes(password));
                StringBuilder stringBuilder = new StringBuilder();

                foreach (byte t in data)
                    stringBuilder.Append(t.ToString("x2"));

                return stringBuilder.ToString();
            }
        }

        public bool Authenticate(string username, string password)
        {
            return Username == username && Password == EncryptPassword(password);
        }
    }
}
