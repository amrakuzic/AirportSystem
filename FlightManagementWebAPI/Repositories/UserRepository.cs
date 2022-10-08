using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlightManagementWebAPI.Repositories
{
    public class UserRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public UserRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<User> GetUsers()
        {
            return _airportSystemContext.Users.Include(user => user.Role).ToList();
        }

        public void InsertUser(User user)
        {
            _airportSystemContext.Users.Add(user);
            _airportSystemContext.SaveChanges();
        }

        public User GetUser(int userId)
        {
            return _airportSystemContext.Users.
                FirstOrDefault(user => user.Id.Equals(userId));
        }

        public void UpdateUser(User user)
        {
            var userForUpdate = GetUser(user.Id);
            if (userForUpdate != null)
            {
                userForUpdate.Username = user.Username;
                userForUpdate.Password = user.Password;
                userForUpdate.RoleId = user.RoleId;

                _airportSystemContext.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var user = GetUser(userId);
            if (user != null)
            {
                _airportSystemContext.Users.Remove(user);
                _airportSystemContext.SaveChanges();
            }
        }
    }
}
