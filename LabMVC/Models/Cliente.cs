using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LabWebForms.Models
{
    public class Cliente
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Cidade Cidade { get; set; }

        public void Salvar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Nome, Telefone, id_cidade) VALUES (@Nome, @Telefone, @idCidade)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", Nome);
                command.Parameters.AddWithValue("@Telefone", Telefone);
                command.Parameters.AddWithValue("@idCidade", Cidade.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static List<Cliente> Todos()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome, id_cidade, Telefone FROM Clientes";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Telefone = reader["Telefone"].ToString()
                    };

                    if(reader["id_cidade"] != DBNull.Value)
                        cliente.Cidade = new Cidade() { Id = Convert.ToInt32(reader["id_cidade"]) };

                    clientes.Add(cliente);
                }
            }
            return clientes;
        }
    }
}
