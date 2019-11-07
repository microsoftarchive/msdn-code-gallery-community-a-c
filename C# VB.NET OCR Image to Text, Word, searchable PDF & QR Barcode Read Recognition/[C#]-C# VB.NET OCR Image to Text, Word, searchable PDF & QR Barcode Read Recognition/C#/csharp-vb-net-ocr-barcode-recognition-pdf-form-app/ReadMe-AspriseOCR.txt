Asprise OCR and Barcode Recognition SDK with Data Capture ◎ Royalty Free. #1 OCR Engine on NuGet

► TO RUN THE SAMPLE OCR APPLICATION
-----------------------------------

static class Program { // Program.cs
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new asprise_ocr_api.OcrSampleForm()); // ☜ Run OcrSampleForm
    }
}

► PERFORM OCR IN JUST A FEW LINES
-----------------------------------

using asprise_ocr_api;

AspriseOCR.SetUp();
AspriseOCR ocr = new AspriseOCR();
ocr.StartEngine("eng", AspriseOCR.SPEED_FASTEST);
string file = "C:\\YOUR_FILE.jpg"; // ☜ jpg, gif, tif, pdf, etc.
string s = ocr.Recognize(file, -1, -1, -1, -1, -1, AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);
Console.WriteLine("Result: " + s);
ocr.StopEngine();

► OCR PROGRAMMING GUIDE
-----------------------------------

Developer's Guide: http://asprise.com/royalty-free-library/c%23-sharp.net-ocr-barcode-reader-sdk-samples-docs.html

► CONTACT ASPRISE
-----------------------------------

Asprise OCR supports more than twenty languages as well as IMR passport MRZ, however only five popular languages are included
in this trial kit. Please contact us if you need to evaluate other languages.

Email: contact@asprise.com
Web:   http://asprise.com/royalty-free-library/c%23-sharp.net-ocr-api-overview.html
