using ContactManager.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ContactManager.Formatters
{
    public class ContactPngFormatter : BufferedMediaTypeFormatter
    {
        public ContactPngFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));
        }

        public override void WriteToStream(Type type, object value, Stream stream, HttpContent content)
        {
            var contact = value as Contact;
            if (contact != null)
            {
                var imageId = contact.ContactId % 8;
                if (imageId == 0)
                {
                    imageId++;
                }

                var path = string.Format(@"Images\Image{0}.png", imageId);
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    byte[] bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, (int)fileStream.Length);
                    stream.Write(bytes, 0, (int)fileStream.Length);
                }
            }
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(Contact).Equals(type);
        }
    }
}
