using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Collections;
using System.IO;

namespace CleanupWorkflowHistory
{
    class Program
    {
        private static string _SiteUrl;
        private static string _ListName;
        private static int _NumDays;
        private static uint _MaxHistoryListDelete;
        private static int _MaxRecycleBinDelete;
        private static bool _PermanentDelete;
        private static bool _ReportOnly;
        private static string _LogFileName;
        private static int _BatchCounter = 0;
        private static int _SiteRecycleBinCounter = 0;
        private static int _WebRecycleBinCounter = 0;

        static void Main(string[] args)
        {
            if (args.Length != 8)
            {
                ShowUsage();
            }
            else
            {
                try // may fail on convert
                {
                    // get the arguments
                    _SiteUrl = args[0];
                    _ListName = args[1];
                    Int32.TryParse(args[2], out _NumDays);
                    uint.TryParse(args[3], out _MaxHistoryListDelete);
                    Int32.TryParse(args[4], out _MaxRecycleBinDelete);
                    _PermanentDelete = Convert.ToBoolean(args[5]);
                    _ReportOnly = Convert.ToBoolean(args[6]);
                    _LogFileName = args[7];
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to convert arguments: {0}", ex.Message);
                    return; // exit
                }

                CreateLogFile(_LogFileName);
                LogMessage("");
                LogMessage(DateTime.Now + ": started CleanupWorkflowHistory");

                PurgeHistoryList(_SiteUrl, _ListName, _NumDays, _MaxHistoryListDelete, _PermanentDelete, _ReportOnly);

                //if (_PermanentDelete)
                //{
                    PurgeWebRecycleBin(_SiteUrl, _ListName, _MaxRecycleBinDelete);
                    PurgeSiteRecycleBin(_SiteUrl, _ListName, _MaxRecycleBinDelete);
                //}

                LogMessage(DateTime.Now + ": finished CleanupWorkflowHistory");
            }
        }

        static bool PurgeHistoryList(string pSiteUrl, string pListName, int pNumDays, uint pMaxHistoryListDelete, bool pPermanentDelete, bool pReportOnly)
        {
            // make number of days negative
            int _NegativeNumDays = pNumDays * -1;
            string _FormattedDate = SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.UtcNow.AddDays(_NegativeNumDays));

            // CAML query to get items based on criteria
            string _Filter = "<Where><Lt><FieldRef Name='Modified' /><Value Type='DateTime'>" + _FormattedDate + "</Value></Lt></Where>";

            SPQuery query = new SPQuery();
            query.RowLimit = pMaxHistoryListDelete; // has to be uint datatype
            query.Query = _Filter;

            try
            {
                using (SPSite site = new SPSite(pSiteUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        // Get the list that has the items we want to delete
                        SPList list = web.Lists[pListName];
                        string listGuid = list.ID.ToString();

                        // SPListItemCollection itemCollection = list.Items;  //all items in the list
                        SPListItemCollection itemCollection = list.GetItems(query);

                        // create new StringBuilder
                        StringBuilder batchString = new StringBuilder();

                        // add the main text to the stringbuilder
                        batchString.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Batch>");

                        // add each item to the batch string and give it a command Delete
                        foreach (SPListItem item in itemCollection)
                        {
                            // create a new method section
                            batchString.Append("<Method>");
                            // insert the listid to know where to delete from
                            batchString.Append("<SetList Scope=\"Request\">" + Convert.ToString(item.ParentList.ID) + "</SetList>");
                            // the item to delete
                            batchString.Append("<SetVar Name=\"ID\">" + Convert.ToString(item.ID) + "</SetVar>");
                            // set the action you would like to preform
                            batchString.Append("<SetVar Name=\"Cmd\">Delete</SetVar>");
                            // close the method section
                            batchString.Append("</Method>");
                            // increment counter
                            _BatchCounter++;
                        }

                        // close the batch section
                        batchString.Append("</Batch>");

                        LogMessage(DateTime.Now + ":  started processing batch.");

                        // if not ReportOnly mode
                        if (pReportOnly == false)
                        {
                            try
                            {
                                //perform the batch
                                web.ProcessBatchData(batchString.ToString());
                                LogMessage(DateTime.Now + ":   MaxHistoryListDelete: " + pMaxHistoryListDelete);
                                LogMessage(DateTime.Now + ":   " + _BatchCounter + " items deleted");
                                LogMessage(DateTime.Now + ":  finished processing batch");
                                return true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Delete failed: " + ex.Message);
                                return false;
                            }
                        }
                        else // if ReportOnly mode
                        {
                            LogMessage(DateTime.Now + ":   running in Report Mode (read-only)");
                            LogMessage(DateTime.Now + ":   MaxHistoryListDelete: " + pMaxHistoryListDelete);
                            LogMessage(DateTime.Now + ":   " + _BatchCounter + " items will be deleted");
                            LogMessage(DateTime.Now + ":  finished processing batch");
                            return true;
                        }
                    } // end using
                } // end using
            } // end try
            
