# Broadcast Real-time SQL data using SignalR
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET Framework
- SignalR
- ASP.NET SignalR
- SignalR 2.0
## Topics
- Broadcast data using SIgnalR
- How to show data using SignalR
- How to load sql data without page refresh
- how to get notification without page refresh
- how to display data without page refresh
- how to user signalr in asp.net
- signalr with asp.net
## Updated
- 03/31/2014
## Description

<p><strong><span style="font-size:small">Introduction</span></strong></p>
<p><span style="font-size:small"><strong>SignalR &ndash; </strong>SignalR is an ASP.Net server library for adding real-time functionality to a web application. This includes client libraries for JavaScript and other clients.<strong>&nbsp;</strong></span></p>
<p><span style="font-size:small">Building the Sample</span></p>
<p><span style="font-size:small"><strong>Getting started</strong></span><br>
<br>
<span style="font-size:small">to get started with SignalR:</span></p>
<ul>
<li>
<p><span style="font-size:small">Start Visual Studio 2013</span></p>
</li><li>
<p><span style="font-size:small">Create a new website</span></p>
</li><li>
<p><span style="font-size:small">Provide the name and location of website</span></p>
</li><li>
<p><span style="font-size:small">Click &quot;Next&quot;</span></p>
</li></ul>
<p><strong style="font-size:small">Install SignalR</strong></p>
<p><span style="font-size:small"><strong><br>
</strong>Click &quot;Tools&quot; | &quot;Library Package Manager&quot; | &quot;Package Manager Console&quot; and run&nbsp;the command: &quot;<strong>install-package Microsoft.AspNet.SignalR&quot;</strong></span></p>
<p><span style="font-size:small">&nbsp;<img id="111435" src="111435-img1.jpg" alt=""></span></p>
<p><span style="font-size:small">Screenshot 1.</span><br>
<br>
<span style="font-size:small">Or&nbsp;</span><br>
<br>
<span style="font-size:small">Install using NuGet package Manager, right-click on &quot;Project&quot; and click on &quot;Manage Nuget packages&quot; and search for &quot;SignalR&quot; then click &quot;Install&quot;.</span></p>
<p><span style="font-size:small">&nbsp;<img id="111436" src="111436-img2.jpg" alt="" width="298" height="462"></span></p>
<p><span style="font-size:small">Screenshot 2.</span></p>
<p><span style="font-size:small">This is my database table screenshot.</span></p>
<p><span style="font-size:small"><img id="111437" src="111437-img3.jpg" alt="" width="732" height="411">&nbsp;</span></p>
<p><span style="font-size:small">Screenshot 3.</span></p>
<p><span style="font-size:small">Now define connection string in web.config.</span></p>
<p><span style="font-size:small">&lt;connectionStrings&gt;</span></p>
<p><span style="font-size:small">&lt;add name=&quot;DefaultConnection&quot; connectionString=&quot;data source=SERVER-NAME;database=DATABASENAME;user id =USERID;password=PASSOWRD&quot; providerName=&quot;System.Data.SqlClient&quot; /&gt;</span></p>
<p><span style="font-size:small">&lt;/connectionStrings&gt;</span></p>
<p><span style="font-size:small">Now add a new hub class</span></p>
<p><span style="font-size:small">&nbsp;<img id="111439" src="111439-img4.jpg" alt="" width="951" height="539"></span></p>
<p><span style="font-size:small">Screenshot 4.</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p class="scriptcode"></p>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>
<pre class="hidden"><span style="font-size:small">NotificationHub.cs

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

[HubName(&quot;notificationHub&quot;)]
public class NotificationHub : Hub
{
    private static readonly ConcurrentDictionary&lt;string, User&gt; Users = new ConcurrentDictionary&lt;string, User&gt;(StringComparer.InvariantCultureIgnoreCase);

