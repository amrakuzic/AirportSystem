using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlightManagementWebAPI.Repositories
{
    public class LuggageRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public LuggageRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<Luggage> GetLuggages()
        {
            return _airportSystemContext.Luggages.Include(luggage => luggage.Passenger).ToList();
        }
        public void InsertLuggage(Luggage luggage)
        {
            _airportSystemContext.Luggages.Add(luggage);
            _airportSystemContext.SaveChanges();
        }

        public Luggage GetLuggage(int luggageId)
        {
            return _airportSystemContext.Luggages.
                FirstOrDefault(luggage => luggage.Id.Equals(luggageId));
        }

        public void UpdateLuggage(Luggage luggage)
        {
            var luggageForUpdate = GetLuggage(luggage.Id);
            if (luggageForUpdate != null)
            {
                luggageForUpdate.Count = luggage.Count;
                luggageForUpdate.Weight = luggage.Weight;
                luggageForUpdate.PassengerId = luggage.PassengerId;
                _airportSystemContext.SaveChanges();
            }
        }

        public void DeleteLuggage(int luggageId)
        {
            var luggage = GetLuggage(luggageId);
            if (luggage != null)
            {
                _airportSystemContext.Luggages.Remove(luggage);
                _airportSystemContext.SaveChanges();
            }
        }
    }
}
