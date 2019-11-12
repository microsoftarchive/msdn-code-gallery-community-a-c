using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Nexus.Windows.Forms;


namespace netLowLevelDiskFunctions
{
    public partial class Form1 : Form
    {
        private double secondsCounter = 0;
        private double previousSectorCount = 0;
        private double previousTrackCount = 0;

        public Form1()
        {
            InitializeComponent();
            PopulateDriveListBox();

        }

        // Populate drive list box
        private void PopulateDriveListBox()
        {
            foreach (string dID in GetDriveList())
            {
                lbDriveList.Items.Add(dID);
            }
        }

        #region "WMI LOW LEVEL COMMANDS"

        /// <summary>
        /// Returns the number of bytes that the drive sectors contain.
        /// </summary>
        /// <param name="drive">
        /// Int: The drive number to scan.
        /// </param>
        /// <returns>
        /// Int: The number of bytes the sector contains.
        /// </returns>
        public int BytesPerSector(int drive)
        {
            int driveCounter = 0;
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (driveCounter == drive)
                    {
                        var t = queryObj["BytesPerSector"];
                        return int.Parse(t.ToString());
                        
                    }
                    driveCounter++;
                }
            }
            catch (ManagementException)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Returns a list of physical drive IDs
        /// </summary>
        /// <returns>
        /// ArrayList: Device IDs of all connected physical hard drives
        ///  </returns>
        public ArrayList GetDriveList()
        {
            ArrayList drivelist = new ArrayList();

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    drivelist.Add(queryObj["DeviceID"].ToString());
                }
            }
            catch (ManagementException)
            {
                return null;
            }
            return drivelist;
        }

        /// <summary>
        /// Returns the total sectors on the specified drive
        /// </summary>
        /// <param name="drive">
        /// int: The drive to be queried.
        /// </param>
        /// <returns>
        /// int: Returns the total number of sectors
        /// </returns>
        public static int GetTotalSectors(int drive)
        {
            int driveCount = 0;
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (driveCount == drive)
                    {
                        var t = queryObj["TotalSectors"];
                        return int.Parse(t.ToString());
                        
                    }
                    driveCount++;
                }
            }
            catch (ManagementException)
            {
                return -1;
            }
            return -1;
        }

        /// <summary>
        /// Returns the number of Sectors per track.
        /// </summary>
        /// <param name="drive">
        /// The drive to be queried.
        /// </param>
        /// <returns>
        /// int: the number of sectors per track
        /// </returns>
        public static int GetSectorsPerTrack(int drive)
        {
            int driveCount = 0;
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if(driveCount == drive)
                    {
                        var t = queryObj["SectorsPerTrack"];
                        return int.Parse(t.ToString());
                    }
                    driveCount++;
                }
            }
            catch (ManagementException )
            {
                return -1;
            }
            return -1;
        }

        /// <summary>
        /// Returns the total number of tracks on this hard drive
        /// </summary>
        /// <param name="drive">
        /// The drive to be parsed
        /// </param>
        /// <returns>
        /// int: the number of tracks on the drive
        /// </returns>
        public static int GetTotalTracks(int drive)
        {
            int DriveCount = 0;
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (DriveCount == drive)
                    {
                        var t = queryObj["TotalTracks"];
                        return int.Parse((t.ToString()));
                    }
                    DriveCount++;
                }
                
            }
            catch (ManagementException )
            {
                return -1;
            }
            return -1;
        }

        #endregion

        #region "API CALLS"

        public enum EMoveMethod : uint
        {
            Begin = 0,
            Current = 1,
            End = 2
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint SetFilePointer(
            [In] SafeFileHandle hFile,
            [In] long lDistanceToMove,
            [Out] out int lpDistanceToMoveHigh,
            [In] EMoveMethod dwMoveMethod);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess,
          uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
          uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32", SetLastError = true)]
        internal extern static int ReadFile(SafeFileHandle handle, byte[] bytes,
           int numBytesToRead, out int numBytesRead, IntPtr overlapped_MustBeZero);

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerSeconds.Enabled = true;
            int drive = lbDriveList.SelectedIndex;
            int trackBufferSize = int.Parse(tbTrackBufferSize.Text);

            if(cbTracks.CheckState == CheckState.Checked)
            {
                int bps = BytesPerSector(drive);
                int spt = GetSectorsPerTrack(drive);
                int bpt = bps*spt;
                double tt = GetTotalTracks(drive);
                lblBytesPerSector.Text = bps.ToString("N0");
                lblBytesPerTrack.Text = (bps*spt).ToString("N0");
                lblTotalTracks.Text = tt.ToString("N0");
                progress.Maximum = int.Parse(tt.ToString());
                
                double p = 100 / tt;
                
                
                string dr = lbDriveList.Items[0].ToString();
                

                for (double idx = 0; idx < tt; idx += (1 * trackBufferSize))
                {
                    StringBuilder sb = new StringBuilder();
                    lblTrack.Text = idx.ToString("N0");
                    progress.Value = int.Parse(idx.ToString());
                    double r = p * idx;
                    lblPercentage.Text = r.ToString();
                    r = Math.Round(r, 0);
                    progressPie.Items.Add(new PieChartItem(r, Color.BurlyWood, "Tracks", "Number of Tracks Processed", 0));
             //      
                    
                     byte[] b = DumpTrack(dr, idx, bpt,trackBufferSize);
                    

                    foreach (byte byt in b)
                    {
                        sb.Append(byt.ToString("X2"));
                    }
                    lblHash.Text = md5Hash(sb.ToString()).ToUpperInvariant(); // hash this and show 
                    progressPie.Items.RemoveAt(0);
                    Application.DoEvents();
                }
            }
            else
            {
             
            lblBytesPerSector.Text = BytesPerSector(drive).ToString("N0");
            lblTotalSectors.Text = GetTotalSectors(drive).ToString("N0");
            string dr = lbDriveList.Items[0].ToString();
            for(double idx=0;idx < double.Parse(lblTotalSectors.Text);idx++)
            {
                StringBuilder sb = new StringBuilder();
                lblSector.Text = idx.ToString("N0");
                byte[] b = DumpSector(dr, idx, int.Parse(lblBytesPerSector.Text));
                
                foreach (byte byt in b)
                {
                    sb.Append(byt.ToString("X2"));
                }
               lblHash.Text = md5Hash(sb.ToString()).ToUpperInvariant(); // hash this and show 
                Application.DoEvents();   
            }
            
            }
        }

        private string md5Hash(string p)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(p);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
           return s.ToString();
            
        }

        /// <summary>
        /// Returns the Sector from the drive at the specified location
        /// </summary>
        /// <param name="drive">
        /// The drive to have a sector read
        /// </param>
        /// <param name="sector">
        /// The sector number to read.
        /// </param>
        /// <param name="bytesPerSector"></param>
        /// <returns></returns>
        private byte[] DumpSector(string drive, double sector, int bytesPerSector)
        {
            short FILE_ATTRIBUTE_NORMAL = 0x80;
            short INVALID_HANDLE_VALUE = -1;
            uint GENERIC_READ = 0x80000000;
            uint GENERIC_WRITE = 0x40000000;
            uint CREATE_NEW = 1;
            uint CREATE_ALWAYS = 2;
            uint OPEN_EXISTING = 3;



            SafeFileHandle handleValue = CreateFile(drive, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (handleValue.IsInvalid)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            double sec = sector * bytesPerSector;
            
            int size = int.Parse(bytesPerSector.ToString());
            byte[] buf = new byte[size];
            int read = 0;
            int moveToHigh;
            SetFilePointer(handleValue, int.Parse(sec.ToString()), out moveToHigh, EMoveMethod.Begin);
            ReadFile(handleValue, buf, size, out read, IntPtr.Zero);
            handleValue.Close();
            return buf;
        }

        /// <summary>
        /// Returns the Sector from the drive at the specified location
        /// </summary>
        /// <param name="drive">
        /// The drive to have a sector read
        /// </param>
        /// <param name="sector">
        /// The sector number to read.
        /// </param>
        /// <param name="bytesPerSector"></param>
        /// <returns></returns>
        private byte[] DumpTrack(string drive, double track, int bytesPerTrack, int TrackBufferSize)
        {
            short FILE_ATTRIBUTE_NORMAL = 0x80;
            short INVALID_HANDLE_VALUE = -1;
            uint GENERIC_READ = 0x80000000;
            uint GENERIC_WRITE = 0x40000000;
            uint CREATE_NEW = 1;
            uint CREATE_ALWAYS = 2;
            uint OPEN_EXISTING = 3;



            SafeFileHandle handleValue = CreateFile(drive, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (handleValue.IsInvalid)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            double trx = (track * bytesPerTrack * TrackBufferSize);

            int size = int.Parse(bytesPerTrack.ToString());
            byte[] buf = new byte[size * TrackBufferSize];
            int read = 0;
            int moveToHigh;
            SetFilePointer(handleValue, long.Parse(trx.ToString()), out moveToHigh, EMoveMethod.Begin);
            ReadFile(handleValue, buf, size, out read, IntPtr.Zero);
            handleValue.Close();
            return buf;
        }


        private void timerSeconds_Tick(object sender, EventArgs e)
        {
            secondsCounter++;
            lblSectorsPerSecond.Text = (double.Parse(lblSector.Text) - previousSectorCount).ToString(("N0"));
            previousSectorCount = double.Parse(lblSector.Text);

            lblTracksPerSecond.Text = (double.Parse(lblTrack.Text) - previousTrackCount).ToString(("N0"));
            previousTrackCount = double.Parse(lblTrack.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }


}
