using LOPEZADRI_FILE_MANAGER_2.Models;
using System.Data;
using System.IO.Compression;

namespace LOPEZADRI_FILE_MANAGER_2
{
    public partial class Form1 : Form
    {

        /* Lista que se usa para almacenar los resultados que contenga del metodo de la clase 
        FileHelper */
        private List<FileHelper> fileHelp;
        /*Ruta de donde provienen los archivos*/
        string folderpath = @"c:\users\lopezadri\desktop\expedientes\";
        //string folderPath2 = @"C:\Users\Usuario\Desktop\Expedientes\ ";
        private string zipsDirectoryPath = Path.Combine(Environment.CurrentDirectory, "ZIPS");
        int bandera, bandera2;

        public Form1()
        {
            /* Crea una lista cada que se inicia el programa */
            InitializeComponent();
            fileHelp = new List<FileHelper>();
            CreateZipsDirectory();
        }
        // Método para crear el directorio "ZIPS" si no existe
        private void CreateZipsDirectory()
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
        // Método para buscar y resaltar archivos ZIP en el DataGridView
        private void SearchAndHighlightZipFiles()
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
        private void Form1_Load(object sender, EventArgs e)
        {
            /* La lista le asignas el resultado del metodo de la clase */
            fileHelp = FileHelper.LoadPath(folderpath);
            //fileHelp = FileHelper.LoadPath(folderPath2);
            bandera = 1;

            loadExtractedList();



        }
        public void loadExtractedList()
        {
            if (bandera == 1)
            {
                // Convierte la lista de objetos FileHelper a un DataTable
                DataTable dataTable = FileHelper.ConvertListToDataTable(fileHelp);

                // Establece el DataTable como fuente de datos para el DataGridView
                dgvExpedientes.DataSource = dataTable;

                // Oculta y configura las columnas específicas del DataGridView
                dgvExpedientes.Columns[1].Visible = false;
                dgvExpedientes.Columns[1].HeaderText = string.Empty;
                dgvExpedientes.Columns[2].Visible = false;
                dgvExpedientes.Columns[2].HeaderText = string.Empty;
                dgvExpedientes.Columns[3].Visible = false;
                dgvExpedientes.Columns[3].HeaderText = string.Empty;

            }
            else
            {
                // Convierte la lista de objetos FileHelper a un DataTable
                DataTable dataTable = FileHelper.ConvertListToDataTable(fileHelp);

                // Establece el DataTable como fuente de datos para el DataGridView
                dgvContenido.DataSource = dataTable;

                // Oculta y configura las columnas específicas del DataGridView
                dgvContenido.Columns[1].Visible = false;
                dgvContenido.Columns[1].HeaderText = string.Empty;
                dgvContenido.Columns[2].Visible = false;
                dgvContenido.Columns[2].HeaderText = string.Empty;
                dgvContenido.Columns[3].Visible = false;
                dgvContenido.Columns[3].HeaderText = string.Empty;


            }

        }

        private void dgvExpedientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lista nueva para almacenar lo que está dentro del ZIP
            fileHelp = new List<FileHelper>();
            // Bandera para decisión en extraer el contenido a un DataTable
            bandera = 2;

            // Verificar si la celda seleccionada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el contenido de la celda seleccionada
                string cellValue = (string)dgvExpedientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Realizar la acción deseada solo si el contenido de la celda no es nulo
                if (cellValue != null)
                {
                    try
                    {
                        // Crear la carpeta "ZIPS" en el directorio de trabajo actual si no existe
                        CreateZipsDirectory();

                        // Crear una carpeta con el nombre del archivo (sin la extensión .zip) dentro de "ZIPS"
                        string folderName = Path.GetFileNameWithoutExtension(cellValue);

                        string zipsFolder = Path.Combine(zipsDirectoryPath, folderName);

                        // Verificar si la carpeta ya existe antes de intentar extraer los archivos nuevamente
                        if (!Directory.Exists(zipsFolder))
                        {
                            Directory.CreateDirectory(zipsFolder);

                            // Extraer solo archivos con extensión ".zip"
                            using (ZipArchive archive = ZipFile.OpenRead(Path.Combine(folderpath, cellValue)))
                            {
                                foreach (ZipArchiveEntry entry in archive.Entries)
                                {
                                    if (entry.FullName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                                    {
                                        entry.ExtractToFile(Path.Combine(zipsFolder, entry.FullName), true);

                                        string nestedZipPath = Path.Combine(zipsFolder, entry.FullName);

                                        // Actualizar el segundo DataGridView con el nombre del ZIP anidado
                                        dgvContenido.DataSource = GetNestedZipNameTable(entry.FullName);

                                        // Actualizar el tercer DataGridView con el contenido del ZIP anidado
                                        dgvContenidoZip.DataSource = GetNestedZipContentTable(nestedZipPath, zipsFolder);

                                        // Refrescar las vistas de los DataGridViews
                                        dgvContenido.Refresh();
                                        dgvContenidoZip.Refresh();
                                    }
                                }
                            }
                        }
                        else
                        {
                            // La carpeta ya existe, cargar los archivos en el DataGridView nuevamente
                            fileHelp = FileHelper.LoadPath(zipsFolder)
                                .Where(file => Path.GetExtension(file.nameFile) == ".zip")
                                .ToList();

                            // Actualizar el segundo DataGridView con el nombre del ZIP anidado
                            dgvContenido.DataSource = GetNestedZipNameTable(fileHelp.FirstOrDefault()?.nameFile);

                            // Actualizar el tercer DataGridView con el contenido del ZIP anidado
                            dgvContenidoZip.DataSource = GetNestedZipContentTable(Path.Combine(zipsFolder, fileHelp.FirstOrDefault()?.nameFile), zipsFolder);

                            // Refrescar las vistas de los DataGridViews
                            dgvContenido.Refresh();
                            dgvContenidoZip.Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar posibles excepciones al extraer el archivo ZIP
                        MessageBox.Show($"Error al extraer el archivo ZIP: {ex.Message}");
                    }
                }
            }
        }

        private DataTable GetNestedZipNameTable(string nestedZipName)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NombreZIPAnidado", typeof(string));
            dataTable.Rows.Add(nestedZipName);
            return dataTable;
        }

        private DataTable GetNestedZipContentTable(string nestedZipPath, string extractionPath)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NombreArchivo", typeof(string));

            using (ZipArchive nestedArchive = ZipFile.OpenRead(nestedZipPath))
            {
                foreach (ZipArchiveEntry nestedEntry in nestedArchive.Entries)
                {
                    nestedEntry.ExtractToFile(Path.Combine(extractionPath, nestedEntry.FullName), true);
                    dataTable.Rows.Add(nestedEntry.FullName);
                }
            }

            return dataTable;
        }


    }

}

