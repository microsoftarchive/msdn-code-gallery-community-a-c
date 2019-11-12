namespace BTL.Infrastructure.Dci
{
    /// <summary>
    /// Using in the case you don't have anything for input parameter
    /// </summary>
    public class NullDciParameter : IDciParameter
    {
        public void EnsureAllParamIsValid()
        {
        }
    }
}