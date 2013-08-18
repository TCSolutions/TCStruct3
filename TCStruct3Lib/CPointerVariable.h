#ifndef CPOINTERVARIABLE_H
#define CPOINTERVARIABLE_H

#include "Global.h"
#include <Windows.h>

class CPointerVariable
{
public:
	void* lpVariable;
	size_t tSize;
	CPointerVariable(void* _lpVariable, size_t _tSize);
	~CPointerVariable() {delete lpVariable;}
};

NOMANGLE CPointerVariable* EXPORTED CreateCPointerVariableClassObject(void* _lpVariable, size_t _tSize);
NOMANGLE bool EXPORTED FreeCPointerVariableClassObject(CPointerVariable* cpVar);
#endif