﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTindahan.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}