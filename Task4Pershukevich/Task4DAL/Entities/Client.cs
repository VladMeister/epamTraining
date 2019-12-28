﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Client(int id, string firstName, string lastName)
        {
            Id = id;
            Firstname = firstName;
            Lastname = lastName;
        }
    }
}
