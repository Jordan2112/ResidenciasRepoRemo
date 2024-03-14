using LOPEZADRI_FILE_MANAGER_2.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO.Compression;
using System.Windows.Forms;



namespace LOPEZADRI_FILE_MANAGER_2
{
    public partial class Form1 : Form
    {

        /* Lista que se usa para almacenar los resultados que contenga del metodo de la clase 
        FileHelper */
        private List<FileHelper>? fileHelp;

        private List<FileHelper>? fileHelp2;

        private ZipHelper zipHelper;

        public string zipsDirectoryPath = Path.Combine(Environment.CurrentDirectory, "ZIPS");

        public static string carpetaConsultas = Path.Combine(Environment.CurrentDirectory, "Consultas");
        /*Ruta de donde provienen los archivos*/
        //string folderpath = @"c:\users\lopezadri\desktop\expedientes\";
        string folderpath = carpetaConsultas;

        List<string> rutas = new List<string>
        {
            //@"F:\ARCHIVO DIGITAL\FACTURADOS\PATENTE 1684 2023",
            //@"F:\ARCHIVO DIGITAL\FACTURADOS\PATENTE 1684 2024",
            @"F:\ARCHIVO DIGITAL\FACTURADOS\PRUEBA 1684 2023",
            @"F:\ARCHIVO DIGITAL\FACTURADOS\PRUEBA 1684 2024"


        };

        int flag;

        private string? lastClickedCellValue = null;

        string? nestedZipPath;

        string? folderName, cellValue;

        string? nameFile;

        string[]? elementos;

        string[] elementos2;

        static string conn = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

        static string conn2 = ConfigurationManager.ConnectionStrings["CSAAIWIN"].ConnectionString;

        List<string> nombresArchivosAgregados = new List<string>();

        string? dleteZip = "";

        string? patente;

        string? aduana;

        string? pedimento;

        string cellvalue2;

        private bool datosCargados = false;

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
            //fileHelp = FileHelper.LoadPath(folderpath);
            ////fileHelp = FileHelper.LoadPath(folderPath2);
            //flag = 1;

            //loadExtractedList();

            MostrarOcultarControles();

            txtFiltro.Focus();

            txtFiltro.TextChanged += txtFiltro_TextChanged;
            timer1.Start();
        }

