# Copy protect for Your Windows Forms application
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Cryptography
## Updated
- 07/04/2012
## Description

<h1>Introduction</h1>
<p>You want to protect Your application for multiple copy? This sample demontrates how You can use&nbsp;the cryptographic service provider (CSP) version of the TripleDES &nbsp;algorithm</p>
<p><span style="text-decoration:underline"><a href="http://msdn.microsoft.com/de-de/library/system.security.cryptography.tripledes.aspx">http://msdn.microsoft.com/de-de/library/system.security.cryptography.tripledes.aspx</a></span></p>
<p>&nbsp;</p>
<h1>program description</h1>
<p>&nbsp;<img src="56068-scrs.jpg" alt="" width="614" height="711"></p>
<p><strong>Section &quot;Customer computer analysed data&quot;</strong></p>
<p>analyse customer Computername. The computername noramlly is fixed.</p>
<p>analsyse Customer user name (the current logged user).&nbsp;</p>
<p>analyse Customer serial drive no (here C:). Drive C: normally is fixed</p>
<p>&nbsp;</p>
<p>That means: You retrieve a login code for 1. this computer, 2. this user and 3. this computer by drive C:</p>
<p>You can change this according to Your demands.</p>
<p><strong>Section &quot;full string of analysed data&quot;</strong></p>
<p>The three data strings above are concated to one string</p>
<p><strong>Section &quot;encrypted full data send to seller of the software&quot;</strong></p>
<p>The customer sends this string via Email to the seller. He cannot analyse now, what the source of this string is.</p>
<p><strong>Section &quot;seller decrypts data from customer&quot;</strong></p>
<p>The data form customer are decrypted here</p>
<p><strong>Section &quot;code from seller to customer &quot;</strong></p>
<p>The seller geneates a login code and sends this back to customer</p>
<p><strong>Section &quot;customer enteres login code (dez) here&quot;</strong></p>
<p>Customer enters login code (box login code here) and presses button Loging</p>
<h1>Data Encryption Standard</h1>
<p>DES is the archetypal block cipher &nbsp;- an algorithm that takes a fixed-length string of plaintext bits and transforms it through a series of complicated operations into another ciphertext bitstring of the same length. In the case of DES, the block size
 is 64 bits. DES also uses a key to customize the transformation, so that decryption can supposedly only be performed by those who know the particular key used to encrypt. The key ostensibly consists of 64 bits; however, only 56 of these are actually used by
 the algorithm. Eight bits are used solely for checking parity , and are thereafter discarded. Hence the effective key length is 56 bits, and it is never quoted as such. Every 8th bit of the selected key is discarded, that is, positions 8, 16, 24, 32, 40, 48,
 56, 64 are removed from the 64 bit key leaving behind only the 56 bit key.</p>
<p>For more information see: http://www.rfc-editor.org/rfc/rfc4772.txt</p>
<p>A cryptographic service provider (CSP) contains implementations of cryptographic standards and algorithms. At a minimum, a CSP consists of a dynamic-link library (DLL) that implements the functions in CryptoSPI. Most CSPs contain the implementation of all
 of their own functions; however, some CSPs implement their functions mainly in a service program based on Microsoft Win32 and managed by the Win32 service control manager. Others implement functions in hardware, such as a smart card or secure coprocessor.
 If a CSP does not implement its own functions, the DLL acts as a pass-through layer, facilitating the communication between the operating system and the actual CSP implementation.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Imports System.Security.Cryptography
Imports System.Management
Imports System.IO
''' &lt;summary&gt;
''' Demo. Copyprotect for Your Winform application
''' &lt;/summary&gt;
''' &lt;remarks&gt;last update 2012-03-16&lt;/remarks&gt;
Public Class MainForm1

    Private TripleDes As New TripleDESCryptoServiceProvider
    Private loginOK As Boolean = False
    Private myCode As Int64

  
