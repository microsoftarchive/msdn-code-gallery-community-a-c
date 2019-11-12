using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHTMLHelpers
{
    public interface IMHTMLHelper
    {

        byte[] GetMHTML(string url);

    }
}
