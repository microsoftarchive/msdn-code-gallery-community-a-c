using ChatBot.Serialization;
using ChatBot.Services;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChatBot.Controllers
{
    public class MessagesController : ApiController
    {
        public async Task<Message> Post([FromBody]Message message)
        {
            //Message msg = new Message();
            //msg.Type = "Message";
            //msg.Created = DateTime.Now;
            //msg.ConversationId = message.ConversationId;
            //msg.Id = "123456";
            //msg.Text = message.Text;

            //return await Task.FromResult<Message>(msg);
            return await Response(message);
        }

        private static async Task<Message> Response(Message message)
        {
            Message resposta = new Message();
            var response = await Luis.GetResponse(message.Text);

            if (response != null)
            {
                var intent = new Intent();
                var entity = new Entity();

                string acao = string.Empty;
                string pessoa = string.Empty;
                string agendaInf = string.Empty;
                string agendaResult = string.Empty;

                foreach (var item in response.entities)
                {
                    switch (item.type)
                    {
                        case "Pessoa":
                            pessoa = item.entity;
                            break;
                        case "AgendaInf":
                            agendaInf = item.entity;
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(pessoa))
                {
                    if (!string.IsNullOrEmpty(agendaInf))
                        resposta = message.CreateReplyMessage($"OK! Entendi, mostrando {agendaInf} de {pessoa}");
                    else
                        resposta = message.CreateReplyMessage("Não entendi qual informação vc quer do " + pessoa + ".");
                }
                else
                    resposta = message.CreateReplyMessage("Não entendi qual a pessoa vc deseja a informação.");
            }
            return resposta;
        }
    }
}
