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
            components = new System.ComponentModel.Container();
            gbxExpedientes = new GroupBox();
            pcbCargando = new PictureBox();
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
            lblUsuario = new Label();
            lblHora = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            btnGuardar = new Button();
            cmbAduana = new ComboBox();
            cmbPatente = new ComboBox();
            btnSearch = new Button();
            cbxClientes = new ComboBox();
            lblHasta = new Label();
            lblDe = new Label();
            dtpHasta = new DateTimePicker();
            dtpDe = new DateTimePicker();
            txtPedimento = new TextBox();
            rbtFechaCliente = new RadioButton();
            rbtFecha = new RadioButton();
            rbtPedimento = new RadioButton();
            gbxExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbCargando).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvExpedientes).BeginInit();
            gbxContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenido).BeginInit();
            gbxZipContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenidoZip).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // gbxExpedientes
            // 
            gbxExpedientes.Controls.Add(pcbCargando);
            gbxExpedientes.Controls.Add(txtFiltro);
            gbxExpedientes.Controls.Add(label1);
            gbxExpedientes.Controls.Add(dgvExpedientes);
            gbxExpedientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxExpedientes.Location = new Point(12, 233);
            gbxExpedientes.Name = "gbxExpedientes";
            gbxExpedientes.Size = new Size(244, 440);
            gbxExpedientes.TabIndex = 1;
            gbxExpedientes.TabStop = false;
            gbxExpedientes.Text = "EXPEDIENTES OPERATIVOS";
            // 
            // pcbCargando
            // 
            pcbCargando.Image = Properties.Resources.cargando;
            pcbCargando.Location = new Point(20, 165);
            pcbCargando.Name = "pcbCargando";
            pcbCargando.Size = new Size(196, 136);
            pcbCargando.SizeMode = PictureBoxSizeMode.CenterImage;
            pcbCargando.TabIndex = 2;
            pcbCargando.TabStop = false;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(53, 27);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.PlaceholderText = "N° Expediente";
            txtFiltro.Size = new Size(185, 25);
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
            dgvExpedientes.Location = new Point(6, 58);
            dgvExpedientes.Name = "dgvExpedientes";
            dgvExpedientes.ReadOnly = true;
            dgvExpedientes.RowHeadersVisible = false;
            dgvExpedientes.RowTemplate.Height = 25;
            dgvExpedientes.Size = new Size(232, 376);
            dgvExpedientes.TabIndex = 0;
            dgvExpedientes.CellContentDoubleClick += dgvExpedientes_CellContentDoubleClick;
            dgvExpedientes.CellMouseClick += dgvExpedientes_CellMouseClick;
            dgvExpedientes.MouseDown += dgvExpedientes_MouseDown;
            // 
            // gbxContenido
            // 
            gbxContenido.Controls.Add(dgvContenido);
            gbxContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxContenido.Location = new Point(262, 233);
            gbxContenido.Name = "gbxContenido";
            gbxContenido.Size = new Size(339, 440);
            gbxContenido.TabIndex = 2;
            gbxContenido.TabStop = false;
            gbxContenido.Text = "CONTENIDO PRINCIPAL";
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
            dgvContenido.Size = new Size(327, 410);
            dgvContenido.TabIndex = 0;
            dgvContenido.CellClick += dgvContenido_CellClick;
            dgvContenido.CellContentClick += dgvContenido_CellContentClick;
            dgvContenido.CellMouseClick += dgvContenido_CellMouseClick;
            dgvContenido.MouseDown += dgvContenido_MouseDown;
            // 
            // gbxZipContenido
            // 
            gbxZipContenido.Controls.Add(dgvContenidoZip);
            gbxZipContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxZipContenido.Location = new Point(607, 233);
            gbxZipContenido.Name = "gbxZipContenido";
            gbxZipContenido.Size = new Size(510, 440);
            gbxZipContenido.TabIndex = 3;
            gbxZipContenido.TabStop = false;
            gbxZipContenido.Text = "CONTENIDO SECUNDARIO";
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
            dgvContenidoZip.Location = new Point(7, 24);
            dgvContenidoZip.Name = "dgvContenidoZip";
            dgvContenidoZip.ReadOnly = true;
            dgvContenidoZip.RowHeadersVisible = false;
            dgvContenidoZip.RowTemplate.Height = 25;
            dgvContenidoZip.Size = new Size(497, 410);
            dgvContenidoZip.TabIndex = 0;
            //dgvContenidoZip.CellContentClick += dgvContenidoZip_CellContentClick;
            dgvContenidoZip.CellMouseClick += dgvContenidoZip_CellMouseClick;
            dgvContenidoZip.MouseDown += dgvContenidoZip_MouseDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 52);
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
            groupBox1.Location = new Point(512, 94);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(276, 112);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "AGREGAR";
            // 
            // rbtzipContenido
            // 
            rbtzipContenido.AutoSize = true;
            rbtzipContenido.Location = new Point(150, 29);
            rbtzipContenido.Name = "rbtzipContenido";
            rbtzipContenido.Size = new Size(118, 21);
            rbtzipContenido.TabIndex = 5;
            rbtzipContenido.Text = "Zip Secundario";
            rbtzipContenido.UseVisualStyleBackColor = true;
            // 
            // rbtzipPrincipal
            // 
            rbtzipPrincipal.AutoSize = true;
            rbtzipPrincipal.Checked = true;
            rbtzipPrincipal.Location = new Point(26, 29);
            rbtzipPrincipal.Name = "rbtzipPrincipal";
            rbtzipPrincipal.Size = new Size(104, 21);
            rbtzipPrincipal.TabIndex = 4;
            rbtzipPrincipal.TabStop = true;
            rbtzipPrincipal.Text = "Zip principal";
            rbtzipPrincipal.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.OldLace;
            btnAgregar.Location = new Point(70, 56);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 42);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.FlatStyle = FlatStyle.Popup;
            groupBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(512, 19);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(276, 69);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "ZIP ELEGIDO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(48, 28);
            label2.Name = "label2";
            label2.Size = new Size(173, 23);
            label2.TabIndex = 0;
            label2.Text = "1684 240 4000001.zip";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(927, 29);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(78, 21);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "Usuario1";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHora.Location = new Point(951, 84);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(0, 21);
            lblHora.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(groupBox1);
            groupBox3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(800, 215);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "ACCIONES";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnGuardar);
            groupBox4.Controls.Add(cmbAduana);
            groupBox4.Controls.Add(cmbPatente);
            groupBox4.Controls.Add(btnSearch);
            groupBox4.Controls.Add(cbxClientes);
            groupBox4.Controls.Add(lblHasta);
            groupBox4.Controls.Add(lblDe);
            groupBox4.Controls.Add(dtpHasta);
            groupBox4.Controls.Add(dtpDe);
            groupBox4.Controls.Add(txtPedimento);
            groupBox4.Controls.Add(rbtFechaCliente);
            groupBox4.Controls.Add(rbtFecha);
            groupBox4.Controls.Add(rbtPedimento);
            groupBox4.Location = new Point(6, 17);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(500, 189);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "BUSQUEDA";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.OldLace;
            btnGuardar.BackgroundImage = Properties.Resources.guardar_el_archivo;
            btnGuardar.BackgroundImageLayout = ImageLayout.Zoom;
            btnGuardar.Location = new Point(400, 102);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(71, 48);
            btnGuardar.TabIndex = 12;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbAduana
            // 
            cmbAduana.FormattingEnabled = true;
            cmbAduana.Location = new Point(271, 28);
            cmbAduana.Name = "cmbAduana";
            cmbAduana.Size = new Size(96, 25);
            cmbAduana.TabIndex = 11;
            cmbAduana.DropDown += cmbAduana_DropDown;
            // 
            // cmbPatente
            // 
            cmbPatente.FormattingEnabled = true;
            cmbPatente.Location = new Point(163, 27);
            cmbPatente.Name = "cmbPatente";
            cmbPatente.Size = new Size(102, 25);
            cmbPatente.TabIndex = 10;
            cmbPatente.DropDown += cmbPatente_DropDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.OldLace;
            btnSearch.BackgroundImage = Properties.Resources.busqueda_de_lupa;
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.Location = new Point(400, 37);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(71, 44);
            btnSearch.TabIndex = 9;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbxClientes
            // 
            cbxClientes.FormattingEnabled = true;
            cbxClientes.Location = new Point(163, 125);
            cbxClientes.Name = "cbxClientes";
            cbxClientes.Size = new Size(204, 25);
            cbxClientes.TabIndex = 8;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(163, 95);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(47, 17);
            lblHasta.TabIndex = 7;
            lblHasta.Text = "Hasta:";
            // 
            // lblDe
            // 
            lblDe.AutoSize = true;
            lblDe.Location = new Point(163, 64);
            lblDe.Name = "lblDe";
            lblDe.Size = new Size(29, 17);
            lblDe.TabIndex = 6;
            lblDe.Text = "De:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(228, 94);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(139, 25);
            dtpHasta.TabIndex = 5;
            // 
            // dtpDe
            // 
            dtpDe.Format = DateTimePickerFormat.Short;
            dtpDe.Location = new Point(228, 58);
            dtpDe.Name = "dtpDe";
            dtpDe.Size = new Size(139, 25);
            dtpDe.TabIndex = 4;
            // 
            // txtPedimento
            // 
            txtPedimento.Location = new Point(163, 69);
            txtPedimento.Name = "txtPedimento";
            txtPedimento.PlaceholderText = "N° Pedimento";
            txtPedimento.Size = new Size(204, 25);
            txtPedimento.TabIndex = 3;
            // 
            // rbtFechaCliente
            // 
            rbtFechaCliente.AutoSize = true;
            rbtFechaCliente.Location = new Point(25, 129);
            rbtFechaCliente.Name = "rbtFechaCliente";
            rbtFechaCliente.Size = new Size(117, 21);
            rbtFechaCliente.TabIndex = 2;
            rbtFechaCliente.Text = "Fecha y cliente";
            rbtFechaCliente.UseVisualStyleBackColor = true;
            rbtFechaCliente.CheckedChanged += rbtFechaCliente_CheckedChanged;
            // 
            // rbtFecha
            // 
            rbtFecha.AutoSize = true;
            rbtFecha.Location = new Point(25, 77);
            rbtFecha.Name = "rbtFecha";
            rbtFecha.Size = new Size(67, 21);
            rbtFecha.TabIndex = 1;
            rbtFecha.Text = "Fechas";
            rbtFecha.UseVisualStyleBackColor = true;
            rbtFecha.CheckedChanged += rbtFecha_CheckedChanged;
            // 
            // rbtPedimento
            // 
            rbtPedimento.AutoSize = true;
            rbtPedimento.Checked = true;
            rbtPedimento.Location = new Point(25, 26);
            rbtPedimento.Name = "rbtPedimento";
            rbtPedimento.Size = new Size(93, 21);
            rbtPedimento.TabIndex = 0;
            rbtPedimento.TabStop = true;
            rbtPedimento.Text = "Pedimento";
            rbtPedimento.UseVisualStyleBackColor = true;
            rbtPedimento.CheckedChanged += rbtPedimento_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 680);
            Controls.Add(groupBox3);
            Controls.Add(lblHora);
            Controls.Add(gbxZipContenido);
            Controls.Add(gbxContenido);
            Controls.Add(lblUsuario);
            Controls.Add(gbxExpedientes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            gbxExpedientes.ResumeLayout(false);
            gbxExpedientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbCargando).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvExpedientes).EndInit();
            gbxContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContenido).EndInit();
            gbxZipContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContenidoZip).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblUsuario;
        private Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private RadioButton rbtFechaCliente;
        private RadioButton rbtFecha;
        private RadioButton rbtPedimento;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDe;
        private TextBox txtPedimento;
        private ComboBox cbxClientes;
        private Label lblHasta;
        private Label lblDe;
        private Button btnSearch;
        private ComboBox cmbAduana;
        private ComboBox cmbPatente;
        private Button btnGuardar;
        private PictureBox pcbCargando;
    }
}
