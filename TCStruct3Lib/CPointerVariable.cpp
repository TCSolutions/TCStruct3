#include "CPointerVariable.h"

CPointerVariable::CPointerVariable(void* _lpVariable, size_t _tSize)
{
	lpVariable = operator new(_tSize);
	memcpy_s(&tSize, sizeof(size_t), &_tSize, sizeof(size_t));
	memcpy_s(lpVariable, tSize, _lpVariable, tSize);
}

NOMANGLE CPointerVariable* EXPORTED CreateCPointerVariableClassObject(void* _lpVariable, size_t _tSize)
{
	return new CPointerVariable(_lpVariable, _tSize);
}

NOMANGLE bool EXPORTED FreeCPointerVariableClassObject(CPointerVariable* cpVar)
{
	if(cpVar==0) return false;
	delete cpVar;
	return true;
}