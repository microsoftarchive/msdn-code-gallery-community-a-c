using Microsoft.AspNet.Facebook;
using Newtonsoft.Json;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// http://go.microsoft.com/fwlink/?LinkId=301877

namespace SampleFacebookBirthdayApp.Models
{
    public class MyAppUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonProperty("picture")] // This renames the property to picture.
        public FacebookConnection<FacebookPicture> ProfilePicture { get; set; }

        [FacebookFieldModifier("limit(8)")] // This sets the size of the friend list to 8, remove it to get all friends.
        public FacebookGroupConnection<MyAppUserFriend> Friends { get; set; }

        [FacebookFieldModifier("limit(16)")] // This sets the size of the photo list to 16, remove it to get all photos.
        public FacebookGroupConnection<FacebookPhoto> Photos { get; set; }
    }
}
