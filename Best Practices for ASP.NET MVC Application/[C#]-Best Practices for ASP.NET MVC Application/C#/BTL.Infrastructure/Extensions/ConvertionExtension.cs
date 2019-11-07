namespace BTL.Infrastructure.Extensions
{
    public static class ConvertionExtension
    {
        public static int ConvertToInteger(this string source)
        {
            int result;

            int.TryParse(source, out result);

            return result;
        }
        public static bool ConvertToBool(this string source)
        {
            bool result;

            bool.TryParse(source, out result);

            return result;
        }
    }
}