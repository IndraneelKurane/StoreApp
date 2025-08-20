using StoreApp.HttpHandler.Base;
using StoreApp.Models;

namespace StoreApp.HttpHandler;

public class LocationHttpService : HttpClientService<Location>
{
    public LocationHttpService(HttpClient httpClient) : base(httpClient)
    {
    }
}
