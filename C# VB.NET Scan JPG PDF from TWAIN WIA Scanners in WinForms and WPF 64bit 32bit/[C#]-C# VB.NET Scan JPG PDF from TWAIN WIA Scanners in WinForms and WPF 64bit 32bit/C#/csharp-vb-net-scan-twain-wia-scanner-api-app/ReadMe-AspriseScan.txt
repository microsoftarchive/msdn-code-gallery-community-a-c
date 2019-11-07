Asprise Scan C# VB.NET SDK ◎ 64bit and 32bit Applications Scanning from TWAIN WIA Flatbed and ADF Scanners as PDF, TIFF or JPG

► TO RUN THE SAMPLE SCAN APPLICATION
-----------------------------------

static class Program { // Program.cs
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new asprise_imaging_api.SampleScanForm()); // ☜ Run SampleScanForm
    }
}

► PERFORM SCAN IN JUST A FEW LINES
----------------------------------

using asprise_imaging_api;

Result result = new AspriseImaging().Scan(new Request()
    .SetTwainCap(TwainConstants.ICAP_PIXELTYPE, TwainConstants.TWPT_RGB)
    .SetPromptScanMore(true) // prompt to scan more pages
    .AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_JPG)
      .SetSavePath(".\\${TMS}${EXT}")), // Environment variables in path will be expanded
  "select", true, true); // "select" prompts device selection dialog.

List<string> files = result == null ? null : result.GetImageFiles();
Console.WriteLine("Scanned: " + string.Join(", ", files == null ? new string[0] : files.ToArray()));

► SCAN PROGRAMMING GUIDE
------------------------

Developer's Guide and API docs: http://asprise.com/c%23-vb.net-scanner-api/twain-wia-document-scan-library-sdk-samples-docs.html

► DOWNLOAD SOURCE CODE OF SCAN .NET API & DEMOS
-----------------------------------------------

Source code of Asprise Scan .NET API & demos: http://asprise.com/c%23-vb.net-scanner-api/twain-wia-windows-adf-pdf-component-download.html

► CONTACT ASPRISE
-----------------

We're ready to help. Please send your inquiries through:

Email: contact@asprise.com
Web:   http://asprise.com/c%23-vb.net-scanner-api/twain-wia-scan-pdf-library-overview.html
