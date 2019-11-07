using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS.Model;
using AWS_SQS_Kinesis.Helpers;
using AWS_SQS_Kinesis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AWS_SQS_Kinesis.Controllers
{
    public class MessageController : Controller
    {
        private readonly IOptions<AccessHelper> _options;
        private SQSHelper _helper = null;
        public MessageController(IOptions<AccessHelper> options)
        {
            _options = options;
        }
        public SQSHelper Helper
        {
            get
            {
                if (_helper == null)
                {
                    var kv = (AccessHelper)_options.Value;
                    _helper = new SQSHelper(kv.AccessKey, kv.SecretKey, RegionEndpoint.APNortheast1);
                }
                return _helper;
            }
        }
        public async Task<IActionResult> Index()
        {
            var models = new List<QueueModel>();
            var queues =await Helper.GetQueue();
            foreach (var q in queues.QueueUrls)
            {
                models.Add(new QueueModel(q));
            }
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QueueModel model)
        {
            if(ModelState.IsValid)
            {
                await Helper.CreateQueue(model.QueueName);
               
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            var request = Request.Query["query"].ToString();
            if (request == null)
                throw new InvalidOperationException();
            await Helper.DeleteQueue(request.ToString());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Send()
        {
            var url = Request.Query["url"].ToString();
            if (url == null)
                throw new InvalidOperationException();
            var model = new MessageModel("",url,"");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Send(MessageModel model)
        {
            if(ModelState.IsValid)
            {
                await Helper.SendMessage(model.URL,model.Message);
            }
            return RedirectToAction("messages",new { url=model.URL });
        }

        public async Task<IActionResult> Messages()
        {
            var url = Request.Query["url"].ToString();
            var response =await Helper.GetAllMessages(url);
            var models = new List<MessageModel>();
            foreach (var msg in response)
            {
                models.Add(new MessageModel(msg.Body,url,msg.ReceiptHandle));
            }
            return View(models);
        }

        public async Task<IActionResult> DeleteMessage()
        {
            var url = Request.Query["url"].ToString();
            var handler = Request.Query["handler"].ToString();
            await Helper.DeleteMessage(url,handler);
            return RedirectToAction("Index");
        }

    }
}