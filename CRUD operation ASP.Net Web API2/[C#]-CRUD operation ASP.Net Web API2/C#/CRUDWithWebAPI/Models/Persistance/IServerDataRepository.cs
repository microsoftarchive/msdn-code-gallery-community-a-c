using System.Collections.Generic;

namespace CRUDWithWebAPI.Models.Persistance
{
    public interface IServerDataRepository
    {
        ServerData Get(int id);
        IEnumerable<ServerData> GetAll();
        ServerData Add(ServerData serverData);
        void Delete(int id);
        bool Update(ServerData serverData);

    }
}
