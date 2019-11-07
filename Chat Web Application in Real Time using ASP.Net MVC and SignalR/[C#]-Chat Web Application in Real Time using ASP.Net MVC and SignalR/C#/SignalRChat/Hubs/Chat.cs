using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace SignalRChat.Hubs
{
    public class Chat : Hub
    {
        public void EnviarMensagem(string apelido, string mensagem)
        {
            Clients.PublicarMensagem(apelido, mensagem);
        }
    }
}