    #region Methods
    /// &lt;summary&gt;
    /// Provides the handler for SignalR OnConnected event
    /// supports async threading
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public override Task OnConnected()
    {
        string profileId = &quot;111&quot;; //Context.QueryString[&quot;id&quot;];
        string connectionId = Context.ConnectionId;
        var user = Users.GetOrAdd(profileId, _ =&gt; new User
        {
            ProfileId = profileId,
            ConnectionIds = new HashSet&lt;string&gt;()
        });
        lock (user.ConnectionIds)
        {
            user.ConnectionIds.Add(connectionId);
            Groups.Add(connectionId, user.ProfileId);
        }
        return base.OnConnected();
    }

    /// &lt;summary&gt;
    /// Provides the handler for SignalR OnDisconnected event
    /// supports async threading
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public override Task OnDisconnected()
    {
        string profileId = Context.QueryString[&quot;id&quot;];
        string connectionId = Context.ConnectionId;
        User user;
        Users.TryGetValue(profileId, out user);
        if (user != null)
        {
            lock (user.ConnectionIds)
            {
                user.ConnectionIds.RemoveWhere(cid =&gt; cid.Equals(connectionId));
                Groups.Remove(connectionId, user.ProfileId);
                if (!user.ConnectionIds.Any())
                {
                    User removedUser;
                    Users.TryRemove(profileId, out removedUser);
                }
            }
        }
        return base.OnDisconnected();
    }

    /// &lt;summary&gt;
    /// Provides the handler for SignalR OnReconnected event
    /// supports async threading
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public override Task OnReconnected()
    {
        return base.OnReconnected();
    }

    /// &lt;summary&gt;
    /// Provides the facility to send individual user notification message
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;profileId&quot;&gt;
    /// Set to the ProfileId of user who will receive the notification
    /// &lt;/param&gt;
    /// &lt;param name=&quot;message&quot;&gt;
    /// set to the notification message
    /// &lt;/param&gt;
    public void Send(string profileId, string message)
    {
        //Clients.User(profileId).send(message);
    }

    /// &lt;summary&gt;
    /// Provides the facility to send group notification message
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;username&quot;&gt;
    /// set to the user groupd name who will receive the message
    /// &lt;/param&gt;
    /// &lt;param name=&quot;message&quot;&gt;
    /// set to the notification message
    /// &lt;/param&gt;
    public void SendUserMessage(String username, String message)
    {
        Clients.Group(username).sendUserMessage(message);
    }

    /// &lt;summary&gt;
    /// Provides the ability to get User from the dictionary for passed in profileId
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;profileId&quot;&gt;
    /// set to the profileId of user that need to be fetched from the dictionary
    /// &lt;/param&gt;
    /// &lt;returns&gt;
    /// return User object if found otherwise returns null
    /// &lt;/returns&gt;
    private User GetUser(string profileId)
    {
        User user;
        Users.TryGetValue(profileId, out user);
        return user;
    }

    /// &lt;summary&gt;
    /// Provide theability to get currently connected user
    /// &lt;/summary&gt;
    /// &lt;returns&gt;
    /// profileId of user based on current connectionId
    /// &lt;/returns&gt;
    public IEnumerable&lt;string&gt; GetConnectedUser()
    {
        return Users.Where(x =&gt;
        {
            lock (x.Value.ConnectionIds)
            {
                return !x.Value.ConnectionIds.Contains(Context.ConnectionId, StringComparer.InvariantCultureIgnoreCase);
            }
        }).Select(x =&gt; x.Key);
    }
    #endregion

    Int16 totalNewMessages = 0;
    Int16 totalNewCircles = 0;
    Int16 totalNewJobs = 0;
    Int16 totalNewNotification = 0;

