using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ShanuWebAPIFileM.Models;
using System.Net;
using  Newtonsoft.Json;

namespace shanuAPIConsume
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			

			// to browse Image files. 
			this.openFileDialog1.Filter =
				"Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
				"All files (*.*)|*.*";

			// Allow the user to select multiple images. 
			this.openFileDialog1.Multiselect = true;
			this.openFileDialog1.Title = "Browse files to upload.";
		}

		#region Upload File
		//Upload File Button Click event
		private void btnUpload_Click(object sender, EventArgs e)
		{

			 Boolean uploadStatus = false;
			DialogResult dr = this.openFileDialog1.ShowDialog();
			if (dr == System.Windows.Forms.DialogResult.OK)
			{
				foreach (String localFilename in openFileDialog1.FileNames)
				{
					string url = "http://localhost:51389/api/FileHandlingAPI";
					string filePath = @"\";
					Random rnd = new Random();
					string uploadFileName = "Imag"+rnd.Next(9999).ToString();
					uploadStatus = Upload(url, filePath, localFilename, uploadFileName);
				}
			}
			if (uploadStatus)
			{
				MessageBox.Show("File Uploaded");
			}
			else
			{
				MessageBox.Show("File Not Uploaded");
			}
		}


		// filepath = @"Some\Folder\";
		// url= "http://localhost:51389/api/FileHandlingAPI";
		// localFilename = "c:\newProduct.jpg" 
		//uploadFileName="newFileName"
		bool Upload(string url, string filePath, string localFilename, string uploadFileName)
		{
			Boolean isFileUploaded = false;

			try
			{
				HttpClient httpClient = new HttpClient();

				var fileStream = File.Open(localFilename, FileMode.Open);
				var fileInfo = new FileInfo(localFilename);
				UploadFIle uploadResult = null;
				bool _fileUploaded = false;

				MultipartFormDataContent content = new MultipartFormDataContent();
				content.Headers.Add("filePath", filePath);
				content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", uploadFileName  + fileInfo.Extension)
						);

				Task taskUpload = httpClient.PostAsync(url, content).ContinueWith(task =>
				{
					if (task.Status == TaskStatus.RanToCompletion)
					{
						var response = task.Result;

						if (response.IsSuccessStatusCode)
						{
							uploadResult = response.Content.ReadAsAsync<UploadFIle>().Result;
							if (uploadResult != null)
								_fileUploaded = true;

							////// Read other header values if you want..
							////foreach (var header in response.Content.Headers)
							////{
							////	Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
							////}
						}
						else
						{
							//Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
							//Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
						}
					}

					fileStream.Dispose();
				});

				taskUpload.Wait();
				if (_fileUploaded)
					isFileUploaded = true;
				//AddMessage(uploadResult.FileName + " with length " + uploadResult.FileLength
				//				+ " has been uploaded at " + uploadResult.LocalFilePath);


				httpClient.Dispose();

			}
			catch (Exception ex)
			{
				//	AddMessage(ex.Message);
				isFileUploaded = false;
			}


			return isFileUploaded;
		}
 
		#endregion
		#region FileInformation
		//Get File List
		private void btnFileList_Click(object sender, EventArgs e)
		{
			string URI = "http://localhost:51389/api/FileHandlingAPI/getFileInfo?Id=1";
			GetFileInformation(URI);
		}

		 
		private async void GetFileInformation(string url)
		{
			List<ServerFileInformation> filesinformation = new List<ServerFileInformation>();
			using (var client = new HttpClient())
			{
				using (var response = await client.GetAsync(url))
				{
					if (response.IsSuccessStatusCode)
					{
						var fileJsonString = await response.Content.ReadAsStringAsync();

					 dataGridView1.DataSource = JsonConvert.DeserializeObject<ServerFileInformation[]>(fileJsonString).ToList();
						//filesinformation = JsonConvert.DeserializeObject<ServerFileInformation[]>(fileJsonString).ToList();
					}
				}
			}
		}


		public class ServerFileInformation
		{
			public string Filename { get; set; } // Filename of the file 
			public string Path { get; set; } // Path of the file on the server 
			public long Length { get; set; } // Size of the file (bytes) 
			public bool IsDirectory { get; set; } // true if the filename is 
		}
		#endregion

		#region Download File
		//Download File
		private void btnDownload_Click(object sender, EventArgs e)
		{
			string url = "http://localhost:51389/Uploads/";
			string downloadFileName = txtFileName.Text.Trim();
			string downloadPath = Application.StartupPath + @"\Downloads\";

			if (!Directory.Exists(downloadPath))
				Directory.CreateDirectory(downloadPath);

			Boolean isFileDownloaded = Download(url, downloadFileName, downloadPath);
			if (isFileDownloaded)
			{
				MessageBox.Show("File Downloaded");
			}
			else
			{
				MessageBox.Show("File Not Downloaded");
			}
		}

		// url = http://localhost:51389/Uploads/"  
		// downloadFileName = "new2.jpg" 
		// downloadPath =  Application.StartupPath + "/Downloads/";
		bool Download(string url, string downloadFileName, string downloadFilePath)
		{
			string downloadfile = downloadFilePath + downloadFileName;
			string httpPathWebResource = null;
			Boolean ifFileDownoadedchk = false;
			ifFileDownoadedchk = false;
			WebClient myWebClient = new WebClient();
			httpPathWebResource = url + downloadFileName;
			myWebClient.DownloadFile(httpPathWebResource, downloadfile);

			ifFileDownoadedchk = true;

			return ifFileDownoadedchk;
		}



		#endregion

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			string fileName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
			txtFileName.Text = fileName;
		}
	}
}
