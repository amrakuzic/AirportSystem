using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System.Collections.Generic;
using System.Linq;

namespace FlightManagementWebAPI.Repositories
{
    public class RoleRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public RoleRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<Role> GetRoles()
        {
            return _airportSystemContext.Roles.ToList();
        }

        public void InsertRole(Role role)
        {
            _airportSystemContext.Roles.Add(role);
            _airportSystemContext.SaveChanges();
        }

        public Role GetRole(int roleId)
        {
            return _airportSystemContext.Roles.
                FirstOrDefault(role => role.Id.Equals(roleId));
        }

        public void UpdateRole(Role role)
        {
            var roleForUpdate = GetRole(role.Id);
            if (roleForUpdate != null)
            {
                roleForUpdate.Type = role.Type;

                _airportSystemContext.SaveChanges();
            }
        }

        public void DeleteRole(int roleId)
        {
            var role = GetRole(roleId);
            if (role != null)
            {
                _airportSystemContext.Roles.Remove(role);
                _airportSystemContext.SaveChanges();
            }
        }
    }
}