    [HubMethodName(&quot;sendNotifications&quot;)]
    public string SendNotifications()
    {
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[&quot;DefaultConnection&quot;].ConnectionString))
        {
            string query = &quot;SELECT  NewMessageCount, NewCircleRequestCount, NewNotificationsCount, NewJobNotificationsCount FROM [dbo].[Modeling_NewMessageNotificationCount] WHERE UserProfileId=&quot; &#43; &quot;62021&quot;;
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try { 
                command.Notification = null;
                DataTable dt = new DataTable();
                SqlDependency dependency = new SqlDependency(command);
                dependency.OnChange &#43;= new OnChangeEventHandler(dependency_OnChange);                
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                var reader = command.ExecuteReader();
                dt.Load(reader);
                if (dt.Rows.Count &gt; 0)
                {
                    totalNewMessages = Int16.Parse(dt.Rows[0][&quot;NewMessageCount&quot;].ToString());
                    totalNewCircles = Int16.Parse(dt.Rows[0][&quot;NewCircleRequestCount&quot;].ToString());
                    totalNewJobs = Int16.Parse(dt.Rows[0][&quot;NewJobNotificationsCount&quot;].ToString());
                    totalNewNotification = Int16.Parse(dt.Rows[0][&quot;NewNotificationsCount&quot;].ToString());
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                throw;
            }
            }
        }
        IHubContext context = GlobalHost.ConnectionManager.GetHubContext&lt;NotificationHub&gt;();
        return context.Clients.All.RecieveNotification(totalNewMessages, totalNewCircles, totalNewJobs, totalNewNotification);
    }


    private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
        if (e.Type == SqlNotificationType.Change)
        {
            NotificationHub nHub = new NotificationHub();
            nHub.SendNotifications();
        }
    }
}

Startup.cs
[assembly: OwinStartup(&quot;TestingConfiguration&quot;, typeof(EmployeeStartup))]
    public class EmployeeStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();          
        }
    }
User.cs
    #region Properties

    /// &lt;summary&gt;
    /// Property to get/set ProfileId
    /// &lt;/summary&gt;
    public string ProfileId
    {
        get;
        set;
    }

    /// &lt;summary&gt;
    /// Propoerty to get/set multiple ConnectionId
    /// &lt;/summary&gt;
    public HashSet&lt;string&gt; ConnectionIds
    {
        get;
        set;
    }

    #endregion
}

Index.html
&lt;head&gt;
    &lt;title&gt;New Notifications&lt;/title&gt;
    &lt;script src=&quot;Scripts/jquery-1.6.4.min.js&quot;&gt;&lt;/script&gt;
    &lt;script src=&quot;Scripts/jquery.signalR-2.0.2.min.js&quot;&gt;&lt;/script&gt;        
    &lt;script src=&quot;signalr/hubs&quot;&gt;&lt;/script&gt;
    &lt;script type=&quot;text/javascript&quot;&gt;
        $(function () {            
            // Declare a proxy to reference the hub.
            var notifications = $.connection.notificationHub;
            debugger;
            // Create a function that the hub can call to broadcast messages.
            notifications.client.recieveNotification = function (totalNewMessages, totalNewCircles, totalNewJobs, totalNewNotifications) {
                // Add the message to the page.                
                $('#spanNewMessages').text(totalNewMessages);
                $('#spanNewCircles').text(totalNewCircles);
                $('#spanNewJobNotifications').text(totalNewJobs);
                $('#spanNewNotifications').text(totalNewNotifications);
            };
            // Start the connection.
            $.connection.hub.start().done(function () {
                notifications.server.sendNotifications();
            }).fail(function (e) {
                alert(e);
            });
            //$.connection.hub.start();            
        });
    &lt;/script&gt;
&lt;/head&gt;
&lt;body&gt;
    &lt;h1&gt;Broadcast Realtime SQL data using SignalR&lt;/h1&gt;
    &lt;div&gt;
        &lt;p&gt;You have &lt;span id=&quot;spanNewMessages&quot;&gt;0&lt;/span&gt; New Message Notification.&lt;/p&gt;
        &lt;p&gt;You have &lt;span id=&quot;spanNewCircles&quot;&gt;0&lt;/span&gt; New Circles Notification.&lt;/p&gt;
        &lt;p&gt;You have &lt;span id=&quot;spanNewJobNotifications&quot;&gt;0&lt;/span&gt; New Job Notification.&lt;/p&gt;
        &lt;p&gt;You have &lt;span id=&quot;spanNewNotifications&quot;&gt;0&lt;/span&gt; New Notification.&lt;/p&gt;
    &lt;/div&gt;
