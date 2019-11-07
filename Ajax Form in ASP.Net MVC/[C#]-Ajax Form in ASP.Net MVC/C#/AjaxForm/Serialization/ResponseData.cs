
namespace AjaxForm.Serialization
{
    public class ResponseData<T>
    {
        public T Data { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsSuccess { get { return this.Data == null; } }
    }   
}