        public void loadExtractedList()
        {

            if (flag == 1)
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
        string? rutaDirecta;

        string rutaGuadar;

        private void dgvExpedientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvContenido.ColumnHeadersVisible = true;
            dgvContenidoZip.ColumnHeadersVisible = true;

            // Lista nueva para almacenar lo que está dentro del ZIP
            fileHelp = new List<FileHelper>();
            fileHelp2 = new List<FileHelper>();

            // Bandera para decisión en extraer el contenido a un DataTable
            flag = 2;

            // Verificar si la celda seleccionada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el contenido de la celda seleccionada
                cellValue = (string)dgvExpedientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                rutaDirecta = dgvExpedientes.Rows[e.RowIndex].Cells[3].Value.ToString();
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
                        nameFile = folderName;
                        Debug.Write(nameFile);

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
                                    string path = folderpath + @"\" + cellValue;

                                    label2.BackColor = Color.Yellow;
                                    fileHelp = FileHelper.LoadPath(path);

                                    loadExtractedList();

                                    zipHelper.SearchAndHighlightZipFiles(dgvContenido);

                                    fileHelp2 = FileHelper.LoadPath(nestedZipPath);

                                    zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);

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
                            fileHelp = FileHelper.LoadPath(folderpath + @"\" + cellValue);
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

                        try
                        {
                            AddFilesToMainZip(selectedFiles);
                        }
                        catch (Exception)
                        {
                            // Manejar la excepción específica de AddFilesToExtractedZip
                            MessageBox.Show($"Selecciona el primer archivo zip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;  // Puedes decidir si quieres salir del método o realizar alguna otra acción en caso de excepción.
                        }

                        // Agregar archivos al ZIP principal

                        HighlightLastCellAdded(dgvContenido);

                        BdActions gestorBD = new BdActions(conn);

                        gestorBD.AddRegistry(patente, aduana, pedimento, "Agrego", nombresArchivosAgregados, lblUsuario.Text, null);

                        MessageBox.Show("Archivo agregado correctamente al ZIP.", "C O R R E C T O", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        nombresArchivosAgregados.Clear();

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

                        try
                        {
                            AddFilesToExtractedZip(selectedFiles);
                        }
                        catch (Exception)
                        {
                            // Manejar la excepción específica de AddFilesToExtractedZip
                            MessageBox.Show($"Selecciona el segundo archivo zip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;  // Puedes decidir si quieres salir del método o realizar alguna otra acción en caso de excepción.
                        }

                        HighlightLastCellAdded(dgvContenidoZip);

                        BdActions gestorBD = new BdActions(conn);
                        string zipV = patente + @" " + aduana + @" " + pedimento + @" " + @"-V";
                        gestorBD.AddRegistry(patente, aduana, pedimento, "Agrego", nombresArchivosAgregados, lblUsuario.Text, zipV);

                        MessageBox.Show("Archivo agregado correctamente al ZIP.", "C O R R E C T O", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        nombresArchivosAgregados.Clear();
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
                string mainZipPath = Path.Combine(folderpath, label2.Text);
                // Ruta del ZIP temporal
                string tempZipPath = Path.Combine(Path.GetTempPath(), "temp_zip_" + Guid.NewGuid().ToString() + ".zip");

                // Copiar el ZIP principal al temporal
                File.Copy(mainZipPath, tempZipPath, true);

                // Extraer archivos actuales del ZIP principal
                List<FileHelper>? currentFiles = FileHelper.LoadPath(tempZipPath);

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
                            nombresArchivosAgregados.Add(fileName);

                            using (Stream entryStream = entry.Open())
                            using (FileStream fileStream = File.OpenRead(filePath))
                            {
                                fileStream.CopyTo(entryStream);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Archivo(s) ya existente(s).", "A D V E R T E N C I A", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }

                }

                // Sustituir el ZIP principal con el ZIP temporal
                File.Copy(tempZipPath, mainZipPath, true);

                fileHelp = FileHelper.LoadPath(mainZipPath);

                loadExtractedList();

                zipHelper.SearchAndHighlightZipFiles(dgvContenido);

                fileHelp2 = FileHelper.LoadPath(nestedZipPath);

                zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);
                elementos = nameFile.Split(' ');
                patente = elementos.Length > 0 ? elementos[0] : "No hay elemento";
                aduana = elementos.Length > 1 ? elementos[1] : "No hay elemento";
                pedimento = elementos.Length > 2 ? elementos[2] : "No hay elemento";

                if (File.Exists(tempZipPath))
                {
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

                // Copiar el ZIP interno al temporal
                File.Copy(nestedZipPath, tempZipPath, true);

                // Extraer archivos actuales del ZIP interno
                List<FileHelper>? currentNestedFiles = FileHelper.LoadPath(tempZipPath);

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
                            nombresArchivosAgregados.Add(fileName);
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

                // Vuelve a cargar la lista de archivos extraídos
                fileHelp2 = FileHelper.LoadPath(nestedZipPath);
                zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);

                elementos = nameFile.Split(' ');
                patente = elementos.Length > 0 ? elementos[0] : "No hay elemento";
                aduana = elementos.Length > 1 ? elementos[1] : "No hay elemento";
                pedimento = elementos.Length > 2 ? elementos[2] : "No hay elemento";

                if (File.Exists(tempZipPath))
                {
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
        string cellValueD;
        private void dgvContenido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda seleccionada es válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el contenido de la celda seleccionada
                cellValueD = dgvContenido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Validar si el contenido de la celda es un archivo ZIP
                if (!string.IsNullOrEmpty(cellValueD) && cellValueD.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    label2.Text = cellValueD;
                    label2.BackColor = Color.GreenYellow;

                }

            }
        }

        private void HighlightLastCellAdded(DataGridView dataGridView)
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

        private void dgvExpedientes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = dgvExpedientes.HitTest(e.X, e.Y).RowIndex;
                int columnIndex = dgvExpedientes.HitTest(e.X, e.Y).ColumnIndex;

                Debug.Write(rowIndex + "\n" + columnIndex);

                if (rowIndex >= 0 && columnIndex >= 0)
                {
                    dgvExpedientes.CurrentCell = dgvExpedientes.Rows[rowIndex].Cells[columnIndex];


                    // Asigna tu icono a la propiedad Image

                    ContextMenuStrip menu = new ContextMenuStrip();

                    ToolStripItem descargarFile = menu.Items.Add("Descargar");
                    descargarFile.Image = Properties.Resources.descargar; // Puedes asignar una imagen apropiada
                    descargarFile.Name = "Descargar";
                    descargarFile.Click += DescargarFile_Click;

                    ToolStripItem eliminarFile = menu.Items.Add("Eliminar");
                    eliminarFile.Image = Properties.Resources.eliminar;
                    eliminarFile.Name = "Eliminar";
                    eliminarFile.Click += EliminarFileZip_Click;

                    // Obtienes las coordenadas de la celda seleccionada.
                    Rectangle coordenada = dgvExpedientes.GetCellDisplayRectangle(columnIndex, rowIndex, false);

                    int anchoCelda = coordenada.Location.X; // Ancho de la localización de la celda
                    int altoCelda = coordenada.Location.Y;  // Alto de la localización de la celda

                    // Y para mostrar el menú lo haces de esta forma:
                    int X = anchoCelda + dgvExpedientes.Location.X + 150;
                    int Y = altoCelda;

                    menu.Show(dgvExpedientes, new Point(X, Y));
                }
            }
        }

        private void dgvContenido_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = dgvContenido.HitTest(e.X, e.Y).RowIndex;
                int columnIndex = dgvContenido.HitTest(e.X, e.Y).ColumnIndex;

                Debug.Write(rowIndex + "\n" + columnIndex);

                if (rowIndex >= 0 && columnIndex >= 0)
                {
                    dgvContenido.CurrentCell = dgvContenido.Rows[rowIndex].Cells[columnIndex];

                    ContextMenuStrip menu = new ContextMenuStrip();
                    ToolStripItem descargarFile = menu.Items.Add("Descargar");
                    descargarFile.Image = Properties.Resources.descargar; // Puedes asignar una imagen apropiada
                    descargarFile.Name = "Descargar";
                    descargarFile.Click += DescargarFile2_Click;


                    ToolStripItem eliminarFile = menu.Items.Add("Eliminar");
                    eliminarFile.Image = Properties.Resources.eliminar;
                    eliminarFile.Name = "Eliminar";
                    eliminarFile.Click += EliminarFileZip1_Click;

                    // Obtienes las coordenadas de la celda seleccionada.
                    Rectangle coordenada = dgvContenido.GetCellDisplayRectangle(columnIndex, rowIndex, false);

                    int anchoCelda = coordenada.Location.X; // Ancho de la localización de la celda
                    int altoCelda = coordenada.Location.Y;  // Alto de la localización de la celda

                    // Y para mostrar el menú lo haces de esta forma:
                    int X = anchoCelda + dgvContenido.Location.X + 180;
                    int Y = altoCelda;

                    menu.Show(dgvContenido, new Point(X, Y));
                }
            }
        }

        private void dgvContenidoZip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = dgvContenidoZip.HitTest(e.X, e.Y).RowIndex;
                int columnIndex = dgvContenidoZip.HitTest(e.X, e.Y).ColumnIndex;

                Debug.Write(rowIndex + "\n" + columnIndex);

                if (rowIndex >= 0 && columnIndex >= 0)
                {
                    dgvContenidoZip.CurrentCell = dgvContenidoZip.Rows[rowIndex].Cells[columnIndex];

                    ContextMenuStrip menu = new ContextMenuStrip();
                    ToolStripItem descargarFile = menu.Items.Add("Descargar");
                    descargarFile.Image = Properties.Resources.descargar; // Puedes asignar una imagen apropiada
                    descargarFile.Name = "Descargar";
                    descargarFile.Click += DescargarFile3_Click;

                    ToolStripItem eliminarFile = menu.Items.Add("Eliminar");
                    eliminarFile.Image = Properties.Resources.eliminar;
                    eliminarFile.Name = "Eliminar";
                    eliminarFile.Click += EliminarFileZip2_Click;

                    // Obtienes las coordenadas de la celda seleccionada.
                    Rectangle coordenada = dgvContenidoZip.GetCellDisplayRectangle(columnIndex, rowIndex, false);

                    int anchoCelda = coordenada.Location.X; // Ancho de la localización de la celda
                    int altoCelda = coordenada.Location.Y;  // Alto de la localización de la celda

                    // Y para mostrar el menú lo haces de esta forma:
                    int X = anchoCelda + dgvContenidoZip.Location.X + 280;
                    int Y = altoCelda;

                    menu.Show(dgvContenidoZip, new Point(X, Y));
                }
            }
        }

        private void DescargarFile_Click(object sender, EventArgs e)
        {

            DownloadZip();
        }

        private void DescargarFile2_Click(object sender, EventArgs e)
        {
            DownloadZip2(rutaDirecta, dleteZip);
        }
        private void DescargarFile3_Click(object sender, EventArgs e)
        {
            DownloadZip3(rutaDirecta, cellValueD, dleteZip);
        }

        private void EliminarFileZip_Click(object sender, EventArgs e)
        {
            DeleteSelectedFile(dgvExpedientes);
        }

        private void EliminarFileZip1_Click(object sender, EventArgs e)
        {
            // Agrega un cuadro de diálogo para ingresar la contraseña

            DeleteSelectedFile(dgvContenido);

        }

        private void EliminarFileZip2_Click(object sender, EventArgs e)
        {
            // Agrega un cuadro de diálogo para ingresar la contraseña

            DeleteSelectedFile(dgvContenidoZip);

        }

        private void DownloadZip()
        {
            DataGridViewCell selectedCell = dgvExpedientes.CurrentCell;

            // Asegúrate de que hay una celda seleccionada
            if (selectedCell != null)
            {
                // Obtiene la ruta del archivo ZIP desde la columna 3 de la fila seleccionada
                string? archivoZIP = dgvExpedientes.Rows[selectedCell.RowIndex].Cells[3].Value.ToString(); // Suponiendo que la columna 3 tiene el índice 2

                // Verifica si el archivo existe
                if (File.Exists(archivoZIP))
                {
                    // Puedes realizar otras validaciones del archivo según tus necesidades antes de descargarlo

                    // Pide al usuario la ubicación para guardar el archivo descargado
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivos ZIP (*.zip)|*.zip";
                    saveFileDialog.FileName = Path.GetFileName(archivoZIP);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Copia el archivo ZIP a la ubicación seleccionada por el usuario
                            File.Copy(archivoZIP, saveFileDialog.FileName, true);
                            MessageBox.Show("Descarga completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al descargar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El archivo seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DownloadZip2(string rutaArchivoZip, string nombreArchivoDeseado)
        {
            string directorioTemporal = Path.Combine(Path.GetTempPath(), "ArchivosTemporales");

            try
            {
                // Crea el directorio temporal si no existe
                Directory.CreateDirectory(directorioTemporal);

                // Descomprime el archivo .zip en el directorio temporal
                ZipFile.ExtractToDirectory(rutaArchivoZip, directorioTemporal);

                // Ruta completa al archivo deseado dentro del directorio temporal
                string rutaArchivoDeseado = Path.Combine(directorioTemporal, nombreArchivoDeseado);

                // Verifica si el archivo deseado existe
                if (File.Exists(rutaArchivoDeseado))
                {
                    // Pide al usuario la ubicación para guardar el archivo descargado
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Todos los archivos (*.*)|*.*";
                    saveFileDialog.FileName = nombreArchivoDeseado;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Copia el archivo deseado a la ubicación seleccionada por el usuario
                        File.Copy(rutaArchivoDeseado, saveFileDialog.FileName, true);
                        MessageBox.Show("Descarga completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo deseado no se encontró dentro del archivo .zip.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al descargar el archivo desde el archivo .zip: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Elimina el directorio temporal y su contenido
                Directory.Delete(directorioTemporal, true);
            }

        }
        private void DownloadZip3(string rutaArchivoZipExterno, string? nombreArchivoZipInterno, string nombreArchivoDeseado)
        {
            if (nombreArchivoZipInterno != null && nombreArchivoZipInterno.EndsWith("-V.zip"))
            {
                string directorioTemporalExterno = Path.Combine(Path.GetTempPath(), "ArchivosTemporalesExterno");

                string directorioTemporalInterno = Path.Combine(Path.GetTempPath(), "ArchivosTemporalesInterno");

                try
                {

                    // Crea el directorio temporal si no existe
                    Directory.CreateDirectory(directorioTemporalExterno);

                    // Descomprime el archivo .zip externo en el directorio temporal externo
                    ZipFile.ExtractToDirectory(rutaArchivoZipExterno, directorioTemporalExterno);

                    // Ruta completa al archivo .zip interno dentro del directorio temporal externo
                    string rutaArchivoZipInterno = Path.Combine(directorioTemporalExterno, nombreArchivoZipInterno);

                    // Crea el directorio temporal interno si no existe
                    Directory.CreateDirectory(directorioTemporalInterno);

                    // Descomprime el archivo .zip interno en el directorio temporal interno
                    ZipFile.ExtractToDirectory(rutaArchivoZipInterno, directorioTemporalInterno);

                    // Ruta completa al archivo deseado dentro del directorio temporal interno
                    string rutaArchivoDeseado = Path.Combine(directorioTemporalInterno, nombreArchivoDeseado);

                    // Verifica si el archivo deseado existe
                    if (File.Exists(rutaArchivoDeseado))
                    {
                        // Pide al usuario la ubicación para guardar el archivo descargado
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Todos los archivos (*.*)|*.*";
                        saveFileDialog.FileName = nombreArchivoDeseado;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Copia el archivo deseado a la ubicación seleccionada por el usuario
                            File.Copy(rutaArchivoDeseado, saveFileDialog.FileName, true);
                            MessageBox.Show("Descarga completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El archivo deseado no se encontró dentro del archivo .zip interno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al descargar el archivo desde el archivo .zip externo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Elimina los directorios temporales y su contenido
                    Directory.Delete(directorioTemporalExterno, true);
                    Directory.Delete(directorioTemporalInterno, true);
                }

            }
            else
            {
                MessageBox.Show($"Selecciona el segundo archivo zip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void DeleteSelectedFile(DataGridView dataGridView)
        {
            if (dataGridView.CurrentCell != null)
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    if (dataGridView == dgvExpedientes)
                    {
                        // Obtener la ruta del archivo desde la celda del DataGridView
                        string? rutaArchivo = dataGridView.Rows[rowIndex].Cells["Ruta"].Value.ToString();

                        // Eliminar el archivo físico si la ruta existe
                        if (File.Exists(rutaArchivo))
                        {
                            try
                            {
                                File.Delete(rutaArchivo);

                                dataGridView.Rows.RemoveAt(rowIndex);

                                MessageBox.Show("Archivo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                fileHelp.Clear(); // Limpia la lista
                                fileHelp2.Clear(); // Limpia la segunda lista

                                // Desvincula y limpia las columnas del primer DataGridView
                                dgvContenido.DataSource = null;
                                dgvContenido.Columns.Clear();

                                // Desvincula y limpia las columnas del segundo DataGridView
                                dgvContenidoZip.DataSource = null;
                                dgvContenidoZip.Columns.Clear();

                                // Vuelve a vincular los DataGridView a las listas limpias
                                dgvContenido.DataSource = fileHelp;
                                dgvContenidoZip.DataSource = fileHelp2;

                                // Borra visualmente los nombres de las columnas
                                dgvContenido.ColumnHeadersVisible = false;
                                dgvContenidoZip.ColumnHeadersVisible = false;



                                BdActions gestorBD = new BdActions(conn);

                                gestorBD.DeleteRegistry(patente, aduana, pedimento, "Elimino", cellvalue2, lblUsuario.Text, null);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El archivo no existe en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    if (dataGridView == dgvContenido)
                    {
                        // Validar si hay un ZIP principal seleccionado
                        if (lastClickedCellValue != null)
                        {
                            // Ruta del ZIP principal en la carpeta principal
                            string mainZipPath = Path.Combine(folderpath, cellValue);

                            Debug.WriteLine(mainZipPath);

                            string tempZipFilePath = Path.GetTempFileName();

                            // Ruta del ZIP temporal
                            try
                            {
                                // Copiar el ZIP principal al temporal
                                File.Copy(mainZipPath, tempZipFilePath, true);
                                string? rutaEliminar = dleteZip;

                                using (ZipArchive zipArchive = ZipFile.Open(tempZipFilePath, ZipArchiveMode.Update))
                                {
                                    // Buscar y eliminar el archivo dentro del ZIP
                                    ZipArchiveEntry? entryToRemove = zipArchive.GetEntry(rutaEliminar);
                                    if (entryToRemove != null)
                                    {
                                        entryToRemove.Delete();

                                        elementos2 = label2.Text.Split(' ');

                                        if (elementos2.Length >= 3)
                                        {
                                            // Obtener los valores deseados
                                            patente = elementos2[0];
                                            aduana = elementos2[1];

                                            // Eliminar ".zip" y/o "-V" del último elemento y obtener el pedimento
                                            pedimento = elementos2[2].Replace(".zip", "").Replace("-V", "");
                                        }
                                        else
                                        {
                                            // No hay suficientes elementos en la cadena
                                            patente = "No hay elemento";
                                            aduana = "No hay elemento";
                                            pedimento = "No hay elemento";
                                        }

                                        BdActions gestorBD = new BdActions(conn);

                                        gestorBD.DeleteRegistry(patente, aduana, pedimento, "Elimino", rutaEliminar, lblUsuario.Text, null);

                                    }
                                    else
                                    {
                                        MessageBox.Show("No existe tal archivo");
                                    }
                                }

                                // Reemplazar el archivo ZIP original con la versión modificada
                                File.Copy(tempZipFilePath, mainZipPath, true);


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
                                File.Delete(tempZipFilePath);
                            }

                        }
                    }
                    if (dataGridView == dgvContenidoZip)
                    {
                        if (lastClickedCellValue != null)
                        {
                            // Ruta del ZIP principal en la carpeta principal
                            string nestedZipPath = Path.Combine(zipsDirectoryPath, folderName, lastClickedCellValue);
                            string rutaActualizar = Path.Combine(folderpath, folderName + @".zip");
                            Debug.WriteLine(rutaActualizar);

                            string tempZipFilePath = Path.GetTempFileName();

                            try
                            {
                                // Copiar el ZIP principal al temporal
                                File.Copy(nestedZipPath, tempZipFilePath, true);

                                string? rutaEliminar = dleteZip;

                                using (ZipArchive zipArchive = ZipFile.Open(tempZipFilePath, ZipArchiveMode.Update))
                                {
                                    // Buscar y eliminar el archivo dentro del ZIP
                                    ZipArchiveEntry? entryToRemove = zipArchive.GetEntry(rutaEliminar);
                                    if (entryToRemove != null)
                                    {
                                        entryToRemove.Delete();

                                        elementos2 = label2.Text.Split(' ');

                                        // Verificar si hay suficientes elementos en la cadena
                                        if (elementos2.Length >= 3)
                                        {
                                            // Obtener los valores deseados
                                            patente = elementos2[0];
                                            aduana = elementos2[1];

                                            // Eliminar "-V.zip" del último elemento y obtener el pedimento
                                            pedimento = elementos2[2].Replace("-V.zip", "");
                                        }
                                        else
                                        {
                                            // No hay suficientes elementos en la cadena
                                            patente = "No hay elemento";
                                            aduana = "No hay elemento";
                                            pedimento = "No hay elemento";
                                        }

                                        string zipV = patente + @" " + aduana + @" " + pedimento + @" " + @"-V";

                                        BdActions gestorBD = new BdActions(conn);

                                        gestorBD.DeleteRegistry(patente, aduana, pedimento, "Elimino", rutaEliminar, lblUsuario.Text, zipV);

                                    }
                                    else
                                    {
                                        MessageBox.Show("No existe tal archivo");
                                    }
                                }

                                // Reemplazar el archivo ZIP original con la versión modificada
                                File.Copy(tempZipFilePath, nestedZipPath, true);
                                ReplaceInnerZipInOuterZip();

                                fileHelp = FileHelper.LoadPath(rutaActualizar);

                                loadExtractedList();
                                Debug.WriteLine(nestedZipPath);

                                zipHelper.SearchAndHighlightZipFiles(dgvContenido);

                                fileHelp2 = FileHelper.LoadPath(nestedZipPath);

                                zipHelper.LoadExtractedListZip(dgvContenidoZip, fileHelp2);

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Selecciona el segundo zip.", "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                // Eliminar el archivo ZIP temporal
                                File.Delete(tempZipFilePath);
                            }

                        }

                    }

                }
            }
        }

        private void dgvContenidoZip_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Verificar si se hizo clic derecho
            if (e.Button == MouseButtons.Right)
            {
                // Verificar si la celda seleccionada es válida
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtener el contenido de la celda seleccionada
                    dleteZip = dgvContenidoZip.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                }
            }
        }

        private void dgvContenido_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Verificar si la celda seleccionada es válida
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtener el contenido de la celda seleccionada
                    dleteZip = dgvContenido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                }
            }
        }

        private void dgvExpedientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Verificar si la celda seleccionada es válida
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtener el contenido de la celda seleccionada
                    cellvalue2 = dgvExpedientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    // Dividir la cadena por espacios
                    elementos2 = cellvalue2.Split(' ');

                    // Verificar si hay suficientes elementos en la cadena
                    if (elementos2.Length >= 3)
                    {
                        // Obtener los valores deseados
                        patente = elementos2[0];
                        aduana = elementos2[1];

                        // Eliminar ".zip" del último elemento y obtener el pedimento
                        pedimento = elementos2[2].Replace(".zip", "");
                    }
                    else
                    {
                        // No hay suficientes elementos en la cadena
                        patente = "No hay elemento";
                        aduana = "No hay elemento";
                        pedimento = "No hay elemento";
                    }
                }
            }
        }

        //private void timer1_Tick_1(object sender, EventArgs e)
        //{
        //    lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        //}

        public string BuscarArchivoEnRutas(string nombreArchivo, List<string> rutas)
        {
            // Iterar sobre cada ruta en la lista de rutas
            foreach (string ruta in rutas)
            {
                // Combinar la ruta actual con el nombre del archivo para obtener la ruta completa del archivo
                string rutaCompleta = Path.Combine(ruta, nombreArchivo);

                // Verificar si el archivo existe en la ruta completa
                if (File.Exists(rutaCompleta))
                {
                    // Si el archivo existe, devolver la ruta completa del archivo encontrado
                    return rutaCompleta;
                }
            }

            // Si el archivo no se encuentra en ninguna de las rutas, lanzar una excepción
            throw new FileNotFoundException($"El archivo '{nombreArchivo}' no se encontró en las rutas especificadas.");
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            BdActions bd = new BdActions(conn2);

            if (rbtPedimento.Checked)
            {
                string pedimento = txtPedimento.Text;
                string patente = cmbPatente.SelectedItem.ToString();
                string aduana = cmbAduana.SelectedItem.ToString();

                // Llamar al método archivoQuery para obtener el nombre del archivo
                List<string> nombresArchivos = bd.pedimentoBusqueda(patente, aduana, pedimento);

                // Buscar los archivos en las rutas especificadas
                try
                {
                    foreach (string nombreArchivo in nombresArchivos)
                    {
                        string rutaEncontrada = BuscarArchivoEnRutas(nombreArchivo, rutas);
                        // Aquí puedes hacer lo que necesites con la ruta del archivo encontrada
                        Debug.WriteLine($"El archivo se encontró en la siguiente ruta: {rutaEncontrada}");

                        // Construir la nueva ruta donde copiaremos el archivo
                        string nuevaRutaArchivo = Path.Combine(carpetaConsultas, nombreArchivo);

                        // Verificar si el archivo ya existe en la carpeta de consultas
                        if (!File.Exists(nuevaRutaArchivo))
                        {
                            try
                            {
                                // Verificar si el directorio "Consultas" no existe y crearlo si es necesario
                                if (!Directory.Exists(carpetaConsultas))
                                {
                                    Directory.CreateDirectory(carpetaConsultas);
                                }

                                // Copiar el archivo a la nueva ubicación
                                File.Copy(rutaEncontrada, nuevaRutaArchivo);

                                Debug.WriteLine($"Archivo copiado a la nueva ubicación: {nuevaRutaArchivo}");

                                fileHelp = FileHelper.LoadPath(folderpath);
                                //fileHelp = FileHelper.LoadPath(folderPath2);
                                flag = 1;

                                loadExtractedList();
                            }
                            catch (Exception ex)
                            {
                                // Manejar posibles excepciones al crear el directorio o copiar el archivo
                                MessageBox.Show($"Error al copiar el archivo: {ex.Message}");
                            }
                        }
                        else
                        {
                            Debug.WriteLine("El archivo ya existe en la carpeta de consultas.");

                            fileHelp = FileHelper.LoadPath(folderpath);
                            //fileHelp = FileHelper.LoadPath(folderPath2);
                            flag = 1;

                            loadExtractedList();
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Debug.WriteLine("No se encontró el archivo", ex);
                }
            }

            if (rbtFecha.Checked)
            {
                DateTime fechaDe = dtpDe.Value.Date;
                DateTime fechaHasta = dtpHasta.Value.Date;

                // Establecer hora, minutos y segundos a cero para fechaDe
                DateTime fechaNuevaDe = new DateTime(fechaDe.Year, fechaDe.Month, fechaDe.Day, 0, 0, 0);

                // Establecer hora, minutos y segundos al final del día (23:59:59) para fechaHasta
                DateTime fechaNuevaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59);

                Debug.WriteLine(fechaNuevaDe.ToString("MM/dd/yyyy HH:mm:ss"));
                Debug.WriteLine(fechaNuevaHasta.ToString("MM/dd/yyyy HH:mm:ss"));

                List<string> nombresArchivos = bd.pedimentoFechasBusqueda(fechaNuevaDe,fechaNuevaHasta);





            }
            if (rbtFechaCliente.Checked)
            {

            }


        }



        private void cmbPatente_DropDown(object sender, EventArgs e)
        {
            List<string> Patentes = new List<string>
            {
                "1684"
            };

            cmbPatente.DataSource = Patentes;
            datosCargados = true;
        }

        private void cmbAduana_DropDown(object sender, EventArgs e)
        {
            List<string> Aduana = new List<string>
            {
                "240"
            };

            cmbAduana.DataSource = Aduana;
            datosCargados = true;
        }

        private void rbtPedimento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPedimento.Checked)
            {
                // Limpia la carpeta de consultas
                LimpiarCarpetaConsultasyZips();
                LimpiarDataGrid();
                MostrarOcultarControles();

            }
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFecha.Checked)
            {
                // Limpia la carpeta de consultas
                LimpiarCarpetaConsultasyZips();
                LimpiarDataGrid();
                MostrarOcultarControles();
            }
        }

        private void rbtFechaCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFechaCliente.Checked)
            {
                // Limpia la carpeta de consultas
                LimpiarCarpetaConsultasyZips();
                LimpiarDataGrid();
                MostrarOcultarControles();
            }
        }

        private void LimpiarDataGrid()
        {
            // Limpia el DataSource de cada DataGrid
            dgvExpedientes.DataSource = null;
            dgvContenido.DataSource = null;
            dgvContenidoZip.DataSource = null;
            // Añade más líneas si tienes más DataGrids que necesiten limpiarse
        }

        private void LimpiarCarpetaConsultasyZips()
        {
            try
            {
                // Verificar si la carpeta de consultas existe
                if (Directory.Exists(carpetaConsultas))
                {
                    // Obtener todos los archivos en la carpeta de consultas
                    string[] archivos = Directory.GetFiles(carpetaConsultas);

                    // Eliminar cada archivo encontrado
                    foreach (string archivo in archivos)
                    {
                        File.Delete(archivo);
                    }

                }

            }
            catch (Exception ex)
            {
                // Manejar posibles excepciones al limpiar la carpeta
                MessageBox.Show($"Error al limpiar la carpeta de consultas: {ex.Message}");
            }
        }

        private void MostrarOcultarControles()
        {
            if (rbtPedimento.Checked)
            {
                lblDe.Visible = false;
                lblHasta.Visible = false;
                cbxClientes.Visible = false;
                dtpDe.Visible = false;
                dtpHasta.Visible = false;
                txtPedimento.Visible = true;
                label2.Text = string.Empty;

                // Ajusta los nombres y cantidad de controles según sea necesario
            }
            if (rbtFecha.Checked)
            {
                lblDe.Visible = true;
                lblHasta.Visible = true;
                cbxClientes.Visible = false;
                dtpDe.Visible = true;
                dtpHasta.Visible = true;
                txtPedimento.Visible = false;
                label2.Text= string.Empty;
                txtPedimento.Text = string.Empty;
               

            }
            if (rbtFechaCliente.Checked)
            {
                lblDe.Visible = true;
                lblHasta.Visible = true;
                cbxClientes.Visible = true;
                dtpDe.Visible = true;
                dtpHasta.Visible = true;
                txtPedimento.Visible = false;
                label2.Text= string.Empty;
                txtPedimento.Text = string.Empty;
               
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mostrar un MessageBox para confirmar si el usuario desea cerrar la aplicación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la aplicación?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige 'No', cancelar el cierre de la aplicación
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                LimpiarCarpetaConsultasyZips();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Ruta del archivo original
            string rutaOrigen = rutaDirecta;

            // Variable para indicar si se encontró el archivo en alguna de las rutas
            bool archivoEncontrado = false;

            // Recorrer todas las rutas originales en el servidor
            foreach (string rutaDestino in rutas)
            {
                // Construir la ruta completa del archivo de destino
                string rutaArchivoDestino = Path.Combine(rutaDestino, Path.GetFileName(rutaOrigen));

                // Verificar si el archivo de destino ya existe
                if (File.Exists(rutaArchivoDestino))
                {
                    archivoEncontrado = true;

                    // Mostrar un cuadro de diálogo de confirmación
                    DialogResult result = MessageBox.Show("El archivo de destino ya existe en la ruta " + rutaDestino + ". ¿Deseas reemplazarlo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Si el usuario elige "Sí" en el cuadro de diálogo
                    if (result == DialogResult.Yes)
                    {
                        // Intentar reemplazar el archivo
                        try
                        {
                            // Copiar el archivo origen a la ruta de destino
                            File.Copy(rutaOrigen, rutaArchivoDestino, true); // Reemplazar el archivo
                            MessageBox.Show("El archivo ha sido reemplazado correctamente en la ruta " + rutaDestino + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al intentar reemplazar el archivo en la ruta " + rutaDestino + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Salir del bucle ya que se encontró y reemplazó el archivo
                        break;
                    }
                }
            }

            if (!archivoEncontrado)
            {
                MessageBox.Show("El archivo no se encontró en ninguna de las rutas originales en el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}



