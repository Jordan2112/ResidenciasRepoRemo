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
            comboBox1 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            txtPedimento = new TextBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            gbxExpedientes.SuspendLayout();
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
            gbxExpedientes.Controls.Add(txtFiltro);
            gbxExpedientes.Controls.Add(label1);
            gbxExpedientes.Controls.Add(dgvExpedientes);
            gbxExpedientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxExpedientes.Location = new Point(12, 263);
            gbxExpedientes.Name = "gbxExpedientes";
            gbxExpedientes.Size = new Size(244, 396);
            gbxExpedientes.TabIndex = 1;
            gbxExpedientes.TabStop = false;
            gbxExpedientes.Text = "EXPEDIENTES OPERATIVOS";
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
            dgvExpedientes.Size = new Size(232, 332);
            dgvExpedientes.TabIndex = 0;
            dgvExpedientes.CellContentDoubleClick += dgvExpedientes_CellContentDoubleClick;
            dgvExpedientes.CellMouseClick += dgvExpedientes_CellMouseClick;
            dgvExpedientes.MouseDown += dgvExpedientes_MouseDown;
            // 
            // gbxContenido
            // 
            gbxContenido.Controls.Add(dgvContenido);
            gbxContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbxContenido.Location = new Point(262, 263);
            gbxContenido.Name = "gbxContenido";
            gbxContenido.Size = new Size(339, 396);
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
            dgvContenido.Size = new Size(327, 366);
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
            gbxZipContenido.Location = new Point(607, 263);
            gbxZipContenido.Name = "gbxZipContenido";
            gbxZipContenido.Size = new Size(510, 396);
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
            dgvContenidoZip.Size = new Size(497, 366);
            dgvContenidoZip.TabIndex = 0;
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
            groupBox1.Location = new Point(256, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(422, 69);
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
            btnAgregar.Location = new Point(286, 17);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 42);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.FlatStyle = FlatStyle.Popup;
            groupBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(6, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(244, 65);
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
            label2.Location = new Point(25, 23);
            label2.Name = "label2";
            label2.Size = new Size(2, 23);
            label2.TabIndex = 0;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(862, 38);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(78, 21);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "Usuario1";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHora.Location = new Point(884, 96);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(0, 21);
            lblHora.TabIndex = 6;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick_1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(groupBox1);
            groupBox3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(759, 245);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "ACCIONES";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBox1);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(dateTimePicker2);
            groupBox4.Controls.Add(dateTimePicker1);
            groupBox4.Controls.Add(txtPedimento);
            groupBox4.Controls.Add(radioButton3);
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Location = new Point(6, 97);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(739, 142);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "BUSQUEDA";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(523, 75);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 25);
            comboBox1.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(267, 96);
            label5.Name = "label5";
            label5.Size = new Size(47, 17);
            label5.TabIndex = 7;
            label5.Text = "Hasta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(267, 65);
            label4.Name = "label4";
            label4.Size = new Size(29, 17);
            label4.TabIndex = 6;
            label4.Text = "De:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(332, 90);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(139, 25);
            dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(332, 59);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(139, 25);
            dateTimePicker1.TabIndex = 4;
            // 
            // txtPedimento
            // 
            txtPedimento.Location = new Point(34, 75);
            txtPedimento.Name = "txtPedimento";
            txtPedimento.PlaceholderText = "N° Pedimento";
            txtPedimento.Size = new Size(204, 25);
            txtPedimento.TabIndex = 3;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(555, 26);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(117, 21);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "Fecha y cliente";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(346, 26);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(67, 21);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Fechas";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(90, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(93, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Pedimento";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 667);
            Controls.Add(groupBox3);
            Controls.Add(lblHora);
            Controls.Add(lblUsuario);
            Controls.Add(gbxZipContenido);
            Controls.Add(gbxContenido);
            Controls.Add(gbxExpedientes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox txtPedimento;
        private ComboBox comboBox1;
        private Label label5;
        private Label label4;
    }
}
