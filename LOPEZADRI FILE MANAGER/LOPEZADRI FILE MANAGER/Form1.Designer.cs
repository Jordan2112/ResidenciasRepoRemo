namespace LOPEZADRI_FILE_MANAGER
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dtgExpedientes = new DataGridView();
            groupBox3 = new GroupBox();
            dtgContenido = new DataGridView();
            lblHora = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblFecha = new Label();
            groupBox4 = new GroupBox();
            dtgContenidoZip = new DataGridView();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgExpedientes).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgContenido).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgContenidoZip).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(582, 186);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "INFORMACION";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtgExpedientes);
            groupBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 204);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(290, 343);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "EXPEDIENTES";
            // 
            // dtgExpedientes
            // 
            dtgExpedientes.AllowUserToAddRows = false;
            dtgExpedientes.AllowUserToDeleteRows = false;
            dtgExpedientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgExpedientes.BackgroundColor = Color.White;
            dtgExpedientes.BorderStyle = BorderStyle.Fixed3D;
            dtgExpedientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgExpedientes.Location = new Point(6, 20);
            dtgExpedientes.Name = "dtgExpedientes";
            dtgExpedientes.ReadOnly = true;
            dtgExpedientes.RowTemplate.Height = 25;
            dtgExpedientes.Size = new Size(278, 317);
            dtgExpedientes.TabIndex = 0;
            dtgExpedientes.CellDoubleClick += dtgExpedientes_CellDoubleClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dtgContenido);
            groupBox3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(308, 205);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(286, 343);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "CONTENIDO";
            // 
            // dtgContenido
            // 
            dtgContenido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgContenido.BackgroundColor = Color.White;
            dtgContenido.BorderStyle = BorderStyle.Fixed3D;
            dtgContenido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgContenido.Location = new Point(6, 20);
            dtgContenido.Name = "dtgContenido";
            dtgContenido.RowTemplate.Height = 25;
            dtgContenido.Size = new Size(272, 317);
            dtgContenido.TabIndex = 0;
            dtgContenido.CellDoubleClick += dtgContenido_CellDoubleClick;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblHora.Location = new Point(606, 12);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(62, 20);
            lblHora.TabIndex = 4;
            lblHora.Text = "9:28:05";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblFecha.Location = new Point(597, 29);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(86, 20);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "01/02/204";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dtgContenidoZip);
            groupBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.Location = new Point(600, 208);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(281, 340);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "ZIPCONTENIDO";
            // 
            // dtgContenidoZip
            // 
            dtgContenidoZip.BackgroundColor = Color.White;
            dtgContenidoZip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgContenidoZip.Location = new Point(6, 19);
            dtgContenidoZip.Name = "dtgContenidoZip";
            dtgContenidoZip.RowTemplate.Height = 25;
            dtgContenidoZip.Size = new Size(266, 315);
            dtgContenidoZip.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(891, 557);
            Controls.Add(groupBox4);
            Controls.Add(lblFecha);
            Controls.Add(lblHora);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgExpedientes).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgContenido).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgContenidoZip).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridView dtgExpedientes;
        private DataGridView dtgContenido;
        private Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private Label lblFecha;
        private GroupBox groupBox4;
        private DataGridView dtgContenidoZip;
    }
}
