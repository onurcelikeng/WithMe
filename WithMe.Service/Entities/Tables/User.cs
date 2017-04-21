using System.Collections.Generic;

namespace WithMe.Service.Entities.Tables
{
    public class User
    {
        public User()
        {
            ReqActivities = new List<Activity>();
            ResActivities = new List<Activity>();
        }


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public string DeviceName { get; set; }

        public string DeviceNumber { get; set; }


        // Reverse navigation
        public virtual ICollection<Activity> ReqActivities { get; set; }

        public virtual ICollection<Activity> ResActivities { get; set; }
    }
}