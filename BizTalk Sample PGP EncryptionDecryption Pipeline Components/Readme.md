# BizTalk: Sample: PGP Encryption/Decryption Pipeline Components
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- BizTalk Server
- BizTalk Custom Pipeline Component
- PGP
## Topics
- Security
- Encryption/Decryption
- BizTalk
- Custom Pipeline Component
## Updated
- 06/27/2012
## Description

<h1>Introduction</h1>
<pre><span>A sample demonstrates the PGP Encryption/Decryption in pipelines. </span></pre>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<pre>A sample is based on a sample by <a href=" http://bajwork.blogspot.com/2007/08/pgp-pipeline-component-v11.html ">Brian Jones </a> See <a href="http://209.40.205.14/wp-content/uploads/2009/07/PGP.zip">original code here</a>.</pre>
<p>The main additions to original code:</p>
<ul>
<li>Single pipeline component was separated to two Encrypt<br>
and Decrypt pipeline components. It simplifies the pipeline configurations. </li><li>Configuration parameters are stored in SSO,<br>
which, I hope, improves security. </li><li>File names for temporary files are regenerated randomly<br>
each time. That eliminates errors in case when temporary file names are based<br>
on the inbound file names and pipelines are working simultaneously in several<br>
ports. </li></ul>
<p>To build pipeline components you have to download a BouncyCastle.Crypto.dll<br>
assembly from <a href="http://www.bouncycastle.org/csharp">http://www.bouncycastle.org/csharp</a>.</p>
<p>The solution includes two pairs of the PGP keys. You can<br>
generate yours pairs using, for example, <strong><a href="http://primianotucci.com">PortablePGP</a></strong> utility</p>
<p>Configuration includes a config file for a <a href="http://seroter.wordpress.com/2007/09/21/biztalk-sso-configuration-data-storage-tool/">
<strong>SSO Config Store</strong> utility </a>created by Richard Seroter.&nbsp;&nbsp;</p>
<p>The test pipeline project includes four pipelines:</p>
<ul>
<li>Send and Receive pipelines for Encryption </li><li>Send and Receive pipelines for Decryption. </li></ul>
<p>To test these pipelines I&rsquo;ve created four receive ports and<br>
four send ports. They create four test workflows:</p>
<ul>
<li><strong>Encryption on a Receive port:<br>
<br>
</strong>RP::GLD.Samples.Pipelines.Encrypt.Encode &nbsp;( <strong>PgpEncryptReceive</strong> pipeline )<br>
&nbsp;==&gt;<br>
SP:: GLD.Samples.Pipelines.Encrypt.PassThru<br>
<br>
</li><li><strong>Encryption on a Send port:<br>
<br>
</strong>RP::GLD.Samples.Pipelines.Encrypt.PassThru&nbsp;&nbsp;<br>
&nbsp;==&gt;<br>
SP:: GLD.Samples.Pipelines.Encrypt.Encode ( <strong>PgpEncryptSend</strong> pipeline )<br>
<br>
</li><li><strong>Decryption on a Receive port:<br>
<br>
</strong>RP:: GLD.Samples.Pipelines.Decrypt.Decode ( <strong>PgpDecryptReceive</strong> pipeline )<br>
&nbsp;==&gt;<br>
SP:: GLD.Samples.Pipelines.Decrypt.PassThru<br>
<br>
</li><li><strong>Decryption on a Send port:<br>
<br>
</strong>RP:: GLD.Samples.Pipelines.Decrypt.PassThru <br>
&nbsp;==&gt;<br>
SP:: GLD.Samples.Pipelines.Decrypt.Decrypt ( <strong>PgpDecryptSend</strong> pipeline )
</li></ul>
<p>&nbsp;</p>
<p><strong>To test pipelines:</strong></p>
<ul>
<li>Use test text files in a <strong>Tests\TestData</strong> folder </li><li>To <strong>test encryption</strong>:
<ol>
<li>Copy test files to a <strong>Tests\Encrypt\In</strong> folder </li><li>Encrypted files are created in a <strong>Test\Encrypt\Out</strong> folder. </li></ol>
</li><li>To <strong>test decryption</strong>:
<ol>
<li>Copy test encrypted files from a <strong>Test\Encrypt\Out</strong> folder to a
<strong>Tests\Decrypt\In</strong> folder </li><li>Decrypted files are created in a <strong>Test\Decrypt\Out</strong> folder. </li></ol>
</li></ul>
