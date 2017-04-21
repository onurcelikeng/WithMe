using System;

namespace WithMe.Service.Models
{
    public sealed class ActivityModel
    {
        public int ActivityId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}