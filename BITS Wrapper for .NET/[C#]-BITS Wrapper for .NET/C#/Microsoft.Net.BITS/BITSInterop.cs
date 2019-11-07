using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Net.BITS.Interop
{
	[ComImport, CoClass(typeof(BackgroundCopyManager2_0Class)), Guid("5CE34C0D-0DC9-4C1F-897C-DAA1B78CEE7C")]
	internal interface BackgroundCopyManager2_0 : IBackgroundCopyManager
	{
	}

	[ComImport, TypeLibType((short)2), Guid("6D18AD12-BDE3-4393-B311-099C346E6DF9"), ClassInterface((short)0)]
	internal class BackgroundCopyManager2_0Class : IBackgroundCopyManager, BackgroundCopyManager2_0
	{
		// Methods
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void CreateJob([In, MarshalAs(UnmanagedType.LPWStr)] string DisplayName, [In, ComAliasName("BG_JOB_TYPE")] BackgroundCopyJobType Type, [ComAliasName("GUID")] out Guid pJobId, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void EnumJobs([In] uint dwFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyJobs ppenum);

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void GetErrorDescription([In, MarshalAs(UnmanagedType.Error)] int hResult, [In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pErrorDescription);

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void GetJob([In, ComAliasName("GUID")] ref Guid jobID, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);
	}

	internal enum BG_AUTH_SCHEME
	{
		// Fields
		BG_AUTH_SCHEME_BASIC = 1,
		BG_AUTH_SCHEME_DIGEST = 2,
		BG_AUTH_SCHEME_NEGOTIATE = 4,
		BG_AUTH_SCHEME_NTLM = 3,
		BG_AUTH_SCHEME_PASSPORT = 5
	}

	internal enum BG_AUTH_TARGET
	{
		// Fields
		BG_AUTH_TARGET_PROXY = 2,
		BG_AUTH_TARGET_SERVER = 1
	}

	internal enum BackgroundCopyJobProxyUsage
	{
		Preconfig,
		NoProxy,
		Override,
		Autodetect
	}

	[Flags]
	internal enum BackgroundCopyJobNotifyFlags
	{
		None = 0,
		Transferred = 0x0001,
		Error = 0x0002,
		Disable = 0x0004,
		Modification = 0x0008
	}

	[ComImport, Guid("97EA99C7-0186-4AD4-8DF9-C5B4E0ED6B22"), InterfaceType((short)1)]
	internal interface IBackgroundCopyCallback
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void JobTransferred([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void JobError([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyError pError);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void JobModification([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In] uint dwReserved);
	}

	[ComImport, InterfaceType((short)1), Guid("19C613A0-FCB8-4F28-81AE-897C3D078F81")]
	internal interface IBackgroundCopyError
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetError([ComAliasName("BG_ERROR_CONTEXT")] out BackgroundCopyErrorContext pContext, [MarshalAs(UnmanagedType.Error)] out int pCode);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetFile([MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyFile pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetErrorDescription([In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pErrorDescription);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetErrorContextDescription([In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pContextDescription);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetProtocol([MarshalAs(UnmanagedType.LPWStr)] out string pProtocol);
	}

	[ComImport, Guid("01B7BD23-FB88-4A77-8490-5891D3E4653A"), InterfaceType((short)1)]
	internal interface IBackgroundCopyFile
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetRemoteName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetLocalName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetProgress(out BackgroundCopyFileProgress pVal);
	}

	[ComImport, InterfaceType((short)1), Guid("37668D37-507E-4160-9316-26306D150B12")]
	internal interface IBackgroundCopyJob
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] BackgroundCopyFileInfo[] pFileSet);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void EnumFiles([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyFiles pEnum);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Suspend();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Resume();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Cancel();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Complete();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetId([ComAliasName("GUID")] out Guid pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetType([ComAliasName("BG_JOB_TYPE")] out BackgroundCopyJobType pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetProgress(out BackgroundCopyJobProgress pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetTimes(out BackgroundCopyJobTimes pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetState([ComAliasName("BG_JOB_STATE")] out BackgroundCopyJobState pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetError([MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyError ppError);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetOwner([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetDescription([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetPriority([In, ComAliasName("BG_JOB_PRIORITY")] BackgroundCopyJobPriority Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetPriority([ComAliasName("BG_JOB_PRIORITY")] out BackgroundCopyJobPriority pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetNotifyFlags([In] uint Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetNotifyFlags(out uint pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetNotifyInterface([In, MarshalAs(UnmanagedType.IUnknown)] object Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetNotifyInterface([MarshalAs(UnmanagedType.IUnknown)] out object pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetMinimumRetryDelay([In] uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetMinimumRetryDelay(out uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetNoProgressTimeout([In] uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetNoProgressTimeout(out uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetErrorCount(out uint Errors);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetProxySettings([In, ComAliasName("BG_JOB_PROXY_USAGE")] BackgroundCopyJobProxyUsage ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetProxySettings([ComAliasName("BG_JOB_PROXY_USAGE")] out BackgroundCopyJobProxyUsage pProxyUsage, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyList, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyBypassList);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void TakeOwnership();
	}

	[ComImport, Guid("54B50739-686F-45EB-9DFF-D6A9A0FAA9AF"), InterfaceType((short)1), ComConversionLoss]
	internal interface IBackgroundCopyJob2 : IBackgroundCopyJob
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BackgroundCopyFileInfo[] pFileSet);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void EnumFiles([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyFiles pEnum);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Suspend();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Resume();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Cancel();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Complete();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetId([ComAliasName("GUID")] out Guid pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetType([ComAliasName("BG_JOB_TYPE")] out BackgroundCopyJobType pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetProgress(out BackgroundCopyJobProgress pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetTimes(out BackgroundCopyJobTimes pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetState([ComAliasName("BG_JOB_STATE")] out BackgroundCopyJobState pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetError([MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyError ppError);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetOwner([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetDescription([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetPriority([In, ComAliasName("BG_JOB_PRIORITY")] BackgroundCopyJobPriority Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetPriority([ComAliasName("BG_JOB_PRIORITY")] out BackgroundCopyJobPriority pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetNotifyFlags([In] uint Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetNotifyFlags(out uint pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetNotifyInterface([In, MarshalAs(UnmanagedType.IUnknown)] object Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetNotifyInterface([MarshalAs(UnmanagedType.IUnknown)] out object pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetMinimumRetryDelay([In] uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetMinimumRetryDelay(out uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetNoProgressTimeout([In] uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetNoProgressTimeout(out uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetErrorCount(out uint Errors);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetProxySettings([In, ComAliasName("BG_JOB_PROXY_USAGE")] BackgroundCopyJobProxyUsage ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetProxySettings([ComAliasName("BG_JOB_PROXY_USAGE")] out BackgroundCopyJobProxyUsage pProxyUsage, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyList, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyBypassList);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void TakeOwnership();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetNotifyCmdLine([In, MarshalAs(UnmanagedType.LPWStr)] string Program, [In, MarshalAs(UnmanagedType.LPWStr)] string Parameters);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetNotifyCmdLine([MarshalAs(UnmanagedType.LPWStr)] out string pProgram, [MarshalAs(UnmanagedType.LPWStr)] out string pParameters);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetReplyProgress(out BackgroundCopyJobReplyProgress pProgress);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetReplyData(out IntPtr ppBuffer, out ulong pLength);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetReplyFileName([In, MarshalAs(UnmanagedType.LPWStr)] string ReplyFileName);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetReplyFileName([MarshalAs(UnmanagedType.LPWStr)] out string pReplyFileName);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetCredentials([In, ComAliasName("BG_AUTH_CREDENTIALS")] ref BG_AUTH_CREDENTIALS Credentials);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void RemoveCredentials([In, ComAliasName("BG_AUTH_TARGET")] BG_AUTH_TARGET Target, [In, ComAliasName("BG_AUTH_SCHEME")] BG_AUTH_SCHEME Scheme);
	}

	[ComImport, InterfaceType((short)1), Guid("443C8934-90FF-48ED-BCDE-26F5C7450042")]
	internal interface IBackgroundCopyJob3 : IBackgroundCopyJob2
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BackgroundCopyFileInfo[] pFileSet);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void EnumFiles([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyFiles pEnum);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Suspend();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Resume();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Cancel();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void Complete();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetId([ComAliasName("GUID")] out Guid pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetType([ComAliasName("BG_JOB_TYPE")] out BackgroundCopyJobType pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetProgress(out BackgroundCopyJobProgress pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetTimes(out BackgroundCopyJobTimes pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetState([ComAliasName("BG_JOB_STATE")] out BackgroundCopyJobState pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetError([MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyError ppError);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetOwner([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetDescription([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetPriority([In, ComAliasName("BG_JOB_PRIORITY")] BackgroundCopyJobPriority Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetPriority([ComAliasName("BG_JOB_PRIORITY")] out BackgroundCopyJobPriority pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetNotifyFlags([In] uint Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetNotifyFlags(out uint pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetNotifyInterface([In, MarshalAs(UnmanagedType.IUnknown)] object Val);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetNotifyInterface([MarshalAs(UnmanagedType.IUnknown)] out object pVal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetMinimumRetryDelay([In] uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetMinimumRetryDelay(out uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetNoProgressTimeout([In] uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetNoProgressTimeout(out uint Seconds);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetErrorCount(out uint Errors);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetProxySettings([In, ComAliasName("BG_JOB_PROXY_USAGE")] BackgroundCopyJobProxyUsage ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetProxySettings([ComAliasName("BG_JOB_PROXY_USAGE")] out BackgroundCopyJobProxyUsage pProxyUsage, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyList, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyBypassList);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void TakeOwnership();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetNotifyCmdLine([In, MarshalAs(UnmanagedType.LPWStr)] string Program, [In, MarshalAs(UnmanagedType.LPWStr)] string Parameters);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetNotifyCmdLine([MarshalAs(UnmanagedType.LPWStr)] out string pProgram, [MarshalAs(UnmanagedType.LPWStr)] out string pParameters);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetReplyProgress(out BackgroundCopyJobReplyProgress pProgress);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetReplyData(out IntPtr ppBuffer, out ulong pLength);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetReplyFileName([In, MarshalAs(UnmanagedType.LPWStr)] string ReplyFileName);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void GetReplyFileName([MarshalAs(UnmanagedType.LPWStr)] out string pReplyFileName);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void SetCredentials([In, ComAliasName("BG_AUTH_CREDENTIALS")] ref BG_AUTH_CREDENTIALS Credentials);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		new void RemoveCredentials([In, ComAliasName("BG_AUTH_TARGET")] BG_AUTH_TARGET Target, [In, ComAliasName("BG_AUTH_SCHEME")] BG_AUTH_SCHEME Scheme);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void ReplaceRemotePrefix([In, MarshalAs(UnmanagedType.LPWStr)] string OldPrefix, [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void AddFileWithRanges([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName, [In] uint RangeCount, [In] BG_FILE_RANGE Ranges);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetFileACLFlags([In] uint Flags);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetFileACLFlags(out uint Flags);
	}

	[ComImport, Guid("5CE34C0D-0DC9-4C1F-897C-DAA1B78CEE7C"), InterfaceType((short)1)]
	internal interface IBackgroundCopyManager
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void CreateJob([In, MarshalAs(UnmanagedType.LPWStr)] string DisplayName, [In, ComAliasName("BG_JOB_TYPE")] BackgroundCopyJobType Type, [ComAliasName("GUID")] out Guid pJobId, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetJob([In, ComAliasName("GUID")] ref Guid jobID, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void EnumJobs([In] uint dwFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyJobs ppenum);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetErrorDescription([In, MarshalAs(UnmanagedType.Error)] int hResult, [In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pErrorDescription);
	}

	[ComImport, InterfaceType((short)1), Guid("CA51E165-C365-424C-8D41-24AAA4FF3C40")]
	internal interface IEnumBackgroundCopyFiles
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Next([In] uint celt, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyFile rgelt, [In, Out] ref uint pceltFetched);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Skip([In] uint celt);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Reset();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyFiles ppenum);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetCount(out uint puCount);
	}

	[ComImport, Guid("1AF4F612-3B71-466F-8F58-7B6F73AC57AD"), InterfaceType((short)1)]
	internal interface IEnumBackgroundCopyJobs
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Next([In] uint celt, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob rgelt, [In, Out] ref uint pceltFetched);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Skip([In] uint celt);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Reset();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyJobs ppenum);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetCount(out uint puCount);
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct BackgroundCopyFileProgress
	{
		public ulong BytesTotal;
		public ulong BytesTransferred;
		public int Completed;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct BackgroundCopyFileInfo
	{
		[MarshalAs(UnmanagedType.LPWStr)]
		public string RemoteName;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string LocalName;

		public BackgroundCopyFileInfo(string remoteUrl, string localFilePath)
		{
			this.RemoteName = remoteUrl;
			this.LocalName = localFilePath;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct BG_FILE_RANGE
	{
		public ulong InitialOffset;
		public ulong Length;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct BackgroundCopyJobTimes
	{
		public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
		public System.Runtime.InteropServices.ComTypes.FILETIME ModificationTime;
		public System.Runtime.InteropServices.ComTypes.FILETIME TransferCompletionTime;
	}

	[StructLayout(LayoutKind.Explicit, Size = 16, Pack = 4)]
	internal struct BG_AUTH_CREDENTIALS
	{
		[FieldOffset(0)]
		public BG_AUTH_TARGET Target;

		[FieldOffset(4)]
		public BG_AUTH_SCHEME Scheme;

		[FieldOffset(8)]
		public BG_AUTH_CREDENTIALS_UNION Credentials;
	}

	[StructLayout(LayoutKind.Explicit, Size = 8, Pack = 4)]
	internal struct BG_AUTH_CREDENTIALS_UNION
	{
		[FieldOffset(0)]
		public BG_BASIC_CREDENTIALS Basic;
	}

	[StructLayout(LayoutKind.Explicit, Size = 8, Pack = 4)]
	internal struct BG_BASIC_CREDENTIALS
	{
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.LPWStr)]
		public string UserName;

		[FieldOffset(4)]
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Password;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct __MIDL___MIDL_itf_bits2_0_0005_0001
	{
		public uint Data1;
		public ushort Data2;
		public ushort Data3;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] Data4;
	}
}
