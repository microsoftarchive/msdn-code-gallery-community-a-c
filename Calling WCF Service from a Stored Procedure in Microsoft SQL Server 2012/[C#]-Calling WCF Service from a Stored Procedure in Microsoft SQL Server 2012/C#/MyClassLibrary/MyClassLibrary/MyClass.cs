using MyClassLibrary.svcService;

namespace MyClassLibrary
{
    public class MyClass
    {
        public static string CallWcfService(string name)
        {
            string result = string.Empty;
            using (Service1 client = new Service1())
            {
                result = client.SayHello(name);
            }
            return result;
        }
    }
}
