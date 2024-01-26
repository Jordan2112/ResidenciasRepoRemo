using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityPrueba.Models;



namespace EntityPrueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refrescar();

        }

        #region HELPER

        private void refrescar()
        {
            using (usuariosEntities db = new usuariosEntities())
            {
                var lst = from d in db.nombres
                          select d;
                dataGridView1.DataSource = lst.ToList();

            }
        }


        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Presentacion.frmTabla ofrmTabla = new Presentacion.frmTabla();
            ofrmTabla.ShowDialog();
            refrescar();
        }
    }   

 

}
