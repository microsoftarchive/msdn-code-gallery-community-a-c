using Microsoft.AspNet.Facebook;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// http://go.microsoft.com/fwlink/?LinkId=301877

namespace SampleFacebookBirthdayApp.Models
{
    public class MyAppUserFriend
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Link { get; set; }

        public string Birthday { get; set; }

        [FacebookFieldModifier("height(100).width(100)")] // This sets the picture height and width to 100px.
        public FacebookConnection<FacebookPicture> Picture { get; set; }
    }
}
