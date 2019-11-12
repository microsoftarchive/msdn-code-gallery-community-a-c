
#region "  Authors / Credit  "
/*--------------------------------------------------------------------------------------------------------------------
| Purpose:              This application uses LDAP (Lightweight Directory Access Protocol) to access Active Directory
| References:           http://www.planet-source-code.com/vb/scripts/ShowCode.asp?txtCodeId=5006&lngWId=10
|                       http://www.developerfusion.com/tools/convert/vb-to-csharp/
| 
| Ver.  Date            Author              Details
| 1.01  12-APR-2010     Anthony Duguid      formatting changes and save file function without the need for the Excel dll
| 1.02  06-JUL-2011     Anthony Duguid      converted to C#.NET 2010
|--------------------------------------------------------------------------------------------------------------------*/
#endregion

using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
//using System.Collections.Specialized;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
//using Microsoft.Win32;
using ADSearch.Scripts;
using ActiveDs;

namespace ADSearch.Forms
{
    public partial class Explorer : Form
    {
        private DirectoryEntry deBase;
        private ListviewSort lvwColumnSorter;

        #region "  Form  "

        /// <summary>
        /// Create an instance of a ListView column sorter and assign it to the ListView control.
        /// </summary>
        public Explorer()
        {
            InitializeComponent();
            lvwColumnSorter = new ListviewSort();
            this.lvwAttributes.ListViewItemSorter = lvwColumnSorter;
        }

        /// <summary>
        /// Open last treenode if exists
        /// </summary>
        /// <param name="sender">contains the sender of the event, so if you had one method bound to multiple controls, you can distinguish them.</param>
        /// <param name="e">refers to the event arguments for the used event, they usually come in the form of properties/functions/methods that get to be available on it.</param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = ADSearch.Scripts.AssemblyInfo.Description;
            this.tslVersion.Text = ADSearch.Scripts.AssemblyInfo.AssemblyVersion;
            this.tslReleaseDate.Text = File.GetLastWriteTime(Application.ExecutablePath).ToString("dd-MMM-yyyy  hh:mm tt");
            this.tslCopyright.Text = "© " + ADSearch.Scripts.AssemblyInfo.Copyright;
            LoadComboBox(this.cboDomain, Properties.Settings.Default.App_DomainList);
            this.cboDomain.Text = Properties.Settings.Default.App_CompanyDomain;
            subRootNode();
            ADSearch.Scripts.AssemblyInfo.SetAddRemoveProgramsIcon("ADSearch.ico");
        }

        #endregion

