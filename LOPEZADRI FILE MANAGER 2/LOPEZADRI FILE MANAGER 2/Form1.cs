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
        string folderPath = @"C:\Users\Lopezadri\Desktop\Expedientes\";
        private string zipsDirectoryPath = Path.Combine(Environment.CurrentDirectory, "ZIPS");
        int bandera;

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
            fileHelp = FileHelper.LoadPath(folderPath);
            bandera = 1;
            loadExtractedList();
           
           
        }
        public void loadExtractedList()
        {
            if(bandera == 1) 
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
            //Lista nueva para almacenar lo qeu esta dentro del zip
            fileHelp = new List<FileHelper>();
            //bandera para decision en extraer el contenido a un data table
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
                        Directory.CreateDirectory(zipsFolder);

                        // Extraer el contenido del archivo ZIP en la carpeta creada dentro de "ZIPS"
                        ZipFile.ExtractToDirectory((folderPath + @"\" + cellValue), zipsFolder);

                        // Mostrar un mensaje informativo
                        MessageBox.Show($"Contenido del archivo {cellValue} extraído en la carpeta 'ZIPS/{folderName}' en el directorio actual.");

                        // Cargar la lista de archivos en la carpeta extraída
                        fileHelp = FileHelper.LoadPath(zipsFolder);

                        // Cargar la lista extraída en el DataGridView
                        loadExtractedList();

                        // Buscar y resaltar los archivos ZIP en la lista
                        SearchAndHighlightZipFiles();
                    }
                    catch (Exception ex)
                    {
                        // Manejar posibles excepciones al extraer el archivo ZIP
                        MessageBox.Show($"Error al extraer el archivo ZIP: {ex.Message}");
                    }
                }
            }

        }




    }
}
