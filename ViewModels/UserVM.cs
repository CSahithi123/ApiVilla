﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
