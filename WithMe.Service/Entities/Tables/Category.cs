using System.Collections.Generic;

namespace WithMe.Service.Entities.Tables
{
    public class Category
    {
        public Category()
        {
            Activitys = new List<Activity>();
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }


        // Reverse navigation
        public virtual ICollection<Activity> Activitys { get; set; }
    }
}