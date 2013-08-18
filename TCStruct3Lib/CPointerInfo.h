#ifndef CPOINTERINFO_H
#define CPOINTERINFO_H

#include "Global.h"
#include "CPointerVariable.h"

class CPointerInfo
{
private:
	wchar_t* _szModule;
	size_t _nModuleLength;
	DWORD _dwPID;
	bool _bIsValidHandle;
public:
	CPointerVariable** cpVars;
	int nVariableCount;
	HANDLE hProcess;
	HMODULE hModule;
	UINT_PTR* lpOffsets;
	int nOffsetCount;
	void SetPID(DWORD dwPID);
	bool GetHandles();
	CPointerInfo(wchar_t* szModule, UINT_PTR* lpOffsets, int nOffsetCount);
	CPointerInfo(wchar_t* szModule, UINT_PTR* lpOffsets, int nOffsetCount, CPointerVariable** _cpVars, int _nVariableCount);
	~CPointerInfo() {CloseHandle(hProcess); delete[] _szModule; delete[] lpOffsets;}
};

NOMANGLE CPointerInfo* EXPORTED CreateCPointerInfoClassObject(wchar_t* szModule, UINT_PTR* lpOffsets, int nOffsetCount);
NOMANGLE CPointerInfo* EXPORTED CreateCPointerInfoClassObjectExtended(wchar_t* szModule, UINT_PTR* lpOffsets, int nOffsetCount, CPointerVariable** _cpVars, int _nVariableCount);
NOMANGLE bool EXPORTED FreeCPointerInfoClassObject(CPointerInfo* cpInfo);

#endif