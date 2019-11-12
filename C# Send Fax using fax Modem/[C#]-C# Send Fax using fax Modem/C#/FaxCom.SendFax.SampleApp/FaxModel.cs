namespace FaxCom.SendFax.SampleApp
{
    public class FaxModel
    {
        public string SenderName { get; set; }
        public string SenderCompany { get; set; }
        public string FaxBodyPath { get; set; }
        public string FaxSubject { get; set; }
        public string FaxDocumentName { get; set; }
        public string RecipientFaxNumber { get; set; }
        public string RecipientName { get; set; }
    }
}
