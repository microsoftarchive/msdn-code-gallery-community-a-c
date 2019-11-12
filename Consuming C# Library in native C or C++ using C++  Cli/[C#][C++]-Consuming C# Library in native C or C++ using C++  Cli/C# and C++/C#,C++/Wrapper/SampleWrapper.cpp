#include "SampleWrapper.h"
#include "NativeInterface.h"
using namespace Sample;

namespace Wrapper
{
#ifdef __cplusplus
extern "C"
{
#endif
	void copyManagedStringToCharPointer(char target[], System::String ^ inputString)
   {
      int maxSize = inputString->Length;
      if ( maxSize > 0) 
      {
         for (int index = 0; index < maxSize; ++index ) 
         {
            target[index] = (char)inputString->default[index];
         }
         target[maxSize] = '\0';
      }
   }

   void copyManagedFloatToUnfloatArray(float target[], array<float> ^ values)
   {
      int maxSize = values->Length;
      if ( maxSize > 0) 
      {
         for (int index = 0; index < maxSize; index++ ) 
         {
            target[index] = (float)values[index];
         }
      }
   }

	__declspec(dllexport) int SumFromCSharp(int i, int j)
	{
		Worker ^ worker = SampleWrapper::Instance->workerObj;
		return worker->Sum(i,j);
	}
	
	__declspec(dllexport) UnManagedStudent GetStudent()
	{
		Worker ^ worker = SampleWrapper::Instance->workerObj;
		ManagedStudent ^ studentObj = worker->GetStudent();
      String ^ mName = studentObj->Name;
      UnManagedStudent studentStruct;
      studentStruct.name = new char[mName->Length];
      copyManagedStringToCharPointer(studentStruct.name,mName);
      return studentStruct;
	}

   GetFloatArrayCallback floatArrayCallback;
   __declspec(dllexport) void GetFloatArrayFromCSharp(GetFloatArrayCallback cb)
   {
      floatArrayCallback = cb;
      Worker ^ worker = SampleWrapper::Instance->workerObj;
      worker->GetSomeFloatValues();
   }

   void SampleWrapper::FloatArrayReadyMethod(array<float> ^ values)
   {
      float *nativeValues = new float[values->Length];
      copyManagedFloatToUnfloatArray(nativeValues, values);
      floatArrayCallback(nativeValues, values->Length);
   }
	
#ifdef __cplusplus
}
#endif
}