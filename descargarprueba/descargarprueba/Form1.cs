using Microsoft.VisualBasic.ApplicationServices;
using System.Net;

namespace descargarprueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rutaServidor = @"c:\users\lopezadri\desktop\expedientes\";

            if (string.IsNullOrWhiteSpace(rutaServidor))
            {
                MessageBox.Show("Por favor, ingresa una ruta de servidor válida.");
                return;
            }

            DescargarArchivosDesdeServidor(rutaServidor);
        }

        private void DescargarArchivosDesdeServidor(string rutaServidor)
        {
            using (WebClient cliente = new WebClient())
            {
                try
                {
                    string[] archivosEnServidor = Directory.GetFiles(rutaServidor);

                    using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                    {
                        folderBrowserDialog.Description = "Seleccione la carpeta de destino";
                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            string carpetaDestinoLocal = folderBrowserDialog.SelectedPath;

                            foreach (string archivoEnServidor in archivosEnServidor)
                            {
                                string nombreArchivo = Path.GetFileName(archivoEnServidor);
                                string rutaDestinoLocal = Path.Combine(carpetaDestinoLocal, nombreArchivo);

                                cliente.DownloadFile(Path.Combine(rutaServidor, nombreArchivo), rutaDestinoLocal);
                            }

                            MessageBox.Show("Descarga completada correctamente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al descargar archivos: {ex.Message}");
                }
            }
        }
    }
}
