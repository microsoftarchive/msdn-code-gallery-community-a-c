using System;

namespace CRUDWithWebAPI.Models
{
    public class ServerData
    {
        public virtual int Id { get; set; }
        public virtual DateTime InitialDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int OrderNumber { get; set; }
        public virtual bool IsDirty { get; set; }
        public virtual string IP { get; set; }
        public virtual int Type { get; set; }
        public virtual int RecordIdentifier { get; set; }
    }
}