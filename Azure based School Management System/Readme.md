# Azure based School Management System
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Forms
- Microsoft Azure
- C# Language
- Visual C#
- Visual Studio 2015
## Topics
- C#
- Windows Forms
- Microsoft Azure
- User Experience
- data and storage
## Updated
- 01/19/2016
## Description

<h1>Introduction</h1>
<p><em>The code sample is a C# windows forms school management system. The system has cloud capabilities as it can connect to the user's Azure SQL database. The system has several functionalities like student enrollment menu, income statement, balance sheet,
 help menu, student academic menu. This is a sample application so there is a lot of room for the user to add functionality that suit their needs.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample is constituted of simple and user friendly menus for student enrollments, student academic information, income statement, and balance sheet. The sample features a log in screen for added security. The user can import student data from a text
 file found locally or by connecting to an Azure SQL database. This sample provides the code to connect to the Azure SQL database but the user must have an Azure account to be able to create the database and retreive the connection strings needed.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Below is the code snippet to connect to an Azure SQL database, more information can be found by consulting documentation on Azure's website.<br>
<em>&nbsp;</em></p>
<p><em>some classes have been created for the user, but it is up to the user to exclude them from the project if needed. &nbsp;
<br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> try
            {
                // Connect to SQL DB assumed to be populated with student data
               
                //Retreive student data
                using (var conn = new SqlConnection(&quot;Server=tcp:SERVER NAME.database.windows.net,1433;Database=DB_NAME;User ID=USER_NAME@SERVER_NAME;Password=INSERT PASSWORD;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;&quot;))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @&quot;
                    SELECT * FROM Students,   
                    ORDER BY lastName;&quot;;
                    // we assume that the needed tables are created in the DB and that the academic info of the students is inserted there
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox1.AppendText(&quot;ID: {0} Name: {1} Order Count: {2}&quot; &#43; reader.GetInt32(0) &#43; reader.GetString(1) &#43; reader.GetInt32(2));
                        }
                    }
                }
            }


            catch (Exception)
            {

                textBox1.Text = &quot;Error in retreiving data from SQL Database&quot;;
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Connect&nbsp;to&nbsp;SQL&nbsp;DB&nbsp;assumed&nbsp;to&nbsp;be&nbsp;populated&nbsp;with&nbsp;student&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retreive&nbsp;student&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(<span class="cs__string">&quot;Server=tcp:SERVER&nbsp;NAME.database.windows.net,1433;Database=DB_NAME;User&nbsp;ID=USER_NAME@SERVER_NAME;Password=INSERT&nbsp;PASSWORD;Encrypt=True;TrustServerCertificate=False;Connection&nbsp;Timeout=30;&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;cmd&nbsp;=&nbsp;conn.CreateCommand();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;@&quot;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;*&nbsp;FROM&nbsp;Students,&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ORDER&nbsp;BY&nbsp;lastName;&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;we&nbsp;assume&nbsp;that&nbsp;the&nbsp;needed&nbsp;tables&nbsp;are&nbsp;created&nbsp;in&nbsp;the&nbsp;DB&nbsp;and&nbsp;that&nbsp;the&nbsp;academic&nbsp;info&nbsp;of&nbsp;the&nbsp;students&nbsp;is&nbsp;inserted&nbsp;there</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Open();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;reader&nbsp;=&nbsp;cmd.ExecuteReader())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(reader.Read())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.AppendText(<span class="cs__string">&quot;ID:&nbsp;{0}&nbsp;Name:&nbsp;{1}&nbsp;Order&nbsp;Count:&nbsp;{2}&quot;</span>&nbsp;&#43;&nbsp;reader.GetInt32(<span class="cs__number">0</span>)&nbsp;&#43;&nbsp;reader.GetString(<span class="cs__number">1</span>)&nbsp;&#43;&nbsp;reader.GetInt32(<span class="cs__number">2</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Error&nbsp;in&nbsp;retreiving&nbsp;data&nbsp;from&nbsp;SQL&nbsp;Database&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em>For more information on Azure, you can check Azure documentation, Microsoft Virtual Academy, and Channel 9.<br>
</em></p>
