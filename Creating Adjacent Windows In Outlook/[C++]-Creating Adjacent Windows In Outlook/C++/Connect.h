/*!-----------------------------------------------------------------------
	connect.h
-----------------------------------------------------------------------!*/
#pragma once
#include "ids.h"

class CConnect;

typedef
	IDispatchImpl<_IDTExtensibility2, &__uuidof(_IDTExtensibility2), &__uuidof(__AddInDesignerObjects), 1, 0>
	IDTExtensibilityImpl;

typedef
	IDispEventSimpleImpl<1, CConnect, &__uuidof(InspectorsEvents)>
	InspectorsEventsSink;

typedef
	IDispEventSimpleImpl<2, CConnect, &__uuidof(ExplorersEvents)>
	ExplorersEventsSink;

/*------------------------------------------------------------------------------
	CConnect class - what Outlook uses to communicate with an add-in
------------------------------------------------------------------------------*/
class ATL_NO_VTABLE CConnect
	: public CComObjectRootEx<CComSingleThreadModel>
	, public CComCoClass<CConnect, &__uuidof(Connect)>
	, public IDTExtensibilityImpl
	, public InspectorsEventsSink
	, public ExplorersEventsSink
{
public:
	CConnect() {}

	// Setup the registration found in addin.rgs
	static HRESULT WINAPI UpdateRegistry(BOOL bRegister) throw()
	{
		ATL::_ATL_REGMAP_ENTRY regMapEntries[] =
		{ { OLESTR("PROGID"), ADDIN_PROGID }
		, { OLESTR("CLSID"), ADDIN_CLSID_STR }
		, { OLESTR("TYPELIB"), TYPELIB_GUID_STR }
		, { NULL, NULL }
		};

		return ATL::_pAtlModule->UpdateRegistryFromResource(IDR_ADDIN, bRegister, regMapEntries);
	}

	DECLARE_NOT_AGGREGATABLE(CConnect)

	BEGIN_COM_MAP(CConnect)
		COM_INTERFACE_ENTRY(IDTExtensibility2)
	END_COM_MAP()

	static _ATL_FUNC_INFO DispatchFuncInfo1;

	BEGIN_SINK_MAP(CConnect)
		SINK_ENTRY_INFO(1, __uuidof(InspectorsEvents),     dispidEventNewInspector,      EvtNewInspector,      &DispatchFuncInfo1)
		SINK_ENTRY_INFO(2, __uuidof(ExplorersEvents),      dispidEventNewExplorer,       EvtNewExplorer,       &DispatchFuncInfo1)
	END_SINK_MAP()

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct() { return S_OK;	}
	void FinalRelease()	{ }

public:
	// IDTExtensibility2 interface
	STDMETHOD(OnConnection)(IDispatch * Application, ext_ConnectMode ConnectMode, IDispatch *AddInInst, SAFEARRAY **custom);
	STDMETHOD(OnDisconnection)(ext_DisconnectMode RemoveMode, SAFEARRAY **custom );
	STDMETHOD(OnAddInsUpdate)(SAFEARRAY **custom );
	STDMETHOD(OnStartupComplete)(SAFEARRAY **custom );
	STDMETHOD(OnBeginShutdown)(SAFEARRAY **custom );

	STDMETHOD(EvtNewInspector)(IDispatch* /*Inspector*/ pdispInspector);
	STDMETHOD(EvtNewExplorer)(IDispatch* /*Explorer*/ pdispExplorer);

protected:
	_ApplicationPtr  m_spApplication;
	_ExplorersPtr    m_spExplorers;
	_InspectorsPtr   m_spInspectors;
};

OBJECT_ENTRY_AUTO(__uuidof(Connect), CConnect)
