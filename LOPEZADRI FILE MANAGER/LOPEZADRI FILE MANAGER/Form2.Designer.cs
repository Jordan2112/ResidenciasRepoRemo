namespace LOPEZADRI_FILE_MANAGER
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gprInformacion = new GroupBox();
            groupBox1 = new GroupBox();
            dtgContenidoZip = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgContenidoZip).BeginInit();
            SuspendLayout();
            // 
            // gprInformacion
            // 
            gprInformacion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gprInformacion.Location = new Point(12, 12);
            gprInformacion.Name = "gprInformacion";
            gprInformacion.Size = new Size(315, 146);
            gprInformacion.TabIndex = 1;
            gprInformacion.TabStop = false;
            gprInformacion.Text = "INFORMACION";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtgContenidoZip);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 164);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(565, 323);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "CONTENIDO";
            // 
            // dtgContenidoZip
            // 
            dtgContenidoZip.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgContenidoZip.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgContenidoZip.BackgroundColor = Color.White;
            dtgContenidoZip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgContenidoZip.Location = new Point(6, 21);
            dtgContenidoZip.Name = "dtgContenidoZip";
            dtgContenidoZip.RowTemplate.Height = 25;
            dtgContenidoZip.Size = new Size(552, 297);
            dtgContenidoZip.TabIndex = 0;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(587, 499);
            Controls.Add(groupBox1);
            Controls.Add(gprInformacion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgContenidoZip).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gprInformacion;
        private GroupBox groupBox1;
        private DataGridView dtgContenidoZip;
    }
}