using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FlightManagementWebAPI.DatabaseContext
{
    public class AirportSystemContext : DbContext
    {
        public AirportSystemContext(DbContextOptions<AirportSystemContext> options)
            : base(options)
        {

        }

        //tablica
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Carrier> Carriers { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Luggage> Luggages { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }

}
