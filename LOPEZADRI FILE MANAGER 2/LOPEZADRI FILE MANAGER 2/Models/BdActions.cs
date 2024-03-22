using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LOPEZADRI_FILE_MANAGER_2.Models
{
    internal class BdActions

    {
        private string connectionString;

        public BdActions(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void pruebaConexion()
        {
            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open(); // Intentar abrir la conexión

                    // Si llegamos aquí sin lanzar una excepción, la conexión es exitosa
                    Debug.WriteLine("La conexión es exitosa.");

                    // Puedes realizar otras operaciones con la base de datos aquí
                    connection.Close();
                } // La conexión se cerrará automáticamente al salir del bloque using
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public List<string> pedimentoBusqueda(string patente, string aduana, string pedimento)
        {
            List<string> nombreArchivo = new List<string>();
            string sql = "SELECT " +
                                 "PAT_AGEN AS PATENTE, " +
                                 "ADU_DESP AS ADUANA, " +
                                 "NUM_PEDI AS NUM_PEDI " +
                         "FROM SAAIO_PEDIME " +
                         "WHERE " +
                                "PAT_AGEN = @Patente AND ADU_DESP = @Aduana AND NUM_PEDI = @Pedimento";

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                using (FbCommand command = new FbCommand(sql, connection))
                {
                    // Parámetros para evitar SQL injection
                    command.Parameters.Add("@Patente", FbDbType.VarChar).Value = patente;
                    command.Parameters.Add("@Aduana", FbDbType.VarChar).Value = aduana;
                    command.Parameters.Add("@Pedimento", FbDbType.VarChar).Value = pedimento;

                    using (FbDataAdapter adapter = new FbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Verificar si se encontraron resultados
                        if (dataTable.Rows.Count > 0)
                        {
                            // Obtener valores de la fila
                            string patenteResultado = dataTable.Rows[0]["PATENTE"].ToString();
                            string aduanaResultado = dataTable.Rows[0]["ADUANA"].ToString();
                            string pedimentoCompleto = dataTable.Rows[0]["NUM_PEDI"].ToString();

                            // Concatenar los valores y agregar la extensión .zip
                            string nombreArchivos = $"{patenteResultado} {aduanaResultado} {pedimentoCompleto}.zip";
                            nombreArchivo.Add(nombreArchivos);

                        }
                        else
                        {
                            throw new Exception("No se encontraron resultados para los parámetros proporcionados.");
                        }
                    }
                }
            }

            return nombreArchivo;

        }

        public List<string> pedimentoFechasBusqueda(DateTime fechaDe, DateTime fechaHasta)
        {
            List<string> nombresArchivos = new List<string>();

            string sql = "SELECT " +
                             "PAT_AGEN AS PATENTE, " +
                             "ADU_DESP AS ADUANA, " +
                             "NUM_PEDI AS NUM_PEDI " +
                         "FROM SAAIO_PEDIME " +
                         "WHERE FEC_PAGO BETWEEN @fechaDe AND @fechaHasta";

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                using (FbCommand command = new FbCommand(sql, connection))
                {
                    // Parámetros para evitar SQL injection
                    command.Parameters.Add("@fechaDe", FbDbType.Date).Value = fechaDe.Date;
                    command.Parameters.Add("@fechaHasta", FbDbType.Date).Value = fechaHasta.Date;

                    using (FbDataAdapter adapter = new FbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Verificar si se encontraron resultados
                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                // Obtener valores de la fila
                                string patenteResultado = row["PATENTE"].ToString();
                                string aduanaResultado = row["ADUANA"].ToString();
                                string pedimentoCompleto = row["NUM_PEDI"].ToString();

                                // Concatenar los valores y agregar la extensión .zip
                                string nombreArchivo = $"{patenteResultado} {aduanaResultado} {pedimentoCompleto}.zip";
                                nombresArchivos.Add(nombreArchivo);
                            }
                        }
                    }
                }
            }
            nombresArchivos.Sort();

            return nombresArchivos;
        }






        public void AddRegistry(string patente, string aduana, string pedimento, string tipoModificacion, List<string> nombresArchivos, string usuario, string zipV)
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

                        if (zipV == null)
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
                catch (Exception ex)
                {
                    MessageBox.Show("Posible error en BD ", ex.Message);
                }

            }
        }

        public void DeleteRegistry(string patente, string aduana, string pedimento, string tipoModificacion, string nombreArchivo, string usuario, string zipV)
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

                        if (zipV == null)
                        {
                            command.Parameters.Add(new SqlParameter("@Valor5", nombreArchivo));
                        }
                        else
                        {
                            command.Parameters.Add(new SqlParameter("@Valor5", zipV + " --> " + nombreArchivo));
                        }

                        command.Parameters.Add(new SqlParameter("@Valor6", usuario));

                        command.CommandTimeout = 10;

                        connection.Open();
                        int filasAfectadas = command.ExecuteNonQuery();
                        connection.Close();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Posible error en BD ", ex.Message);
                }

            }
        }


    }
}
