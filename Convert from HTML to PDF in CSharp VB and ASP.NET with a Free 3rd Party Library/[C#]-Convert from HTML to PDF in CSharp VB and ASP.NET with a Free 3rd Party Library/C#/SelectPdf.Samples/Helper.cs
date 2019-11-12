using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectPdf.Samples
{
    public class Helper
    {
        public static string SomeShortText()
        {
            return @"This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text. This is some short text.";
        }

        public static string SomeText()
        {
            return @"This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

New paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

3rd paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. New paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

4th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text.";
        }

        public static string SomeLongText()
        {
            return @"This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

New paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

3rd paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. New paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

4th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

5th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

6th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

7th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

8th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

9th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. 

10th paragraph. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text. This is some long text.";
        }

        public static string SomeVeryLongText()
        {
            return SomeLongText() + SomeLongText() + SomeLongText() + SomeLongText() + SomeLongText();
        }

        public static string PageBreaksText()
        {
            return @"<html>
    <body>
        <div style=""font-size: 28px; page-break-after: always"">
            This is a short paragraph of text. After it, a page break will be inserted. <br/>
            This is a short paragraph of text. After it, a page break will be inserted. <br/>
            This is a short paragraph of text. After it, a page break will be inserted. <br/>
            This is a short paragraph of text. After it, a page break will be inserted. <br/>
        </div>

        <div style=""font-size: 28px; "">
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
            This paragraph should appear in the second page (the first paragraph inserted a page break after it). <br/>
        </div>

        <div style=""font-size: 28px; page-break-inside: avoid; "">
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
            This paragraph should all be displayed in the same page (contains page-break-inside: avoid). Since it's too large to appear in the second page, it will all appear in the third page. <br/>
        </div>
    </body>
</html>
";
        }

        public static float PixelsToPoints(float value)
        {
            return 96f * value / 72f;
        }

        public static float PointsToPixels(float value)
        {
            return 72f * value / 96f;
        }
    }
}