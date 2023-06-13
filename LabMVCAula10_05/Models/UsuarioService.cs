using Npgsql;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LabMVCAula10_05.Models
{
    public partial class Usuario
    {


        private readonly string connectionString = ConfigurationManager.ConnectionStrings["PostgresConexao"].ConnectionString;

        public bool VerificarUsuario()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE login = @login AND senha = @senha";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", Login);
                command.Parameters.AddWithValue("@senha", Senha); 

                connection.Open();
                object result = command.ExecuteScalar();
                int count = Convert.ToInt32(result);

                return count > 0;
            }
        }


        public void CadastrarUsuario()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO usuarios (login, senha, nome, email) VALUES (@Login, @Senha, @Nome, @Email)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", Nome);
                command.Parameters.AddWithValue("@Login", Login);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Senha", Senha);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}