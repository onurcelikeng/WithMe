using System;

namespace WithMe.Service.Entities.Tables
{
    public class Activity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int ReqUserId { get; set; }

        public int ResUserId { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }


        // Foreign keys
        public virtual Category Category { get; set; }

        public virtual User ReqUser { get; set; }

        public virtual User ResUser { get; set; }
    }
}