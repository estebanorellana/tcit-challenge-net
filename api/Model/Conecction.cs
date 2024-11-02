using Npgsql;

namespace api.Model
{
    public class Conecction
    {
        public dynamic Connect()
        {
            string connectionString = "Host=localhost;Username=usr_challenge;Password=deveor.cl;Database=challenge";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString); 
            connection.Open();
            return connection;
        }
    }
}