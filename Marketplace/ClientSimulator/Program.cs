using ClientSimulator.Models;
using ClientSimulator.Repository;
using System.Net.Http.Json;

string _uriOrder = "/api/Order";

var repositoryInstanceTest = new DapperPostgresRepository();

var cpfs = await repositoryInstanceTest.GetUsersCpfAsync();
var idsProduct = await repositoryInstanceTest.GetProductIds();

HttpClient client = new()
{
    BaseAddress = new Uri("https://localhost:7268/"),
};

foreach (var cpf in cpfs)
{
    foreach (var id in idsProduct)
    {
        var requestContent = new NewOrderRequestModel
        {
            Cpf = cpf,
            ProductIds = new List<long> { id }
        };

        var response = client.PostAsJsonAsync(_uriOrder, requestContent).Result;

        Task.Delay(1000).Wait();
    };
}