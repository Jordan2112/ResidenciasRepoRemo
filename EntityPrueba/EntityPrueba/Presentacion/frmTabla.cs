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

namespace EntityPrueba.Presentacion
{
    public partial class frmTabla : Form
    {
        public frmTabla()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using(usuariosEntities db = new usuariosEntities()) 
            {
                nombres nm = new nombres();

                nm.id = 1;
                nm.nombre = textBox2.Text;
                nm.correo = textBox3.Text;


                db.nombres.Add(nm);
                db.SaveChanges();

                this.Close();

            
            
            }
        }
    }
}
