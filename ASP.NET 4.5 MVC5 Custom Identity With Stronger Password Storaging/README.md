# ASP.NET 4.5 MVC5 Custom Identity With Stronger Password Storaging
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC 5
- ASP.NET Identity
## Topics
- Security
- ASP.NET MVC 5
- ASP.NET Identity
- Password Hashing
## Updated
- 04/09/2014
## Description

<p>ASP.NET 4.5 MVC 5 was released a few months ago and it brought a load of new features, one of them being ASP.NET Identity which is the replacement of the former Simple Membership and Membership before that.</p>
<p>If you create a basic MVC 5 application you will get a project with a basic implementation of this Identity that makes calls to a UserManager object to deal with authentication. This object then communicates with a UserStore object that deals with the database
 through a UserContext object.</p>
<p>Microsoft made it really easy and this will get you through most of the basic things you may want to do, but as always, we don't want the default implementations, we want to make customizations. Therefore I developed a custom Identity implementation with
 the specific goal of customizing the way passwords are dealt with.</p>
<p>By default, ASP.NET hashes passwords using 5000 rounds of the&nbsp;PBKDF2 (Password-Based Key Derivation Function 2), which is a key stretching algorithm and they used a class named Rfc2898DeriveBytes that has a HMACSHA256 hashing algorithm&nbsp;which is
 not considered to be very secure anymore.</p>
<p>In my implementation I used a modded&nbsp;&nbsp;implementation of Rfc2898DeriveBytes&nbsp;by Ian Harris,&nbsp;that uses the way more secure&nbsp;HMACSHA512&nbsp;hashing algorithm and also added the possibility of setting the number of rounds, which is way
 more secure and lasting. In the future, as computer power evolves, you can &nbsp;increase the number of rounds for an increased security.</p>
<p>Besides PBKDF2 I also integrated BCrypt by&nbsp;Damien Miller and SCrypt by&nbsp;Colin Percival which are widely more accepted as more secure hashing algorithms.</p>
<p>First of all I created a new MVC5 project that gave me all the basic AccountController methods.</p>
<p>After that I started by creating my custom Identity provider so I replaced the UserManager with a&nbsp;<strong>tmUserManager</strong>&nbsp;that implements an&nbsp;<strong>ItmUserManager</strong>&nbsp;with all the basic methods shown below.</p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/1.png"><img class="alignnone size-full x_x_wp-image-52" src="http://onlywayiknowhow.files.wordpress.com/2014/02/1.png" alt="ItmUserManager" width="700" height="164"></a></p>
<p>This is the object to have on the AccountController replacing the current implementation. I have also added IoC that has nothing to do with my point what so ever but it just looks nice.</p>
<p><strong>Before</strong></p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/2.png"><img class="alignnone size-full x_x_wp-image-53" src="http://onlywayiknowhow.files.wordpress.com/2014/02/2.png" alt="AccountController Default" width="700" height="63"></a></p>
<p><strong>After</strong></p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/3.png"><img class="alignnone size-full x_x_wp-image-54" src="http://onlywayiknowhow.files.wordpress.com/2014/02/3.png" alt="AccountController Custom" width="398" height="101"></a></p>
<p>After this I implemented my own UserStore to which I called&nbsp;<strong>tmUserStore</strong>&nbsp;running a&nbsp;<strong>tmIdentityUser</strong>. This&nbsp;<strong>tmUserStore</strong>&nbsp;also has a&nbsp;<strong>tmUserContext</strong>&nbsp;object to communicate
 with a SQL database through a&nbsp;<strong>tmDbContext</strong>.</p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/4.png"><img class="alignnone size-full x_x_wp-image-55" src="http://onlywayiknowhow.files.wordpress.com/2014/02/4.png" alt="tmUserStore" width="681" height="101"></a></p>
<p>Now for the fun part!</p>
<p>I implemented a mechanism to let you use different Hashing Algorithms&nbsp;that let's you easily add and configure how you want them to behave. The project already has ready to use:&nbsp;<strong>BCrypt</strong>;&nbsp;<strong>SCrypt</strong>;&nbsp;<strong>PBKDF2</strong>;</p>
<p>So, how does it work?</p>
<p>I have a static class HashingConfig with two public static methods:</p>
<ul>
<li>public static string HashPassword(string password) </li><li>public static bool VerifyPassword(string password, string hash) </li></ul>
<p>The configurations of these algorithms can be done via the Web.config in the appSettings section and in this example, SCrypt is enabled and it is set for 2^16 rounds, all the others are commented.</p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/21.png"><img class="alignnone size-full x_x_wp-image-73" src="http://onlywayiknowhow.files.wordpress.com/2014/02/21.png" alt="HashingConfig Hashing Configurations" width="700" height="311"></a></p>
<p>The values you set here, will then be used when you<span>&nbsp;call the Hashing function on the&nbsp;</span><strong>HashingConfig</strong><span>&nbsp;class that has the following method of extracting the settings defined.</span></p>
<p><img class="alignnone size-full x_x_wp-image-72" src="http://onlywayiknowhow.files.wordpress.com/2014/02/11.png" alt="Web.config Hashing Configurations" width="700" height="531"></p>
<p>Theses settings are then used when you call for a&nbsp;<strong>HashPassword</strong>&nbsp;or&nbsp;<strong>VerifyPassword.</strong></p>
<p><strong>&nbsp;</strong>Usage of HashPassword: Simply call it and send the password to hash.</p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/8.png"><img class="alignnone size-full x_x_wp-image-61" src="http://onlywayiknowhow.files.wordpress.com/2014/02/8.png" alt="HashPassword" width="485" height="406"></a></p>
<p>Usage of VerifyPassword: Simply call it and send the password to hash and the previously stored hashed representation of it.</p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/7.png"><img class="alignnone size-full x_x_wp-image-60" src="http://onlywayiknowhow.files.wordpress.com/2014/02/7.png" alt="VerifyPassword" width="469" height="472"></a></p>
<p>As you can read on my comments, if you want to add another algorithm, create another case with your implementation and create a class that handles the communication with your algorithm class such as this example for BCrypt below.</p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/9.png"><img class="alignnone size-full x_x_wp-image-62" src="http://onlywayiknowhow.files.wordpress.com/2014/02/9.png" alt="BCrypt Example" width="661" height="307"></a></p>
<p>So that leaves me with a nice tree view like the image below where I have put all the back implementation of the hashing algorithms into their respective folders.</p>
<p><a href="http://onlywayiknowhow.files.wordpress.com/2014/02/10.png"><img class="alignnone size-full x_x_wp-image-63" src="http://onlywayiknowhow.files.wordpress.com/2014/02/10.png" alt="Hashing TreeView" width="273" height="273"></a></p>
<p>So that is it!</p>