        #region "  Toolbar  "

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboFindItems_DropDownClosed(object sender, EventArgs e)
        {
            FindItem(this.cboFindItems.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboFindItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int keyAscii = Convert.ToInt32(e.KeyChar);
                e.KeyChar = Convert.ToChar(keyAscii);
                if (keyAscii == 13)
                {
                    FindItem(this.cboFindItems.Text);
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.DisplayMessage(ex);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            string strFileName = this.tvwGroups.SelectedNode.Text;
            exportListViewToCsv(strFileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbFind_Click(object sender, EventArgs e)
        {
            FindItem(this.cboFindItems.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbFindDevice_Click(object sender, EventArgs e)
        {
            string value = "";
            string strFind = "";
            string strParam = "";
            if (ADSearch.Scripts.DialogBox.InputBox("Find Device (nbtstat)", "Enter a parameter and keyword. (-a 'Machine Name' or -A 'IP address')", ref value) == DialogResult.OK)
            {
                strFind = value;
            }
            if (string.IsNullOrEmpty(strFind))
                return;
            //defaults to machine search
            if (strFind.IndexOf("-") == -1)
            {
                strParam = "-a";
            }
            string strMsg = RunCmd(strParam, strFind);

            Message f = new Message();
            f.Text = strMsg;
            f.Title = strFind;
            f.ShowDialog();

            //MessageBox.Show(strMsg, "Log of " + strFind, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSettings_Click(object sender, EventArgs e)
        {
            Settings f = new Settings();
            f.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbUserList_Click(object sender, EventArgs e)
        {
            GetUsersInGroup(cboFindItems.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDomain_DropDownClosed(object sender, EventArgs e)
        {
            Properties.Settings.Default.App_CompanyDomain = this.cboDomain.Text;
            subRootNode();
        }

        #endregion

        #region "  Listview  "

        /// <summary>
        /// Set the ListViewItemSorter property to a new ListViewItemComparer object. Determine whether the column is the same as the last column clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwAttributes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwAttributes.Sort();

        }

        /// <summary>
        /// Search the properties of the selected value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwAttributes_DoubleClick(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i <= this.lvwAttributes.SelectedItems.Count - 1; i++)
            {
                string strTemp = this.lvwAttributes.SelectedItems[i].SubItems[1].Text;

                if (strTemp.Length > 0)
                {
                    FindItem(strTemp);
                }

                //string strName = lvwAttributes.SelectedItems[i].Text;
                //switch (strName)
                //{
                //    case "member":
                //    case "memberOf":
                //    case "CurrentMachine":
                //    case "LanID":
                //string strTemp = this.lvwAttributes.SelectedItems[i].SubItems[1].Text;
                        //FindItem(strTemp);
                        //break;              
                //}
            }
        }

        #endregion

        #region "  Treeview  "

        /// <summary>
        /// Fills listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string strAttributeValue = "";
                string strFormatValue = "";
                string strFileName = "";
                DirectoryEntry list = (DirectoryEntry)e.Node.Tag;
                if (this.tvwGroups.SelectedNode.Text != null)
                {
                    strFileName = this.tvwGroups.SelectedNode.Text;
                    Properties.Settings.Default.Form_LastObject = strFileName;
                }
                this.lvwAttributes.Clear();
                this.lvwAttributes.Columns.Add("Attribute", 150, HorizontalAlignment.Left);
                this.lvwAttributes.Columns.Add("Format Value", 150, HorizontalAlignment.Left);
                this.lvwAttributes.Columns.Add("Value", 475, HorizontalAlignment.Left);
                this.lvwAttributes.Columns.Add("Name", 0, HorizontalAlignment.Left);
                foreach (object listIter in list.Properties.PropertyNames)
                {
                    foreach (Object iter in list.Properties[listIter.ToString()])
                    {
                        ListViewItem item = new ListViewItem(listIter.ToString(), 0);
                        //Needed in order to convert these types to a type that is viewable.
                        switch (iter.GetType().ToString())
                        {
                            case "System.__ComObject":
                                //strAttributeValue = iter.ToString(); 
                                strAttributeValue = AdsDateValue(iter);
                                strFormatValue = "* DateTime";
                                break;
                            case "System.Byte[]":
                                strAttributeValue = Convert.ToString(iter);  //not sure if this is working... ALD 2011-JUL-11
                                strFormatValue = "* System.Byte[]";
                                //strFormatValue = System.Text.Encoding.UTF8.GetString(Convert.ToByte(iter));
                                //strFormatValue = System.Text.Encoding.UTF8.GetString(ObjectToBytes(iter));
                                break;
                            default:
                                try
                                {
                                    DateTime dt = DateTime.Parse(iter.ToString());  // format if string is a date
                                    strAttributeValue = dt.ToString("dd-MMM-yyyy h:mm tt").ToUpper();
                                    strFormatValue = "* DateTime";
                                }
                                catch
                                {
                                    strAttributeValue = iter.ToString();
                                    strFormatValue = "";  // have to reset this
                                }
                                break;
                        }
                        string strAttribute = listIter.ToString();
                        switch (strAttribute)
                        {
                            case "member":
                            case "memberOf":
                                string[] strItems = strAttributeValue.Split(Convert.ToChar(","));  // load into an array
                                strFormatValue = strItems[0].Replace("CN=", "");
                                if (strFormatValue.Contains("\\"))
                                {
                                    strFormatValue = strFormatValue.Replace("\\", "");  // admins put \ in the user's full name, yea!?
                                    strFormatValue += "," + strItems[1].Replace("CN=", "");  // last, first name - thanks again for changing the format admins
                                }
                                break;
                        }
                        item.SubItems.Add(strFormatValue);
                        item.SubItems.Add(strAttributeValue);
                        item.SubItems.Add(strFileName);
                        this.lvwAttributes.Items.AddRange(new ListViewItem[] { item });
                    }
                }
                //update form title
                this.Text = Application.ProductName + " (" + strFileName + ")";
            }
            catch (System.Runtime.InteropServices.COMException)
            {

            }
            catch (Exception ex)
            {
                ErrorHandler.DisplayMessage(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwGroups_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (e.Node.ImageIndex > 4)
                return;
            try
            {
                if (e.Node.GetNodeCount(false) == 1 & string.IsNullOrEmpty(e.Node.Nodes[0].Text))
                {
                    e.Node.Nodes[0].Remove();
                    subEnumerateChildren(e.Node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to expand " + e.Node.FullPath + ":" + ex.ToString());
            }
            if (e.Node.GetNodeCount(false) > 0)
            {
                switch (e.Node.ImageIndex)
                {
                    case 1:
                    case 3:
                        e.Node.ImageIndex = e.Node.ImageIndex + 1;
                        e.Node.SelectedImageIndex = e.Node.SelectedImageIndex + 1;
                        break;
                }
            }

            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwGroups_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            switch (e.Node.ImageIndex)
            {
                case 2:
                case 4:
                    e.Node.ImageIndex = e.Node.ImageIndex - 1;
                    e.Node.SelectedImageIndex = e.Node.SelectedImageIndex - 1;
                    break;
            }
        }

        #endregion

        #region "  Functions  "

        /// <summary>
        /// Format the attribute as a date
        /// </summary>
        /// <param name="oV">the attribute for a active directory object</param>
        /// <returns>returns formatted date value</returns>
        public string AdsDateValue(object oV)
        {
            try
            {
                IADsLargeInteger v = (IADsLargeInteger)oV;
                long dV = Convert.ToInt64(v.HighPart) * 4294967296L + Convert.ToInt64(v.LowPart);
                DateTime xDate = System.DateTime.FromFileTime(dV);
                return xDate.ToString("dd-MMM-yyyy h:mm tt").ToUpper();

            }
            catch
            {
                DateTime xDate = System.DateTime.MinValue;
                return xDate.ToString("dd-MMM-yyyy h:mm tt").ToUpper();

            }
        }

        /// <summary>
        /// Export the contents of a listview to a .csv file
        /// </summary>
        /// <param name="pstrName">part of the file name</param>
        /// <returns>has the function completed without error</returns>
        public bool exportListViewToCsv(string pstrName)
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string strFileName = strPath + "\\ActiveDirectory_" + pstrName + ".csv";
            ListView lv = this.lvwAttributes;
            try
            {
                System.IO.StreamWriter os = new System.IO.StreamWriter(strFileName);  // Open output file  

                // Write Headers  
                for (int i = 0; i <= lv.Columns.Count - 1; i++)
                {
                    // replace quotes with double quotes if necessary  
                    os.Write("\"" + lv.Columns[i].Text.Replace("\"", "\"\"") + "\",");
                }
                os.WriteLine(); //create headers

                // Write records 
                for (int i = 0; i <= lv.Items.Count - 1; i++)
                {
                    //if (lv.Items(i).SubItems(0).Text == "memberOf" | lv.Items(i).SubItems(0).Text == "member")  // Export all instead
                    //{
                    for (int j = 0; j <= lv.Columns.Count - 1; j++)
                    {
                        os.Write(lv.Items[i].SubItems[j].Text.Replace(",", ";") + ",");
                    }
                    os.WriteLine();
                    //}

                }
                os.Close();
                Process.Start(strFileName); //open file

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return (false);
            }

            return (true);

        }

        /// <summary>
        /// Search for user by machine name
        /// </summary>
        /// <param name="pstrParam">parameter(s) for nbtstat</param>
        /// <param name="pstrAttr">computer name</param>
        /// <returns>the results from the command prompt</returns>
        public string RunCmd(string pstrParam = "", string pstrAttr = "")
        {
            Process p = new Process();
            string strCmd = null;
            try
            {
                strCmd = System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\cmd.exe";
                p.StartInfo.FileName = strCmd;
                p.StartInfo.Arguments = "/C nbtstat " + pstrParam + " " + pstrAttr;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                string strMsg = p.StandardOutput.ReadToEnd();
                p.Close();
                return strMsg;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;

            }
            finally
            {
                if ((p != null))
                {
                    //p.Dispose();
                    p = null;
                }
            }

        }

        #endregion

        #region "  Subroutine  "

        /// <summary>
        /// To create the initial node for the domain
        /// </summary>
        public void subRootNode()
        {
            try
            {
                this.tvwGroups.Nodes.Clear();
                deBase = new DirectoryEntry("LDAP://" + this.cboDomain.Text);
                TreeNode oRootNode = this.tvwGroups.Nodes.Add(deBase.Path);
                oRootNode.Tag = deBase;
                oRootNode.Text = deBase.Name.Substring(3);
                oRootNode.Nodes.Add("");
                ExpandNode(this.tvwGroups, this.tvwGroups.TopNode.FullPath.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot create initial node: " + ex.ToString());
                System.Environment.Exit(0);
            }
        }

        /// <summary>
        /// associate icons with tree nodes
        /// </summary>
        /// <param name="oRootNode">node from tree</param>
        public void subEnumerateChildren(TreeNode oRootNode)
        {
            DirectoryEntry deParent = (DirectoryEntry)oRootNode.Tag;
            foreach (DirectoryEntry deChild in deParent.Children)
            {
                TreeNode oChildNode = oRootNode.Nodes.Add(deChild.Path);
                switch (deChild.SchemaClassName)
                {
                    case "computer":
                        oChildNode.ImageIndex = 6;
                        oChildNode.SelectedImageIndex = 6;
                        break;
                    case "user":
                        oChildNode.ImageIndex = 7;
                        oChildNode.SelectedImageIndex = 7;
                        break;
                    case "group":
                        oChildNode.ImageIndex = 8;
                        oChildNode.SelectedImageIndex = 8;
                        break;
                    case "organizationalUnit":
                        oChildNode.ImageIndex = 3;
                        oChildNode.SelectedImageIndex = 3;
                        oChildNode.Nodes.Add("");
                        break;
                    case "container":
                        oChildNode.ImageIndex = 1;
                        oChildNode.SelectedImageIndex = 1;
                        oChildNode.Nodes.Add("");
                        break;
                    case "publicFolder":
                        oChildNode.ImageIndex = 5;
                        oChildNode.SelectedImageIndex = 5;
                        oChildNode.Nodes.Add("");
                        break;
                    default:
                        oChildNode.ImageIndex = 1;
                        oChildNode.SelectedImageIndex = 1;
                        oChildNode.Nodes.Add("");
                        break;
                }
                oChildNode.Tag = deChild;
                oChildNode.Text = deChild.Name.Substring(3).Replace("\\", "");
            }
        }

        /// <summary>
        /// Expand the tree node
        /// </summary>
        /// <param name="objTreeView">The treeview object</param>
        /// <param name="fullNodePath">The node oject</param>
        public void ExpandNode(TreeView objTreeView, string fullNodePath)
        {
            Int32 i = 0;
            string buf = "";
            string pathSep = objTreeView.PathSeparator;
            for (i = 0; i <= objTreeView.Nodes.Count - 1; i++)
            {
                buf = fullNodePath.Split(pathSep.ToCharArray())[0];
                if (objTreeView.Nodes[i].Text.Substring(0, buf.Length) == fullNodePath.Split(pathSep.ToCharArray())[0])
                {
                    OpenNodes(objTreeView.Nodes[i], fullNodePath, pathSep, 1);
                    return;
                }
            }

        }

        /// <summary>
        /// Search for anything in active directory
        /// </summary>
        /// <param name="pstrFind">Search text</param>
        public void FindItem(string pstrFind = "")
        {
            try
            {
                string value = "";
                string strFind = "";
                if (pstrFind == "")
                {
                    if (ADSearch.Scripts.DialogBox.InputBox("Find", "Enter the Active Directory object you wish to find?", ref value) == DialogResult.OK)
                    {
                        if (value != "")
                        {
                            strFind = value;
                        }
                        else
                        {
                            return; // nothing entered =""
                        }
                    }
                    else
                    {
                        return; // user cancelled
                    }
                }
                else
                {
                    strFind = pstrFind;
                }
                this.Cursor = Cursors.WaitCursor;
                DirectorySearcher objSearch = new DirectorySearcher();
                SearchResult queryResults = default(SearchResult);
                objSearch.SearchRoot = new DirectoryEntry("LDAP://" + this.cboDomain.Text);
                objSearch.SearchScope = SearchScope.Subtree;
                objSearch.PropertiesToLoad.Add("cn");
                objSearch.Filter = "(sAMAccountName=" + strFind + ")";
                queryResults = objSearch.FindOne();
                if (queryResults == null)
                {
                    objSearch.Filter = "(sAMAccountName=" + strFind + "$)";
                    queryResults = objSearch.FindOne();
                }
                if (queryResults == null)
                {
                    objSearch.Filter = "(mail=" + strFind + ")";
                    queryResults = objSearch.FindOne();
                }
                if (queryResults == null)
                {
                    objSearch.Filter = "(SN=" + strFind + ")";
                    queryResults = objSearch.FindOne();
                }
                if (queryResults == null)
                {
                    objSearch.Filter = "(cn=" + strFind + ")";
                    queryResults = objSearch.FindOne();
                }
                if (queryResults == null)
                {
                    MessageBox.Show("Nothing found matching your search criteria!", "Nothing Found!", MessageBoxButtons.OK);
                    return;
                }
                //Format path needed by the ExpandNode procedure.
                string[] nodeToFind = queryResults.Path.Split(Convert.ToChar(","));
                Array.Reverse(nodeToFind);
                string findIt = objSearch.SearchRoot.Name.Substring(3);
                for (int x = 0; x <= nodeToFind.GetUpperBound(0); x++)
                {
                    string test1 = nodeToFind[x].Substring(0, 2);
                    if (test1 == "OU")
                    {
                        findIt = findIt + "\\" + nodeToFind[x].Substring(3);
                    }
                }
                var strCN = queryResults.Properties["CN"][0].ToString();
                if (strCN == null == false)
                {
                    findIt = findIt + "\\" + strCN;
                }
                ExpandNode(this.tvwGroups, findIt);
                if (cboFindItems.Items.Contains(strFind) == false)
                {
                    this.cboFindItems.Items.Insert(0, strFind);
                    this.cboFindItems.Text = strFind;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        public void GetUsersInGroup(string groupName)
        {
            string domainName = Properties.Settings.Default.App_CompanyDomain;
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);
            ListView lvwListView = this.lvwAttributes;
            ListViewItem itmListItem = default(ListViewItem);
            lvwListView.Clear();
            lvwListView.Columns.Add("Name", 175, HorizontalAlignment.Left);
            lvwListView.Columns.Add("LanID", 100, HorizontalAlignment.Left);
            lvwListView.Columns.Add("Email", 225, HorizontalAlignment.Left);
            lvwListView.Columns.Add("Office", 150, HorizontalAlignment.Left);
            lvwListView.Columns.Add("Title", 200, HorizontalAlignment.Left);
            lvwListView.Columns.Add("Phone Number", 150, HorizontalAlignment.Left);
            lvwListView.Columns.Add("When Created", 150, HorizontalAlignment.Left);

            if (grp != null)
            {
                foreach (Principal p in grp.GetMembers(false))
                {
                    itmListItem = new ListViewItem();
                    itmListItem.Text = p.Name;
                    itmListItem.SubItems.Add(p.SamAccountName);

                    if (p.StructuralObjectClass == "user")
                    {
                        var uP = (UserPrincipal)p;
                        if (uP != null)
                        {
                            itmListItem.SubItems.Add(uP.EmailAddress);
                        }
                    }
                    var creationDate = string.Empty;
                    var physicaldeliveryofficename = string.Empty;
                    var title = string.Empty;
                    var telephoneNumber = string.Empty;
                    var prop = string.Empty;
                    var directoryEntry = p.GetUnderlyingObject() as DirectoryEntry;
                    prop = "whenCreated";
                    if (directoryEntry.Properties.Contains(prop))
                    {
                        creationDate = directoryEntry.Properties[prop].Value.ToString();
                    }
                    prop = "physicaldeliveryofficename";
                    if (directoryEntry.Properties.Contains(prop))
                    {
                        physicaldeliveryofficename = directoryEntry.Properties[prop].Value.ToString();
                    }
                    prop = "title";
                    if (directoryEntry.Properties.Contains(prop))
                    {
                        title = directoryEntry.Properties[prop].Value.ToString();
                    }
                    prop = "telephoneNumber";
                    if (directoryEntry.Properties.Contains(prop))
                    {
                        telephoneNumber = directoryEntry.Properties[prop].Value.ToString();
                    }
                    itmListItem.SubItems.Add(physicaldeliveryofficename);
                    itmListItem.SubItems.Add(title);
                    itmListItem.SubItems.Add(telephoneNumber);
                    itmListItem.SubItems.Add(creationDate);
                    lvwListView.Items.Add(itmListItem);
                    lvwListView.Refresh();
                    itmListItem = null;
                    this.Text = Application.ProductName + " (" + groupName + ")";
                }
                
                grp.Dispose();
                ctx.Dispose();
                }

        }
        
        /// <summary>
        /// Open the treeview node
        /// </summary>
        /// <param name="iNode">The treeview node object</param>
        /// <param name="nPath">The path of the treeview node</param>
        /// <param name="nPathSep">The path step of n of the active directory object</param>
        /// <param name="dirIndex">The directory index of the active directory object</param>
        public void OpenNodes(TreeNode iNode, string nPath, string nPathSep, Int32 dirIndex)
        {
            Int32 i = 0;
            Int32 pLen = 0;
            string buf = "";
            iNode.Expand();
            iNode.EnsureVisible();
            pLen = nPath.Split(nPathSep.ToCharArray()).Length - 1;
            if (pLen >= dirIndex)
            {
                for (i = 0; i <= dirIndex; i++)
                {
                    buf += nPath.Split(nPathSep.ToCharArray())[i] + nPathSep;
                    Application.DoEvents();
                }
                try
                {
                    for (i = 0; i <= iNode.Nodes.Count - 1; i++)
                    {
                        if (iNode.Nodes[i].FullPath + nPathSep == buf)
                        {
                            OpenNodes(iNode.Nodes[i], nPath, nPathSep, dirIndex + 1);
                            return;
                        }
                        Application.DoEvents();
                    }
                }
                catch
                {
                }
            }
            else
            {
                iNode.TreeView.SelectedNode = iNode;
            }
        }

        /// <summary>
        /// Load a combobox from a comma separated string of text
        /// </summary>
        /// <param name="pcboComboBox">The combobox object</param>
        /// <param name="pstrList">The comma separated string of text</param>
        public void LoadComboBox(ToolStripComboBox pcboComboBox, string pstrList = "")
        {
            string[] arrList = null;
            int i = 0;
            arrList = pstrList.Split((",").ToCharArray());
            pcboComboBox.Items.Clear();
            for (i = 0; i <= arrList.GetUpperBound(0); i++)
            {
                pcboComboBox.Items.Add((arrList[i]).Trim());
            }

        }

        #endregion

    }
}
