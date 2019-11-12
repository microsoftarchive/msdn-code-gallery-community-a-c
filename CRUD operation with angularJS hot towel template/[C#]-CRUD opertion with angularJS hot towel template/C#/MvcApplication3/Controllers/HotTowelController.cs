using MvcApplication3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Data.Entity.Core;
using System.Threading;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;

namespace MvcApplication3.Controllers
{
    public class HotTowelController : Controller
    {
        //
        // GET: /HotTowel/
        PeopleRepository  Repository = new PeopleRepository();
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ModifyPeople(Contacts people)
        {
            Repository.ModifyUser(people);
            return new EmptyResult();
        }
        public ActionResult SavePeople(Contacts people)
        {
            /*
            var contacts = from b in Repository.Contacts
                           where b.FirstName == people.FirstName
                           select b;
            int count = contacts.Count<Contacts>();

                if (count > 0)
                    return new HttpStatusCodeResult(404,"Name already present");
             * 
             */
            Repository.Save(people);
            return getJson<Contacts>(people);
        }


        public ActionResult DeletePeople(Contacts people)
        {
            Repository.Delete(people);

            return new EmptyResult();
        }
        public ActionResult GetPeopleDetails()
        {


            return getJson<DbSet>(Repository.Contacts);

        }

        private ActionResult getJson<TEnitry>(TEnitry obj)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(obj, settings),
                ContentType = "application/json"

            };


            return jsonResult;
        }
    }
}
