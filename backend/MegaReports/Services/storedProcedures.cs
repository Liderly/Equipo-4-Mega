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
        public decimal ExecuteStoredProcedureMontoxTecnico(int TecnicoId)
    {
        decimal montoTotal = 0;
        using (SqlConnection connection = new SqlConnection(_Connection))
        {
            Console.WriteLine("ID del técnico: " + TecnicoId);
            using (SqlCommand command = new SqlCommand("ObtenerMontoTotalTecnico", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TecnicoId", TecnicoId)); 

                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    montoTotal = Convert.ToDecimal(result); 
                }
            }
        }
        return montoTotal; 
    }
}