#Region &quot;formevents&quot;

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
                         Handles Me.Load

        'analyse data from system:
        Dim computername As String = My.Computer.Name
        Dim user As String = My.User.Name
        Dim driveSerial As String = GetDriveSerialNumber(&quot;C:&quot;)
        Dim coding As String = user &amp; &quot;\&quot; &amp; driveSerial &amp; &quot;\&quot; &amp; computername
        Dim cipherText As String = EncryptData(coding)
        Dim plainText As String = DecryptData(cipherText)

        'generate login code:
        Dim code As Int64 = generateCode(coding)
        Me.myCode = code ' f&uuml;r das assembly zur Verf&uuml;gung stellen

        ' visualize data in Form
        TextBox1.Text = computername
        TextBox2.Text = user
        TextBox3.Text = driveSerial
        TextBox4.Text = coding              'full data string
        TextBox5.Text = cipherText          'encrypted data string 
        tbLogincode.Text = code.ToString    'login code (dez)
        TextBox7.Text = Hex(code)           'login code (hex)
        TextBox8.Text = plainText           'decrypt (test)
        PictureBox1.Image = My.Resources.Standby
        tbEnterLoginCode.Focus()

    End Sub

    ''' &lt;summary&gt;
    ''' login and start 
    ''' &lt;/summary&gt;
    Private Sub btn_Check(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) Handles btnCeck.Click
        If Me.tbLogincode.Text = Me.tbEnterLoginCode.Text Then

            loginOK = True
            PictureBox1.Image = My.Resources.Ok
            MsgBox(&quot;Login successfull!&quot;)

            '************************************
            ' here condition to start any programm
            '************************************
        Else

            loginOK = False
            PictureBox1.Image = My.Resources.Standby
            MsgBox(&quot;Login failed!&quot;)

        End If
    End Sub

#End Region
#Region &quot;ulitities&quot;

    ''' &lt;summary&gt;
    ''' generate login code from computer data
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;_coding&quot;&gt;encryted string&lt;/param&gt;
    ''' &lt;returns&gt;login code dez / string&lt;/returns&gt;
    Private Function generateCode(ByVal _coding As String) As Int64
        Dim _code As Int64
        For I As Integer = 1 To Len(_coding)
            _code &#43;= (Asc(Mid(_coding, I, 1)) * 915734)
        Next
        Return _code
    End Function

    ''' &lt;summary&gt;
    ''' encrypt data
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;plaintext&quot;&gt;string to be encrypted&lt;/param&gt;
    ''' &lt;returns&gt;encryted data&lt;/returns&gt;
    Private Function EncryptData(ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms, _
            TripleDes.CreateEncryptor(), _
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    ''' &lt;summary&gt;
    ''' decrypt data
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;encryptedtext&quot;&gt;encrypted string&lt;/param&gt;
    ''' &lt;returns&gt;plaint text&lt;/returns&gt;
    Private Function DecryptData(ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms, _
            TripleDes.CreateDecryptor(), _
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

    ''' &lt;summary&gt;
    ''' get dirve serial number
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;drive&quot;&gt;C:&lt;/param&gt;
    ''' &lt;returns&gt;drive serial&lt;/returns&gt;
    Private Function GetDriveSerialNumber(ByVal drive As String) As String

        Dim driveSerial As String = String.Empty
        Dim driveFixed As String = System.IO.Path.GetPathRoot(drive)
        driveFixed = Replace(driveFixed, &quot;\&quot;, String.Empty)

        Using querySearch As New ManagementObjectSearcher(&quot;SELECT VolumeSerialNumber FROM Win32_LogicalDisk Where Name = '&quot; &amp; driveFixed &amp; &quot;'&quot;)

            Using queryCollection As ManagementObjectCollection = querySearch.Get()

                Dim moItem As ManagementObject

                For Each moItem In queryCollection

                    driveSerial = CStr(moItem.Item(&quot;VolumeSerialNumber&quot;))

                    Exit For
                Next
            End Using
        End Using
        Return driveSerial
    End Function
#End Region

End Class</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Security.Cryptography&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Management&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.IO&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;Demo.&nbsp;Copyprotect&nbsp;for&nbsp;Your&nbsp;Winform&nbsp;application</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;last&nbsp;update&nbsp;2012-03-16&lt;/remarks&gt;</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;MainForm1&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;TripleDes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TripleDESCryptoServiceProvider&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;loginOK&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;myCode&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int64<span class="visualBasic__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
#Region&nbsp;&quot;formevents</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'analyse&nbsp;data&nbsp;from&nbsp;system:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;computername&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;My.Computer.Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;user&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;My.User.Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;driveSerial&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;GetDriveSerialNumber(<span class="visualBasic__string">&quot;C:&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;coding&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;user&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;\&quot;&nbsp;&amp;&nbsp;driveSerial&nbsp;&amp;&nbsp;&quot;</span>\&quot;&nbsp;&amp;&nbsp;computername&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cipherText&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;EncryptData(coding)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;plainText&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;DecryptData(cipherText)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'generate&nbsp;login&nbsp;code:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;code&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int64&nbsp;=&nbsp;generateCode(coding)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.myCode&nbsp;=&nbsp;code&nbsp;<span class="visualBasic__com">'&nbsp;f&uuml;r&nbsp;das&nbsp;assembly&nbsp;zur&nbsp;Verf&uuml;gung&nbsp;stellen</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;visualize&nbsp;data&nbsp;in&nbsp;Form</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;computername&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox2.Text&nbsp;=&nbsp;user&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox3.Text&nbsp;=&nbsp;driveSerial&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox4.Text&nbsp;=&nbsp;coding&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'full&nbsp;data&nbsp;string</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox5.Text&nbsp;=&nbsp;cipherText&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'encrypted&nbsp;data&nbsp;string&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbLogincode.Text&nbsp;=&nbsp;code.ToString&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'login&nbsp;code&nbsp;(dez)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox7.Text&nbsp;=&nbsp;Hex(code)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'login&nbsp;code&nbsp;(hex)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox8.Text&nbsp;=&nbsp;plainText&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'decrypt&nbsp;(test)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PictureBox1.Image&nbsp;=&nbsp;My.Resources.Standby&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbEnterLoginCode.Focus()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;login&nbsp;and&nbsp;start&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btn_Check(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnCeck.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.tbLogincode.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.tbEnterLoginCode.Text&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loginOK&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PictureBox1.Image&nbsp;=&nbsp;My.Resources.Ok&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;Login&nbsp;successfull!&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'************************************</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;here&nbsp;condition&nbsp;to&nbsp;start&nbsp;any&nbsp;programm</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'************************************</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loginOK&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PictureBox1.Image&nbsp;=&nbsp;My.Resources.Standby&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;Login&nbsp;failed!&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
#Region&nbsp;&quot;ulitities</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;generate&nbsp;login&nbsp;code&nbsp;from&nbsp;computer&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;_coding&quot;&gt;encryted&nbsp;string&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;login&nbsp;code&nbsp;dez&nbsp;/&nbsp;string&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;generateCode(<span class="visualBasic__keyword">ByVal</span>&nbsp;_coding&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int64&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;_code&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int64&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;I&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;Len(_coding)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_code&nbsp;&#43;=&nbsp;(Asc(Mid(_coding,&nbsp;I,&nbsp;<span class="visualBasic__number">1</span>))&nbsp;*&nbsp;<span class="visualBasic__number">915734</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_code&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;encrypt&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;plaintext&quot;&gt;string&nbsp;to&nbsp;be&nbsp;encrypted&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;encryted&nbsp;data&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;EncryptData(<span class="visualBasic__keyword">ByVal</span>&nbsp;plaintext&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Convert&nbsp;the&nbsp;plaintext&nbsp;string&nbsp;to&nbsp;a&nbsp;byte&nbsp;array.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;plaintextBytes()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;=&nbsp;System.Text.Encoding.Unicode.GetBytes(plaintext)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Create&nbsp;the&nbsp;stream.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ms&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;System.IO.MemoryStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Create&nbsp;the&nbsp;encoder&nbsp;to&nbsp;write&nbsp;to&nbsp;the&nbsp;stream.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;encStream&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CryptoStream(ms,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TripleDes.CreateEncryptor(),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Security.Cryptography.CryptoStreamMode.Write)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Use&nbsp;the&nbsp;crypto&nbsp;stream&nbsp;to&nbsp;write&nbsp;the&nbsp;byte&nbsp;array&nbsp;to&nbsp;the&nbsp;stream.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;encStream.Write(plaintextBytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;plaintextBytes.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;encStream.FlushFinalBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Convert&nbsp;the&nbsp;encrypted&nbsp;stream&nbsp;to&nbsp;a&nbsp;printable&nbsp;string.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Convert.ToBase64String(ms.ToArray)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;decrypt&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;encryptedtext&quot;&gt;encrypted&nbsp;string&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;plaint&nbsp;text&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;DecryptData(<span class="visualBasic__keyword">ByVal</span>&nbsp;encryptedtext&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Convert&nbsp;the&nbsp;encrypted&nbsp;text&nbsp;string&nbsp;to&nbsp;a&nbsp;byte&nbsp;array.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;encryptedBytes()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;=&nbsp;Convert.FromBase64String(encryptedtext)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Create&nbsp;the&nbsp;stream.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ms&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;System.IO.MemoryStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Create&nbsp;the&nbsp;decoder&nbsp;to&nbsp;write&nbsp;to&nbsp;the&nbsp;stream.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;decStream&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CryptoStream(ms,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TripleDes.CreateDecryptor(),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Security.Cryptography.CryptoStreamMode.Write)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Use&nbsp;the&nbsp;crypto&nbsp;stream&nbsp;to&nbsp;write&nbsp;the&nbsp;byte&nbsp;array&nbsp;to&nbsp;the&nbsp;stream.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decStream.Write(encryptedBytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;encryptedBytes.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decStream.FlushFinalBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Convert&nbsp;the&nbsp;plaintext&nbsp;stream&nbsp;to&nbsp;a&nbsp;string.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;System.Text.Encoding.Unicode.GetString(ms.ToArray)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;get&nbsp;dirve&nbsp;serial&nbsp;number</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;drive&quot;&gt;C:&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;drive&nbsp;serial&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetDriveSerialNumber(<span class="visualBasic__keyword">ByVal</span>&nbsp;drive&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;driveSerial&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;driveFixed&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;System.IO.Path.GetPathRoot(drive)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;driveFixed&nbsp;=&nbsp;Replace(driveFixed,&nbsp;<span class="visualBasic__string">&quot;\&quot;</span>,&nbsp;<span class="visualBasic__keyword">String</span>.Empty)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;querySearch&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ManagementObjectSearcher(<span class="visualBasic__string">&quot;SELECT&nbsp;VolumeSerialNumber&nbsp;FROM&nbsp;Win32_LogicalDisk&nbsp;Where&nbsp;Name&nbsp;=&nbsp;'&quot;</span>&nbsp;&amp;&nbsp;driveFixed&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;'&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;queryCollection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ManagementObjectCollection&nbsp;=&nbsp;querySearch.<span class="visualBasic__keyword">Get</span>()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;moItem&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ManagementObject&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;moItem&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;queryCollection&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;driveSerial&nbsp;=&nbsp;<span class="visualBasic__keyword">CStr</span>(moItem.Item(<span class="visualBasic__string">&quot;VolumeSerialNumber&quot;</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;driveSerial&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span><span class="visualBasic__preproc">&nbsp;
#End&nbsp;Region</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>The algorithm to create loging code:</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim _code As Int64</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For I As Integer = 1 To Len(_coding)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _code &#43;= (Asc(Mid(_coding, I, 1)) * 915734)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next</p>
<p>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return _code</p>
<p>&nbsp;</p>
<p>This is only a suggestion. Your can create Your own procedure</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>Discussion about the security of this protect.</h1>
<p>I've received a lot responses here in this german thread:</p>
<p><a href="http://social.msdn.microsoft.com/Forums/de-DE/vbasicexpresseditionde/thread/ba605263-4cc2-4923-8f64-ecf57053daaf">http://social.msdn.microsoft.com/Forums/de-DE/vbasicexpresseditionde/thread/ba605263-4cc2-4923-8f64-ecf57053daaf</a></p>
<p>One community member (LitleBlueBird) said that a hacker who is proficient in&nbsp; MSIL programing&nbsp; would easily crack this protect. Another community member (Arno) observed that his customer users would not be able to do something like this and had
 no interest in illegal actions.&nbsp;&nbsp; ......</p>
<h1>Useful Link</h1>
<p>I've found a very useful code to store login code in a hidden textfile:</p>
<p><a href="http://code.msdn.microsoft.com/Secure-Login-Example-42facaf1">http://code.msdn.microsoft.com/Secure-Login-Example-42facaf1</a></p>
<p>msdn article:</p>
<p><a href="http://support.microsoft.com/kb/307010/en-us">http://support.microsoft.com/kb/307010/en-us</a></p>
<p>&nbsp;</p>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
