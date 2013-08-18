#ifndef STANDARDOUTPUT_H
#define STANDARDOUTPUT_H

#include "Global.h"

namespace StandardOutputHandler
{
	typedef bool _stdcall StandardOutputCallback(char* szOutput);

	NOMANGLE bool EXPORTED SetSTANDARDOUTPUTCallback(StandardOutputCallback* soCallback);
	NOMANGLE bool EXPORTED FreeSTANDARDOUTPUTCallback(void);

	bool PrintString(char* szOutput);

	namespace detail
	{
		extern StandardOutputCallback* psoCallback;
	}
}
#endif
