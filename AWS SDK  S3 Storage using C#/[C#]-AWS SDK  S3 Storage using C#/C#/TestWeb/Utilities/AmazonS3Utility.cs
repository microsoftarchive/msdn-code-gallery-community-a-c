//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Amazon;
//using Amazon.S3;
//using Amazon.S3.Transfer;
////using Amazon.S3.Model;
//namespace TestWeb.Utilities
//{
//    public class AmazonS3Utility
//    {
//        public bool IsUploaded(string localFilePath, string bucketName, string subDirectoryInBucket, string s3FileName)
//        {

//            IAmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client("AKIAIIYSWA2FGZ7WBNVQ","Ri9jDovwfRlr02lF/84yPTn9AxhDq74efJgn6R",RegionEndpoint.APNortheast1);
//            TransferUtility utility = new TransferUtility(client);
//            TransferUtilityUploadRequest uploadRequest = new TransferUtilityUploadRequest();

//            if(subDirectoryInBucket=="" || subDirectoryInBucket == null)
//            {
//                uploadRequest.BucketName = bucketName;
//            }
//            else
//            {
//                uploadRequest.BucketName = bucketName + @"/"+subDirectoryInBucket;
//            }
//            uploadRequest.Key = s3FileName;
//            uploadRequest.FilePath = localFilePath;
//            utility.Upload(uploadRequest);
//            return true;
//        }
//    }
//}