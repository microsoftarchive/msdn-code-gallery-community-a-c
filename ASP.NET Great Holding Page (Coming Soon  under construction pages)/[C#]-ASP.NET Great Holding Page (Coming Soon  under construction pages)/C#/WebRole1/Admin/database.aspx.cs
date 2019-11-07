using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;

namespace WebApplication1.Admin.Database
{
    public partial class _default : System.Web.UI.Page
    {
        // http://msdn.microsoft.com/en-us/library/windowsazure/ff394114.aspx
        // http://thomaslarock.com/2012/03/march-madness-sql-azure-sys-dm_exec_query_plan/
        // http://blogs.msdn.com/b/sqlazure/archive/2010/08/13/10049896.aspx
        // http://blogs.msdn.com/b/sqlazure/archive/tags/sql+azure/
        #region "SQL Azure Queries"
        //        -- Glenn Berry
        //-- March 2011
        //-- http://sqlserverperformance.wordpress.com/
        //-- Twitter: GlennAlanBerry


        //-- Get version information
        //SELECT @@VERSION AS [SQL Version Info];

        //-- SQL Azure Builds 
        //-- Build            Description
        //-- 10.25.9200        RTM Service Update 1
        //-- 10.25.9268        RTM Service Update 2
        //-- 10.25.9331        RTM Service Update 3
        //-- 10.25.9386        RTM Service Update 4
        //-- 10.25.9445        RTM Service Update 5
        //-- 10.25.9501        RTM Service Update "5a" (Nov 3, 2010)


        //-- You must be connected to master database
        //-- to run these queries

        //-- Get bandwidth usage by database by hour (for billing)
        //SELECT database_name, direction, class, time_period, 
        //       quantity AS [KB Transferred], [time]
        //FROM sys.bandwidth_usage
        //ORDER BY [time] DESC;

        //-- Get overall cost by SKU in dollars
        //SELECT SKU, SUM    (CASE WHEN USAGE.SKU = N'Web'
        //                            THEN (Quantity * 9.99/31)
        //                       WHEN USAGE.SKU = N'Business'
        //                          THEN (Quantity * 99.99/31)
        //                 END ) AS [CostInDollars]
        //FROM sys.Database_Usage AS USAGE
        //WHERE DATEPART(yy, TIME) = DATEPART(yy, GetUTCDate())
        //AND DATEPART(mm, TIME) = DATEPART(mm, GetUTCDate())
        //GROUP BY SKU;


        //-- Get Bandwidth cost by direction and type
        //SELECT USAGE.Time_Period, USAGE.Direction,
        //            CASE WHEN USAGE.Direction = N'Egress'
        //                    THEN 0.15 * USAGE.BandwidthInKB/(1024 * 1024)
        //                     WHEN USAGE.DIRECTION = N'Ingress'
        //                    THEN 0.10 * USAGE.BandwidthInKB/(1024 * 1024)
        //            END AS [CostInDollars]
        //FROM (SELECT Time_Period, Direction, SUM(Quantity) AS [BandwidthInKB]
        //       FROM sys.Bandwidth_Usage
        //       WHERE  DATEPART(yy, TIME) = DATEPART(yy, GetUTCDate())
        //       AND    DATEPART(mm, TIME) = DATEPART(mm, GetUTCDate())
        //       AND class = N'External'
        //       GROUP BY Time_Period, Direction) AS USAGE;


        //-- Get number of databases by SKU for this SQL Azure account (for billing)
        //SELECT sku, quantity, [time]
        //FROM sys.database_usage
        //ORDER BY [time] DESC;

        //-- Get firewall rules (must be connected to master)
        //SELECT id, name, start_ip_address, end_ip_address, 
        //create_date, modify_date 
        //FROM sys.firewall_rules
        //ORDER BY id;

        //-- List all logins on "instance" (must be connected to master)
        //SELECT name, principal_id, [sid], type_desc, 
        //       is_disabled, create_date, default_database_name
        //FROM sys.sql_logins
        //ORDER BY name;

        //-- List all databases (must be connected to master)
        //SELECT name, database_id, create_date, [compatibility_level]
        //FROM sys.databases;


        //-- Must connect to a user database 
        //-- in order to run these queries

        //-- Get max allowed size of database (use your database name)
        //SELECT CONVERT(BIGINT, DATABASEPROPERTYEX('ngservices' , 'MaxSizeInBytes'))/1073741824.0  AS [MaxSizeInGB];

        //-- Get current size of database
        //SELECT (SUM(reserved_page_count) * 8192)/1048576.0 AS [Database Size in MB]
        //FROM sys.dm_db_partition_stats;

        //-- Switch to Business Edition ($99.99/month)
        //ALTER DATABASE AdventureWorksLT2008R2 
        //MODIFY (EDITION = 'BUSINESS', MAXSIZE = 10GB);

        //-- Refresh SQL Azure Portal web page to see change

        //-- Switch to Web Edition ($9.99/month)
        //ALTER DATABASE AdventureWorksLT2008R2 
        //MODIFY (EDITION = 'WEB', MAXSIZE = 1GB);



        //-- Get row counts for tables in current database
        //SELECT OBJECT_NAME(object_id) AS [ObjectName], row_count, object_id, index_id 
        //FROM sys.dm_db_partition_stats
        //WHERE index_id < 2
        //ORDER BY row_count DESC;

        //-- Monitor connections in current database
        //SELECT s.session_id, s.login_name, e.connection_id,
        //      s.last_request_end_time, s.cpu_time, 
        //      e.connect_time
        //FROM sys.dm_exec_sessions AS s
        //INNER JOIN sys.dm_exec_connections AS e
        //ON s.session_id = e.session_id
        //ORDER BY s.login_name;


        //-- Get session count by host name
        //SELECT [host_name], COUNT(*) AS [SessionCount] 
        //FROM sys.dm_exec_sessions AS s
        //GROUP BY [host_name]
        //ORDER BY [host_name]; 


        //-- Top Cached Plans By Execution Count
        //SELECT q.[text], hcpu.total_worker_time, 
        //       hcpu.execution_count, hcpu.plan_handle
        //FROM 
        //    (SELECT TOP (50) qs.* 
        //     FROM sys.dm_exec_query_stats AS qs 
        //     ORDER BY qs.total_worker_time DESC) AS hcpu 
        //     CROSS APPLY sys.dm_exec_sql_text(plan_handle) AS q 
        //ORDER BY hcpu.execution_count DESC;


        //-- Top Cached Plans By total worker time (CPU)
        //SELECT q.[text], hcpu.total_worker_time, 
        //       hcpu.execution_count, hcpu.plan_handle
        //FROM 
        //    (SELECT TOP (50) qs.* 
        //     FROM sys.dm_exec_query_stats AS qs 
        //     ORDER BY qs.total_worker_time DESC) AS hcpu 
        //     CROSS APPLY sys.dm_exec_sql_text(plan_handle) AS q 
        //ORDER BY hcpu.total_worker_time DESC;

        //-- Find top Avg CPU time queries
        //SELECT TOP (25) MIN(query_stats.statement_text) AS [Statement Text], 
        //SUM(query_stats.total_worker_time) / SUM(query_stats.execution_count) AS [Avg CPU Time],
        //query_stats.query_hash AS [Query Hash]
        //FROM (SELECT QS.*, SUBSTRING(ST.[text], (QS.statement_start_offset/2) + 1,
        //    ((CASE statement_end_offset 
        //        WHEN -1 THEN DATALENGTH(st.[text])
        //        ELSE QS.statement_end_offset END 
        //            - QS.statement_start_offset)/2) + 1) AS statement_text
        //     FROM sys.dm_exec_query_stats AS QS
        //     CROSS APPLY sys.dm_exec_sql_text(QS.sql_handle) AS ST) AS query_stats
        //GROUP BY query_stats.query_hash
        //ORDER BY [Avg CPU Time] DESC;


        //-- Top Cached Plans By total logical reads (Memory)
        //SELECT q.[text], hcpu.total_logical_reads, 
        //       hcpu.execution_count, hcpu.plan_handle
        //FROM 
        //    (SELECT TOP (50) qs.* 
        //     FROM sys.dm_exec_query_stats AS qs 
        //     ORDER BY qs.total_worker_time DESC) AS hcpu 
        //     CROSS APPLY sys.dm_exec_sql_text(plan_handle) AS q 
        //ORDER BY hcpu.total_logical_reads DESC;


        //-- Top Cached Plans By total elapsed time
        //SELECT q.[text], hcpu.total_elapsed_time, 
        //       hcpu.execution_count, hcpu.plan_handle
        //FROM 
        //    (SELECT TOP (50) qs.* 
        //     FROM sys.dm_exec_query_stats AS qs 
        //     ORDER BY qs.total_worker_time DESC) AS hcpu 
        //     CROSS APPLY sys.dm_exec_sql_text(plan_handle) AS q 
        //ORDER BY hcpu.total_elapsed_time DESC;

        //-- This works in SQL Azure
        //EXEC sp_updatestats;

        //-- This works in SQL Azure
        //UPDATE STATISTICS CurrentPostMeta  -- This is a table name

        //-- DMVs that were added in SQL Azure Service Update 1
        //SELECT * FROM sys.dm_exec_connections; 
        //SELECT * FROM sys.dm_exec_requests; 
        //SELECT * FROM sys.dm_exec_sessions; 
        //SELECT * FROM sys.dm_tran_database_transactions;  
        //SELECT * FROM sys.dm_tran_active_transactions;

        //-- Other DMFs
        //SELECT * FROM sys.dm_exec_query_plan       -- needs a plan_handle
        //SELECT * FROM sys.dm_exec_sql_text           -- needs a plan_handle
        //SELECT * FROM sys.dm_exec_text_query_plan  -- needs a plan_handle, stmt_start_offset, stmt_end_offset
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            lbASPNetDBSize.Text = GetASPNETDBSize();
            lblCMSDBSize.Text = GetCMSDBSize();
        }

        private string GetCMSDBSize()
        {
            decimal res = 0;
            SqlConnection conn = new SqlConnection(CMSDataSource.ConnectionString);
            SqlCommand command = new SqlCommand("SELECT (SUM(reserved_page_count) * 8192)/1048576.0 AS [Database Size in MB] FROM sys.dm_db_partition_stats;", conn);
            conn.Open();
            res = (decimal)command.ExecuteScalar();
            conn.Close();

            return res.ToString() + " MB";
        }

        protected void timerUpdate_Tick(object sender, EventArgs e)
        {
            lbASPNetDBSize.Text = GetASPNETDBSize();
            lblCMSDBSize.Text = GetCMSDBSize();
        }

        private string GetASPNETDBSize()
        {
            decimal res = 0;
            SqlConnection conn = new SqlConnection(aspnetdbDataSource.ConnectionString);
            SqlCommand command = new SqlCommand("SELECT (SUM(reserved_page_count) * 8192)/1048576.0 AS [Database Size in MB] FROM sys.dm_db_partition_stats;", conn);
            conn.Open();
            res = (decimal)command.ExecuteScalar();
            conn.Close();

            return res.ToString() + " MB";
        }


    }
}