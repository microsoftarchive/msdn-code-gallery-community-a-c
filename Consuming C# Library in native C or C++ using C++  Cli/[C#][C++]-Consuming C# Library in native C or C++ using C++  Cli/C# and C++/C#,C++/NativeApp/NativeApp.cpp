// NativeApp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "NativeInterface.h"
void ReceivedText(char* text);
void ReceivedFloatArray(float values[], int length);
int _tmain(int argc, _TCHAR* argv[])
{
	int SumValue = 0;
	char retValue = ' ';
	SumValue = SumFromCSharp(4,5);
	printf("Sum calculated in C#: %d \n",SumValue);

	UnManagedStudent student = GetStudent();
   printf("Name of the student received from C# %s \n",student.name);

   GetFloatArrayFromCSharp(&ReceivedFloatArray);

   printf("Enter any key to Terminate");
	scanf("%c",&retValue);
	return 0;

}

void ReceivedFloatArray(float values[], int length)
{
   for(int i = 0; i < length; i++)
   {
      printf("Received float value %f \n",values[i]);
   }
}

