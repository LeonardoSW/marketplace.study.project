namespace ClientSimulator.Models
{
    public class NewOrderRequestModel
    {
        public string Cpf { get; set; }
        public List<long> ProductIds { get; set; }
    }
}
