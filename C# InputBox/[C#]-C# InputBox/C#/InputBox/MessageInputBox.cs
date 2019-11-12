using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InputBox
{
    class MessageBoxInput
    {
        public enum icon : uint
        {
            SiidDocnoassoc = 0,
            SiidDocassoc = 1,
            SiidApplication = 2,
            SiidFolder = 3,
            SiidFolderopen = 4,
            SiidDrive525 = 5,
            SiidDrive35 = 6,
            SiidDriveremove = 7,
            SiidDrivefixed = 8,
            SiidDrivenet = 9,
            SiidDrivenetdisabled = 10,
            SiidDrivecd = 11,
            SiidDriveram = 12,
            SiidWorld = 13,
            SiidServer = 15,
            SiidPrinter = 16,
            SiidMynetwork = 17,
            SiidFind = 22,
            SiidHelp = 23,
            SiidShare = 28,
            SiidLink = 29,
            SiidSlowfile = 30,
            SiidRecycler = 31,
            SiidRecyclerfull = 32,
            SiidMediacdaudio = 40,
            SiidLock = 47,
            SiidAutolist = 49,
            SiidPrinternet = 50,
            SiidServershare = 51,
            SiidPrinterfax = 52,
            SiidPrinterfaxnet = 53,
            SiidPrinterfile = 54,
            SiidStack = 55,
            SiidMediasvcd = 56,
            SiidStuffedfolder = 57,
            SiidDriveunknown = 58,
            SiidDrivedvd = 59,
            SiidMediadvd = 60,
            SiidMediadvdram = 61,
            SiidMediadvdrw = 62,
            SiidMediadvdr = 63,
            SiidMediadvdrom = 64,
            SiidMediacdaudioplus = 65,
            SiidMediacdrw = 66,
            SiidMediacdr = 67,
            SiidMediacdburn = 68,
            SiidMediablankcd = 69,
            SiidMediacdrom = 70,
            SiidAudiofiles = 71,
            SiidImagefiles = 72,
            SiidVideofiles = 73,
            SiidMixedfiles = 74,
            SiidFolderback = 75,
            SiidFolderfront = 76,
            SiidShield = 77,
            SiidWarning = 78,
            SiidInfo = 79,
            SiidError = 80,
            SiidKey = 81,
            SiidSoftware = 82,
            SiidRename = 83,
            SiidDelete = 84,
            SiidMediaaudiodvd = 85,
            SiidMediamoviedvd = 86,
            SiidMediaenhancedcd = 87,
            SiidMediaenhanceddvd = 88,
            SiidMediahddvd = 89,
            SiidMediabluray = 90,
            SiidMediavcd = 91,
            SiidMediadvdplusr = 92,
            SiidMediadvdplusrw = 93,
            SiidDesktoppc = 94,
            SiidMobilepc = 95,
            SiidUsers = 96,
            SiidMediasmartmedia = 97,
            SiidMediacompactflash = 98,
            SiidDevicecellphone = 99,
            SiidDevicecamera = 100,
            SiidDevicevideocamera = 101,
            SiidDeviceaudioplayer = 102,
            SiidNetworkconnect = 103,
            SiidInternet = 104,
            SiidZipfile = 105,
            SiidSettings = 106,
            SiidDrivehddvd = 132,
            SiidDrivebd = 133,
            SiidMediahddvdrom = 134,
            SiidMediahddvdr = 135,
            SiidMediahddvdram = 136,
            SiidMediabdrom = 137,
            SiidMediabdr = 138,
            SiidMediabdre = 139,
            SiidClustereddrive = 140,
            SiidMaxIcons = 175
        }

        [Flags]
        public enum Shgsi : uint
        {
            ShgsiIconlocation = 0,
            ShgsiIcon = 0x000000100,
            ShgsiSysiconindex = 0x000004000,
            ShgsiLinkoverlay = 0x000008000,
            ShgsiSelected = 0x000010000,
            ShgsiLargeicon = 0x000000000,
            ShgsiSmallicon = 0x000000001,
            ShgsiShelliconsize = 0x000000004
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct Info
        {
            public UInt32 cbSize;
            public IntPtr hIcon;
            public Int32 iSysIconIndex;
            public Int32 iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }

        [DllImport("Shell32.dll", SetLastError = false)]
        public static extern Int32 SHGetStockIconInfo(icon siid, Shgsi uFlags, ref Info psii);

        public static string ShowDialog(string text, string caption, icon siid)
        {
            Form prompt = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Width = 500,
                Height = 180,
                ControlBox = false,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
            };
            Label textLabel = new Label()
            {
                Left = 80,
                Top = 20,
                Text = text,
                Width = 400
            };
            textLabel.Font = new Font(textLabel.Font.Name, 11, FontStyle.Regular);
            var painel = new Panel() { Top = 0, Height = 90, Width = 500, BackColor = Color.White };
            var inputBox = new TextBox() { Left = 80, Top = 50, Width = 380 };
            inputBox.Font = new Font(inputBox.Font.Name, 11, FontStyle.Regular);
            var sii = new Info { cbSize = (UInt32)Marshal.SizeOf(typeof(Info)) };
            Marshal.ThrowExceptionForHR(SHGetStockIconInfo(siid, Shgsi.ShgsiIcon, ref sii));
            var icone = new PictureBox
            {
                Left = 25,
                Top = 42,
                Width = 50,
                Height = 50,
                Image = Icon.FromHandle(sii.hIcon).ToBitmap()
            };
            Button confirmaracao = new Button()
            {
                Text = @"Confirmar",
                Left = 350,
                Width = 100,
                Height = 30,
                Top = 100
            };
            Button cancelaracao = new Button()
            {
                Text = @"Cancelar",
                Left = 240,
                Width = 100,
                Height = 30,
                Top = 100
            };
            cancelaracao.Click += (sender, e) =>
            {
                inputBox.Text = null; prompt.Dispose();
            };
            confirmaracao.Click += (sender, e) =>
            {
                prompt.Close();
            };
            prompt.Controls.Add(painel);
            prompt.Controls.Add(confirmaracao);
            prompt.Controls.Add(cancelaracao);
            painel.Controls.Add(textLabel);
            painel.Controls.Add(icone);
            painel.Controls.Add(inputBox);
            prompt.ShowDialog();
            return inputBox.Text;
        }
    }

}
