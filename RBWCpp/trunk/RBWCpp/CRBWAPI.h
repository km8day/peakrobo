// Machine generated IDispatch wrapper class(es) created with Add Class from Typelib Wizard

#import "F:\\Program Files\\RobotWorks65\\RobotWorks65.exe" no_namespace
// CRBWAPI wrapper class

class CRBWAPI : public COleDispatchDriver
{
public:
	CRBWAPI(){} // Calls COleDispatchDriver default constructor
	CRBWAPI(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	CRBWAPI(const CRBWAPI& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

	// Attributes
public:

	// Operations
public:


	// _API methods
public:
	short Cap_GetStatus()
	{
		short result;
		InvokeHelper(0x60030000, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	short Cap_GetPoint(long POINT, CaptureData * CapData)
	{
		short result;
		static BYTE parms[] = VTS_I4 VTS_UNKNOWN ;
		InvokeHelper(0x60030001, DISPATCH_METHOD, VT_I2, (void*)&result, parms, POINT, CapData);
		return result;
	}
	long Cap_GetPointCount()
	{
		long result;
		InvokeHelper(0x60030002, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	short Get_CreatePointData(long POINT, OrientationData * Data)
	{
		short result;
		static BYTE parms[] = VTS_I4 VTS_PR4 ;
		InvokeHelper(0x60030003, DISPATCH_METHOD, VT_I2, (void*)&result, parms, POINT, Data);
		return result;
	}
	long Get_PointCount()
	{
		long result;
		InvokeHelper(0x60030004, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	short Get_TableCell_C(long * table, long * row, long * col, long * Leng, LPCTSTR Value)
	{
		short result;
		static BYTE parms[] = VTS_PI4 VTS_PI4 VTS_PI4 VTS_PI4 VTS_BSTR ;
		InvokeHelper(0x60030005, DISPATCH_METHOD, VT_I2, (void*)&result, parms, table, row, col, Leng, Value);
		return result;
	}
	short Set_TableCell(long * table, long * row, long * col, LPCTSTR Value)
	{
		short result;
		static BYTE parms[] = VTS_PI4 VTS_PI4 VTS_PI4 VTS_BSTR ;
		InvokeHelper(0x60030006, DISPATCH_METHOD, VT_I2, (void*)&result, parms, table, row, col, Value);
		return result;
	}
	CString Get_TableCell_ST(long * table, long * row, long * col)
	{
		CString result;
		static BYTE parms[] = VTS_PI4 VTS_PI4 VTS_PI4 ;
		InvokeHelper(0x60030007, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, table, row, col);
		return result;
	}
	short Get_ToolName_C(LPCTSTR Value)
	{
		short result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x60030008, DISPATCH_METHOD, VT_I2, (void*)&result, parms, Value);
		return result;
	}
	short Get_ToolName(BSTR * Value)
	{
		short result;
		static BYTE parms[] = VTS_PBSTR ;
		InvokeHelper(0x60030009, DISPATCH_METHOD, VT_I2, (void*)&result, parms, Value);
		return result;
	}
	short Get_TableCell(long * table, long * row, long * col, BSTR * Value)
	{
		short result;
		static BYTE parms[] = VTS_PI4 VTS_PI4 VTS_PI4 VTS_PBSTR ;
		InvokeHelper(0x6003000a, DISPATCH_METHOD, VT_I2, (void*)&result, parms, table, row, col, Value);
		return result;
	}
	short Get_PointXYZ(long POINT, double * X, double * Y, double * z)
	{
		short result;
		static BYTE parms[] = VTS_I4 VTS_PR8 VTS_PR8 VTS_PR8 ;
		InvokeHelper(0x6003000b, DISPATCH_METHOD, VT_I2, (void*)&result, parms, POINT, X, Y, z);
		return result;
	}
	short Get_Position(double * X, double * Y, double * z, double * Rx, double * Ry, double * Rz)
	{
		short result;
		static BYTE parms[] = VTS_PR8 VTS_PR8 VTS_PR8 VTS_PR8 VTS_PR8 VTS_PR8 ;
		InvokeHelper(0x6003000c, DISPATCH_METHOD, VT_I2, (void*)&result, parms, X, Y, z, Rx, Ry, Rz);
		return result;
	}
	short Get_PointData(long POINT, PointData * Data)
	{
		short result;
		static BYTE parms[] = VTS_I4 VTS_UNKNOWN ;
		InvokeHelper(0x6003000d, DISPATCH_METHOD, VT_I2, (void*)&result, parms, POINT, Data);
		return result;
	}
	long Set_PathPointData(short * PT, OrientationData * Dat)
	{
		long result;
		static BYTE parms[] = VTS_PI2 VTS_UNKNOWN ;
		InvokeHelper(0x6003000e, DISPATCH_METHOD, VT_I4, (void*)&result, parms, PT, Dat);
		return result;
	}
	long Set_PathScript()
	{
		long result;
		InvokeHelper(0x6003000f, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	short Set_PointFull(long POINT, OrientationData * Dat)
	{
		short result;
		static BYTE parms[] = VTS_I4 VTS_UNKNOWN ;
		InvokeHelper(0x60030010, DISPATCH_METHOD, VT_I2, (void*)&result, parms, POINT, Dat);
		return result;
	}
	short Set_PointXYZ(long POINT, double X, double Y, double z)
	{
		short result;
		static BYTE parms[] = VTS_I4 VTS_R8 VTS_R8 VTS_R8 ;
		InvokeHelper(0x60030011, DISPATCH_METHOD, VT_I2, (void*)&result, parms, POINT, X, Y, z);
		return result;
	}
	short Exec_SimulationRun()
	{
		short result;
		InvokeHelper(0x60030012, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}
	short Exec_GotoPoint(long POINT)
	{
		short result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x60030013, DISPATCH_METHOD, VT_I2, (void*)&result, parms, POINT);
		return result;
	}
	short Get_ConvData(ConvData * Data)
	{
		short result;
		static BYTE parms[] = VTS_UNKNOWN ;
		InvokeHelper(0x60030014, DISPATCH_METHOD, VT_I2, (void*)&result, parms, Data);
		return result;
	}
	short Get_JButtons(short * Dopt, BOOL * Dstt)
	{
		short result;
		static BYTE parms[] = VTS_PI2 VTS_PBOOL ;
		InvokeHelper(0x60030015, DISPATCH_METHOD, VT_I2, (void*)&result, parms, Dopt, Dstt);
		return result;
	}
	VARIANT Get_PivotData(PivotData * Data)
	{
		VARIANT result;
		static BYTE parms[] = VTS_UNKNOWN ;
		InvokeHelper(0x60030016, DISPATCH_METHOD, VT_VARIANT, (void*)&result, parms, Data);
		return result;
	}
	short Exec_Convert()
	{
		short result;
		InvokeHelper(0x60030017, DISPATCH_METHOD, VT_I2, (void*)&result, NULL);
		return result;
	}

	// _API properties
public:

};
