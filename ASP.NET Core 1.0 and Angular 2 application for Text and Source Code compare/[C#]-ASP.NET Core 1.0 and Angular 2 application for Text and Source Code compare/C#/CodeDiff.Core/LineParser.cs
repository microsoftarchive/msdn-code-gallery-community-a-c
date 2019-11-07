using System;
using System.Diagnostics.Contracts;
using System.IO;
using MsdrRu.CodeDiff.DiffAlgorithm;

namespace MsdrRu.CodeDiff
{
    public class LineParser
    {
        public static Tuple<Line, Line> Parse(Diff.Item[] items, string version1, string version2)
        {
            Contract.Requires<ArgumentNullException>(items != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(version1));
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(version1));

            //First Line reference.
            var version1FirstLine = ParseToLinkedLineList(version1);
            //First Line reference.
            var version2FirstLine = ParseToLinkedLineList(version2);

            var version1CurrentLine = version1FirstLine;
            var version2CurrentLine = version2FirstLine;

            // ReSharper disable once SuggestVarOrType_SimpleTypes
            foreach (Diff.Item item in items)
            {
                //Modified rows.
                if (item.DeletedA > 0 && item.InsertedB > 0)
                {
                    var line1 = (ulong) item.StartA;
                    var line2 = (ulong) item.StartB;
                    var affected1 = (ulong)item.DeletedA;
                    var affected2 = (ulong)item.InsertedB;

                    ulong i = 1;
                    while (affected1 >= i || affected2 >= i)
                    {
                        if (affected1 >= i && affected2 >= i)
                        {
                            ModifyLineStatus(ref version1FirstLine, version1CurrentLine, line1 + i, LineStatus.Modified);
                            ModifyLineStatus(ref version2FirstLine, version2CurrentLine, line2 + i, LineStatus.Modified);
                        }
                        else if (affected1 < i && affected2 >= i)
                        {
                            AddEmptyLine(ref version1FirstLine, version1CurrentLine, line1 - 1 + i);
                            ModifyLineStatus(ref version2FirstLine, version2CurrentLine, line2 + i, LineStatus.Inserted);
                        }
                        else
                        {
                            ModifyLineStatus(ref version1FirstLine, version1CurrentLine, line1 + i, LineStatus.Removed);
                            AddEmptyLine(ref version2FirstLine, version2CurrentLine, line2 - 1 + i);
                        }

                        i++;

                    }
                }

                //Removed rows.
                if (item.DeletedA > 0 && item.InsertedB == 0)
                {
                    for (var i = 1; i <= item.DeletedA; i++)
                    {
                        ModifyLineStatus(ref version1FirstLine, version1CurrentLine, (ulong)(item.StartA + i), LineStatus.Removed);
                        AddEmptyLine(ref version2FirstLine, version2CurrentLine, (ulong)(item.StartB));
                    }
                }

                //Inserted rows.
                if (item.DeletedA == 0 && item.InsertedB > 0)
                {
                    for (var i = 1; i <= item.InsertedB; i++)
                    {
                        ModifyLineStatus(ref version1FirstLine, version2CurrentLine, (ulong)(item.StartB + i), LineStatus.Inserted);
                        AddEmptyLine(ref version1FirstLine, version1CurrentLine, (ulong)(item.StartA));
                    }
                }
            }

            return new Tuple<Line, Line>(version1FirstLine, version2FirstLine);
        }

        private static void ModifyLineStatus(ref Line firstLine, Line currentLine, ulong position, LineStatus lineStatus)
        {
            if (position == 0)
            {
                firstLine = new Line
                {
                    Next = currentLine,
                    Status = lineStatus
                };
            }
            else
            {
                while (currentLine.OriginalLineNumber != position)
                {
                    currentLine = currentLine.Next;
                }

                currentLine.Status = lineStatus;
            }
        }

        private static void AddEmptyLine(ref Line firstLine, Line currentLine, ulong position)
        {
            if (position == 0)
            {
                firstLine = new Line {Next = currentLine};
            }
            else
            {
                while (currentLine.OriginalLineNumber != position)
                {
                    if (currentLine.Next == null)
                    {
                        currentLine.Next = new Line();
                        return;
                    }

                    currentLine = currentLine.Next;
                }

                var newLine = new Line { Next = currentLine.Next };
                currentLine.Next = newLine;
            }
        }

        private static Line ParseToLinkedLineList(string inputText)
        {
            ulong lineNumber = 1;
            var firstLine = new Line(lineNumber)
            {
                Status = LineStatus.Original
            };

            using (var reader = new StringReader(inputText))
            {
                string line;
                var currentLine = firstLine;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber == 1)
                    {
                        currentLine.Content = line;
                    }
                    else
                    {
                        currentLine.Next = new Line(lineNumber)
                        {
                            Content = line,
                            Status = LineStatus.Original,
                            Previous = currentLine
                        };

                        currentLine = currentLine.Next;
                    }

                    lineNumber++;
                }
            }

            return firstLine;
        }
    }
}
