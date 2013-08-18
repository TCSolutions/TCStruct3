#ifndef DEBUGOUTPUT_H
#define DEBUGOUTPUT_H

#include "Global.h"

namespace DebugOutputHandler
{
	typedef bool _stdcall DebugOutputCallback(char* szOutput, char* szFunction, char* szDetails, char* szExtraInfo);

	NOMANGLE bool EXPORTED SetDebugOutputCallback(DebugOutputCallback* doCallback);
	NOMANGLE bool EXPORTED FreeDebugOutputCallback(void);

	bool PrintDebugString(char* szOutput, char* szFunction, char* szDetails, char* szExtraInfo);

	namespace detail
	{
		extern DebugOutputCallback* pdoCallback;
	}
}
#endif
