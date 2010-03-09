// Machine generated IDispatch wrapper class(es) created with Add Class from Typelib Wizard

#import "c:\\Documents and Settings\\Administrator\\My Documents\\Visual Studio 2008\\Projects\\OutCom\\OutCom\\Debug\\OutCom.exe" no_namespace
// CSimple wrapper class

class CSimple : public COleDispatchDriver
{
public:
	CSimple(){} // Calls COleDispatchDriver default constructor
	CSimple(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	CSimple(const CSimple& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

	// Attributes
public:

	// Operations
public:


	// ISimple methods
public:
	MyStruct GetStruct()
	{
		InvokeHelper(0x1, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	MyStruct GetStructByIndex(long lIndex)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x2, DISPATCH_METHOD, VT_EMPTY, NULL, parms, lIndex);
	}

	// ISimple properties
public:

};
