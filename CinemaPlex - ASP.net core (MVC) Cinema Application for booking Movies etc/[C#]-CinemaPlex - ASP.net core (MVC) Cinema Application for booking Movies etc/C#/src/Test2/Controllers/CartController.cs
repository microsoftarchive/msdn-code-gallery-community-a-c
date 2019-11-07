using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CinemaPlex.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaPlex.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        // GET: /cart/booking/id
        [AllowAnonymous]
        public IActionResult Booking(int id)
        {
            ViewData["SessionId"] = id;
            return View();
        }
        [AllowAnonymous]
        public ActionResult Add(int Id)
        {
            String sessionData = HttpContext.Session.GetString("cart");
            CartModel cartModel;
            CartMovie cartMovie = new CartMovie();
            if (sessionData == null)
            {
                cartModel = new CartModel();
                cartModel.cartResults = new List<CartMovie>();
                cartModel.cartId = Guid.NewGuid();
            }
            else
            {
                cartModel = JsonConvert.DeserializeObject<CartModel>(sessionData);
            }
            cartMovie.sessionId = Id;
            cartMovie.quantity = 0;
            cartModel.cartResults.Add(cartMovie);
            string sessionSave = JsonConvert.SerializeObject(cartModel);
            HttpContext.Session.SetString("cart", sessionSave);
            return Redirect("/Cart");
        }

        [AllowAnonymous]
        public ActionResult Remove(int Id)
        {
            String sessionData = HttpContext.Session.GetString("cart");
            CartModel cartModel;
            if (sessionData == null)
            {
                return Redirect("/Cart");
            }
            else
            {
                cartModel = JsonConvert.DeserializeObject<CartModel>(sessionData);
                var sessionToRemove = cartModel.cartResults.First(x => x.sessionId == Id);
                cartModel.cartResults.Remove(sessionToRemove);
            }
            string sessionSave = JsonConvert.SerializeObject(cartModel);
            HttpContext.Session.SetString("cart", sessionSave);
            return Redirect("/Cart");
        }
        public ActionResult Checkout()
        {
            String sessionData = HttpContext.Session.GetString("cart");
            //Todo: Save data into database..
            var cartModel = JsonConvert.DeserializeObject<CartModel>(sessionData);
            ViewData["CartId"] = cartModel.cartId;
            return Redirect("/Cart/Success");
        }
        public ActionResult AddSeats(int id, string seats)
        {
            try
            {
                String sessionData = HttpContext.Session.GetString("cart");
                CartModel cartModel;
                if (sessionData == null)
                {
                    return Redirect("/Cart");
                }
                else
                {
                    cartModel = JsonConvert.DeserializeObject<CartModel>(sessionData);
                    var session = cartModel.cartResults.First(x => x.sessionId == id);
                    if (session.seatIds != null)
                    {
                        var seatsJson = JsonConvert.DeserializeObject<List<String>>(seats);
                        var seatsSessionJson = JsonConvert.DeserializeObject<List<String>>(session.seatIds);
                        seatsSessionJson.AddRange(seatsJson);
                        string seatsString = JsonConvert.SerializeObject(seatsSessionJson);
                        session.seatIds = seatsString;
                    }
                    else
                    {
                        var seatsJson = JsonConvert.DeserializeObject<List<String>>(seats);
                        session.seatIds = seats;
                    }
                }
                string sessionSave = JsonConvert.SerializeObject(cartModel);
                HttpContext.Session.SetString("cart", sessionSave);
                return Redirect("/Cart");
            }
            catch (Exception)
            {
                return Redirect("/Error");
            }
        }
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
