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
            gbxExpedientes = new GroupBox();
            txtFiltro = new TextBox();
            label1 = new Label();
            dgvExpedientes = new DataGridView();
            gbxContenido = new GroupBox();
            dgvContenido = new DataGridView();
            gbxZipContenido = new GroupBox();
            dgvContenidoZip = new DataGridView();
            label3 = new Label();
            groupBox1 = new GroupBox();
            rbtzipContenido = new RadioButton();
            rbtzipPrincipal = new RadioButton();
            btnAgregar = new Button();
            groupBox2 = new GroupBox();
            label2 = new Label();
            gbxExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpedientes).BeginInit();
            gbxContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenido).BeginInit();
            gbxZipContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenidoZip).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // gbxExpedientes
            // 
            gbxExpedientes.Controls.Add(txtFiltro);
            gbxExpedientes.Controls.Add(label1);
            gbxExpedientes.Controls.Add(dgvExpedientes);
            gbxExpedientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxExpedientes.Location = new Point(12, 149);
            gbxExpedientes.Name = "gbxExpedientes";
            gbxExpedientes.Size = new Size(238, 335);
            gbxExpedientes.TabIndex = 1;
            gbxExpedientes.TabStop = false;
            gbxExpedientes.Text = "EXPEDIENTES";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(53, 27);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.PlaceholderText = "N° Expediente";
            txtFiltro.Size = new Size(177, 25);
            txtFiltro.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(41, 17);
            label1.TabIndex = 1;
            label1.Text = "Filtro";
            // 
            // dgvExpedientes
            // 
            dgvExpedientes.AllowUserToAddRows = false;
            dgvExpedientes.AllowUserToDeleteRows = false;
            dgvExpedientes.AllowUserToResizeColumns = false;
            dgvExpedientes.AllowUserToResizeRows = false;
            dgvExpedientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpedientes.BackgroundColor = SystemColors.Window;
            dgvExpedientes.BorderStyle = BorderStyle.Fixed3D;
            dgvExpedientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpedientes.Location = new Point(6, 64);
            dgvExpedientes.Name = "dgvExpedientes";
            dgvExpedientes.ReadOnly = true;
            dgvExpedientes.RowHeadersVisible = false;
            dgvExpedientes.RowTemplate.Height = 25;
            dgvExpedientes.Size = new Size(224, 264);
            dgvExpedientes.TabIndex = 0;
            dgvExpedientes.CellContentDoubleClick += dgvExpedientes_CellContentDoubleClick;
            // 
            // gbxContenido
            // 
            gbxContenido.Controls.Add(dgvContenido);
            gbxContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxContenido.Location = new Point(256, 149);
            gbxContenido.Name = "gbxContenido";
            gbxContenido.Size = new Size(245, 335);
            gbxContenido.TabIndex = 2;
            gbxContenido.TabStop = false;
            gbxContenido.Text = "CONTENIDO";
            // 
            // dgvContenido
            // 
            dgvContenido.AllowUserToAddRows = false;
            dgvContenido.AllowUserToDeleteRows = false;
            dgvContenido.AllowUserToResizeColumns = false;
            dgvContenido.AllowUserToResizeRows = false;
            dgvContenido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContenido.BackgroundColor = SystemColors.Window;
            dgvContenido.BorderStyle = BorderStyle.Fixed3D;
            dgvContenido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContenido.Location = new Point(6, 24);
            dgvContenido.Name = "dgvContenido";
            dgvContenido.ReadOnly = true;
            dgvContenido.RowHeadersVisible = false;
            dgvContenido.RowTemplate.Height = 25;
            dgvContenido.Size = new Size(233, 304);
            dgvContenido.TabIndex = 0;
            dgvContenido.CellClick += dgvContenido_CellClick;
            dgvContenido.CellContentClick += dgvContenido_CellContentClick;
            // 
            // gbxZipContenido
            // 
            gbxZipContenido.Controls.Add(dgvContenidoZip);
            gbxZipContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxZipContenido.Location = new Point(507, 149);
            gbxZipContenido.Name = "gbxZipContenido";
            gbxZipContenido.Size = new Size(440, 335);
            gbxZipContenido.TabIndex = 3;
            gbxZipContenido.TabStop = false;
            gbxZipContenido.Text = "ZIPCONTENIDO";
            // 
            // dgvContenidoZip
            // 
            dgvContenidoZip.AllowUserToAddRows = false;
            dgvContenidoZip.AllowUserToDeleteRows = false;
            dgvContenidoZip.AllowUserToResizeColumns = false;
            dgvContenidoZip.AllowUserToResizeRows = false;
            dgvContenidoZip.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContenidoZip.BackgroundColor = SystemColors.Window;
            dgvContenidoZip.BorderStyle = BorderStyle.Fixed3D;
            dgvContenidoZip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContenidoZip.Location = new Point(6, 24);
            dgvContenidoZip.Name = "dgvContenidoZip";
            dgvContenidoZip.ReadOnly = true;
            dgvContenidoZip.RowHeadersVisible = false;
            dgvContenidoZip.RowTemplate.Height = 25;
            dgvContenidoZip.Size = new Size(428, 304);
            dgvContenidoZip.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 55);
            label3.Name = "label3";
            label3.Size = new Size(0, 17);
            label3.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtzipContenido);
            groupBox1.Controls.Add(rbtzipPrincipal);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(159, 140);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar";
            // 
            // rbtzipContenido
            // 
            rbtzipContenido.AutoSize = true;
            rbtzipContenido.Location = new Point(23, 55);
            rbtzipContenido.Name = "rbtzipContenido";
            rbtzipContenido.Size = new Size(118, 21);
            rbtzipContenido.TabIndex = 5;
            rbtzipContenido.TabStop = true;
            rbtzipContenido.Text = "Zip Secundario";
            rbtzipContenido.UseVisualStyleBackColor = true;
            // 
            // rbtzipPrincipal
            // 
            rbtzipPrincipal.AutoSize = true;
            rbtzipPrincipal.Location = new Point(23, 28);
            rbtzipPrincipal.Name = "rbtzipPrincipal";
            rbtzipPrincipal.Size = new Size(104, 21);
            rbtzipPrincipal.TabIndex = 4;
            rbtzipPrincipal.TabStop = true;
            rbtzipPrincipal.Text = "Zip principal";
            rbtzipPrincipal.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(23, 82);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(104, 42);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(177, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(293, 40);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 17);
            label2.Name = "label2";
            label2.Size = new Size(0, 17);
            label2.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 496);
            Controls.Add(groupBox2);
            Controls.Add(gbxZipContenido);
            Controls.Add(gbxContenido);
            Controls.Add(gbxExpedientes);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            gbxExpedientes.ResumeLayout(false);
            gbxExpedientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpedientes).EndInit();
            gbxContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContenido).EndInit();
            gbxZipContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContenidoZip).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxExpedientes;
        private GroupBox gbxContenido;
        private GroupBox gbxZipContenido;
        private DataGridView dgvExpedientes;
        private DataGridView dgvContenido;
        private DataGridView dgvContenidoZip;
        private TextBox txtFiltro;
        private Label label1;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnAgregar;
        private RadioButton rbtzipContenido;
        private RadioButton rbtzipPrincipal;
        private GroupBox groupBox2;
        private Label label2;
    }
}
