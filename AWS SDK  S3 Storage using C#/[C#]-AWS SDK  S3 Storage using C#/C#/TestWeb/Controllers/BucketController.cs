using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;
using TestWeb.Utilities.Common;

namespace TestWeb.Controllers
{
    public class BucketController : Controller
    {
        private readonly IAWSServce _awsService;
        public BucketController(IAWSServce service)
        {
            this._awsService = service;
        }
        // GET: Bucket
        public ActionResult Index()
        {
            var model = new List<BucketModel>();
            ListBucketsResponse bucketsResponse = _awsService.Client.ListBuckets();
            foreach (var bucket in bucketsResponse.Buckets)
            {
                var region = this._awsService.Client.GetBucketLocation(bucket.BucketName).Location.Value;
                GetPreSignedUrlRequest req = new GetPreSignedUrlRequest();
                req.BucketName = bucket.BucketName;
                req.Expires = DateTime.Now.AddDays(5);
                req.Protocol = Protocol.HTTPS;
                model.Add(new BucketModel(bucket.BucketName, bucket.CreationDate, region, _awsService.Client.GetPreSignedURL(req)));
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BucketModel model)
        {
            try
            {
                PutBucketRequest bucketRequest = new PutBucketRequest();
                bucketRequest.BucketName = model.BucketName;
                this._awsService.Client.PutBucket(bucketRequest);
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index");

        }


        public ActionResult Delete(string bucket)
        {
            try
            {
                var location = this._awsService.Client.GetBucketLocation(bucket);
                DeleteBucketRequest deleteBucketRequest = new DeleteBucketRequest();
                deleteBucketRequest.BucketName = bucket;
                deleteBucketRequest.BucketRegion = new S3Region(location.Location);
                this._awsService.Client.DeleteBucket(deleteBucketRequest);
             
            }
            catch(Exception ex)
            {
                TempData["Error"]= ex.Message;
            }
            return RedirectToAction("Index");
        }
       

    }
}