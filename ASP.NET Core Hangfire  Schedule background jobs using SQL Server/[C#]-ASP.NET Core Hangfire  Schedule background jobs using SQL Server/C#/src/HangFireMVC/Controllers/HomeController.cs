using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using System.Diagnostics;

namespace HangFireMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // for and forgot job example
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget Job Executed"));

            // delayed job example
            BackgroundJob.Schedule(() => Console.WriteLine("Delayed job executed"), TimeSpan.FromMinutes(1));

            // recurring job example
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Minutely Job executed"), Cron.Minutely);

            // Continuations job example
            var id = BackgroundJob.Enqueue(() => Console.WriteLine("Hello, "));
            BackgroundJob.ContinueWith(id, () => Console.WriteLine("world!"));

            return View();
        }
		
		public IActionResult Error()
        {
            return View();
        }
    }
}
