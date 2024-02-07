using LOPEZADRI_FILE_MANAGER.Models;
using System.Data;
using System.IO.Compression;

namespace LOPEZADRI_FILE_MANAGER
{
    public partial class Form1 : Form
    {
        //Lista para almacenar los datos de los archivos de la ruta proveniente principal
        private List<fileInfo> fileList;
        //Lista para almacenar el contenido del el zip 
        private List<fileInfo> fileListZip;

        string? pathComplete = "";

        int Bandera = 0;

        string folderPath = @"C:\Users\Lopezadri\Desktop\Expedientes\";

        public Form1()
        {
            InitializeComponent();

            fileList = new List<fileInfo>();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           
            fileList = fileInfo.LoadFiles(folderPath);
            cargarArchivosListaaDatagrid();

        }
        public void cargarArchivosListaaDatagrid()
        {
            DataTable dataTable = fileInfo.ConvertListToDataTable(fileList);
            dtgExpedientes.DataSource = dataTable;

            dtgExpedientes.Columns[2].Visible = false;
            dtgExpedientes.Columns[2].HeaderText = string.Empty;
            dtgExpedientes.Columns[1].Visible = false;
            dtgExpedientes.Columns[1].HeaderText = string.Empty;

        }
        public void cargarArchivosZip()
        {
            

            if (Bandera == 1)
            {
                DataTable dataTable = fileInfo.ConvertListToDataTableZip(fileListZip);
                dtgContenido.DataSource = dataTable;
                dtgContenido.CurrentCell = null;
                dtgContenido.Columns[2].Visible = false;
                dtgContenido.Columns[2].HeaderText = string.Empty;
                dtgContenido.Columns[1].Visible = false;
                dtgContenido.Columns[1].HeaderText = string.Empty;
            }
            else
            {
                DataTable dataTable = fileInfo.ConvertListToDataTableZip2(fileListZip);
               

            }

        }
        private void dtgExpedientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Bandera = 1;

            fileListZip = new List<fileInfo>();

            int rowIndex = e.RowIndex;

            //MessageBox.Show(rowIndex.ToString());

            if (rowIndex >= 0 && rowIndex < fileList.Count)
            {
                // Obtener el elemento seleccionado en la lista
                fileInfo selectedFile = fileList[rowIndex];

                // Almacenar el contenido de una columna específica en una variable
                string? contenidoColumna = dtgExpedientes.Rows[rowIndex].Cells[2].Value?.ToString();
                pathComplete = contenidoColumna;
                fileListZip = fileInfo.LoadFilesZip(selectedFile.filePath);

                cargarArchivosZip();

                SearchAndHighlightZipFiles();
            }
            
        }
        private void SearchAndHighlightZipFiles()
        {
            foreach (DataGridViewRow row in dtgContenido.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {

                    object cellValue = cell.Value;


                    if (cellValue?.ToString()?.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) == true)
                    {

                        cell.Style.BackColor = Color.Yellow;
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void dtgContenido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Bandera = 2;
            if (dtgContenido.Rows.Count > 0)
            {
                // Iterar a través de todas las filas del DataGridView
                foreach (DataGridViewRow row in dtgContenido.Rows)
                {
                    // Obtener el valor de la celda en la primera columna de la fila actual
                    object cellValue = row.Cells[2].Value;

                    // Verificar si el valor no es nulo y termina en ".zip"
                    if (cellValue != null && cellValue.ToString().EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        // El contenido de la celda actual termina en ".zip"
                        string? pathZip = pathComplete + @"\" +  cellValue.ToString();


                        MessageBox.Show(pathZip);
                        fileListZip = new List<fileInfo>();

                        fileListZip = fileInfo.ExtractZipContents(pathZip);

                       
                    }
                }
            }
           
        }

    }

}
