using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPlex.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string MovieLogo { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string MainCast { get; set; }
        public string Director { get; set; }
        public string RunningTime { get; set; }
        public string Classification { get; set; }
    }
    public class CinemaModel
    {
        [Key]
        public int CineplexID { get; set; }
        public string Location { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Address { get; set; }
    }
    public class SessionModel
    {
        [Key]
        public int SessionID { get; set; }
        public int CineplexID { get; set; }
        public int MovieID { get; set; }
        public TimeSpan TimeRunning { get; set; }
        public Double BookingCapacity { get; set; }
        public Double BookedCapacity { get; set; }
        //We store the bookedseats as JSON.
        public string BookedSeats { get; set; }
    }
    public class CartModel
    {
        public Guid cartId { get; set; }
        public List<CartMovie> cartResults { get; set; }
    }
    public class CartMovie
    {
        public int sessionId { get; set; }
        public int quantity { get; set; }
        public string seatIds { get; set; }
    }
}
