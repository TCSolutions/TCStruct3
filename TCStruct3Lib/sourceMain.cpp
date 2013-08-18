#include <Windows.h>
#include <TlHelp32.h>
#include "DebugOutput.h"
#include "StandardOutput.h"
#include "CPointer.h"
#include <stdio.h>

NOMANGLE void EXPORTED CSSTest(CPointerInfo* lolhi)
{;
	DWORD pID;
	GetWindowThreadProcessId(FindWindow(L"Valve001", L"Counter-Strike Source"), &pID);

	lolhi->SetPID(pID);
	lolhi->GetHandles();

	CPointer lol3(lolhi);
	
	if(lol3.Read(sizeof(int)))
	{
	int lol5 = *(int*)lol3.lpValue;
	char* lpBuffer = new char[260];
	sprintf_s(lpBuffer, 260, "%d", lol5);
	
	DebugOutputHandler::PrintDebugString(lpBuffer, NULL, NULL, NULL);

	delete[] lpBuffer;
	}

	int lol = 3;

	lol3.Write(lolhi->cpVars[0]);
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpReserved )
{
	switch( fdwReason )
	{
	case DLL_PROCESS_ATTACH:
		
		break;

	case DLL_PROCESS_DETACH:        

		break;    
	}

	return TRUE;
}