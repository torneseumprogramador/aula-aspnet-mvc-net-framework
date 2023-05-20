using System;
using System.IO;
using System.Data.SQLite;

namespace LabMVC.Utils
{
    public class ConectaBase
    {
        public static SQLiteConnection Conexao()
        {
            //var src = $"{AppDomain.CurrentDomain.GetData("DataDirectory").ToString()}/Utils/database.sqlite";
            var src = $"C:/Users/covid/Documents/Docs/c#/UpskillCurso/aula-aspnet-mvc-net-framework/LabMVC/Utils/database.sqlite";
            try
            {
                //Valida se a base existe;
                if (!File.Exists(src))
                {
                    SQLiteConnection.CreateFile(src);
                }

                return new SQLiteConnection($"data source={src}; version=3;");
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível iniciar a base, {ex}");
            }
        }

    }
}