﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
