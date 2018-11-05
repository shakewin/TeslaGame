using Microsoft.AspNetCore.Http;

namespace TeslaGame.Infrastructure
{
    public class UrlExtensions
    {
		public static string PathAndQuery(this HttpRequest request) =>
			request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
