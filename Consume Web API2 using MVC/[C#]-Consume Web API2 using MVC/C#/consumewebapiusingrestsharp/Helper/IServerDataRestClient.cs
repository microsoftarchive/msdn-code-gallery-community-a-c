using System;
namespace consumewebapiusingrestsharp.Helper
{
    public interface IServerDataRestClient
    {
        void Add(consumewebapiusingrestsharp.Models.ServerData serverData);
        void Delete(int id);
        System.Collections.Generic.IEnumerable<consumewebapiusingrestsharp.Models.ServerData> GetAll();
        consumewebapiusingrestsharp.Models.ServerData GetById(int id);
        consumewebapiusingrestsharp.Models.ServerData GetByIP(int ip);
        consumewebapiusingrestsharp.Models.ServerData GetByType(int type);
        void Update(consumewebapiusingrestsharp.Models.ServerData serverData);
    }
}
