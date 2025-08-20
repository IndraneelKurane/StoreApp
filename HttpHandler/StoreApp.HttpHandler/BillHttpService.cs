using StoreApp.HttpHandler.Base;
using StoreApp.Models;

namespace StoreApp.HttpHandler;

public class BillHttpService : HttpClientService<Bill>
{
    public BillHttpService(HttpClient httpClient) : base(httpClient)
    {
    }
}
