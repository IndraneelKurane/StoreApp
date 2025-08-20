using StoreApp.HttpHandler.Base;
using StoreApp.Models;

namespace StoreApp.HttpHandler;

public class LocationRowHttpService : HttpClientService<LocationRow>
{
    public LocationRowHttpService(HttpClient httpClient) : base(httpClient)
    {
    }
}
