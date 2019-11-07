# CUDA 5.0 and Visual Studio 2012 Configuration
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2012
- CUDA
- NSight
## Topics
- Parallel Programming
- GPGPU
## Updated
- 07/22/2013
## Description

<h1><span style="color:#800000; font-size:small">Note that CUDA 5.5 fully supports Visual Studio 2012..</span></h1>
<p>&nbsp;</p>
<h1>Introduction</h1>
<div style="font-size:small">I will explain in this article how to set your environment in order to successfully write and run CUDA 5 programs with Visual Studio 2012. It takes time to figure out how to get it done and there is very little information on the
 internet, so hopefully, I will make life a little easier for some of you. When you study GPGPU programming it helps to understand cross-platform programming paradigms and technologies, such as AMP, CUDA, OpenCL, and DirectCompute because all of them target
 the same hardware and consequently have similar limitations.</div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Prerequisites for the attached project are CUDA 5.0, NSight 3.0 RC1, Visual Studio 2012. The code is extremely simple (just under 100 lines in one file) and serves more to give you a complete configured Visual Studio custom project
 that works. You can build on it.</div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">The main idea in parallel programming is to write code as if you were writing a program that will execute on one thread only, then specifying that you want to run that program simultaneously on as many threads as necessary.</div>
<h1><span>Building the Sample</span></h1>
<div style="font-size:small">To run the sample you have to install the following prerequisites: CUDA 5.0, NSight 3.0 RC1, Visual Studio 2012</div>
<h1>Description</h1>
<h2>Required Software</h2>
<div style="font-size:small">Start with installing CUDA 5.0 and NSight software. You can download everything from the following links:</div>
<div style="font-size:small">
<ul style="list-style-type:lower-latin">
<li><a href="http://docs.nvidia.com/cuda/cuda-getting-started-guide-for-microsoft-windows/index.html" target="_blank">NVIDIA CUDA Getting Started Guide for Microsoft Windows</a>
</li><li><a href="http://www.nvidia.com/object/cuda_home_new.html" target="_blank">CUDA Zone</a>
</li><li><a href="https://developer.nvidia.com/rdp/nsight-visual-studio-edition-registered-developer-program">Nsight Visual Studio</a>
</li></ul>
</div>
<div style="font-size:small">You have to be registered with NVidia to install the software.</div>
<h2>Verify Installation</h2>
<div style="font-size:small">Navigate to <span style="font-family:'Courier New',Courier,monospace; font-size:small">
C:\ProgramData\NVIDIA Corporation\CUDA Samples\v5.0\bin\win64\Release</span> and run
<span style="font-family:'Courier New',Courier,monospace; font-size:small; font-weight:bold; color:#006600">
deviceQuery</span>.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75897" src="75897-devicequery.png" alt="device query" style="width:700px; height:auto"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">It is always interesting to compare capabilities of your hardware with the latest available specs. Important here are number of threads, blocks, grids. Number of threads per block is vital because when you design your code you do
 not want to exceed that number when calling your kernels.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75898" src="75898-numthreads.png" alt="number of threads"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Also important Runtime limit on kernels setting. On my machine it is 7 seconds. Normally it is set to 2 seconds. It is better when there is no limit.</div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">The runtime limit is a mechanism for maintaining GPU responsiveness. Windows will reset display driver when a task appears to be hanging or running longer than the permitted quantum time (default is 2 seconds as I already mentioned.
 Mine must be 7 because I have Quadro card). The display driver is restarted to free up the GPU for display and other waiting apps. Users will notice a momentary screen flicker with a message in the task bar like &ldquo;Display driver has stopped responding
 and has successfully recovered&rdquo;.</div>
<div style="font-size:small">&nbsp;</div>
<div><span style="font-size:small">Here&rsquo;s how to find the timeout value for your computer:</span></div>
<div>&nbsp;</div>
<div>
<pre style="color:#808080; font-size:small; font-family:'Courier New',Courier,monospace">// PS C:\WINDOWS\system32&gt; cd hklm:
PS HKLM:\&gt; dir

    Hive: HKEY_LOCAL_MACHINE

Name                           Property                                                                                                                                                 
----                           --------                                                                                                                                                 
BCD00000000                                                                                                                                                                             
HARDWARE                                                                                                                                                                                
SAM                                                                                                                                                                                     
SOFTWARE                                                                                                                                                                                
SYSTEM                                                                                                                                                                                  

