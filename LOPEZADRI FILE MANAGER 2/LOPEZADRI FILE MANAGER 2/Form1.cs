using LOPEZADRI_FILE_MANAGER_2.Models;
using System.Data;
using System.Diagnostics;
using System.IO.Compression;


namespace LOPEZADRI_FILE_MANAGER_2
{
    public partial class Form1 : Form
    {

        /* Lista que se usa para almacenar los resultados que contenga del metodo de la clase 
        FileHelper */
        private List<FileHelper> fileHelp;

        private List<FileHelper>? fileHelp2;

        private ZipHelper zipHelper;

        /*Ruta de donde provienen los archivos*/
        string folderpath = @"c:\users\lopezadri\desktop\expedientes\";

        private string zipsDirectoryPath = Path.Combine(Environment.CurrentDirectory, "ZIPS");
        int bandera;

        public Form1()
        {
            /* Crea una lista cada que se inicia el programa */
            InitializeComponent();

            dgvContenido.CellClick += dgvContenido_CellClick;

            fileHelp = new List<FileHelper>();

            zipHelper = new ZipHelper(zipsDirectoryPath);

            zipHelper.CreateZipsDirectory();



        }
        private void Form1_Load(object sender, EventArgs e)
        {

            /* La lista le asignas el resultado del metodo de la clase */
            fileHelp = FileHelper.LoadPath(folderpath);
            //fileHelp = FileHelper.LoadPath(folderPath2);
            bandera = 1;

            loadExtractedList();
            txtFiltro.Focus();

            txtFiltro.TextChanged += txtFiltro_TextChanged;

        }
        public void loadExtractedList()
        {

            if (bandera == 1)
            {
                // Convierte la lista de objetos FileHelper a un DataTable
                DataTable dataTable = FileHelper.ConvertListToDataTable(fileHelp);

                // Establece el DataTable como fuente de datos para el DataGridView
                dgvExpedientes.DataSource = dataTable;

                if (dgvExpedientes.RowCount > 0 && dgvExpedientes.ColumnCount > 0)
                {
                    dgvExpedientes.CurrentCell = this.dgvExpedientes[0, 0];
                    this.dgvExpedientes.CurrentCell.Selected = false;
                }

                // Oculta y configura las columnas específicas del DataGridView
                dgvExpedientes.Columns[1].Visible = false;
                dgvExpedientes.Columns[1].HeaderText = string.Empty;
                dgvExpedientes.Columns[2].Visible = false;
                dgvExpedientes.Columns[2].HeaderText = string.Empty;
                dgvExpedientes.Columns[3].Visible = false;
                dgvExpedientes.Columns[3].HeaderText = string.Empty;

                foreach (DataGridViewColumn column in dgvExpedientes.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
            else
            {
                // Convierte la lista de objetos FileHelper a un DataTable
                DataTable dataTable = FileHelper.ConvertListToDataTable(fileHelp);

                // Establece el DataTable como fuente de datos para el DataGridView
                dgvContenido.DataSource = dataTable;

                if (dgvContenido.RowCount > 0 && dgvContenido.ColumnCount > 0)
                {
                    dgvContenido.CurrentCell = this.dgvExpedientes[0, 0];
                    this.dgvContenido.CurrentCell.Selected = false;
                }

                // Oculta y configura las columnas específicas del DataGridView
                dgvContenido.Columns[1].Visible = false;
                dgvContenido.Columns[1].HeaderText = string.Empty;
                dgvContenido.Columns[2].Visible = false;
                dgvContenido.Columns[2].HeaderText = string.Empty;
                dgvContenido.Columns[3].Visible = false;
                dgvContenido.Columns[3].HeaderText = string.Empty;


                foreach (DataGridViewColumn column in dgvContenido.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
        }


        private string? lastClickedCellValue = null;
        string? nestedZipPath;
        string? folderName, cellValue;
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
                cellValue = (string)dgvExpedientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                label2.Text = cellValue;


                // Realizar la acción deseada solo si el contenido de la celda no es nulo
                if (cellValue != null)
                {
                    try
                    {
                        // Crear la carpeta "ZIPS" en el directorio de trabajo actual si no existe
                        //CreateZipsDirectory();
                        zipHelper.CreateZipsDirectory();

                        // Crear una carpeta con el nombre del archivo (sin la extensión .zip) dentro de "ZIPS"
                        folderName = Path.GetFileNameWithoutExtension(cellValue);
                        string zipsFolder = Path.Combine(zipsDirectoryPath, folderName);

                        // Verificar si es la misma celda que la última clicada
                        if (lastClickedCellValue != cellValue)
                        {
                            // Eliminar carpetas en "ZIPS" correspondientes a elementos anteriores
                            zipHelper.CleanupZipsDirectory();
                            //CleanupZipsDirectory();

                            Directory.CreateDirectory(zipsFolder);

                            // Extraer solo el primer archivo con extensión ".zip"
                            using (ZipArchive archive = ZipFile.OpenRead(Path.Combine(folderpath, cellValue)))
                            {
                                ZipArchiveEntry? firstZipEntry = archive.Entries.FirstOrDefault(entry => entry.FullName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase));

                                if (firstZipEntry != null)
                                {
                                    // Extraer solo el primer archivo ZIP
                                    zipHelper.ExtractZipEntry(firstZipEntry, zipsFolder);
                                    //ExtractZipEntry(firstZipEntry, zipsFolder);

                                    // Ruta del zip que está en el programa
                                    nestedZipPath = Path.Combine(zipsFolder, firstZipEntry.FullName);
                                    // Ruta del zip principal
                                    string path = folderpath + cellValue;

                                    fileHelp = FileHelper.LoadPath(path);

                                    loadExtractedList();

                                    zipHelper.SearchAndHighlightZipFiles(dgvContenido);


                                    //SearchAndHighlightZipFiles();

                                    fileHelp2 = FileHelper.LoadPath(nestedZipPath);

                                    zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);


                                    //loadExtractedListZip();
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró ningún archivo ZIP dentro del archivo seleccionado.", "N O T I F I C A C I O N", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            // La carpeta ya existe, mostrar los archivos nuevamente
                            fileHelp = FileHelper.LoadPath(folderpath + cellValue);
                            loadExtractedList();
                            zipHelper.SearchAndHighlightZipFiles(dgvContenido);

                            //SearchAndHighlightZipFiles();

                            // Obtener la lista de archivos ZIP en la carpeta
                            string[] zipFiles = Directory.GetFiles(zipsFolder, "*.zip");

                            if (zipFiles.Length == 1)
                            {
                                // Obtener el contenido del único archivo ZIP en la carpeta
                                using (ZipArchive archive = ZipFile.OpenRead(zipFiles[0]))
                                {
                                    // Obtener la lista de archivos del ZIP
                                    fileHelp2 = new List<FileHelper>();

                                    // Obtener la lista de archivos del ZIP
                                    fileHelp2 = FileHelper.LoadPath(zipFiles[0]);

                                    // Mostrar la lista de archivos del ZIP
                                    zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);

                                    //loadExtractedListZip();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún archivo ZIP", "N O T I F I C A C I O N", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        lastClickedCellValue = cellValue;
                    }
                    catch (Exception ex)
                    {
                        // Manejar posibles excepciones al trabajar con el archivo ZIP
                        MessageBox.Show($"Error al leer o extraer el archivo ZIP: {ex.Message}", "N O T I F I C A C I O N", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
        }

        private void txtFiltro_TextChanged(object? sender, EventArgs e)
        {
            fileHelp = FileHelper.LoadPath(folderpath);

            // Eliminar espacios en blanco alrededor del texto del filtro
            string filtroSinEspacios = txtFiltro.Text.Trim();

            // Filtrar la lista utilizando LINQ
            List<FileHelper> filteredList = fileHelp
                .Where(fh => fh.nameFile.Replace(" ", "").Contains(filtroSinEspacios.Replace(" ", "")))
                .ToList();

            DataTable dataTable = FileHelper.ConvertListToDataTable(filteredList);

            // Asignar el DataTable al DataGridView
            dgvExpedientes.DataSource = dataTable;

            dgvContenido.DataSource = null;
            dgvContenidoZip.DataSource = null;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            

            if (rbtzipPrincipal.Checked)
            {
                MessageBox.Show("Recuerda a cual zip quieres agregar.", "A D V E R T E N C I A", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (lastClickedCellValue != null)
                {
                    // Abrir cuadro de diálogo en la carpeta de documentos
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = true;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Obtener la lista de archivos seleccionados
                        string[] selectedFiles = openFileDialog.FileNames;

                        // Agregar archivos al ZIP principal
                        AddFilesToMainZip(selectedFiles);
                        ResaltarUltimaCeldaAgregada(dgvContenido);

                    }
                }
                else
                {
                    // Mostrar MessageBox de advertencia
                    MessageBox.Show("Haga doble clic en un ZIP principal antes de agregar archivos.", "A D V E R T E N C I A", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if (rbtzipContenido.Checked)
            {
                MessageBox.Show("Recuerda a cual zip quieres agregar.", "A D V E R T E N C I A", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (lastClickedCellValue != null)
                {

                    // Abrir cuadro de diálogo en la carpeta de documentos
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = true;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Obtener la lista de archivos seleccionados
                        string[] selectedFiles = openFileDialog.FileNames;
                        //ReplaceInnerZipInOuterZip();
                        // Agregar archivos al ZIP principal
                        AddFilesToExtractedZip(selectedFiles);
                        ResaltarUltimaCeldaAgregada(dgvContenidoZip);
                    }
                }
                else
                {
                    // Mostrar MessageBox de advertencia
                    MessageBox.Show("Haga doble clic en un ZIP principal antes de agregar archivos.", "A D V E R T E N C I A", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                // Ningún radio button seleccionado, mostrar MessageBox de advertencia
                MessageBox.Show("Seleccione una opción antes de agregar archivos.", "A D V E R T E N C I A", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddFilesToMainZip(string[] files)
        {
            // Validar si hay un ZIP principal seleccionado
            if (lastClickedCellValue != null)
            {
                // Ruta del ZIP principal en la carpeta principal
                string mainZipPath = Path.Combine(folderpath, lastClickedCellValue);
              
                // Ruta del ZIP temporal
                string tempZipPath = Path.Combine(Path.GetTempPath(), "temp_zip_" + Guid.NewGuid().ToString() + ".zip");

                try
                {
                    // Copiar el ZIP principal al temporal
                    File.Copy(mainZipPath, tempZipPath, true);

                    // Extraer archivos actuales del ZIP principal
                    List<FileHelper> currentFiles = FileHelper.LoadPath(tempZipPath);

                    // Abrir el archivo ZIP temporal
                    using (ZipArchive archive = ZipFile.Open(tempZipPath, ZipArchiveMode.Update))
                    {
                        // Agregar archivos seleccionados al ZIP temporal
                        foreach (string filePath in files)
                        {
                            string fileName = Path.GetFileName(filePath);

                            // Verificar si el archivo ya existe en el ZIP
                            if (!currentFiles.Any(file => file.nameFile.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                            {
                                // Crear una nueva entrada en el ZIP y extraer el archivo
                                ZipArchiveEntry entry = archive.CreateEntry(fileName);
                                using (Stream entryStream = entry.Open())
                                using (FileStream fileStream = File.OpenRead(filePath))
                                {
                                    fileStream.CopyTo(entryStream);
                                }
                            }
                        }

                    }

                    // Sustituir el ZIP principal con el ZIP temporal
                    File.Copy(tempZipPath, mainZipPath, true);

                    MessageBox.Show("Archivo agregado correctamente.", "C O R R E C T O", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    fileHelp = FileHelper.LoadPath(mainZipPath);

                    loadExtractedList();

                    zipHelper.SearchAndHighlightZipFiles(dgvContenido);

                    fileHelp2 = FileHelper.LoadPath(nestedZipPath);

                    zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);

                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }
                finally
                {
                    // Eliminar el archivo ZIP temporal
                    File.Delete(tempZipPath);
                }

            }
        }

        private void AddFilesToExtractedZip(string[] files)
        {
            // Validar si hay un ZIP principal seleccionado dentro de la ruta del programa
            if (lastClickedCellValue != null)
            {
                // Ruta del ZIP interno en la carpeta principal
                string nestedZipPath = Path.Combine(zipsDirectoryPath, folderName, lastClickedCellValue);
                Debug.WriteLine(nestedZipPath);

                // Ruta del ZIP temporal
                string tempZipPath = Path.Combine(Path.GetTempPath(), "temp_nested_zip_" + Guid.NewGuid().ToString() + ".zip");

                try
                {
                    // Copiar el ZIP interno al temporal
                    File.Copy(nestedZipPath, tempZipPath, true);

                    // Extraer archivos actuales del ZIP interno
                    List<FileHelper> currentNestedFiles = FileHelper.LoadPath(tempZipPath);

                    // Abrir el archivo ZIP temporal interno
                    using (ZipArchive nestedArchive = ZipFile.Open(tempZipPath, ZipArchiveMode.Update))
                    {
                        // Agregar archivos seleccionados al ZIP temporal interno
                        foreach (string filePath in files)
                        {
                            string fileName = Path.GetFileName(filePath);

                            // Verificar si el archivo ya existe en el ZIP interno
                            if (!currentNestedFiles.Any(file => file.nameFile.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                            {
                                // Crear una nueva entrada en el ZIP interno y extraer el archivo
                                ZipArchiveEntry nestedEntry = nestedArchive.CreateEntry(fileName);
                                using (Stream entryStream = nestedEntry.Open())
                                using (FileStream fileStream = File.OpenRead(filePath))
                                {
                                    fileStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }

                    // Sustituir el ZIP interno con el ZIP temporal
                    File.Copy(tempZipPath, nestedZipPath, true);
                    ReplaceInnerZipInOuterZip();

                    MessageBox.Show("Archivo agregado correctamente al ZIP interno.", "C O R R E C T O", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Vuelve a cargar la lista de archivos extraídos
                    fileHelp2 = FileHelper.LoadPath(nestedZipPath);
                    zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);


                }
                catch(Exception)
                {
                    MessageBox.Show("Selecciona el segundo archivo ZIP.", "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Eliminar el archivo ZIP temporal interno
                    File.Delete(tempZipPath);
                   
                }

            }
        }

        private void ReplaceInnerZipInOuterZip()
        {
            // Ruta del ZIP externo
            string outerZipPath = Path.Combine(folderpath, cellValue);
            Debug.WriteLine(outerZipPath);
            // Ruta temporal para la carpeta del ZIP externo
            string outerFolderTempPath = Path.Combine(Path.GetTempPath(), "temp_outer_folder_" + Guid.NewGuid().ToString());

            try
            {
                // Extraer el archivo ZIP externo a la carpeta temporal
                ZipFile.ExtractToDirectory(outerZipPath, outerFolderTempPath);

                // Ruta del ZIP interno en la carpeta temporal
                string innerZipTempPath = Path.Combine(outerFolderTempPath, lastClickedCellValue);

                // Ruta del nuevo ZIP que quieres agregar al ZIP interno
                string newInnerZipPath = zipsDirectoryPath + @"\" + folderName + @"\" + lastClickedCellValue;
                
                // Eliminar el archivo ZIP original
                File.Delete(outerZipPath);

                // Sustituir el ZIP interno con el nuevo ZIP
                File.Copy(newInnerZipPath, innerZipTempPath, true);

                // Sobrescribir el archivo ZIP original con la carpeta temporal actualizada
                ZipFile.CreateFromDirectory(outerFolderTempPath, outerZipPath, CompressionLevel.Optimal, false);
            }
            finally
            {
                // Eliminar la carpeta temporal externa
                Directory.Delete(outerFolderTempPath, true);
            }
        }

        private void dgvContenido_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda clicada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el valor de la celda clicada
                lastClickedCellValue = dgvContenido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Deseleccionar la celda actual en otras filas
                foreach (DataGridViewRow row in dgvExpedientes.Rows)
                {
                    if (row.Index != e.RowIndex) // Evitar deseleccionar la celda clicada
                    {
                        row.Selected = false;
                    }
                }

            }
        }

        private void dgvContenido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda seleccionada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el contenido de la celda seleccionada
                string? cellValue = dgvContenido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Validar si el contenido de la celda es un archivo ZIP
                if (!string.IsNullOrEmpty(cellValue) && cellValue.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    label2.Text = cellValue;
                }
                else
                {
                    MessageBox.Show("Selecciona el archivo ZIP.", "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResaltarUltimaCeldaAgregada(DataGridView dataGridView)
        {
            // Obtener el índice de la última fila en el DataGridView
            int ultimaFilaIndex = dataGridView.Rows.Count - 1;

            // Obtener la última celda en la última fila
            DataGridViewCell ultimaCelda = dataGridView.Rows[ultimaFilaIndex].Cells[0];

            // Establecer la celda actual para resaltarla
            dataGridView.CurrentCell = ultimaCelda;

            // Hacer que la celda sea visible en el área visible del DataGridView
            dataGridView.FirstDisplayedScrollingRowIndex = ultimaFilaIndex;
        }



    }

}



