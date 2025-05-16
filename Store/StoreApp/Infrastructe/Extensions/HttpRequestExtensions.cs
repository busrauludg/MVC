namespace StoreApp.Infrastructe.Extensions
{
    public static class HttpRequestExtensions
    {
        //sepete ekleme yaptığımız ssayfalarda kullanıçaz
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue
                ? $"{request.Path}{request.Query}"
                :request.Path.ToString();
        }
    }
}
