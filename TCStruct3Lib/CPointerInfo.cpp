#include "CPointer.h"
#include "DebugOutput.h"
#include <TlHelp32.h>

CPointerInfo::CPointerInfo(wchar_t* szModule, UINT_PTR* _lpOffsets, int _nOffsetCount)
{
	_nModuleLength = (int)wcslen(szModule) + 1;
	_szModule = new wchar_t[_nModuleLength];
	memcpy(_szModule, szModule, _nModuleLength * sizeof(wchar_t));
	lpOffsets = new UINT_PTR[_nOffsetCount];
	memcpy(lpOffsets, _lpOffsets, _nOffsetCount * sizeof(UINT_PTR));
	nOffsetCount = _nOffsetCount;
}

CPointerInfo::CPointerInfo(wchar_t* szModule, UINT_PTR* _lpOffsets, int _nOffsetCount, CPointerVariable** _cpVars, int _nVariableCount)
{
	_nModuleLength = (int)wcslen(szModule) + 1;
	_szModule = new wchar_t[_nModuleLength];
	memcpy(_szModule, szModule, _nModuleLength * sizeof(wchar_t));
	lpOffsets = new UINT_PTR[_nOffsetCount];
	memcpy(lpOffsets, _lpOffsets, _nOffsetCount * sizeof(UINT_PTR));
	nOffsetCount = _nOffsetCount;
	cpVars = _cpVars;
	memcpy(&nVariableCount, &_nVariableCount, sizeof(int));
}

void CPointerInfo::SetPID(DWORD dwPID)
{
	memcpy_s(&_dwPID, sizeof(DWORD), &dwPID, sizeof(DWORD));
}

bool CPointerInfo::GetHandles()
{

	hModule = (HMODULE)NULL;
	HANDLE hSnap;
	hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, _dwPID);
	MODULEENTRY32 me32;
	me32.dwSize = (DWORD)sizeof(MODULEENTRY32);
	Module32First(hSnap, &me32);
	
	do
	{
		if(wcscmp(me32.szModule, _szModule)==0)
		{
			hModule = me32.hModule;
		}
	} while(Module32Next(hSnap, &me32));

	CloseHandle(hSnap);

	if(hModule==0) {_bIsValidHandle = false; return false;}
	if(hProcess!=0) CloseHandle(hProcess);
	
	hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, _dwPID);

	if(hProcess==0) {_bIsValidHandle = false; return false;}

	return true;
}

NOMANGLE CPointerInfo* EXPORTED CreateCPointerInfoClassObject(wchar_t* szModule, UINT_PTR* lpOffsets, int nOffsetCount)
{
	return new CPointerInfo(szModule, lpOffsets, nOffsetCount);
}

NOMANGLE CPointerInfo* EXPORTED CreateCPointerInfoClassObjectExtended(wchar_t* szModule, UINT_PTR* lpOffsets, int nOffsetCount, CPointerVariable** _cpVars, int _nVariableCount)
{
	return new CPointerInfo(szModule, lpOffsets, nOffsetCount, _cpVars, _nVariableCount);
}

NOMANGLE bool EXPORTED FreeCPointerInfoClassObject(CPointerInfo* cpInfo)
{
	if(cpInfo==0) return false;
	delete cpInfo;
	return true;
}