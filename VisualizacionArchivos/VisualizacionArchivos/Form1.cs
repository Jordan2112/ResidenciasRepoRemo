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
        private string archivoZip;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Selccione un archivo";
            op.Filter = "Archivos PDF|*.pdf| Todos los archivos|*.*";

            if(op.ShowDialog() == DialogResult.OK)
            { 
                archivoZip = op.FileName;

                using (ZipFile zip = new ZipFile(archivoZip))
                {
                    dataGridView1.Rows.Clear();

                    foreach(ZipEntry entry in zip)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = entry.Name;
                        row.Cells[1].Value = entry.Size;

                        dataGridView1.Rows.Add(row);
                       

                    }


                };
               
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreArchivo = textBox1.Text.Trim();



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string nombre = row.Cells[0].Value.ToString();

                using (ZipFile zipfile = new ZipFile(archivoZip))
                {
                    ZipEntry entry = zipfile.GetEntry(nombre);
                    if (entry != null)
                    {
                        using (StreamReader reader = new StreamReader(zipfile.GetInputStream(entry)))
                        {
                            string contenido = reader.ReadToEnd();

                            webBrowser1.Navigate(contenido);


                        };
                    
                    }

                };
            
            }
        }
    }
}
