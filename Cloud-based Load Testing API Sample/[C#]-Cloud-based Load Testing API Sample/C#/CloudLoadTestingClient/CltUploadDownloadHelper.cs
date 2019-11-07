using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace CloudLoadTestingClient
{
    class CltUploadDownloadHelper
    {
        /// <summary>
        /// Uploads the load test files in the given directory to the test drop location.
        /// </summary>
        /// <param name="localDirectory">the local dir that contains the test source files</param>
        /// <param name="testDrop">test drop to which the file should be uploaded</param>
        public static void Upload(string localDirectory, TestDrop testDrop)
        {
            List<string> files = new List<string>();
            if (Directory.Exists(localDirectory))
            {
                files.AddRange(Directory.GetFiles(localDirectory).ToArray());
            }

            files.ForEach(file => UploadFile(file, testDrop));
        }

        private static void UploadFile(string localFile, TestDrop testDrop, bool retryOnFailure = true)
        {
            int uploadRetryCount = 0;

            do
            {
                try
                {
                    Logger.LogMessage("Uploading file {0} to blob.", Path.GetFileName(localFile));
                    CloudBlobContainer container = new CloudBlobContainer(testDrop.AccessData.DropContainerUrl, new StorageCredentialsSharedAccessSignature(testDrop.AccessData.SasKey));
                    CloudBlockBlob blob = container.GetBlockBlobReference(Path.GetFileName(localFile.ToLower()));
                    using (var fileStream = File.OpenRead(localFile))
                    {
                        blob.UploadFromStream(fileStream);
                    }

                    return;
                }
                catch
                {
                    if (uploadRetryCount < 3)
                    {
                        uploadRetryCount++;
                    }
                    else
                    {
                        throw;
                    }
                }

            } while (true);
        }

        /// <summary>
        /// Downloads the result from the given uri to the target file path. In case target file path is not specified
        /// downloads to a default location and returns the file path.
        /// </summary>
        /// <param name="resultsUri">uri of the results file</param>
        /// <param name="targetFilePath">target file path to which the file will be downloaded</param>
        /// <returns>file location of the downloaded file</returns>
        public static string DownloadResult(string resultsUri, string targetFilePath = null)
        {
            if (string.IsNullOrWhiteSpace(resultsUri))
            {
                throw new ArgumentException("Invalid resultsuri.", "resultsUri");
            }

            var filePathToUse = targetFilePath;
            if (string.IsNullOrWhiteSpace(filePathToUse))
            {
                filePathToUse = Path.Combine(ResultsFileLocation, GetFileName(resultsUri));
            }

            Logger.LogMessage("DownloadResult: Downloading result file {0} to {1}", resultsUri, filePathToUse);
            //TODO: Listen to progress events and report status
            using (var downloadClient = new WebClient())
            {
                downloadClient.DownloadFile(resultsUri, filePathToUse);
            }

            return filePathToUse;
        }

        /// <summary>
        /// Decompress the input result file to the target file path.
        /// </summary>
        /// <param name="compressedFilePath">compressed file path</param>
        /// <param name="targetFilePath">target file path</param>
        public static string DecompressResult(string compressedFilePath, string targetFilePath = null)
        {
            if (!IsZipFile(compressedFilePath))
            {
                throw new ArgumentException("The input file is not a valid zip file.", "compressedFilePath");
            }

            var decompressedFilePath = targetFilePath;
            // File is compressed. Decompress it.
            if (string.IsNullOrWhiteSpace(decompressedFilePath))
            {
                decompressedFilePath = compressedFilePath.Substring(0, compressedFilePath.Length - ".zip".Length);
                decompressedFilePath = Path.Combine(ResultsFileLocation, decompressedFilePath);
            }

            Logger.LogMessage("DecompressResult: Decompressing result file {0} to {1}", compressedFilePath, decompressedFilePath);
            using (var inputStream = File.OpenRead(compressedFilePath))
            {
                using (var compressionStream = new GZipStream(inputStream, CompressionMode.Decompress))
                {
                    using (var outputStream = File.Create(decompressedFilePath))
                    {
                        compressionStream.CopyTo(outputStream, 4096);
                    }
                }
            }

            return decompressedFilePath;
        }

        private static string ResultsFileLocation
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_resultsFileLocation))
                {
                    _resultsFileLocation = Environment.ExpandEnvironmentVariables(c_resultDownloadLocation);
                    if (!Directory.Exists(_resultsFileLocation))
                    {
                        Directory.CreateDirectory(_resultsFileLocation);
                    }
                }
                return _resultsFileLocation;
            }
        }

        private static bool IsZipFile(string compressedFilePath)
        {
            return !string.IsNullOrEmpty(compressedFilePath) && compressedFilePath.EndsWith(".zip", StringComparison.OrdinalIgnoreCase);
        }
        private static string GetFileName(string urlString)
        {
            var url = new Uri(urlString);

            // Append a new Guid so that there is no clash in the file name.
            return Guid.NewGuid().ToString() + url.Segments[url.Segments.Length - 1];
        }

        private const string c_resultDownloadLocation = "%Temp%\\ELSDownloadVault";
        private static string _resultsFileLocation;
    }
}
