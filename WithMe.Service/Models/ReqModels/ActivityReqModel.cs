using System;

namespace WithMe.Service.Models.ReqModels
{
    public sealed class ActivityReqModel
    {
        public int ReqUserId { get; set; }

        public int ResUserId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }
    }
}