namespace LOPEZADRI_FILE_MANAGER_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            gbxExpedientes = new GroupBox();
            dgvExpedientes = new DataGridView();
            gbxContenido = new GroupBox();
            dgvContenido = new DataGridView();
            gbxZipContenido = new GroupBox();
            dgvContenidoZip = new DataGridView();
            gbxExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpedientes).BeginInit();
            gbxContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenido).BeginInit();
            gbxZipContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenidoZip).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(622, 160);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "INFORMACION";
            // 
            // gbxExpedientes
            // 
            gbxExpedientes.Controls.Add(dgvExpedientes);
            gbxExpedientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxExpedientes.Location = new Point(12, 169);
            gbxExpedientes.Name = "gbxExpedientes";
            gbxExpedientes.Size = new Size(238, 260);
            gbxExpedientes.TabIndex = 1;
            gbxExpedientes.TabStop = false;
            gbxExpedientes.Text = "EXPEDIENTES";
            // 
            // dgvExpedientes
            // 
            dgvExpedientes.AllowUserToAddRows = false;
            dgvExpedientes.AllowUserToDeleteRows = false;
            dgvExpedientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpedientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpedientes.Location = new Point(6, 24);
            dgvExpedientes.Name = "dgvExpedientes";
            dgvExpedientes.ReadOnly = true;
            dgvExpedientes.RowTemplate.Height = 25;
            dgvExpedientes.Size = new Size(224, 230);
            dgvExpedientes.TabIndex = 0;
            dgvExpedientes.CellContentDoubleClick += dgvExpedientes_CellContentDoubleClick;
            // 
            // gbxContenido
            // 
            gbxContenido.Controls.Add(dgvContenido);
            gbxContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxContenido.Location = new Point(256, 169);
            gbxContenido.Name = "gbxContenido";
            gbxContenido.Size = new Size(245, 260);
            gbxContenido.TabIndex = 2;
            gbxContenido.TabStop = false;
            gbxContenido.Text = "CONTENIDO";
            // 
            // dgvContenido
            // 
            dgvContenido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContenido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContenido.Location = new Point(6, 24);
            dgvContenido.Name = "dgvContenido";
            dgvContenido.RowTemplate.Height = 25;
            dgvContenido.Size = new Size(233, 229);
            dgvContenido.TabIndex = 0;
            // 
            // gbxZipContenido
            // 
            gbxZipContenido.Controls.Add(dgvContenidoZip);
            gbxZipContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxZipContenido.Location = new Point(507, 169);
            gbxZipContenido.Name = "gbxZipContenido";
            gbxZipContenido.Size = new Size(352, 260);
            gbxZipContenido.TabIndex = 3;
            gbxZipContenido.TabStop = false;
            gbxZipContenido.Text = "ZIPCONTENIDO";
            // 
            // dgvContenidoZip
            // 
            dgvContenidoZip.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContenidoZip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContenidoZip.Location = new Point(6, 24);
            dgvContenidoZip.Name = "dgvContenidoZip";
            dgvContenidoZip.RowTemplate.Height = 25;
            dgvContenidoZip.Size = new Size(340, 230);
            dgvContenidoZip.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 439);
            Controls.Add(gbxZipContenido);
            Controls.Add(gbxContenido);
            Controls.Add(gbxExpedientes);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            gbxExpedientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpedientes).EndInit();
            gbxContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContenido).EndInit();
            gbxZipContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContenidoZip).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox gbxExpedientes;
        private GroupBox gbxContenido;
        private GroupBox gbxZipContenido;
        private DataGridView dgvExpedientes;
        private DataGridView dgvContenido;
        private DataGridView dgvContenidoZip;
    }
}
