using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WithMe.Service.Entities.Tables
{
    public class Logging
    {
        public int Id { get; set; }

        public string Table { get; set; }

        public string Operation { get; set; }

        public DateTime CreateDate { get; set; }
    }
}