PS HKLM:\&gt; cd System\CurrentControlSet\Control\GraphicsDrivers

PS HKLM:\System\CurrentControlSet\Control\GraphicsDrivers&gt; dir

    Hive: HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GraphicsDrivers

Name                           Property                                                                                                                                                 
----                           --------                                                                                                                                                 
AdditionalModeLists                                                                                                                                                                     
Configuration                                                                                                                                                                           
Connectivity                                                                                                                                                                            
DCI                            Timeout : 7                                                                                                                                              
UseNewKey                                         
    </pre>
</div>
<div style="font-size:small">Next, run bandwidthTest</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75899" src="75899-bandwidthtest.png" alt="bandwidth test"></div>
<h2>Prepare Visual Studio</h2>
<div style="font-size:small">Navigate to <span style="font-family:'Courier New',Courier,monospace; color:#808000">
C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v5.0\extras\visual_studio_integration\MSBuildExtensions</span> and copy all files from that folder to a temporary location where we could make some changes.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75900" src="75900-buildextensions.png" alt="build extensions" style="width:700px; height:auto"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">We will be adding some data to the following two files:</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75901" src="75901-buildextensionsfiles.png" alt="bild extensions files" style="width:700px; height:auto"></div>
<div style="font-size:small; font-weight:bold"><span style="font-family:'Courier New',Courier,monospace; color:#008000">&nbsp;</span>&nbsp;</div>
<div style="font-size:small; font-weight:bold"><span style="font-family:'Courier New',Courier,monospace; color:#008000">cuda 5.0.props</span> file</div>
<div style="font-size:small; font-weight:bold">&nbsp;</div>
<div style="font-size:small">Add the following CudaClVersion where 2010 (not 2012) is not a mistake. CUDA will not work if you specify 2012 version.</div>
<div style="font-size:small">&nbsp;</div>
<div><span style="color:#808080; font-size:small; font-family:'Courier New',Courier,monospace">&lt;CudaClVersion Condition=&quot;'$(PlatformToolset)' == 'v110'&quot;&gt;2010&lt;/CudaClVersion&gt;
</span></div>
<div>&nbsp;</div>
<div><img id="75902" src="75902-cudaprops.png" alt="CUDA 5.0.props" style="width:700px; height:auto"></div>
<div style="font-size:small; font-weight:bold"><span style="font-family:'Courier New',Courier,monospace; color:#008000">&nbsp;</span>&nbsp;</div>
<div style="font-size:small; font-weight:bold"><span style="font-family:'Courier New',Courier,monospace; color:#008000">cuda 5.0.targets</span> file</div>
<div style="font-size:small; font-weight:bold">&nbsp;</div>
<div style="font-size:small">Modify the following nodes.</div>
<div>
<pre style="color:#808080; font-size:small; font-family:'Courier New',Courier,monospace">         &lt;CudaCleanDependsOn&gt;
            $(CudaCompileDependsOn);
            _SelectedFiles;
            CudaFilterSelectedFiles;
            AddCudaCompileMetadata;
            AddCudaLinkMetadata;
            AddCudaCompileDeps;
            AddCudaCompilePropsDeps;
            ValidateCudaBuild;
            ValidateCudaCodeGeneration;
            ComputeCudaCompileOutput;
            PrepareForCudaBuild
        &lt;/CudaCleanDependsOn&gt;

        GenerateRelocatableDeviceCode=&quot;%(CudaCompile.GenerateRelocatableDeviceCode)&quot;

        CodeGeneration=&quot;%(CudaCompile.CodeGenerationValues)&quot;

        CommandLineTemplate=&quot;&quot;$(CudaToolkitNvccPath)&quot; %(CudaCompile.BuildCommandLineTemplate) %(CudaCompile.ApiCommandLineTemplate) %(CudaCompile.CleanCommandLineTemplate)&quot;
    </pre>
