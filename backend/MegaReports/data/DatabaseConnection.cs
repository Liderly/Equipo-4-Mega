using System.Data.SqlClient;
namespace MegaReports.data
{
    public class SqlServerConnections
    {
        private string _StringConnection = string.Empty;

        public SqlServerConnections(IConfiguration configuration){ //constructor
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _StringConnection = connectionString + ";TrustServerCertificate=True"; // ignorar temas de certificacion ssl
        }

        public string getConnectionString() // Devulevo la cadena de conexion 
        {
            return _StringConnection;
        }
    }
}