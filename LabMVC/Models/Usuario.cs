using LabMVC.Cripto;
using LabMVC.DTO;
using LabMVC.Utils;
using LabWebForms.Models;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.EnterpriseServices.Internal;
using System.Web.UI.WebControls;

namespace LabMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public void Salvar()
        {
            Id = 1; // [!]
            using (SQLiteConnection conexao = ConectaBase.Conexao())
            {
                string sql = "INSERT INTO usuarios (Id, Nome, Login, Email, Senha) VALUES (@Id, @Nome, @Login, @Email, @Senha)";

                conexao.Open();
                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Nome", Nome);
                    command.Parameters.AddWithValue("@Login", Login);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Senha", Senha);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool DefineSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha) && senha.Length >= 6)
            {
                Senha = HashGen.hashficaSenha(senha);
                return true;
            }
            return false;
        }

        public static Usuario BuscarPorLogin(string login)
        {
            Usuario usuario = new Usuario();

            if (!string.IsNullOrEmpty(login))
            {
                var sql = $"SELECT * FROM usuarios usu WHERE usu.login = @login;";

                using (var conexao = ConectaBase.Conexao())
                {
                    conexao.Open();

                    using (var command = new SQLiteCommand(sql, conexao))
                    {
                        command.Parameters.AddWithValue("@login", login);

                        try
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if(reader.Read())
                                {
                                    if (reader.StepCount != 1) return usuario;

                                    usuario.Id = (int)reader["Id"];
                                    usuario.Nome = reader["Nome"].ToString();
                                    usuario.Login = reader["Login"].ToString();
                                    usuario.Email = reader["Email"].ToString();
                                    usuario.Senha = reader["Senha"].ToString();

                                    return usuario;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Houve um problema ao ler da base: {ex}");
                        }
                    }
                }
            }
            return usuario;
        }

        public static bool AutenticaUsuario(LoginDTO usuario)
        {
            if(!string.IsNullOrEmpty(usuario.Login) || !(string.IsNullOrEmpty(usuario.Senha)) && usuario.Senha.Length >= 6)
            {
                var usuarioBase = BuscarPorLogin(usuario.Login);

                if (usuarioBase.Id.Equals(0)) return false;
                
                if (HashGen.hashficaSenha(usuario.Senha).Equals(usuarioBase.Senha)) return true;
            }
            return false;
        }
    }
}