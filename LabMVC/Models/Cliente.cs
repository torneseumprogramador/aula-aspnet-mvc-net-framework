using Npgsql;
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
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Nome, Telefone, id_cidade) VALUES (@Nome, @Telefone, @idCidade)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
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
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome, id_cidade, Telefone FROM Clientes";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
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