</div>
<div><img id="75904" src="75904-cudatargets.png" alt="CUDA 5.0.targets" style="width:700px; height:auto"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Now you can copy the files to the MS Build folder. You will find two BuildCustomizations folders, you will need the one under v110:
<span style="font-family:'Courier New',Courier,monospace; font-size:small; color:#808000">
C:\Program Files (x86)\MSBuild\Microsoft.Cpp\v4.0\V110\BuildCustomizations</span>. NVidia CUDA SDK samples will use customizations from another folder where the files were copied there during CUDA setup.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75905" src="75905-msbuild.png" alt="ms build" style="width:700px; height:auto"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">In Visual Studio map CUDA file extensions to the C&#43;&#43; to enable code highlighting and intellisence. You will find the mapping under Text Editor.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75907" src="75907-vsfilemapping.png" alt="cu file extension mapping to the C&#43;&#43;" style="width:700px; height:auto"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">And finally, change supported version from 1600 to 1700. To do that, open host_config.h file under
<span style="font-family:'Courier New',Courier,monospace; font-size:small; color:#808000">
C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v5.0\include</span> and scroll to line 90.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75908" src="75908-hostconfig.png" alt="host config" style="width:700px; height:auto"></div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<div><img id="75909" src="75909-supportedversion.png" alt="supported version"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Now you can build CUDA projects.</div>
<h2>CUDA Project</h2>
<div style="font-size:small">Create console application.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75912" src="75912-consoleapp.png" alt="console app" style="width:700px; height:auto"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Select Empty Project.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75911" src="75911-emptyproject.png" alt="empty project"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Change configuratino to x64</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75913" src="75913-x64.png" alt="debug configuration x64"></div>
<div style="font-size:small">Select Build Customizations.</div>
<div><img id="75925" src="75925-vsbuildcustomizations.png" alt="build customizations" style="width:700px; height:auto"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Change compiler to NVidia's by selecting CUDA targets.</div>
<div style="font-size:small">&nbsp;</div>
<div><img id="75915" src="75915-vscudatargets.png" alt="cuda targets"></div>
<div style="font-size:small"></div>
<div style="font-size:small">Modify Visual Studio directories to resolve Include and Lib files.</div>
<div style="font-size:small"></div>
<div><img id="75917" src="75917-vsincludepath.png" alt="include path" style="width:700px; height:auto"></div>
<div></div>
<div><img id="75918" src="75918-vslibpath.png" alt="lib path" style="width:700px; height:auto"></div>
<div></div>
<div><img id="75919" src="75919-vsdirectories.png" alt="visual studio directories" style="width:700px; height:auto"></div>
<div style="font-size:small"></div>
<div style="font-size:small">Still under project properties dialog, go to CUDA and make sure that it targets x64 platform.</div>
<div style="font-size:small"></div>
<div><img id="75920" src="75920-vsx64-2.png" alt="CUDA x64 target" style="width:700px; height:auto"></div>
<div style="font-size:small"></div>
<div style="font-size:small">Almost done! Now we can add a code file.</div>
<div style="font-size:small"></div>
<div><img id="75924" src="75924-addnewitem.png" alt="add new item" style="width:700px; height:auto"></div>
<div style="font-size:small"></div>
<div style="font-size:small">Name it something.cu. File extension <span style="font-family:'Courier New',Courier,monospace; font-size:small; color:#008000">
cu</span> is very important for code files containing CUDA kernels.</div>
<div style="font-size:small"></div>
<div><img id="75921" src="75921-programcu.png" alt="program cu" style="width:700px; height:auto"></div>
<div style="font-size:small"></div>
<div style="font-size:small">Open file properties (right button on the file) and make sure that CUDA targets x64. We are done!</div>
<div style="font-size:small"></div>
<div><img id="75922" src="75922-vsx64.png" alt="x64" style="width:700px; height:auto"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">#include &lt;iostream&gt;
#include &lt;vector&gt;
#include &lt;cuda_runtime.h&gt;

#pragma comment(lib, &quot;cudart&quot;)

using std::cerr;
using std::cout;
using std::endl;
using std::exception;
using std::vector;

static const int MaxSize = 96;

// CUDA kernel: cubes each array value
__global__ void cubeKernel(float* result, float* data)
{
	int idx = threadIdx.x;
	float f = data[idx];
	result[idx] = f * f * f;
}

