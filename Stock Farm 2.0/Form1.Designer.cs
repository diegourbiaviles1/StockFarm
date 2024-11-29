namespace Stock_Farm_2._0
{
    partial class StockFarm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockFarm));
            this.grpInventario = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpInformacion = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSubirImagen = new System.Windows.Forms.Button();
            this.cmbRaza = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdHembra = new System.Windows.Forms.RadioButton();
            this.rdMacho = new System.Windows.Forms.RadioButton();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDesparacitada = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerVacuna = new System.Windows.Forms.DateTimePicker();
            this.chkDesparacitada = new System.Windows.Forms.CheckBox();
            this.chkVacuna = new System.Windows.Forms.CheckBox();
            this.dateTimePickerBorn = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArete = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grpArchivo = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionDeGanadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpArchivo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInventario
            // 
            this.grpInventario.Controls.Add(this.dataGridView1);
            this.grpInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInventario.Location = new System.Drawing.Point(18, 605);
            this.grpInventario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInventario.Name = "grpInventario";
            this.grpInventario.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInventario.Size = new System.Drawing.Size(1522, 425);
            this.grpInventario.TabIndex = 0;
            this.grpInventario.TabStop = false;
            this.grpInventario.Text = "Inventario";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1504, 386);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // grpInformacion
            // 
            this.grpInformacion.Controls.Add(this.pictureBox1);
            this.grpInformacion.Controls.Add(this.btnSubirImagen);
            this.grpInformacion.Controls.Add(this.cmbRaza);
            this.grpInformacion.Controls.Add(this.label4);
            this.grpInformacion.Controls.Add(this.groupBox1);
            this.grpInformacion.Controls.Add(this.txtPeso);
            this.grpInformacion.Controls.Add(this.label3);
            this.grpInformacion.Controls.Add(this.dateTimePickerDesparacitada);
            this.grpInformacion.Controls.Add(this.dateTimePickerVacuna);
            this.grpInformacion.Controls.Add(this.chkDesparacitada);
            this.grpInformacion.Controls.Add(this.chkVacuna);
            this.grpInformacion.Controls.Add(this.dateTimePickerBorn);
            this.grpInformacion.Controls.Add(this.label2);
            this.grpInformacion.Controls.Add(this.txtArete);
            this.grpInformacion.Controls.Add(this.label1);
            this.grpInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInformacion.Location = new System.Drawing.Point(18, 68);
            this.grpInformacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInformacion.Name = "grpInformacion";
            this.grpInformacion.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInformacion.Size = new System.Drawing.Size(1364, 528);
            this.grpInformacion.TabIndex = 1;
            this.grpInformacion.TabStop = false;
            this.grpInformacion.Text = "Información";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1029, 129);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnSubirImagen
            // 
            this.btnSubirImagen.Location = new System.Drawing.Point(1096, 432);
            this.btnSubirImagen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubirImagen.Name = "btnSubirImagen";
            this.btnSubirImagen.Size = new System.Drawing.Size(166, 35);
            this.btnSubirImagen.TabIndex = 13;
            this.btnSubirImagen.Text = "Subir Imagen";
            this.btnSubirImagen.UseVisualStyleBackColor = true;
            this.btnSubirImagen.Click += new System.EventHandler(this.btnSubirImagen_Click);
            // 
            // cmbRaza
            // 
            this.cmbRaza.FormattingEnabled = true;
            this.cmbRaza.Items.AddRange(new object[] {
            "Brahman",
            "Gyr",
            "Indu Brasil",
            "Pardo Suizo",
            "Gyrolando",
            "Jersey",
            "Guzerat",
            "Nelore"});
            this.cmbRaza.Location = new System.Drawing.Point(102, 125);
            this.cmbRaza.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRaza.Name = "cmbRaza";
            this.cmbRaza.Size = new System.Drawing.Size(180, 30);
            this.cmbRaza.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Raza:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdHembra);
            this.groupBox1.Controls.Add(this.rdMacho);
            this.groupBox1.Location = new System.Drawing.Point(30, 385);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(510, 74);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sexo";
            // 
            // rdHembra
            // 
            this.rdHembra.AutoSize = true;
            this.rdHembra.Location = new System.Drawing.Point(310, 29);
            this.rdHembra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdHembra.Name = "rdHembra";
            this.rdHembra.Size = new System.Drawing.Size(104, 26);
            this.rdHembra.TabIndex = 1;
            this.rdHembra.TabStop = true;
            this.rdHembra.Text = "Hembra";
            this.rdHembra.UseVisualStyleBackColor = true;
            // 
            // rdMacho
            // 
            this.rdMacho.AutoSize = true;
            this.rdMacho.Location = new System.Drawing.Point(98, 29);
            this.rdMacho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdMacho.Name = "rdMacho";
            this.rdMacho.Size = new System.Drawing.Size(93, 26);
            this.rdMacho.TabIndex = 0;
            this.rdMacho.TabStop = true;
            this.rdMacho.Text = "Macho";
            this.rdMacho.UseVisualStyleBackColor = true;
            this.rdMacho.CheckedChanged += new System.EventHandler(this.rdMacho_CheckedChanged);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(128, 474);
            this.txtPeso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(148, 28);
            this.txtPeso.TabIndex = 9;
            this.txtPeso.TextChanged += new System.EventHandler(this.txtPeso_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 478);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Peso KG:";
            // 
            // dateTimePickerDesparacitada
            // 
            this.dateTimePickerDesparacitada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDesparacitada.Location = new System.Drawing.Point(370, 323);
            this.dateTimePickerDesparacitada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDesparacitada.Name = "dateTimePickerDesparacitada";
            this.dateTimePickerDesparacitada.Size = new System.Drawing.Size(150, 28);
            this.dateTimePickerDesparacitada.TabIndex = 7;
            // 
            // dateTimePickerVacuna
            // 
            this.dateTimePickerVacuna.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerVacuna.Location = new System.Drawing.Point(30, 323);
            this.dateTimePickerVacuna.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerVacuna.Name = "dateTimePickerVacuna";
            this.dateTimePickerVacuna.Size = new System.Drawing.Size(150, 28);
            this.dateTimePickerVacuna.TabIndex = 6;
            // 
            // chkDesparacitada
            // 
            this.chkDesparacitada.AutoSize = true;
            this.chkDesparacitada.Location = new System.Drawing.Point(370, 271);
            this.chkDesparacitada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDesparacitada.Name = "chkDesparacitada";
            this.chkDesparacitada.Size = new System.Drawing.Size(165, 26);
            this.chkDesparacitada.TabIndex = 5;
            this.chkDesparacitada.Text = "Desparacitada";
            this.chkDesparacitada.UseVisualStyleBackColor = true;
            // 
            // chkVacuna
            // 
            this.chkVacuna.AutoSize = true;
            this.chkVacuna.Location = new System.Drawing.Point(30, 271);
            this.chkVacuna.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVacuna.Name = "chkVacuna";
            this.chkVacuna.Size = new System.Drawing.Size(103, 26);
            this.chkVacuna.TabIndex = 4;
            this.chkVacuna.Text = "Vacuna";
            this.chkVacuna.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBorn
            // 
            this.dateTimePickerBorn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBorn.Location = new System.Drawing.Point(272, 191);
            this.dateTimePickerBorn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerBorn.Name = "dateTimePickerBorn";
            this.dateTimePickerBorn.Size = new System.Drawing.Size(150, 28);
            this.dateTimePickerBorn.TabIndex = 3;
            this.dateTimePickerBorn.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de Nacimiento:";
            // 
            // txtArete
            // 
            this.txtArete.Location = new System.Drawing.Point(102, 45);
            this.txtArete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArete.Name = "txtArete";
            this.txtArete.Size = new System.Drawing.Size(148, 28);
            this.txtArete.TabIndex = 1;
            this.txtArete.TextChanged += new System.EventHandler(this.txtArete_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arete:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(9, 195);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(112, 35);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(9, 115);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(112, 35);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(9, 46);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(112, 35);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(9, 29);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 35);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(9, 74);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(112, 35);
            this.btnCargar.TabIndex = 6;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grpArchivo
            // 
            this.grpArchivo.Controls.Add(this.btnGuardar);
            this.grpArchivo.Controls.Add(this.btnCargar);
            this.grpArchivo.Location = new System.Drawing.Point(1390, 453);
            this.grpArchivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpArchivo.Name = "grpArchivo";
            this.grpArchivo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpArchivo.Size = new System.Drawing.Size(135, 123);
            this.grpArchivo.TabIndex = 7;
            this.grpArchivo.TabStop = false;
            this.grpArchivo.Text = "Archivo";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGreen;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeGanadoToolStripMenuItem,
            this.busquedaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1544, 33);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionDeGanadoToolStripMenuItem
            // 
            this.gestionDeGanadoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gestionDeGanadoToolStripMenuItem.Name = "gestionDeGanadoToolStripMenuItem";
            this.gestionDeGanadoToolStripMenuItem.Size = new System.Drawing.Size(180, 29);
            this.gestionDeGanadoToolStripMenuItem.Text = "Gestion de Ganado";
            // 
            // busquedaToolStripMenuItem
            // 
            this.busquedaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.busquedaToolStripMenuItem.Name = "busquedaToolStripMenuItem";
            this.busquedaToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.busquedaToolStripMenuItem.Text = "Reportes";
            this.busquedaToolStripMenuItem.Click += new System.EventHandler(this.busquedaToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Location = new System.Drawing.Point(1390, 172);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(135, 271);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro";
            // 
            // StockFarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1544, 1034);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpArchivo);
            this.Controls.Add(this.grpInformacion);
            this.Controls.Add(this.grpInventario);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StockFarm";
            this.Text = "StockFarm";
            this.grpInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpInformacion.ResumeLayout(false);
            this.grpInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpArchivo.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInventario;
        private System.Windows.Forms.GroupBox grpInformacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerBorn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArete;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesparacitada;
        private System.Windows.Forms.DateTimePicker dateTimePickerVacuna;
        private System.Windows.Forms.CheckBox chkDesparacitada;
        private System.Windows.Forms.CheckBox chkVacuna;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdHembra;
        private System.Windows.Forms.RadioButton rdMacho;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbRaza;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox grpArchivo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionDeGanadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSubirImagen;
    }
}

