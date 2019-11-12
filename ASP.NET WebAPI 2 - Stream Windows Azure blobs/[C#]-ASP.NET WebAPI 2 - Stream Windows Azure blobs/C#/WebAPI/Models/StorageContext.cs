using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class StorageContext
    {
        private CloudStorageAccount _storageAccount;

        public StorageContext()
        {
            _storageAccount = CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.ConnectionStrings["Azure"].ConnectionString);
        }

        public CloudBlobClient BlobClient
        {
            get { return _storageAccount.CreateCloudBlobClient(); }
        }

        public CloudTableClient TableClient
        {
            get { return _storageAccount.CreateCloudTableClient(); }
        }
    }
}