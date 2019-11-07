namespace BTL.Infrastructure.Encryptions
{
    public interface IEncryptor
    {
        string Encode(string source);
    }
}