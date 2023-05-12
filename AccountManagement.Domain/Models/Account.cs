﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Models
{
    // Account model
    public class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }
    }
}
