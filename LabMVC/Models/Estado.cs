using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace LabWebForms.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public override string ToString()
        {
            return this.Nome;
        }

        public static List<Estado> Todos()
        {
            List<Estado> estados = new List<Estado>();

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, nome, uf FROM Estados";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estado estado = new Estado();
                            estado.Id = reader.GetInt32(0);
                            estado.Nome = reader.GetString(1);
                            estado.UF = reader.GetString(2);
                            estados.Add(estado);
                        }
                    }
                }
            }

            return estados;
        }
    }
}
