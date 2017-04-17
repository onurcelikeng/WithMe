using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WithMe.Service.Entities.Tables
{
    public class Device
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string DeviceName { get; set; }

        public string DeviceNumber { get; set; }
    }
}