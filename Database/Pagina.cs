using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Database
{
    public class Pagina
    {
        private string sqlConn()
        {
            return ConfigurationManager.ConnectionStrings["NomeDaConexao"].ConnectionString;
        }
        public DataTable Lista()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(sqlConn()))
            {
                string queryString = "SELECT * FROM paginas";

                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                return dataTable;
            }
        }

        public void Salvar(int id, string nome, string conteudo, DateTime data)
        {
            using (MySqlConnection connection = new MySqlConnection(sqlConn()))
            {
                string queryString = "";
                MySqlCommand command;
                if (id == 0)
                {
                    queryString = "INSERT INTO paginas (nome, data, conteudo) VALUES (@Nome, @Data, @Conteudo)";
                    command = new MySqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Data", data);
                    command.Parameters.AddWithValue("@Conteudo", conteudo);
                }
                else
                {
                    queryString = "UPDATE paginas SET nome = @Nome, data = @Data, conteudo = @Conteudo WHERE id = @Id";
                    command = new MySqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Data", data);
                    command.Parameters.AddWithValue("@Conteudo", conteudo);
                    command.Parameters.AddWithValue("@Id", id);
                }

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(sqlConn()))
            {
                string queryString = "SELECT * FROM paginas WHERE id = @Id";

                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public void Excluir(int id)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(sqlConn()))
            {
                string queryString = "DELETE FROM paginas WHERE id = @Id";

                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
        }
    }
}
