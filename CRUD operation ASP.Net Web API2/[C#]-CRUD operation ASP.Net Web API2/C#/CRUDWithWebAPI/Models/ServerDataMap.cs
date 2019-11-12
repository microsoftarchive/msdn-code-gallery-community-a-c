using FluentNHibernate.Mapping;

namespace CRUDWithWebAPI.Models
{
    public class ServerDataMap : ClassMap<ServerData>
    {
        public ServerDataMap()
        {
            Table("ServerData");

            Id(x => x.Id, "Id").GeneratedBy.Identity().UnsavedValue(0);

            Map(x => x.InitialDate);
            Map(x => x.EndDate);
            Map(x => x.OrderNumber);
            Map(x => x.IsDirty);
            Map(x => x.IP).Length(11);
            Map(x => x.Type).Length(1);
            Map(x => x.RecordIdentifier);

        }
    }
}