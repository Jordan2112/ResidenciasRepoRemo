using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace VisualizacionArchivos
{
    public partial class Form1 : Form
    {
        private string rutaCarpeta = @"C:\Users\Lopezadri\Desktop\Expedientes\";
        public Form1()
        {
            InitializeComponent();
            
        }

       
        private void contenidoCarpeta()
        {
            if(Directory.Exists(rutaCarpeta))
            {
                string[] documentos = Directory.GetFiles(rutaCarpeta);

                foreach( string documento in documentos ) 
                { 
                    FileInfo fileInfo = new FileInfo(documento);
                   dataGridView1.Rows.Add(new object[] 
                   { 
                      fileInfo.Name,
                      
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
                using (FileStream archivoStream =  new FileStream(ruta, FileMode.Open, FileAccess.Read))
                    using(ZipInputStream zipStream =  new ZipInputStream(archivoStream))
                    {
                        ZipEntry entrada;
                        while ((entrada = zipStream.GetNextEntry()) != null)
                        {   
                            string nombreArchivo = entrada.Name;

                           

                            if (dataGridView2.Rows.Count > 0 ) 
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
                MessageBox.Show("Error al acceder al archivo zip" );
            
            
            }

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDato.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label1.Text = rutaCarpeta + txtDato.Text;
           
            
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            

              contenidoCarpeta();
               


           
            
        }

        private void btnAcceso_Click(object sender, EventArgs e)
        {
            contenidoZip();
            
            txtDato.Text = "";
           

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDato.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            label1.Text += @"\" + txtDato.Text;

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string archivoExistente = label1.Text;
            //    string archivoNuevo = openFileDialog.FileName;

            //    try
            //    {
            //        // Crear un nombre temporal para el nuevo archivo ZIP
            //        string archivoTemporal = Path.GetTempFileName();

            //        // Abrir el archivo ZIP existente
            //        using (FileStream archivoZipExistente = new FileStream(archivoExistente, FileMode.Open))
            //        using (FileStream nuevoArchivo = new FileStream(archivoNuevo, FileMode.Open))
            //        using (ZipFile zip = new ZipFile(archivoZipExistente))
            //        {
            //            // Crear un nuevo archivo ZIP temporal
            //            using (FileStream archivoTemporalStream = new FileStream(archivoTemporal, FileMode.Create))
            //            using (ZipOutputStream zipOutputStream = new ZipOutputStream(archivoTemporalStream))
            //            {
            //                // Copiar las entradas existentes al nuevo archivo ZIP
            //                foreach (ZipEntry entradaExistente in zip)
            //                {
            //                    zipOutputStream.PutNextEntry(entradaExistente);
            //                    StreamUtils.Copy(zip.GetInputStream(entradaExistente), zipOutputStream, new byte[4096]);
            //                    zipOutputStream.CloseEntry();
            //                }

            //                // Agregar la nueva entrada al nuevo archivo ZIP
            //                ZipEntry nuevaEntrada = new ZipEntry(Path.GetFileName(archivoNuevo));
            //                zipOutputStream.PutNextEntry(nuevaEntrada);
            //                StreamUtils.Copy(nuevoArchivo, zipOutputStream, new byte[4096]);
            //                zipOutputStream.CloseEntry();
            //            }
            //        }

            //        // Reemplazar el archivo ZIP existente con el nuevo archivo ZIP temporal
            //        File.Copy(archivoTemporal, archivoExistente, true);

            //        // Eliminar el archivo ZIP temporal
            //        File.Delete(archivoTemporal);

            //        MessageBox.Show("Archivo anexado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string archivoExistente = label1.Text;
                string archivoNuevo = openFileDialog.FileName;

                try
                {
                    // Crear un nuevo archivo ZIP temporal
                    string archivoTemporal = Path.GetTempFileName();

                    using (FileStream archivoTemporalStream = new FileStream(archivoTemporal, FileMode.Create))
                    using (ZipOutputStream zipOutputStream = new ZipOutputStream(archivoTemporalStream))
                    {
                        using (FileStream archivoZipExistente = new FileStream(archivoExistente, FileMode.Open))
                        {
                            using (ZipFile zipFile = new ZipFile(archivoZipExistente))
                            {
                                // Copiar las entradas existentes al nuevo archivo ZIP
                                foreach (ZipEntry entradaExistente in zipFile)
                                {
                                    zipOutputStream.PutNextEntry(entradaExistente);
                                    zipFile.GetInputStream(entradaExistente).CopyTo(zipOutputStream);
                                    zipOutputStream.CloseEntry();
                                }
                            }
                        }

                        // Agregar la nueva entrada al nuevo archivo ZIP
                        using (FileStream nuevoArchivo = new FileStream(archivoNuevo, FileMode.Open))
                        {
                            ZipEntry nuevaEntrada = new ZipEntry(Path.GetFileName(archivoNuevo));
                            zipOutputStream.PutNextEntry(nuevaEntrada);
                            nuevoArchivo.CopyTo(zipOutputStream);
                            zipOutputStream.CloseEntry();
                        }
                    }

                    // Reemplazar el archivo ZIP existente con el nuevo archivo ZIP temporal
                    File.Copy(archivoTemporal, archivoExistente, true);

                    // Eliminar el archivo ZIP temporal
                    File.Delete(archivoTemporal);

                    MessageBox.Show("Archivo anexado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }
    }
}
