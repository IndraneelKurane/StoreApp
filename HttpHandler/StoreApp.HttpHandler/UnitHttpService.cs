using StoreApp.HttpHandler.Base;
using StoreApp.Models;

namespace StoreApp.HttpHandler;

public class UnitHttpService : HttpClientService<Unit>
{
    public UnitHttpService(HttpClient httpClient) : base(httpClient)
    {
    }
}
