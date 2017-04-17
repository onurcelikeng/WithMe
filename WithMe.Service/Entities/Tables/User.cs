using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WithMe.Service.Entities.Tables
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }
    }
}