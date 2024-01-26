using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace Diseño
{
    public partial class Form1 : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();







        private string rutaCarpeta = @"C:\Users\Lopezadri\Desktop\Expedientes\";
        public Form1()
        {
            InitializeComponent();
            panel1.MouseDown += panel1_MouseDown;

        }
        private void contenidoCarpeta()
        {
            if (Directory.Exists(rutaCarpeta))
            {
                string[] documentos = Directory.GetFiles(rutaCarpeta);

                foreach (string documento in documentos)
                {
                    FileInfo fileInfo = new FileInfo(documento);
                    dataGridView1.Rows.Add(new object[]
                    {
                      fileInfo.Name,
                      fileInfo.LastWriteTime.ToString()

                    });

                }
            }
            else
            {
                MessageBox.Show("La carpeta no existe");
            }
        }

        private void contenidoZip()
        {
            //string rutazip = rutaCarpeta += txtDato.Text;
            string ruta = label1.Text;
            Console.WriteLine(ruta);
            try
            {
                using (FileStream archivoStream = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                using (ZipInputStream zipStream = new ZipInputStream(archivoStream))
                {
                    ZipEntry entrada;
                    while ((entrada = zipStream.GetNextEntry()) != null)
                    {
                        string nombreArchivo = entrada.Name;



                        if (dataGridView2.Rows.Count > 0)
                        {
                            dataGridView2.Rows.Add(nombreArchivo);
                        }
                        else
                        {


                        }


                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al acceder al archivo zip");


            }


        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            contenidoCarpeta();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns[""].Index)
            {
                // Obtén el valor de la celda (botón)
                string action = dataGridView1.Rows[e.RowIndex].Cells[""].Value.ToString();

                // Realiza la acción según el contenido del botón
                if (action == "Consultar")
                {
                    string ruta = rutaCarpeta + @"\" + dataGridView1.Columns["Nombre"].Index;
                    try
                    {
                        using (FileStream archivoStream = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                        using (ZipInputStream zipStream = new ZipInputStream(archivoStream))
                        {
                            ZipEntry entrada;
                            while ((entrada = zipStream.GetNextEntry()) != null)
                            {
                                string nombreArchivo = entrada.Name;



                                if (dataGridView2.Rows.Count > 0)
                                {
                                    dataGridView2.Rows.Add(nombreArchivo);
                                }
                                else
                                {


                                }


                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al acceder al archivo zip");


                    }


                }
               
            }
        }
    }
}
