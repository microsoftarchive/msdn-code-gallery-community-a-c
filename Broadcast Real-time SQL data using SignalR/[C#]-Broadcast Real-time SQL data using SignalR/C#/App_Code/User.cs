using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class User
{
    #region Constructor
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion


    #region Properties

    /// <summary>
    /// Property to get/set ProfileId
    /// </summary>
    public string ProfileId
    {
        get;
        set;
    }

    /// <summary>
    /// Propoerty to get/set multiple ConnectionId
    /// </summary>
    public HashSet<string> ConnectionIds
    {
        get;
        set;
    }

    #endregion
}
