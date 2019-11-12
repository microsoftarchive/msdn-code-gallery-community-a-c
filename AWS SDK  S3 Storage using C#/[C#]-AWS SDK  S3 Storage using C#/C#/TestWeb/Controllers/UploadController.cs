using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using TestWeb.Models;
using TestWeb.Utilities;
using TestWeb.Utilities.Common;
using io = System.IO;
namespace TestWeb.Controllers
{
    public class UploadController : Controller
    {
        private readonly IAWSServce _awsService;
        public UploadController(IAWSServce service)
        {
            this._awsService = service;
        }
        // GET: Upload
        public ActionResult Index()
        {
            var list = new List<S3ObjectModel>();
            try
            {
                foreach (var bucket in _awsService.Client.ListBuckets().Buckets)
                {

                    var location = this._awsService.Client.GetBucketLocation(bucket.BucketName).Location.Value;
                    if (location == RegionEndpoint.APNortheast1.SystemName.ToString())
                    {
                        foreach (var obj in _awsService.Client.ListObjects(bucket.BucketName).S3Objects)
                        {
                            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest();
                            request.BucketName = bucket.BucketName;
                            request.Key = obj.Key;
                            request.Expires = DateTime.Now.AddHours(1);
                            request.Protocol = Protocol.HTTP;
                            string downloadLink = _awsService.Client.GetPreSignedURL(request);
                            if (obj != null)
                                list.Add(new S3ObjectModel(obj.Key, bucket.BucketName, downloadLink));
                        }
                    }

                }
            }
            catch (Exception ex) { }
            return View(list);
        }
        public ActionResult Upload()
        {
            if (Request.QueryString.AllKeys.Length == 0)
                return Redirect("/Bucket/index");
            if (TempData["request"] != null)
                TempData["request"] = null;
            TempData["request"] = Request.QueryString[0].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            var request = new PutObjectRequest()
            {
                BucketName = TempData["request"].ToString(),
                CannedACL = S3CannedACL.Private,
                Key = file.FileName,
                InputStream = file.InputStream
            };
            this._awsService.Client.PutObject(request);
            return RedirectToAction("index");
        }

   
        public ActionResult Delete(string objectName, string bucketName)
        {
            DeleteObjectRequest deleterequest = new DeleteObjectRequest();
            deleterequest.BucketName = bucketName;
            deleterequest.Key = objectName;
       
            this._awsService.Client.DeleteObject(deleterequest);
            return RedirectToAction("index");
        }
    }
}
