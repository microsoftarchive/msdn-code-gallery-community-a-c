using System;
using System.Data;
using System.Data.Common;

namespace NtierMvc.DataAccess.Common
{
    /// <summary>
    /// Purpose: Helper Data Handler Class for data parameters and types conversion.
    /// </summary>
    public class DataHandler
    {
        public void AddParameterToCommand(DbCommand command, string paramName, CsType csDataType, ParameterDirection direction, object value)
        {
            if (command == null)
                throw new ArgumentNullException("command", "The AddParameterToCommand Command is null.");

            try
            {
                DbParameter param = command.CreateParameter();
                param.ParameterName = paramName;
                param.DbType = ConvertCsharpDataTypeToDbType(csDataType);
                param.Value = value ?? DBNull.Value;
                param.Direction = direction;
                command.Parameters.Add(param);
            }
            catch (Exception ex)
            {
                //Bubble error to caller and encapsulate Exception object
                throw new Exception("DataHandler::AddParameterToCommand::Error occured.", ex);
            }
        }
        private DbType ConvertCsharpDataTypeToDbType(CsType csDataType)
        {
            var dbType = DbType.String;
            switch (csDataType)
            {
                case CsType.String:
                    dbType = DbType.String;
                    break;
                case CsType.Int:
                    dbType = DbType.Int32;
                    break;
                case CsType.Long:
                    dbType = DbType.Int64;
                    break;
                case CsType.Double:
                    dbType = DbType.Double;
                    break;
                case CsType.Decimal:
                    dbType = DbType.Decimal;
                    break;
                case CsType.DateTime:
                    dbType = DbType.DateTime;
                    break;
                case CsType.Boolean:
                    dbType = DbType.Boolean;
                    break;
                case CsType.Short:
                    dbType = DbType.Int16;
                    break;
                case CsType.Guid:
                    dbType = DbType.Guid;
                    break;
                case CsType.ByteArray:
                case CsType.Binary:
                    dbType = DbType.Binary;
                    break;
            }
            return dbType;
        }
    }
}
