using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WithMe.Service.Entities.Tables
{
    public class Activity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int ReqUser { get; set; }

        public int ResUser { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
    }
}