using CRUDWithWebAPI.Models;
using CRUDWithWebAPI.Models.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWithWebAPI.Controllers
{
    public class ServerDataController : ApiController
    {
        static readonly IServerDataRepository ServerDataRepository = new ServerDataRepository();

        public IEnumerable<ServerData> GetServerData()
        {
            return ServerDataRepository.GetAll();
        }

        public ServerData GetServerDataById(int id)
        {
            var serverData = ServerDataRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return serverData;
        }

        public IEnumerable<ServerData> GetServerDataByType(int type)
        {
            return ServerDataRepository.GetAll().Where(d => d.Type == type);
        }

        public IEnumerable<ServerData> GetServerDataByIP(string ip)
        {
            return ServerDataRepository.GetAll().Where(d => d.IP.ToLower() == ip.ToLower());
        }

        //Why commented this - explained in the article
        //public ServerData PostServerData(ServerData serverData)
        //{
        //    return serverDataRepository.Add(serverData);
        //}

        public HttpResponseMessage PostServerData(ServerData serverData)
        {
            serverData = ServerDataRepository.Add(serverData);

            var response = Request.CreateResponse(HttpStatusCode.Created, serverData);

            var uri = Url.Link("DefaultApi", new { id = serverData.Id });
            response.Headers.Location = new Uri(uri);

            return response;

        }

        public void PutServerData(int id, ServerData serverData)
        {
            serverData.Id = id;

            if (!ServerDataRepository.Update(serverData))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public void DeleteServerData(int id)
        {
            var serverData = ServerDataRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            ServerDataRepository.Delete(id);
        }
    }
}
