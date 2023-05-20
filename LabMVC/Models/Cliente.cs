using LabMVC.Models;
using LabMVC.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Web.UI.WebControls;

namespace LabWebForms.Models
{
    public class Cliente
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }

        public void Salvar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Nome, Telefone, id_cidade) VALUES (@Nome, @Telefone, @idCidade)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", Nome);
                command.Parameters.AddWithValue("@Telefone", Telefone);
                command.Parameters.AddWithValue("@idCidade", Cidade);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static Cliente Recuperar(int id)
        {
            Cliente cliente = new Cliente();

            string sql = "SELECT * FROM Clientes cli WHERE cli.Id = @Id";

            using (var conexao = ConectaBase.Conexao())
            {
                conexao.Open();

                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.StepCount < 1) return cliente;

                                cliente.Id = (int)reader["Id"];
                                cliente.Nome = reader["Nome"].ToString();
                                cliente.Telefone = reader["Telefone"].ToString();
                                cliente.Cidade = reader["Cidade"].ToString();

                                return cliente;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Houve um problema ao ler da base: {ex}");
                    }
                }
            }


            return cliente;
        }

        public static List<Cliente> Todos()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SQLiteConnection conexao = ConectaBase.Conexao())
            {
                string query = "SELECT Id, Nome, Cidade, Telefone FROM Clientes";

                conexao.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, conexao))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Id = (int)reader["Id"],
                                Nome = reader["Nome"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                Cidade = reader["cidade"].ToString()
                            };

                            clientes.Add(cliente);
                        }
                    }
                }
            }
            return clientes;
        }

        public static void Excluir(int id)
        {
            string sql = "DELETE FROM Clientes WHERE Id = @Id";

            using (var conexao = ConectaBase.Conexao())
            {
                conexao.Open();

                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
