using StoreApp.HttpHandler.Base;
using StoreApp.Models;

namespace StoreApp.HttpHandler;

public class ItemHttpService : HttpClientService<Item>
{
    public ItemHttpService(HttpClient httpClient) : base(httpClient)
    {
    }
}
