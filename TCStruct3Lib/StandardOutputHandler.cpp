#include "StandardOutput.h"

namespace StandardOutputHandler
{
	namespace detail
	{
		StandardOutputCallback* psoCallback = nullptr;
	}

	NOMANGLE bool EXPORTED SetStandardOutputCallback(StandardOutputCallback* doCallback)
	{
		if(detail::psoCallback!=nullptr) return false;
		detail::psoCallback = doCallback;
		PrintString("Output Initialized!");
		return true;
	}

	NOMANGLE bool EXPORTED FreeStandardOutputCallback(void)
	{
		if(detail::psoCallback==nullptr) return false;
		detail::psoCallback = nullptr;
		return true;
	}

	bool PrintString(char* szOutput)
	{
		if(detail::psoCallback==nullptr) return false;
		return StandardOutputHandler::detail::psoCallback(szOutput);
	}
}