using LOPEZADRI_FILE_MANAGER_2.Models;
using System.Data;
using System.IO.Compression;

namespace LOPEZADRI_FILE_MANAGER_2
{
    public partial class Form1 : Form
    {

        /* Lista que se usa para almacenar los resultados que contenga del metodo de la clase 
        FileHelper */
        private List<FileHelper> fileHelp, fileHelp2;
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
        public void loadExtractedListZip()
        {
            // Convierte la lista de objetos FileHelper a un DataTable
            DataTable dataTable = FileHelper.ConvertListToDataTable(fileHelp2);

            // Establece el DataTable como fuente de datos para el DataGridView
            dgvContenidoZip.DataSource = dataTable;

            // Oculta y configura las columnas específicas del DataGridView
            dgvContenidoZip.Columns[1].Visible = false;
            dgvContenidoZip.Columns[1].HeaderText = string.Empty;
            dgvContenidoZip.Columns[2].Visible = false;
            dgvContenidoZip.Columns[2].HeaderText = string.Empty;
            dgvContenidoZip.Columns[3].Visible = false;
            dgvContenidoZip.Columns[3].HeaderText = string.Empty;

        }

        private void dgvExpedientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lista nueva para almacenar lo que está dentro del ZIP
            fileHelp = new List<FileHelper>();
            fileHelp2 = new List<FileHelper>();

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

                            // Extraer solo el primer archivo con extensión ".zip"
                            using (ZipArchive archive = ZipFile.OpenRead(Path.Combine(folderpath, cellValue)))
                            {
                                ZipArchiveEntry firstZipEntry = archive.Entries.FirstOrDefault(entry => entry.FullName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase));

                                if (firstZipEntry != null)
                                {
                                    // Extraer solo el primer archivo ZIP
                                    ExtractZipEntry(firstZipEntry, zipsFolder);

                                    // Ruta del zip que está en el programa
                                    string nestedZipPath = Path.Combine(zipsFolder, firstZipEntry.FullName);
                                    // Ruta del zip principal
                                    string path = folderpath + cellValue;

                                    fileHelp = FileHelper.LoadPath(path);

                                    loadExtractedList();
                                    SearchAndHighlightZipFiles();

                                    fileHelp2 = FileHelper.LoadPath(nestedZipPath);
                                    loadExtractedListZip();

                                }
                                else
                                {
                                    MessageBox.Show("No se encontró ningún archivo ZIP dentro del archivo seleccionado.", "NOTIFICACION",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            // La carpeta ya existe, mostrar los archivos nuevamente
                            fileHelp = FileHelper.LoadPath(folderpath + cellValue);
                            loadExtractedList();
                            SearchAndHighlightZipFiles();

                            // Obtener la lista de archivos ZIP en la carpeta
                            string[] zipFiles = Directory.GetFiles(zipsFolder, "*.zip");

                            if (zipFiles.Length == 1)
                            {
                                // Obtener el contenido del único archivo ZIP en la carpeta
                                using (ZipArchive archive = ZipFile.OpenRead(zipFiles[0]))
                                {
                                    // Obtener la lista de archivos del ZIP
                                    fileHelp2 = new List<FileHelper>();
                                    foreach (ZipArchiveEntry entry in archive.Entries)
                                    {
                                        fileHelp2.Add(new FileHelper
                                        {
                                            nameFile = entry.Name,
                                            lastModification = entry.LastWriteTime.DateTime,
                                            filePath = entry.FullName
                                        });
                                    }

                                    // Mostrar la lista de archivos del ZIP
                                    loadExtractedListZip();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún archivo ZIP", "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar posibles excepciones al trabajar con el archivo ZIP
                        MessageBox.Show($"Error al leer o extraer el archivo ZIP: {ex.Message}","NOTIFICACION",MessageBoxButtons.OK,MessageBoxIcon.Question);
                    }
                }
            }
        }

        private void ExtractZipEntry(ZipArchiveEntry entry, string extractPath)
        {
            // Extraer un archivo ZIP
            entry.ExtractToFile(Path.Combine(extractPath, entry.FullName), true);
        }


    }

}

