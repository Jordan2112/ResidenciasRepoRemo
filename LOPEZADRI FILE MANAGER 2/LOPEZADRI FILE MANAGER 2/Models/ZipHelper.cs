using System.Data;
using System.IO.Compression;

namespace LOPEZADRI_FILE_MANAGER_2.Models
{
    internal class ZipHelper
    {
        private string zipsDirectoryPath;

        public ZipHelper(string zipsDirectoryPath)
        {
            this.zipsDirectoryPath = zipsDirectoryPath;
        }

        public void CreateZipsDirectory()
        {
            try
            {
                // Verificar si el directorio "ZIPS" no existe y crearlo si es necesario
                if (!Directory.Exists(zipsDirectoryPath))
                {
                    Directory.CreateDirectory(zipsDirectoryPath);
                }
            }
            catch (Exception ex)
            {
                // Manejar posibles excepciones al crear el directorio
                MessageBox.Show($"Error al crear el directorio 'ZIPS': {ex.Message}");
            }
        }

        public void SearchAndHighlightZipFiles(DataGridView dgvContenido)
        {
            foreach (DataGridViewRow row in dgvContenido.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Obtener el valor de la celda
                    object cellValue = cell.Value;

                    // Verificar si el valor de la celda termina con ".zip" (ignorando mayúsculas y minúsculas)
                    if (cellValue?.ToString()?.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        // Resaltar la celda con un color amarillo
                        cell.Style.BackColor = Color.Yellow;
                    }
                }
            }
        }

        public void LoadExtractedListZip(DataGridView dgvContenidoZip, List<FileHelper> fileHelp2)
        {
            // Convierte la lista de objetos FileHelper a un DataTable
            DataTable dataTable = FileHelper.ConvertListToDataTable(fileHelp2);

            // Establece el DataTable como fuente de datos para el DataGridView
            dgvContenidoZip.DataSource = dataTable;

            if (dgvContenidoZip.RowCount > 0 && dgvContenidoZip.ColumnCount > 0)
            {
                dgvContenidoZip.CurrentCell = dgvContenidoZip[0, 0];
                dgvContenidoZip.CurrentCell.Selected = false;
            }

            // Oculta y configura las columnas específicas del DataGridView
            dgvContenidoZip.Columns[1].Visible = false;
            dgvContenidoZip.Columns[1].HeaderText = string.Empty;
            //dgvContenidoZip.Columns[2].Visible = false;
            //dgvContenidoZip.Columns[2].HeaderText = string.Empty;
            //dgvContenidoZip.Columns[3].Visible = false;
            //dgvContenidoZip.Columns[3].HeaderText = string.Empty;

            foreach (DataGridViewColumn column in dgvContenidoZip.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void CleanupZipsDirectory()
        {
            string[] existingZips = Directory.GetDirectories(zipsDirectoryPath);
            foreach (var zipFolder in existingZips)
            {
                try
                {
                    // Eliminar directamente sin enviar a la papelera de reciclaje
                    Directory.Delete(zipFolder, true);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error al eliminar
                    MessageBox.Show($"Error al eliminar la carpeta {zipFolder}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ExtractZipEntry(ZipArchiveEntry entry, string extractPath)
        {
            // Extraer un archivo ZIP
            entry.ExtractToFile(Path.Combine(extractPath, entry.FullName), true);
        }

        public void ExtraerZip(string rutaZip, string directorioDestino)
        {
            
            // Extraer el contenido del archivo ZIP en el directorio de destino
            ZipFile.ExtractToDirectory(rutaZip, directorioDestino);
        }

    }
}
