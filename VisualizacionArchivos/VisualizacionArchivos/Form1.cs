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
                                if(dataGridView2.Rows.Count == 1 )
                                {
                                    dataGridView3.Rows.Add(nombreArchivo);
                                }
                                
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
    }
}
