/*!-----------------------------------------------------------------------
	connect.cpp

	The main implementation of the addin. It includes the implementation
	for IDTExtensibility2
-----------------------------------------------------------------------!*/
#include "stdafx.h"
#include "connect.h"
#include "AdjacentWindowHelper.h"
#include "Idlecall.h"

int  g_verOLMajor;
bool g_fHostShutdown = false;

/*!-----------------------------------------------------------------------
	CConnect implementation
-----------------------------------------------------------------------!*/

_ATL_FUNC_INFO CConnect::DispatchFuncInfo1 = {CC_STDCALL, VT_EMPTY, 1, {VT_DISPATCH}};

STDMETHODIMP CConnect::OnConnection
	( IDispatch *pApplication
	, ext_ConnectMode /* ConnectMode */
	, IDispatch* /* pAddInInst */
	, SAFEARRAY ** /* custom */ )
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CComBSTR bstrVersion;
	int      v2, v3, v4;

	if (!pApplication)
		return E_POINTER;

	m_spApplication = pApplication;

	// Get the version of Outlook
	if (FAILED(m_spApplication->get_Version(&bstrVersion)))
		return E_FAIL;
	if (4 != swscanf_s(bstrVersion, L"%d.%d.%d.%d", &g_verOLMajor, &v2, &v3, &v4))
		return E_FAIL;

	// Subscribe to Inspectors events
	if (FAILED(m_spApplication->get_Inspectors(&m_spInspectors)))
		return E_FAIL;
	if (FAILED(InspectorsEventsSink::DispEventAdvise(m_spInspectors)))
		return E_FAIL;

	// Subscribe to Explorers events
	if (FAILED(m_spApplication->get_Explorers(&m_spExplorers)))
		return E_FAIL;
	if (FAILED(ExplorersEventsSink::DispEventAdvise(m_spExplorers)))
		return E_FAIL;

	InitializeIdle();
	InitializeAdjacentWindows(m_spExplorers, m_spInspectors);

	return S_OK;
}

STDMETHODIMP CConnect::OnDisconnection
	( ext_DisconnectMode extRemoveMode
	, SAFEARRAY ** /*custom*/ )
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	g_fHostShutdown = (extRemoveMode == ext_dm_HostShutdown);

	UninitializeIdle();

	if (m_spInspectors)
		InspectorsEventsSink::DispEventUnadvise(m_spInspectors);

	if (m_spExplorers)
		ExplorersEventsSink::DispEventUnadvise(m_spExplorers);

	return S_OK;
}

STDMETHODIMP CConnect::OnAddInsUpdate(SAFEARRAY ** /*custom*/)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	return S_OK;
}

STDMETHODIMP CConnect::OnStartupComplete(SAFEARRAY ** /*custom*/)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	return S_OK;
}

STDMETHODIMP CConnect::OnBeginShutdown(SAFEARRAY ** /*custom*/)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	return S_OK;
}

STDMETHODIMP CConnect::EvtNewInspector(IDispatch* /*Inspector*/)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	CallIdle(idleFindTopLevelWindows);
	return S_OK;
}

STDMETHODIMP CConnect::EvtNewExplorer(IDispatch* /*Explorer*/)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	CallIdle(idleFindTopLevelWindows);
	return S_OK;
}

