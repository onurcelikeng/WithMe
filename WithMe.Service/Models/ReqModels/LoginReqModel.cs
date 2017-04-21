namespace WithMe.Service.Models.ReqModels
{
    public sealed class LoginReqModel
    {
        public string Bearer { get; set; }

        public string DeviceType { get; set; }

        public string DeviceNumber { get; set; }
    }
}