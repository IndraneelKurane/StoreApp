using StoreApp.HttpHandler.Base;
using StoreApp.Models;

namespace StoreApp.HttpHandler;

public class PartyHttpService : HttpClientService<Party>
{
    public PartyHttpService(HttpClient httpClient) : base(httpClient)
    {
    }
    // Additional methods specific to PartyHttpService can be added here
}
