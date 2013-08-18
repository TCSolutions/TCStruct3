#include "CPointer.h"
#include "DebugOutput.h"
#include <stdio.h>

CPointer::CPointer(CPointerInfo* _cpInfo)
{
	lpValue = nullptr;
	_bIsAllocated = false;
	cpInfo = _cpInfo;
}

bool CPointer::Read(size_t tSize)
{
	if(_bIsAllocated) free(lpValue);
	
	lpValue = malloc(tSize);

	if(lpValue==0) return false;
	_bIsAllocated = true;

	if(!UpdateAddress())
	{
		char* lpBuffer = new char[260];
		sprintf_s(lpBuffer, 260, "Process Handle: %d\r\nMemory Address: %d\r\nOffset Pointer: %d", (int)cpInfo->hProcess, (int)_lpAddress, (int)cpInfo->lpOffsets);
		DebugOutputHandler::PrintDebugString("Error obtaining memory address", "CPointer::Read", "Update address call failure", lpBuffer);
		delete[] lpBuffer;
		return false;
	}

	return ReadProcessMemory(cpInfo->hProcess, (LPCVOID)_lpAddress, (LPVOID)lpValue, tSize, &_tBytesRead) != 0;
}

bool CPointer::Write(void* _lpValue, size_t tSize)
{
	if(_lpValue==0) return false;

	if(!UpdateAddress())
	{
		char* lpBuffer = new char[260];
		sprintf_s(lpBuffer, 260, "Process Handle: %d\r\nMemory Address: %d\r\nOffset Pointer: %d", (int)cpInfo->hProcess, (int)_lpAddress, (int)cpInfo->lpOffsets);
		DebugOutputHandler::PrintDebugString("Error obtaining memory address", "CPointer::Read", "Update address call failure", lpBuffer);
		delete[] lpBuffer;
		return false;
	}

	return WriteProcessMemory(cpInfo->hProcess, (LPVOID)_lpAddress, (LPCVOID)_lpValue, tSize, &_tBytesWritten) != 0;
}

bool CPointer::Write(CPointerVariable* cpVar)
{
	return Write(cpVar->lpVariable, cpVar->tSize);
}
bool CPointer::UpdateAddress()
{
	_lpAddress = (UINT_PTR)cpInfo->hModule;
	
	for(long i=0;i < cpInfo->nOffsetCount;i++)
	{
		if(i!=0)
		{
			if(!ReadProcessMemory(cpInfo->hProcess, (LPCVOID)_lpAddress, (LPVOID)&_lpAddress, sizeof(_lpAddress), &_tBytesRead)) return false;
		}

		_lpAddress += cpInfo->lpOffsets[i];
	}

	return true;
}