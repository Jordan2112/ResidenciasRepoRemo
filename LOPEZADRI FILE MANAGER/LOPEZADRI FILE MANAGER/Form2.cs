using System.Data;

namespace LOPEZADRI_FILE_MANAGER
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        public void SetDataSource(DataTable dataTable)
        {
            dtgContenidoZip.DataSource = dataTable;
            dtgContenidoZip.CurrentCell = null;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
