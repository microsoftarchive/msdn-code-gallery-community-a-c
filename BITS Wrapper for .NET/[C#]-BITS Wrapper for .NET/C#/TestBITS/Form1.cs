using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Net.BITS;
using System.Runtime.InteropServices;

namespace TestBITS
{
	public partial class Form1 : Form
	{
		public delegate void AddListItem(String myString);
		public AddListItem myDelegate;
		private BackgroundCopyJob job;

		public Form1()
		{
			InitializeComponent();
			myDelegate = new AddListItem(AddListItemMethod);
		}

		public void AddListItemMethod(String myString)
		{
			if (!this.listBox1.InvokeRequired)
				listBox1.Items.Add(myString);
			else
				this.Invoke(myDelegate, myString);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				this.listBox1.Items.Clear();
				AddListItemMethod("Version: " + BackgroundCopyManager.Version.ToString());
				AddListItemMethod("Jobs:");
				foreach (BackgroundCopyJob j in BackgroundCopyManager.Jobs)
				{
					AddListItemMethod("  " + j.DisplayName + ": " + j.State.ToString());
					foreach (Microsoft.Net.BITS.BackgroundCopyFileInfo f in j.Files)
						AddListItemMethod(string.Format("    {0}->{1} ({2}%)", f.RemoteFilePath, f.LocalFilePath, f.PercentComplete));
					if (j.State == Microsoft.Net.BITS.BackgroundCopyJobState.Error)
						j.Cancel();
					if (j.State == Microsoft.Net.BITS.BackgroundCopyJobState.Transferred)
						j.Complete();
					if (j.State == Microsoft.Net.BITS.BackgroundCopyJobState.Suspended)
						if (j.Files.Count > 0)
							j.Resume();
						else
							j.Cancel();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void job_Completed(object sender, BackgroundCopyJobEventArgs e)
		{
			TimeSpan ts = e.Job.TransferCompletionTime - e.Job.CreationTime;
			AddListItemMethod(string.Format("Job '{0}' completed in {1} seconds.", e.Job.DisplayName, ts.Seconds));
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				job = BackgroundCopyManager.CreateJob("Test", "Special");
				job.Error += new System.IO.ErrorEventHandler(job_Error);
				job.Completed += new BackgroundCopyJobEventHandler(job_Completed);
				job.Priority = BackgroundCopyJobPriority.High;
				job.Proxy = null;
				job.MinimumRetryDelay = 15;
				job.SetCredentials(new System.Net.NetworkCredential("username", "password"));
				job.Files.Add(new Uri("http://www.myfavoritedownloads.com/files/"), @"C:\Favorites", new string[] { "file1.jpb", "file2.mpg", "file3.pdf" });
				job.Files.Add("http://www.myfavoritedownloads.com/files/file4.zip", @"C:\Favorites\file4.zip");
				job.Resume();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void job_Error(object sender, System.IO.ErrorEventArgs e)
		{
			AddListItemMethod(e.GetException().Message);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			job = BackgroundCopyManager.CreateJob("UploadTest", "Special", BackgroundCopyJobType.Upload);
			job.Files.Add("http://localhost", @"c:\bits.zip");
		}
	}
}