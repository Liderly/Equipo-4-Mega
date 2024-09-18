using System.Data.SqlClient;
namespace MegaReports.data
{
    public class SqlServerConnection
    {
        private string _StringConnection = string.Empty;

        public SqlServerConnection(IConfiguration configuration){ //constructor
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _StringConnection = connectionString + ";TrustServerCertificate=True"; // ignorar temas de certificacion ssl
        }

        public string getConnectionString() // Devulevo la cadena de conexion 
        {
            return _StringConnection;
        }
    }
}