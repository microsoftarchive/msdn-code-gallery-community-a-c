//------------------------------------------------------------------------------
// <copyright file="CSSqlStoredProcedure.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void spCallWcfService(string name)
    {
        try
        {
            SqlPipe sqlPipe = SqlContext.Pipe;
            string result = MyClassLibrary.MyClass.CallWcfService(name);
            SqlContext.Pipe.Send(result);
        }
        catch (Exception ex)
        {
            SqlContext.Pipe.Send(ex.Message);
        }
    }
}
