using System;
using System.Collections.Generic;
using RestSharp;
using System.Configuration;
using System.Net;
using consumewebapiusingrestsharp.Models;

namespace consumewebapiusingrestsharp.Helper
{
    public class ServerDataRestClient : consumewebapiusingrestsharp.Helper.IServerDataRestClient
    {
        private RestClient client;
        private string url = ConfigurationManager.AppSettings["webapibaseurl"].ToString();

        public ServerDataRestClient()
        {
            client = new RestClient(url);
        }

        public IEnumerable<ServerData> GetAll()
        {
            var request = new RestRequest("api/serverdata", Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<ServerData>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public ServerData GetById(int id)
        {
            var request = new RestRequest("api/serverdata/{id}", Method.GET);

            request.AddParameter("id", id, ParameterType.UrlSegment);

            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<ServerData>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public ServerData GetByType(int type)
        {
            var request = new RestRequest("api/serverdata/type/{datatype}", Method.GET);
            request.AddParameter("datatype", type, ParameterType.UrlSegment);

            var response = client.Execute<ServerData>(request);

            return response.Data;
        }

        public ServerData GetByIP(int ip)
        {
            var request = new RestRequest("api/serverdata/ip/{ip}", Method.GET);
            request.AddParameter("ip", ip, ParameterType.UrlSegment);

            var response = client.Execute<ServerData>(request);

            return response.Data;
        }

        public void Add(ServerData serverData)
        {
            var request = new RestRequest("api/serverdata", Method.POST);
            request.AddBody(serverData);

            var response = client.Execute<ServerData>(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception(response.ErrorMessage);

        }

        public void Update(ServerData serverData)
        {
            var request = new RestRequest("api/serverdata/{id}", Method.PUT);
            request.AddParameter("id", serverData.Id, ParameterType.UrlSegment);
            request.AddBody(serverData);

            var response = client.Execute<ServerData>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception(response.ErrorMessage);
        }

        public void Delete(int id)
        {
            var request = new RestRequest("api/serverdata/{id}", Method.DELETE);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = client.Execute<ServerData>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception(response.ErrorMessage);
        }
    }
}