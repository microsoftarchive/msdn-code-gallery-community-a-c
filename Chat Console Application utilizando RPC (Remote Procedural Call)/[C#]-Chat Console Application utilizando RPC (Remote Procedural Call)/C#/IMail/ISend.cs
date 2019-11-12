using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMail
{
    public interface ISend
    {
        int Register();
        string SendMessage(int id,string message);
        string getMessages();
    }
}
