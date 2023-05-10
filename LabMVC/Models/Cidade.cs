using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LabWebForms.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public static List<Cidade> Todos(Estado estado)
        {
            List<Cidade> cidades = new List<Cidade>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, nome, id_estado FROM Cidades where id_estado = " + estado.Id;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cidade cidade = new Cidade();
                            cidade.Id = reader.GetInt32(0);
                            cidade.Nome = reader.GetString(1);

                            Estado estadoDB = new Estado();
                            estadoDB.Id = reader.GetInt32(2);
                            cidade.Estado = estadoDB;

                            cidades.Add(cidade);
                        }
                    }
                }
            }

            return cidades;
        }
    }
}
