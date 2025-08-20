using StoreApp.HttpHandler.Base;
using StoreApp.Models;

namespace StoreApp.HttpHandler;

public class DeliveryScheduleHttpService : HttpClientService<DeliverySchedule>
{
    public DeliveryScheduleHttpService(HttpClient httpClient) : base(httpClient)
    {
    }

    // Additional methods specific to BillScheduleHttpService can be added here
}
