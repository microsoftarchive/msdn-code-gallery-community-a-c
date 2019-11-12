namespace MvcWebRole.Models
{
    public class UnsubscribeVM
    {
        public string EmailAddress { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }
        public string SubscriberGUID { get; set; }
        public bool? Confirmed { get; set; }
    }
}