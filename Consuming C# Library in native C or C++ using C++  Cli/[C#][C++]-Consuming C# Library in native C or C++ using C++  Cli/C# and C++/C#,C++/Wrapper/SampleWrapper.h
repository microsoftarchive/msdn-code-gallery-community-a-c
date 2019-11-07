using namespace System;
using namespace Sample;
namespace Wrapper
{
	public ref class SampleWrapper
	{
      /* Private Constructor to achieve signle ton*/
		SampleWrapper(void)
		{
			workerObj = gcnew Worker();
         workerObj->ReadFloatValues += gcnew Worker::FloatValuesReady(this, &Wrapper::SampleWrapper::FloatArrayReadyMethod);
		}
	public:
		Worker ^ workerObj;
      /* Static reference to single ton instace.
         In order to use applications built in C.*/
		static SampleWrapper ^ Instance = gcnew SampleWrapper();
      void FloatArrayReadyMethod(array<float> ^ values);
	};
}
