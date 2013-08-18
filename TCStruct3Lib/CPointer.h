#ifndef CPOINTER_H
#define CPOINTER_H

#include "CPointerInfo.h"

class CPointer
{
private:
	bool _bIsAllocated;
	UINT_PTR _lpAddress;
	bool UpdateAddress();
public:
	CPointerInfo* cpInfo;
	void* lpValue;
	SIZE_T _tBytesRead;
	SIZE_T _tBytesWritten;
	bool Read(size_t tSize);
	bool Write(void* lpValue, size_t tSize);
	bool Write(CPointerVariable* cpVar);
	CPointer(CPointerInfo* cpInfo);
	~CPointer() {if(_bIsAllocated) free(lpValue);}
};

#endif