            catch (Exception ex)
            {
                Console.WriteLine("Unable to connect to site: {0} - {1}", _SiteUrl, ex.Message);
                return false;
            }
        }

        static bool PurgeWebRecycleBin(string pSiteUrl, string pListName, int pMaxRecycleBinDelete)
        {
            try
            {
                using (SPSite site = new SPSite(pSiteUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        LogMessage(DateTime.Now + ":  started purging Web Recycle Bin");
                        LogMessage(DateTime.Now + ":   " + web.RecycleBin.Count + " items in Web Recycle Bin");

                        SPRecycleBinQuery query = new SPRecycleBinQuery();
                        query.RowLimit = pMaxRecycleBinDelete;
                        SPRecycleBinItemCollection recycleitems = web.GetRecycleBinItems(query);

                        if (_ReportOnly == false) // delete items
                        {
                            foreach (SPRecycleBinItem item in recycleitems)
                            {
                                if (item.DirName.Contains(_ListName)) // item is from the Workflow History list
                                {
                                    item.Delete();
                                    _WebRecycleBinCounter++;
                                }

                            }
                            LogMessage(DateTime.Now + ":   MaxRecycleBinDelete: " + pMaxRecycleBinDelete);
                            LogMessage(DateTime.Now + ":   " + _WebRecycleBinCounter + " items purged");
                            LogMessage(DateTime.Now + ":  finished purging Web Recycle Bin");
                        }
                        else // in Report Mode - read-only
                        {
                            foreach (SPRecycleBinItem item in recycleitems)
                            {
                                if (item.DirName.Contains(_ListName)) // item is from the Workflow History list
                                {
                                    _WebRecycleBinCounter++;
                                }
                            }
                            LogMessage(DateTime.Now + ":   running in Report Mode (read-only)");
                            LogMessage(DateTime.Now + ":   MaxRecycleBinDelete: " + pMaxRecycleBinDelete);
                            LogMessage(DateTime.Now + ":   " + _WebRecycleBinCounter + " items will be deleted");
                            LogMessage(DateTime.Now + ":  finished purging Web Recycle Bin");
                        }
                    } // end using 
                } // end using
                return true;
            } // end try
            catch (Exception ex)
            {
                LogMessage(DateTime.Now + ":  ERROR in PurgeWebRecycleBin: " + ex.Message);
                LogMessage(DateTime.Now + ":  finished purging Web Recycle Bin");
                return false;
            }
        }

