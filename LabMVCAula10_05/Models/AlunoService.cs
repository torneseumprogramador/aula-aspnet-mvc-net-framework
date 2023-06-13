using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows;
using System.Windows.Forms;

namespace LabMVCAula10_05.Models
{
    public partial class Aluno
    {

            private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["PostgresConexao"].ConnectionString;


            public static void Salvar(Aluno aluno)
            {
                var media = ObterMediaNotas(aluno.Notas);

                aluno.Media = media;
                aluno.Situacao = media < 5 ? Situacao.Reprovado : media >= 5 && media < 7 ? Situacao.Recuperacao : Situacao.Aprovado;
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                        connection.Open();
                        using (var command = new NpgsqlCommand())
                        {
                            try
                            {
                                command.Connection = connection;
                                command.CommandType = CommandType.Text;

                                command.CommandText = $"INSERT INTO Aluno (nome, matricula, notas, media, situacao) VALUES ('{aluno.Nome}', '{aluno.Matricula}', '{aluno.Notas}', '{aluno.Media}', '{aluno.Situacao}')";
                                command.ExecuteNonQuery(); 
                                ExibirMensagemErro("Nota Cadastrada com sucesso!");
                        }
                            catch (Npgsql.PostgresException e)
                            {
                                // Trate a exceção de violação de campo único aqui
                                // Por exemplo, você pode exibir uma mensagem de erro para o usuário informando que o campo já existe
                               ExibirMensagemErro("Erro ao cadastrar aluno: " + e.Message);
                            }
                        }
                }
            }

        public static void Excluir(int matricula)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;

                        command.CommandText = $"DELETE FROM Aluno WHERE matricula = '{matricula}'";
                        command.ExecuteNonQuery();
                    }
                    catch (Npgsql.PostgresException e)
                    {
                        // Trate a exceção aqui
                        Console.WriteLine("Erro ao excluir aluno: " + e.Message);
                    }
                }
            }
        }



        public static List<Aluno> GetListaNotasAlunos()
            {
                var alunos = new List<Aluno>();

                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT nome, matricula, notas, media, situacao FROM Aluno", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var aluno = new Aluno
                                {
                                    Nome = reader.GetString(0),
                                    Matricula = reader.GetInt32(1),
                                    Notas = reader.GetString(2),
                                    Media = reader.GetInt32(3),
                                    Situacao = (Situacao)Enum.Parse(typeof(Situacao), reader.GetString(4))

                                };
                                alunos.Add(aluno);
                            }
                        }
                    }
                }

                return alunos;
            }

        protected static int ObterMediaNotas(string notasString)
        {
            string[] notasArray = notasString.Split(',');

            int[] notas = new int[notasArray.Length];
            var soma = 0;
            for (int i = 0; i < notasArray.Length; i++)
            {
                if (int.TryParse(notasArray[i], out int nota))
                {
                    notas[i] = nota;
                    soma += nota;
                }
                else
                {
                    // Lógica para tratar o caso em que uma nota não é um número inteiro válido
                    // Você pode optar por atribuir um valor padrão, lançar uma exceção, etc.
                }
            }

            return soma / notas.Length;
        }
        public static void ExibirMensagemErro(string mensagem)
        {
            // Aqui você pode exibir a mensagem de erro para o usuário
            // Por exemplo, usando um MessageBox ou outra forma de exibição adequada
            System.Windows.Forms.MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    }
