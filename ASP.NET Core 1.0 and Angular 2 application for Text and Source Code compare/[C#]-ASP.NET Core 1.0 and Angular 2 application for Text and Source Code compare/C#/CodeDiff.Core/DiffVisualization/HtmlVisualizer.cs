using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace MsdrRu.CodeDiff.DiffVisualization
{
    public class HtmlVisualizer
    {
        public static DiffHtmlVisualizationResult Visualize(Tuple<Line, Line> parsingResults)
        {
            Contract.Requires<ArgumentNullException>(parsingResults != null);

            const string emptyStringPattern = "<pre class=\"diff-pre diff-empty\"><span>{0}</span></pre>";
            const string originalStringPattern = "<pre class=\"diff-pre diff-original\"><span>{0}</span>{1}</pre>";
            const string insertedStringPattern = "<pre class=\"diff-pre diff-inserted\"><span>{0}</span>{1}</pre>";
            const string modifiedStringPattern = "<pre class=\"diff-pre diff-modified\"><span>{0}</span>{1}</pre>";
            const string removedStringPattern = "<pre class=\"diff-pre diff-removed\"><span>{0}</span>{1}</pre>";

            var version1DiffHtmlSb = new StringBuilder();
            var version2DiffHtmlSb = new StringBuilder();

            var version1CurrentLine = parsingResults.Item1;
            var version2CurrentLine = parsingResults.Item2;

            uint i = 1;

            while (true)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (version1CurrentLine.Status)
                {
                    case LineStatus.Original:
                        version1DiffHtmlSb.Append(string.Format(originalStringPattern, i, version1CurrentLine.Content));
                        break;
                    case LineStatus.Modified:
                        version1DiffHtmlSb.Append(string.Format(modifiedStringPattern, i, version1CurrentLine.Content));
                        break;
                    case LineStatus.Removed:
                        version1DiffHtmlSb.Append(string.Format(removedStringPattern, i, version1CurrentLine.Content));
                        break;
                    default:
                        version1DiffHtmlSb.Append(string.Format(emptyStringPattern, i));
                        break;
                }

                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (version2CurrentLine.Status)
                {
                    case LineStatus.Original:
                        version2DiffHtmlSb.Append(string.Format(originalStringPattern, i, version2CurrentLine.Content));
                        break;
                    case LineStatus.Modified:
                        version2DiffHtmlSb.Append(string.Format(modifiedStringPattern, i, version2CurrentLine.Content));
                        break;
                    case LineStatus.Inserted:
                        version2DiffHtmlSb.Append(string.Format(insertedStringPattern, i, version2CurrentLine.Content));
                        break;
                    default:
                        version2DiffHtmlSb.Append(string.Format(emptyStringPattern, i));
                        break;
                }

                i++;
                version1CurrentLine = version1CurrentLine.Next;
                version2CurrentLine = version2CurrentLine.Next;

                if (version1CurrentLine == null)
                {
                    break;
                }
            }

            return new DiffHtmlVisualizationResult()
            {
                Version1DiffHtml = version1DiffHtmlSb.ToString(),
                Version2DiffHtml = version2DiffHtmlSb.ToString()
            };
        }
    }
}