        static bool PurgeSiteRecycleBin(string pSiteUrl, string pListName, int pMaxRecycleBinDelete)
        {
            try
            {
                using (SPSite site = new SPSite(pSiteUrl))
                {
                    LogMessage(DateTime.Now + ":  started purging Site Recycle Bin");
                    LogMessage(DateTime.Now + ":   " + site.RecycleBin.Count + " items in Site Recycle Bin");

                    SPRecycleBinQuery query = new SPRecycleBinQuery();
                    query.RowLimit = pMaxRecycleBinDelete;
                    SPRecycleBinItemCollection recycleitems = site.GetRecycleBinItems(query);

                    if (_ReportOnly == false) // delete items
                    {
                        foreach (SPRecycleBinItem item in recycleitems)
                        {
                            if (item.DirName.Contains(_ListName)) // item is from the Workflow History list
                            {
                                item.Delete();
                                _SiteRecycleBinCounter++;
                            }
                        }
                        LogMessage(DateTime.Now + ":   MaxRecycleBinDelete: " + pMaxRecycleBinDelete);
                        LogMessage(DateTime.Now + ":   " + _SiteRecycleBinCounter + " items purged");
                        LogMessage(DateTime.Now + ":  finished purging Site Recycle Bin");
                    }
                    else // in Report Mode - read-only
                    {
                        foreach (SPRecycleBinItem item in recycleitems)
                        {
                            if (item.DirName.Contains(_ListName)) // item is from the Workflow History list
                            {
                                _SiteRecycleBinCounter++;
                            }
                        }
                        LogMessage(DateTime.Now + ":   running in Report Mode (read-only)");
                        LogMessage(DateTime.Now + ":   MaxRecycleBinDelete: " + pMaxRecycleBinDelete);
                        LogMessage(DateTime.Now + ":   " + _SiteRecycleBinCounter + " items will be deleted");
                        LogMessage(DateTime.Now + ":  finished purging Site Recycle Bin");
                    }
                } // end using 
                return true;
            } // end try
            catch (Exception ex)
            {
                LogMessage(DateTime.Now + ":  ERROR in PurgeSiteRecycleBin: " + ex.Message);
                LogMessage(DateTime.Now + ":  finished purging Site Recycle Bin");
                return false;
            }
        }

        static bool CreateLogFile(string pLogFileName)
        {
            try
            {
                // Create the file
                using (StreamWriter writer = File.CreateText(_LogFileName))
                {
                    writer.WriteLine("CleanupWorkflowHistory");  // closed by Using statement
                    writer.WriteLine("======================");
                    writer.WriteLine("SiteUrl: " + _SiteUrl);
                    writer.WriteLine("ListName: " + _ListName);
                    writer.WriteLine("NumDays: " + _NumDays);
                    writer.WriteLine("MaxHistoryListDelete: " + _MaxHistoryListDelete);
                    writer.WriteLine("MaxRecycleBinDelete: " + _MaxRecycleBinDelete);
                    writer.WriteLine("PermanentDelete: " + _PermanentDelete);
                    writer.WriteLine("ReportOnly: " + _ReportOnly);
                    writer.WriteLine("LogFileName: " + _LogFileName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create logfile {0}", ex.Message);
                return false;
            }
        }

        static bool LogMessage(string pInput)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(_LogFileName))
                {
                    Console.WriteLine(pInput);
                    writer.WriteLine(pInput);  // closed by Using statement
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to append logfile {0}", ex.Message);
                return false;
            }
        } 

        static void ShowUsage()
        {
            Console.WriteLine("CleanupWorkflowHistory.exe SiteUrl ListName NumDays MaxHistoryListDelete PermanentDelete ReportOnly");
            Console.WriteLine("");
            Console.WriteLine("Usage:");
            Console.WriteLine("SiteUrl - URL to the SharePoint site");
            Console.WriteLine("ListName - Name of the Workflow History list");
            Console.WriteLine("NumDays - Delete items with Modified date < [Today - NumDays])");
            Console.WriteLine("MaxHistoryListDelete - Maximum number to delete from Workflow History list");
            Console.WriteLine("MaxRecycleBinDelete - Maximum number to delete from Recycle Bin");
            Console.WriteLine("PermanentDelete - Permanently delete the list items from the Recycle Bin");
            Console.WriteLine("ReportOnly - Run in read-only mode");
            Console.WriteLine("LogFileName - Name of the file to use for logging (overwrite if it exists)");
            Console.WriteLine("");
            Console.WriteLine("Example:");
            Console.WriteLine("CleanupWorkflowHistory.exe http://moss/dematic_tools/TimTest 'Workflow History' 60 100 100 false true Cleanup.log");
        }
    }
}
