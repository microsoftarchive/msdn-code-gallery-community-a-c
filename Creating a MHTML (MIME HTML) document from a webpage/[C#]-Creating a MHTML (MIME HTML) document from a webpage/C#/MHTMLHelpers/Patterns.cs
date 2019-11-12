using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MHTMLHelpers
{
    public class Patterns
    {
        public static readonly Regex ScriptPattern = new Regex(@"\<script([\w\s=""]*?(type=("")?text/javascript("")?|src=("")?(?<Url>[\w\.\:\?\-=&/%#]+)("")?)){2}[\w\s\>=""]*?((/?\s*\>)|(\</\s*script\>))", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static readonly Regex LinkPattern = new Regex(@"\<link.*?(href=("")?(?<Url>[\w\.\:\?\-=&/%#]+)("")?).*?((/?\s*\>)|(\</\s*link\>))", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static readonly Regex ImagePattern = new Regex(@"\<img.*?(src=("")?(?<Url>(?!(data:))[\w\.\:\?\-=&/%#]+)("")?).*?(/?\s*\>)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static readonly Regex FileNamePattern = new Regex(@"filename=(?<FileName>[\w\-\.]+);", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}
