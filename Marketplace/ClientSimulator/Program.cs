using ClientSimulator.Models;
using ClientSimulator.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

string _uriOrder = "/api/Order";

var repositoryInstanceTest = new DapperPostgresRepository();

var cpfs = await repositoryInstanceTest.GetUsersCpfAsync();
var idsProduct = await repositoryInstanceTest.GetProductIds();

HttpClient client = new()
{
    BaseAddress = new Uri("https://localhost:7268/"),
};

foreach (var id in idsProduct)
{
    foreach (var cpf in cpfs)
    {
        var requestContent = new NewOrderRequestModel
        {
            Cpf = cpf,
            ProductIds = new List<long> { id }
        };

        var response = client.PostAsJsonAsync(_uriOrder, requestContent).Result;

        var objResponse = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());

        Console.WriteLine($"Status: {response.StatusCode}");
        Console.WriteLine($"Response: {objResponse["result"]}");
        Console.WriteLine("");

        await Task.Delay(2000);
    };
}