// Initializes data on the host
void InitializeData(vector&lt;float&gt;&amp; data)
{
	for (int i = 0; i &lt; MaxSize; &#43;&#43;i)
	{
		data[i] = static_cast&lt;float&gt;(i);
	}
}

// Executes CUDA kernel
void RunCubeKernel(vector&lt;float&gt;&amp; data, vector&lt;float&gt;&amp; result)
{
	const size_t size = MaxSize * sizeof(float);

	// TODO: test for error
	float* d;
	float* r;
	cudaError hr;

	hr = cudaMalloc(reinterpret_cast&lt;void**&gt;(&amp;d), size);			// Could return 46 if device is unavailable.
	if (hr == cudaErrorDevicesUnavailable)
	{
		cerr &lt;&lt; &quot;Close all browsers and rerun&quot; &lt;&lt; endl;
		throw std::runtime_error(&quot;Close all browsers and rerun&quot;);
	}

	hr = cudaMalloc(reinterpret_cast&lt;void**&gt;(&amp;r), size);
	if (hr == cudaErrorDevicesUnavailable)
	{
		cerr &lt;&lt; &quot;Close all browsers and rerun&quot; &lt;&lt; endl;
		throw std::runtime_error(&quot;Close all browsers and rerun&quot;);
	}

	// Copy data to the device
	cudaMemcpy(d, &amp;data[0], size, cudaMemcpyHostToDevice);

	// Launch kernel: 1 block, 96 threads
	// Important: Do not exceed number of threads returned by the device query, 1024 on my computer.
	cubeKernel&lt;&lt;&lt;1, MaxSize&gt;&gt;&gt;(r, d);

	// Copy back to the host
	cudaMemcpy(&amp;result[0], r, size, cudaMemcpyDeviceToHost);

	// Free device memory
	cudaFree(d);
	cudaFree(r);
}

// Main entry into the program
int main(void)
{
	cout &lt;&lt; &quot;In main.&quot; &lt;&lt; endl;

	// Create sample data
	vector&lt;float&gt; data(MaxSize);
	InitializeData(data);

	// Compute cube on the device
	vector&lt;float&gt; cube(MaxSize);
	RunCubeKernel(data, cube);

	// Print out results
	cout &lt;&lt; &quot;Cube kernel results.&quot; &lt;&lt; endl &lt;&lt; endl;

	for (int i = 0; i &lt; MaxSize; &#43;&#43;i)
	{
		cout &lt;&lt; cube[i] &lt;&lt; endl;
	}

	return 0;
}
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#include&nbsp;&lt;iostream&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;vector&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;cuda_runtime.h&gt;</span><span class="cpp__preproc">&nbsp;
&nbsp;
#pragma&nbsp;comment(lib,&nbsp;&quot;cudart&quot;)</span>&nbsp;
&nbsp;
<span class="cpp__keyword">using</span>&nbsp;std::cerr;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;std::cout;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;std::endl;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;std::exception;&nbsp;
<span class="cpp__keyword">using</span>&nbsp;std::vector;&nbsp;
&nbsp;
<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;MaxSize&nbsp;=&nbsp;<span class="cpp__number">96</span>;&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;CUDA&nbsp;kernel:&nbsp;cubes&nbsp;each&nbsp;array&nbsp;value</span>&nbsp;
__global__&nbsp;<span class="cpp__keyword">void</span>&nbsp;cubeKernel(<span class="cpp__datatype">float</span>*&nbsp;result,&nbsp;<span class="cpp__datatype">float</span>*&nbsp;data)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;idx&nbsp;=&nbsp;threadIdx.x;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;f&nbsp;=&nbsp;data[idx];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;result[idx]&nbsp;=&nbsp;f&nbsp;*&nbsp;f&nbsp;*&nbsp;f;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Initializes&nbsp;data&nbsp;on&nbsp;the&nbsp;host</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;InitializeData(vector&lt;<span class="cpp__datatype">float</span>&gt;&amp;&nbsp;data)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;MaxSize;&nbsp;&#43;&#43;i)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data[i]&nbsp;=&nbsp;<span class="cpp__keyword">static_cast</span>&lt;<span class="cpp__datatype">float</span>&gt;(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Executes&nbsp;CUDA&nbsp;kernel</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;RunCubeKernel(vector&lt;<span class="cpp__datatype">float</span>&gt;&amp;&nbsp;data,&nbsp;vector&lt;<span class="cpp__datatype">float</span>&gt;&amp;&nbsp;result)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">size_t</span>&nbsp;size&nbsp;=&nbsp;MaxSize&nbsp;*&nbsp;<span class="cpp__keyword">sizeof</span>(<span class="cpp__datatype">float</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;TODO:&nbsp;test&nbsp;for&nbsp;error</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>*&nbsp;d;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>*&nbsp;r;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cudaError&nbsp;hr;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaMalloc(<span class="cpp__keyword">reinterpret_cast</span>&lt;<span class="cpp__keyword">void</span>**&gt;(&amp;d),&nbsp;size);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Could&nbsp;return&nbsp;46&nbsp;if&nbsp;device&nbsp;is&nbsp;unavailable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(hr&nbsp;==&nbsp;cudaErrorDevicesUnavailable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cerr&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Close&nbsp;all&nbsp;browsers&nbsp;and&nbsp;rerun&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">throw</span>&nbsp;std::runtime_error(<span class="cpp__string">&quot;Close&nbsp;all&nbsp;browsers&nbsp;and&nbsp;rerun&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaMalloc(<span class="cpp__keyword">reinterpret_cast</span>&lt;<span class="cpp__keyword">void</span>**&gt;(&amp;r),&nbsp;size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(hr&nbsp;==&nbsp;cudaErrorDevicesUnavailable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cerr&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Close&nbsp;all&nbsp;browsers&nbsp;and&nbsp;rerun&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">throw</span>&nbsp;std::runtime_error(<span class="cpp__string">&quot;Close&nbsp;all&nbsp;browsers&nbsp;and&nbsp;rerun&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Copy&nbsp;data&nbsp;to&nbsp;the&nbsp;device</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cudaMemcpy(d,&nbsp;&amp;data[<span class="cpp__number">0</span>],&nbsp;size,&nbsp;cudaMemcpyHostToDevice);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Launch&nbsp;kernel:&nbsp;1&nbsp;block,&nbsp;96&nbsp;threads</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Important:&nbsp;Do&nbsp;not&nbsp;exceed&nbsp;number&nbsp;of&nbsp;threads&nbsp;returned&nbsp;by&nbsp;the&nbsp;device&nbsp;query,&nbsp;1024&nbsp;on&nbsp;my&nbsp;computer.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cubeKernel&lt;&lt;&lt;<span class="cpp__number">1</span>,&nbsp;MaxSize&gt;&gt;&gt;(r,&nbsp;d);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Copy&nbsp;back&nbsp;to&nbsp;the&nbsp;host</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cudaMemcpy(&amp;result[<span class="cpp__number">0</span>],&nbsp;r,&nbsp;size,&nbsp;cudaMemcpyDeviceToHost);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Free&nbsp;device&nbsp;memory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cudaFree(d);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cudaFree(r);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Main&nbsp;entry&nbsp;into&nbsp;the&nbsp;program</span>&nbsp;
<span class="cpp__datatype">int</span>&nbsp;main(<span class="cpp__keyword">void</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;In&nbsp;main.&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Create&nbsp;sample&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;vector&lt;<span class="cpp__datatype">float</span>&gt;&nbsp;data(MaxSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;InitializeData(data);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Compute&nbsp;cube&nbsp;on&nbsp;the&nbsp;device</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;vector&lt;<span class="cpp__datatype">float</span>&gt;&nbsp;cube(MaxSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RunCubeKernel(data,&nbsp;cube);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Print&nbsp;out&nbsp;results</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Cube&nbsp;kernel&nbsp;results.&quot;</span>&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;MaxSize;&nbsp;&#43;&#43;i)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;cube[i]&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h2>Summary</h2>
<div style="font-size:small">Was easy, was not it?! Note that when you run your code you will likely encounter
<span style="font-family:'Courier New',Courier,monospace; font-size:small; color:#ff0000">
cudaErrorDevicesUnavailable (46)</span> error. It basically means that if your card is dedicated to video output it may be used by something else, usually a browser. Close all browsers, Internet Explorer that is, and re-run, it wil work now.</div>
<div style="font-size:small"></div>
<div><img id="75926" src="75926-deviceunavailable.png" alt="cuda device is busy"></div>
<h1>Source Code Files</h1>
<dl><dt><span style="font-size:small">program.cu </span></dt><dd><span style="font-size:small">program entry and CUDA cube kernel. </span></dd></dl>