&lt;/body&gt;
</span></pre>
<div class="preview">
<pre class="csharp"><span style="font-size:small"><strong>NotificationHub.cs&nbsp;</strong>
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNet.SignalR;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNet.SignalR.Hubs;&nbsp;
&nbsp;
[HubName(<span class="cs__string">&quot;notificationHub&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NotificationHub&nbsp;:&nbsp;Hub&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;ConcurrentDictionary&lt;<span class="cs__keyword">string</span>,&nbsp;User&gt;&nbsp;Users&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ConcurrentDictionary&lt;<span class="cs__keyword">string</span>,&nbsp;User&gt;(StringComparer.InvariantCultureIgnoreCase);<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Methods</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Provides&nbsp;the&nbsp;handler&nbsp;for&nbsp;SignalR&nbsp;OnConnected&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;supports&nbsp;async&nbsp;threading</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnConnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;profileId&nbsp;=&nbsp;<span class="cs__string">&quot;111&quot;</span>;&nbsp;<span class="cs__com">//Context.QueryString[&quot;id&quot;];</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;connectionId&nbsp;=&nbsp;Context.ConnectionId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;Users.GetOrAdd(profileId,&nbsp;_&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;User&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProfileId&nbsp;=&nbsp;profileId,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConnectionIds&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HashSet&lt;<span class="cs__keyword">string</span>&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(user.ConnectionIds)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user.ConnectionIds.Add(connectionId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Groups.Add(connectionId,&nbsp;user.ProfileId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnConnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Provides&nbsp;the&nbsp;handler&nbsp;for&nbsp;SignalR&nbsp;OnDisconnected&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;supports&nbsp;async&nbsp;threading</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnDisconnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;profileId&nbsp;=&nbsp;Context.QueryString[<span class="cs__string">&quot;id&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;connectionId&nbsp;=&nbsp;Context.ConnectionId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;User&nbsp;user;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Users.TryGetValue(profileId,&nbsp;<span class="cs__keyword">out</span>&nbsp;user);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(user&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(user.ConnectionIds)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user.ConnectionIds.RemoveWhere(cid&nbsp;=&gt;&nbsp;cid.Equals(connectionId));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Groups.Remove(connectionId,&nbsp;user.ProfileId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!user.ConnectionIds.Any())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;User&nbsp;removedUser;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Users.TryRemove(profileId,&nbsp;<span class="cs__keyword">out</span>&nbsp;removedUser);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnDisconnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Provides&nbsp;the&nbsp;handler&nbsp;for&nbsp;SignalR&nbsp;OnReconnected&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;supports&nbsp;async&nbsp;threading</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnReconnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnReconnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Provides&nbsp;the&nbsp;facility&nbsp;to&nbsp;send&nbsp;individual&nbsp;user&nbsp;notification&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;profileId&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Set&nbsp;to&nbsp;the&nbsp;ProfileId&nbsp;of&nbsp;user&nbsp;who&nbsp;will&nbsp;receive&nbsp;the&nbsp;notification</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;message&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;set&nbsp;to&nbsp;the&nbsp;notification&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;profileId,&nbsp;<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Clients.User(profileId).send(message);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Provides&nbsp;the&nbsp;facility&nbsp;to&nbsp;send&nbsp;group&nbsp;notification&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;username&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;set&nbsp;to&nbsp;the&nbsp;user&nbsp;groupd&nbsp;name&nbsp;who&nbsp;will&nbsp;receive&nbsp;the&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;message&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;set&nbsp;to&nbsp;the&nbsp;notification&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SendUserMessage(String&nbsp;username,&nbsp;String&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.Group(username).sendUserMessage(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Provides&nbsp;the&nbsp;ability&nbsp;to&nbsp;get&nbsp;User&nbsp;from&nbsp;the&nbsp;dictionary&nbsp;for&nbsp;passed&nbsp;in&nbsp;profileId</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;profileId&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;set&nbsp;to&nbsp;the&nbsp;profileId&nbsp;of&nbsp;user&nbsp;that&nbsp;need&nbsp;to&nbsp;be&nbsp;fetched&nbsp;from&nbsp;the&nbsp;dictionary</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;return&nbsp;User&nbsp;object&nbsp;if&nbsp;found&nbsp;otherwise&nbsp;returns&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;User&nbsp;GetUser(<span class="cs__keyword">string</span>&nbsp;profileId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;User&nbsp;user;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Users.TryGetValue(profileId,&nbsp;<span class="cs__keyword">out</span>&nbsp;user);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;user;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Provide&nbsp;theability&nbsp;to&nbsp;get&nbsp;currently&nbsp;connected&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;profileId&nbsp;of&nbsp;user&nbsp;based&nbsp;on&nbsp;current&nbsp;connectionId</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;GetConnectedUser()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Users.Where(x&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(x.Value.ConnectionIds)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;!x.Value.ConnectionIds.Contains(Context.ConnectionId,&nbsp;StringComparer.InvariantCultureIgnoreCase);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Select(x&nbsp;=&gt;&nbsp;x.Key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Int16&nbsp;totalNewMessages&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Int16&nbsp;totalNewCircles&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Int16&nbsp;totalNewJobs&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Int16&nbsp;totalNewNotification&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HubMethodName(<span class="cs__string">&quot;sendNotifications&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SendNotifications()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;connection&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(ConfigurationManager.ConnectionStrings[<span class="cs__string">&quot;DefaultConnection&quot;</span>].ConnectionString))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;query&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;&nbsp;NewMessageCount,&nbsp;NewCircleRequestCount,&nbsp;NewNotificationsCount,&nbsp;NewJobNotificationsCount&nbsp;FROM&nbsp;[dbo].[Modeling_NewMessageNotificationCount]&nbsp;WHERE&nbsp;UserProfileId=&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;62021&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlCommand&nbsp;command&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(query,&nbsp;connection))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;command.Notification&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;dt&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDependency&nbsp;dependency&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlDependency(command);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dependency.OnChange&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OnChangeEventHandler(dependency_OnChange);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(connection.State&nbsp;==&nbsp;ConnectionState.Closed)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;reader&nbsp;=&nbsp;command.ExecuteReader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Load(reader);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dt.Rows.Count&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalNewMessages&nbsp;=&nbsp;Int16.Parse(dt.Rows[<span class="cs__number">0</span>][<span class="cs__string">&quot;NewMessageCount&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalNewCircles&nbsp;=&nbsp;Int16.Parse(dt.Rows[<span class="cs__number">0</span>][<span class="cs__string">&quot;NewCircleRequestCount&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalNewJobs&nbsp;=&nbsp;Int16.Parse(dt.Rows[<span class="cs__number">0</span>][<span class="cs__string">&quot;NewJobNotificationsCount&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalNewNotification&nbsp;=&nbsp;Int16.Parse(dt.Rows[<span class="cs__number">0</span>][<span class="cs__string">&quot;NewNotificationsCount&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IHubContext&nbsp;context&nbsp;=&nbsp;GlobalHost.ConnectionManager.GetHubContext&lt;NotificationHub&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;context.Clients.All.RecieveNotification(totalNewMessages,&nbsp;totalNewCircles,&nbsp;totalNewJobs,&nbsp;totalNewNotification);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;dependency_OnChange(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;SqlNotificationEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Type&nbsp;==&nbsp;SqlNotificationType.Change)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotificationHub&nbsp;nHub&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NotificationHub();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nHub.SendNotifications();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
Startup.cs&nbsp;
[assembly:&nbsp;OwinStartup(<span class="cs__string">&quot;TestingConfiguration&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(EmployeeStartup))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EmployeeStartup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configuration(IAppBuilder&nbsp;app)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.MapSignalR();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
User.cs<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Properties</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Property&nbsp;to&nbsp;get/set&nbsp;ProfileId</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ProfileId&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Propoerty&nbsp;to&nbsp;get/set&nbsp;multiple&nbsp;ConnectionId</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;HashSet&lt;<span class="cs__keyword">string</span>&gt;&nbsp;ConnectionIds&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
}&nbsp;
&nbsp;
Index.html&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;New&nbsp;Notifications&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;Scripts/jquery-1.6.4.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;Scripts/jquery.signalR-2.0.2.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;signalr/hubs&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(function&nbsp;()&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Declare&nbsp;a&nbsp;proxy&nbsp;to&nbsp;reference&nbsp;the&nbsp;hub.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;notifications&nbsp;=&nbsp;$.connection.notificationHub;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;debugger;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;function&nbsp;that&nbsp;the&nbsp;hub&nbsp;can&nbsp;call&nbsp;to&nbsp;broadcast&nbsp;messages.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;notifications.client.recieveNotification&nbsp;=&nbsp;function&nbsp;(totalNewMessages,&nbsp;totalNewCircles,&nbsp;totalNewJobs,&nbsp;totalNewNotifications)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;the&nbsp;message&nbsp;to&nbsp;the&nbsp;page.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#spanNewMessages'</span>).text(totalNewMessages);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#spanNewCircles'</span>).text(totalNewCircles);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#spanNewJobNotifications'</span>).text(totalNewJobs);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#spanNewNotifications'</span>).text(totalNewNotifications);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Start&nbsp;the&nbsp;connection.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.connection.hub.start().done(function&nbsp;()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;notifications.server.sendNotifications();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).fail(function&nbsp;(e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//$.connection.hub.start();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Broadcast&nbsp;Realtime&nbsp;SQL&nbsp;data&nbsp;<span class="cs__keyword">using</span>&nbsp;SignalR&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;You&nbsp;have&nbsp;&lt;span&nbsp;id=<span class="cs__string">&quot;spanNewMessages&quot;</span>&gt;<span class="cs__number">0</span>&lt;/span&gt;&nbsp;New&nbsp;Message&nbsp;Notification.&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;You&nbsp;have&nbsp;&lt;span&nbsp;id=<span class="cs__string">&quot;spanNewCircles&quot;</span>&gt;<span class="cs__number">0</span>&lt;/span&gt;&nbsp;New&nbsp;Circles&nbsp;Notification.&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;You&nbsp;have&nbsp;&lt;span&nbsp;id=<span class="cs__string">&quot;spanNewJobNotifications&quot;</span>&gt;<span class="cs__number">0</span>&lt;/span&gt;&nbsp;New&nbsp;Job&nbsp;Notification.&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;You&nbsp;have&nbsp;&lt;span&nbsp;id=<span class="cs__string">&quot;spanNewNotifications&quot;</span>&gt;<span class="cs__number">0</span>&lt;/span&gt;&nbsp;New&nbsp;Notification.&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&lt;/body&gt;&nbsp;
</span></pre>
</div>
</div>
<p></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>
<pre class="hidden"><span style="font-size:small">Global.asax
void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        System.Data.SqlClient.SqlDependency.Start(ConfigurationManager.ConnectionStrings[&quot;DefaultConnection&quot;].ConnectionString);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        System.Data.SqlClient.SqlDependency.Stop(ConfigurationManager.ConnectionStrings[&quot;DefaultConnection&quot;].ConnectionString);

    }
</span></pre>
<div class="preview">
<pre class="csharp"><span style="font-size:small"><strong>Global.asax&nbsp;</strong><span class="cs__keyword">void</span>&nbsp;Application_Start(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Code&nbsp;that&nbsp;runs&nbsp;on&nbsp;application&nbsp;startup</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Data.SqlClient.SqlDependency.Start(ConfigurationManager.ConnectionStrings[<span class="cs__string">&quot;DefaultConnection&quot;</span>].ConnectionString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Application_End(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;Code&nbsp;that&nbsp;runs&nbsp;on&nbsp;application&nbsp;shutdown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Data.SqlClient.SqlDependency.Stop(ConfigurationManager.ConnectionStrings[<span class="cs__string">&quot;DefaultConnection&quot;</span>].ConnectionString);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</span></pre>
</div>
</div>
</div>
<p></p>
<p><span style="font-size:small">Now run the application:</span></p>
<p><span style="font-size:small"><strong>&nbsp;<img id="111440" src="111440-img5.jpg" alt="" width="622" height="222"></strong><strong>&nbsp;</strong></span></p>
<p><span style="font-size:small">Screenshot 5.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Now let me change notification 5 to 50 in database and don&rsquo;t refresh or reload page.</span></p>
<p><span style="font-size:small">&nbsp;<img id="111441" src="111441-img6.jpg" alt="" width="626" height="220"></span></p>
<p><span style="font-size:small">Screenshot 6.</span></p>
