# C# Console Program to Check RAM Memory Size
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Console
## Topics
- C#
- Console Applications
## Updated
- 06/01/2016
## Description

<p><span style="font-size:small">This simple console program gets the RAM memory size of a computer. This program is intended to teach how to use&nbsp;<a href="https://msdn.microsoft.com/en-us/library/aa394239%28v=vs.85%29.aspx" target="_blank">Win32_OperatingSystem</a>
 class and it's properites to access the computer hardware to get various status.</span></p>
<h2></h2>
<h2><span style="font-size:small">Win32_OperatingSystem class</span></h2>
<p><span style="font-size:small">The Win32_OperatingSystem WMI class represents a Windows-based operating system installed on a computer.<br>
The following syntax is simplified from Managed Object Format (MOF) code and includes all of the inherited properties. Properties and methods are in alphabetic order, not MOF order.</span></p>
<h2></h2>
<h2><span style="font-size:small">Various Win32_OperatingSystem class properties:</span></h2>
<h2><span style="font-size:small">Syntax:</span></h2>
<pre><span style="font-size:small">[Singleton, Dynamic, Provider(&quot;CIMWin32&quot;), SupportsUpdate, UUID(&quot;{8502C4DE-5FBB-11D2-AAC1-006008C78BC7}&quot;), AMENDMENT]
class Win32_OperatingSystem : CIM_OperatingSystem
{
  string&nbsp;&nbsp; BootDevice;
  string&nbsp;&nbsp; BuildNumber;
  string&nbsp;&nbsp; BuildType;
  string&nbsp;&nbsp; Caption;
  string&nbsp;&nbsp; CodeSet;
  string&nbsp;&nbsp; CountryCode;
  string&nbsp;&nbsp; CreationClassName;
  string&nbsp;&nbsp; CSCreationClassName;
  string&nbsp;&nbsp; CSDVersion;
  string&nbsp;&nbsp; CSName;
  sint16&nbsp;&nbsp; CurrentTimeZone;
  boolean&nbsp; DataExecutionPrevention_Available;
  boolean&nbsp; DataExecutionPrevention_32BitApplications;
  boolean&nbsp; DataExecutionPrevention_Drivers;
  uint8&nbsp;&nbsp;&nbsp; DataExecutionPrevention_SupportPolicy;
  boolean&nbsp; Debug;
  string&nbsp;&nbsp; Description;
  boolean&nbsp; Distributed;
  uint32&nbsp;&nbsp; EncryptionLevel;
  uint8&nbsp;&nbsp;&nbsp; ForegroundApplicationBoost = 2;
  uint64&nbsp;&nbsp; FreePhysicalMemory;
  uint64&nbsp;&nbsp; FreeSpaceInPagingFiles;
  uint64&nbsp;&nbsp; FreeVirtualMemory;
  datetime InstallDate;
  uint32&nbsp;&nbsp; LargeSystemCache;
  datetime LastBootUpTime;
  datetime LocalDateTime;
  string&nbsp;&nbsp; Locale;
  string&nbsp;&nbsp; Manufacturer;
  uint32&nbsp;&nbsp; MaxNumberOfProcesses;
  uint64&nbsp;&nbsp; MaxProcessMemorySize;
  string&nbsp;&nbsp; MUILanguages[];
  string&nbsp;&nbsp; Name;
  uint32&nbsp;&nbsp; NumberOfLicensedUsers;
  uint32&nbsp;&nbsp; NumberOfProcesses;
  uint32&nbsp;&nbsp; NumberOfUsers;
  uint32&nbsp;&nbsp; OperatingSystemSKU;
  string&nbsp;&nbsp; Organization;
  string&nbsp;&nbsp; OSArchitecture;
  uint32&nbsp;&nbsp; OSLanguage;
  uint32&nbsp;&nbsp; OSProductSuite;
  uint16&nbsp;&nbsp; OSType;
  string&nbsp;&nbsp; OtherTypeDescription;
  Boolean&nbsp; PAEEnabled;
  string&nbsp;&nbsp; PlusProductID;
  string&nbsp;&nbsp; PlusVersionNumber;
  boolean&nbsp; PortableOperatingSystem;
  boolean&nbsp; Primary;
  uint32&nbsp;&nbsp; ProductType;
  string&nbsp;&nbsp; RegisteredUser;
  string&nbsp;&nbsp; SerialNumber;
  uint16&nbsp;&nbsp; ServicePackMajorVersion;
  uint16&nbsp;&nbsp; ServicePackMinorVersion;
  uint64&nbsp;&nbsp; SizeStoredInPagingFiles;
  string&nbsp;&nbsp; Status;
  uint32&nbsp;&nbsp; SuiteMask;
  string&nbsp;&nbsp; SystemDevice;
  string&nbsp;&nbsp; SystemDirectory;
  string&nbsp;&nbsp; SystemDrive;
  uint64&nbsp;&nbsp; TotalSwapSpaceSize;
  uint64&nbsp;&nbsp; TotalVirtualMemorySize;
  uint64&nbsp;&nbsp; TotalVisibleMemorySize;
  string&nbsp;&nbsp; Version;
  string&nbsp;&nbsp; WindowsDirectory;
  uint8&nbsp;&nbsp;&nbsp; QuantumLength;
  uint8&nbsp;&nbsp;&nbsp; QuantumType;
};</span></pre>
<p></p>
<div class="endscriptcode"></div>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<p class="title"><span>C#</span></p>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Management;

namespace RAMmemory
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectQuery wql = new ObjectQuery(&quot;SELECT * FROM Win32_OperatingSystem&quot;);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            double res;

            foreach (ManagementObject result in results)
            {
                res = Convert.ToDouble(result[&quot;TotalVisibleMemorySize&quot;]);
                double fres = Math.Round((res / (1024 * 1024)), 2);
                Console.WriteLine(&quot;Total usable memory size: &quot; &#43; fres &#43; &quot;GB&quot;);
                Console.WriteLine(&quot;Total usable memory size: &quot; &#43; res &#43; &quot;KB&quot;);
            }

            Console.ReadLine();
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Management;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RAMmemory&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjectQuery&nbsp;wql&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObjectQuery(<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Win32_OperatingSystem&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectSearcher&nbsp;searcher&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ManagementObjectSearcher(wql);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectCollection&nbsp;results&nbsp;=&nbsp;searcher.Get();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;res;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(ManagementObject&nbsp;result&nbsp;<span class="cs__keyword">in</span>&nbsp;results)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;res&nbsp;=&nbsp;Convert.ToDouble(result[<span class="cs__string">&quot;TotalVisibleMemorySize&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;fres&nbsp;=&nbsp;Math.Round((res&nbsp;/&nbsp;(<span class="cs__number">1024</span>&nbsp;*&nbsp;<span class="cs__number">1024</span>)),&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Total&nbsp;usable&nbsp;memory&nbsp;size:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;fres&nbsp;&#43;&nbsp;<span class="cs__string">&quot;GB&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Total&nbsp;usable&nbsp;memory&nbsp;size:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;res&nbsp;&#43;&nbsp;<span class="cs__string">&quot;KB&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
