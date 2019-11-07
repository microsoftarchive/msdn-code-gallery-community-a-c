#ifdef __cplusplus
extern "C"
{
#endif
   /* Un managed type definition of student equalent to the Managed*/
   typedef struct
   {
      char* name;
   }UnManagedStudent;

   /* A simple interface using the premitive types. Accepts 2 paramters and retun*/
   __declspec(dllexport) int SumFromCSharp(int i, int j);

   /* An interface to get the Student Information in a Structure.
      This function calls the C# class method and gets the managed Student Object
      and converts to unmanged student*/
	__declspec(dllexport) UnManagedStudent GetStudent();

   /* Function pointer to a native function to achieve call back*/
   typedef void (*GetFloatArrayCallback) (float values[], int length);
   
   /* An interface that makes call to C# to read some float values.
      The C# worker respond back in event call back.
      In order to pass the information back to the native app 
      it should give the callback pointer*/
   __declspec(dllexport) void GetFloatArrayFromCSharp(GetFloatArrayCallback cb);
   
#ifdef __cplusplus
}
#endif