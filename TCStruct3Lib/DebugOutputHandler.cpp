#include "DebugOutput.h"

namespace DebugOutputHandler
{
	namespace detail
	{
		DebugOutputCallback* pdoCallback = nullptr;
	}

	NOMANGLE bool EXPORTED SetDebugOutputCallback(DebugOutputCallback* doCallback)
	{
		if(detail::pdoCallback!=nullptr) return false;
		detail::pdoCallback = doCallback;
		PrintDebugString("Output Initialized!", "SetDebugOutputCallback", "Post callback initialization.", "This message is printed when a callback is successfully set.");
		return true;
	}

	NOMANGLE bool EXPORTED FreeDebugOutputCallback(void)
	{
		if(detail::pdoCallback==nullptr) return false;
		detail::pdoCallback = nullptr;
		return true;
	}

	bool PrintDebugString(char* szOutput, char* szFunction, char* szDetails, char* szExtraInfo)
	{
		if(detail::pdoCallback==nullptr) return false;
		return detail::pdoCallback(szOutput, szFunction, szDetails, szExtraInfo);
	}
}