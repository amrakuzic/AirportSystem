﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Type { get; set; }

        public int Number { get; set; }

        public DateTime ExpirationDate { get; set; }

        //
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

    }
}
