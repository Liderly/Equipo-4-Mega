using System;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class storedProcedure
{
    private readonly string _Connection;

    public storedProcedure(string _StringConnection) => _Connection = _StringConnection;
    public int executeStoredProcedurePuntosxTenico(int param)
    {
        int TotalPuntos = 0;
        using (SqlConnection connection = new SqlConnection(_Connection))
        {
            using (SqlCommand command = new SqlCommand("ObtenerPuntosTecnico", connection)) // llamar el SP
            {
                param = 1;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TecnicoId", param));
                SqlParameter outputParam = new SqlParameter("@TotalPuntos", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                connection.Open();
                command.ExecuteNonQuery();
                TotalPuntos = (int)command.Parameters["@TotalPuntos"].Value;
            }
        }
        return TotalPuntos;
    }

    public List<string> executeStoredProcedureMontoxPuntos()
    {
        List<string> results = new List<string>();
        using (SqlConnection connection = new SqlConnection(_Connection))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("ObtenerMontoPorPuntos", connection)) // llamar el SP
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(reader.GetString(0));
                    }
                }
            }
        }
        return results;
    }
}