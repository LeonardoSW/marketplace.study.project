namespace ClientSimulator.Repository.DapperQueires
{
    public class Queries
    {
        public static string GetProductIds()
            => "select id from products";

        public static string GetCpfUsers()
            => "select cpf from users";
    }
}
