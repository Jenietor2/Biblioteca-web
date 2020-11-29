using Biblioteca_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Biblioteca_web.Data
{
    public class LibroDAL
    {
        private readonly IConfiguration _configuration;

        public LibroDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool InsertBook(LibroModel libroModel)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-5PLC5LP";
                builder.InitialCatalog = "BibliotecaApi2";
                builder.IntegratedSecurity = true;

                //var connectionString = _configuration["Connection"];
                using (SqlConnection cnn = new SqlConnection(builder.ConnectionString))
                {
                    cnn.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[spInsertBook]", cnn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmTitulo", SqlDbType = SqlDbType.NVarChar, Value = libroModel.Titulo });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmActivo", SqlDbType = SqlDbType.Bit, Value = libroModel.Activo });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmGeneroId", SqlDbType = SqlDbType.Int, Value = libroModel.GeneroId });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmRuta", SqlDbType = SqlDbType.NVarChar, Value = libroModel.Ruta });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmAutor", SqlDbType = SqlDbType.NVarChar, Value = libroModel.Autor });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmUsuarioId", SqlDbType = SqlDbType.NVarChar, Value = libroModel.UsuarioID });
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
