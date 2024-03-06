using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using System.Windows.Forms;


namespace descargarprueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            // Llenar el DataGridView con las rutas de archivos PDF (esto puede variar según tu implementación)
            // Aquí estoy usando un ejemplo simple con rutas de archivos estáticas.
            dataGridView1.Rows.Add(@"C:\Users\Lopezadri\Desktop\Certificacion\Docs\1-02 18100158 Carta de Presentacion.pdf");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string rutaArchivo = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            // Puedes abrir la vista previa aquí o llamar a un método que maneje la vista previa
            MostrarVistaPreviaPDF(rutaArchivo);
        }
        private void MostrarVistaPreviaPDF(string rutaArchivo)
        {
            
        }
    }
}
