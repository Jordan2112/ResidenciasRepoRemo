using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LOPEZADRI_FILE_MANAGER_2.Models
{
    internal class BdActions

    {
        private string connectionString;

        public BdActions(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AgregarRegistro(string patente, string aduana, string pedimento, string tipoModificacion, List<string> nombresArchivos, string usuario, string zipV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO RegistroModificaciones (Patente, Aduana, Pedimento, tipo_modificacion, detalle, usuario) VALUES (@Valor1, @Valor2, @Valor3, @Valor4, @Valor5, @Valor6)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        command.Parameters.Add(new SqlParameter("@Valor1", patente));
                        command.Parameters.Add(new SqlParameter("@Valor2", aduana));
                        command.Parameters.Add(new SqlParameter("@Valor3", pedimento));
                        command.Parameters.Add(new SqlParameter("@Valor4", tipoModificacion));

                        // Concatenar los nombres de archivos en una cadena separada por comas
                        string nombresArchivosConcatenados = string.Join(", ", nombresArchivos);

                        if(zipV == null)
                        {
                            command.Parameters.Add(new SqlParameter("@Valor5", nombresArchivosConcatenados));
                        }
                        else
                        {
                            command.Parameters.Add(new SqlParameter("@Valor5", zipV + " --> " + nombresArchivosConcatenados));
                        }

                        command.Parameters.Add(new SqlParameter("@Valor6", usuario));

                        command.CommandTimeout = 10;

                        connection.Open();
                        int filasAfectadas = command.ExecuteNonQuery();
                        connection.Close();


                    }

                }
                catch(Exception)
                {
                    
                }
               
            }
        }
    
    }
}
