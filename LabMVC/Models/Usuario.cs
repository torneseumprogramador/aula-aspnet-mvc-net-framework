using LabWebForms.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LabMVC.Models
{
    public class Usuario
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public void Salvar()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuarios (Nome, Email, Login, Senha) VALUES (@Nome, @Email, @Login, @Senha)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", Nome);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Login", Login);
                command.Parameters.AddWithValue("@Senha", Senha);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static List<Usuario> Todos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome, Email, Login, Senha FROM Usuarios";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Login = reader["Login"].ToString(),
                        Senha = reader["Senha"].ToString()
                    };

                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }
    }
}