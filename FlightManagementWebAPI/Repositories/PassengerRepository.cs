using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class PassengerRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public PassengerRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<Passenger> GetPassengers(bool chked)
        {
            return _airportSystemContext.Passengers.Include(passenger => passenger.Flight).Where(passenger => passenger.IsChecked == chked).ToList();
        }
        public void InsertPassenger(Passenger passenger)
        {
            _airportSystemContext.Passengers.Add(passenger);
            _airportSystemContext.SaveChanges();
        }

        public Passenger GetPassenger(int passengerId)
        {
            return _airportSystemContext.Passengers.
                FirstOrDefault(passenger => passenger.Id.Equals(passengerId));
        }

        public void UpdatePassenger(Passenger passenger)
        {
            var passengerForUpdate = GetPassenger(passenger.Id);
            if (passengerForUpdate != null)
            {
                passengerForUpdate.FirstName = passenger.FirstName;
                passengerForUpdate.LastName = passenger.LastName;
                passengerForUpdate.Gender = passenger.Gender;
                passengerForUpdate.Seat = passenger.Seat;
                passengerForUpdate.IsChecked = passenger.IsChecked;
                _airportSystemContext.SaveChanges();
            }
        }

        public async Task DeletePassenger(int passengerId)
        {
            var passenger = GetPassenger(passengerId);
            var docs = _airportSystemContext.Documents.ToList();
            var luggs = _airportSystemContext.Luggages.ToList();
            foreach (var doc in docs)
            {
                if (doc.PassengerId == passenger.Id)
                {
                    _airportSystemContext.Documents.Remove(doc);
                }
            }
            foreach (var lug in luggs)
            {
                if (lug.PassengerId == passenger.Id)
                {
                    _airportSystemContext.Luggages.Remove(lug);
                }
            }
            if (passenger != null)
            {

                _airportSystemContext.Passengers.Remove(passenger);
                _airportSystemContext.SaveChanges();
            }
        }
    }
}
