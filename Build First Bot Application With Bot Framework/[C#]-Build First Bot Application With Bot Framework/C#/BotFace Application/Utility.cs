using Microsoft.ProjectOxford.Face;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BotFace_Application
{
    public static class Utility
    {
        private static readonly IFaceServiceClient faceServiceClient = new FaceServiceClient(ConfigurationManager.AppSettings["FaceAPIKey"]);
        public static async Task<string> UploadAndDetectFaces(string imageFilePath)
        {
            try
            {
                var requiredFaceAttributes = new FaceAttributeType[] {
                    FaceAttributeType.Age,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Smile
                };
                using (WebClient webClient = new WebClient())
                {
                    using (Stream imageFileStream = webClient.OpenRead(imageFilePath))
                    {
                        var faces = await faceServiceClient.DetectAsync(imageFileStream, returnFaceLandmarks: true, returnFaceAttributes: requiredFaceAttributes);
                        var faceAttributes = faces.Select(face => face.FaceAttributes);
                        string result = string.Empty;
                        faceAttributes.ToList().ForEach(f =>
                            result += $"Age: {f.Age.ToString()} Years  Gender: {f.Gender}  Smile: {f.Smile.ToString()}{Environment.NewLine}{Environment.NewLine}"
                        );
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}

