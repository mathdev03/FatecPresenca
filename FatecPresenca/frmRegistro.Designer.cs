namespace FatecPresenca
{
    partial class frmRegistro
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            dgvDadosRegistro = new DataGridView();
            clmName = new DataGridViewTextBoxColumn();
            clmSemestre = new DataGridViewTextBoxColumn();
            clmHorarioEntrada = new DataGridViewTextBoxColumn();
            clmHorarioSaida = new DataGridViewTextBoxColumn();
            lblStatusDigital = new Label();
            btnIniciarIdent = new Button();
            btnPararIdent = new Button();
            panel1 = new Panel();
            lblSemestreAluno = new Label();
            label5 = new Label();
            lblNomeAluno = new Label();
            label3 = new Label();
            label1 = new Label();
            btnConcluir = new Button();
            btnManual = new Button();
            tmrCaptura = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(111, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 279);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dgvDadosRegistro
            // 
            dgvDadosRegistro.AllowUserToAddRows = false;
            dgvDadosRegistro.AllowUserToDeleteRows = false;
            dgvDadosRegistro.AllowUserToResizeColumns = false;
            dgvDadosRegistro.AllowUserToResizeRows = false;
            dgvDadosRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDadosRegistro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDadosRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDadosRegistro.Columns.AddRange(new DataGridViewColumn[] { clmName, clmSemestre, clmHorarioEntrada, clmHorarioSaida });
            dgvDadosRegistro.Location = new Point(673, 12);
            dgvDadosRegistro.Name = "dgvDadosRegistro";
            dgvDadosRegistro.ReadOnly = true;
            dgvDadosRegistro.RowHeadersWidth = 52;
            dgvDadosRegistro.Size = new Size(644, 591);
            dgvDadosRegistro.TabIndex = 11;
            // 
            // clmName
            // 
            clmName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmName.HeaderText = "Nome";
            clmName.MinimumWidth = 6;
            clmName.Name = "clmName";
            clmName.ReadOnly = true;
            // 
            // clmSemestre
            // 
            clmSemestre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmSemestre.HeaderText = "Semestre";
            clmSemestre.MinimumWidth = 6;
            clmSemestre.Name = "clmSemestre";
            clmSemestre.ReadOnly = true;
            // 
            // clmHorarioEntrada
            // 
            clmHorarioEntrada.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmHorarioEntrada.HeaderText = "Entrada";
            clmHorarioEntrada.MinimumWidth = 6;
            clmHorarioEntrada.Name = "clmHorarioEntrada";
            clmHorarioEntrada.ReadOnly = true;
            // 
            // clmHorarioSaida
            // 
            clmHorarioSaida.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmHorarioSaida.HeaderText = "Saída";
            clmHorarioSaida.MinimumWidth = 6;
            clmHorarioSaida.Name = "clmHorarioSaida";
            clmHorarioSaida.ReadOnly = true;
            // 
            // lblStatusDigital
            // 
            lblStatusDigital.Font = new Font("Segoe UI Black", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusDigital.ForeColor = Color.White;
            lblStatusDigital.Location = new Point(12, 294);
            lblStatusDigital.Name = "lblStatusDigital";
            lblStatusDigital.Size = new Size(442, 46);
            lblStatusDigital.TabIndex = 12;
            lblStatusDigital.Text = "Posicione o Dedo no Sensor";
            lblStatusDigital.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnIniciarIdent
            // 
            btnIniciarIdent.BackColor = Color.White;
            btnIniciarIdent.FlatAppearance.BorderColor = Color.Black;
            btnIniciarIdent.FlatAppearance.BorderSize = 3;
            btnIniciarIdent.FlatStyle = FlatStyle.Flat;
            btnIniciarIdent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIniciarIdent.ForeColor = Color.Black;
            btnIniciarIdent.Location = new Point(124, 362);
            btnIniciarIdent.Name = "btnIniciarIdent";
            btnIniciarIdent.Size = new Size(233, 41);
            btnIniciarIdent.TabIndex = 41;
            btnIniciarIdent.Text = "Iniciar Identificação";
            btnIniciarIdent.UseVisualStyleBackColor = false;
            btnIniciarIdent.Click += btnIniciarIdent_Click;
            // 
            // btnPararIdent
            // 
            btnPararIdent.BackColor = Color.White;
            btnPararIdent.FlatAppearance.BorderColor = Color.Black;
            btnPararIdent.FlatAppearance.BorderSize = 3;
            btnPararIdent.FlatStyle = FlatStyle.Flat;
            btnPararIdent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPararIdent.ForeColor = Color.Black;
            btnPararIdent.Location = new Point(124, 428);
            btnPararIdent.Name = "btnPararIdent";
            btnPararIdent.Size = new Size(233, 41);
            btnPararIdent.TabIndex = 42;
            btnPararIdent.Text = "Parar Identificação";
            btnPararIdent.UseVisualStyleBackColor = false;
            btnPararIdent.Click += btnPararIdent_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblSemestreAluno);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblNomeAluno);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 550);
            panel1.Name = "panel1";
            panel1.Size = new Size(613, 199);
            panel1.TabIndex = 43;
            // 
            // lblSemestreAluno
            // 
            lblSemestreAluno.AutoSize = true;
            lblSemestreAluno.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSemestreAluno.ForeColor = Color.Black;
            lblSemestreAluno.Location = new Point(130, 156);
            lblSemestreAluno.Name = "lblSemestreAluno";
            lblSemestreAluno.Size = new Size(131, 25);
            lblSemestreAluno.TabIndex = 48;
            lblSemestreAluno.Text = "5° SEMESTRE";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(19, 156);
            label5.Name = "label5";
            label5.Size = new Size(105, 25);
            label5.TabIndex = 47;
            label5.Text = "Semestre:";
            // 
            // lblNomeAluno
            // 
            lblNomeAluno.AutoSize = true;
            lblNomeAluno.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeAluno.ForeColor = Color.Black;
            lblNomeAluno.Location = new Point(99, 114);
            lblNomeAluno.Name = "lblNomeAluno";
            lblNomeAluno.Size = new Size(270, 25);
            lblNomeAluno.TabIndex = 46;
            lblNomeAluno.Text = "MATHEUS YUJI SETOGUCHI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(19, 114);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 45;
            label3.Text = "Nome:";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Black", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(19, 17);
            label1.Name = "label1";
            label1.Size = new Size(451, 46);
            label1.TabIndex = 44;
            label1.Text = "REGISTRO SUCESSO: 08:12:10";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnConcluir
            // 
            btnConcluir.BackColor = Color.White;
            btnConcluir.FlatAppearance.BorderColor = Color.Black;
            btnConcluir.FlatAppearance.BorderSize = 3;
            btnConcluir.FlatStyle = FlatStyle.Flat;
            btnConcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConcluir.ForeColor = Color.Black;
            btnConcluir.Location = new Point(1108, 692);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(209, 53);
            btnConcluir.TabIndex = 44;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = false;
            btnConcluir.Click += btnConcluir_Click;
            // 
            // btnManual
            // 
            btnManual.BackColor = Color.White;
            btnManual.FlatAppearance.BorderColor = Color.Black;
            btnManual.FlatAppearance.BorderSize = 3;
            btnManual.FlatStyle = FlatStyle.Flat;
            btnManual.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnManual.ForeColor = Color.Black;
            btnManual.Location = new Point(673, 609);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(196, 43);
            btnManual.TabIndex = 45;
            btnManual.Text = "Manual";
            btnManual.UseVisualStyleBackColor = false;
            // 
            // tmrCaptura
            // 
            tmrCaptura.Interval = 1000;
            tmrCaptura.Tick += tmrCaptura_Tick;
            // 
            // frmRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1329, 761);
            Controls.Add(btnManual);
            Controls.Add(btnConcluir);
            Controls.Add(panel1);
            Controls.Add(btnPararIdent);
            Controls.Add(btnIniciarIdent);
            Controls.Add(lblStatusDigital);
            Controls.Add(dgvDadosRegistro);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvDadosRegistro;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewTextBoxColumn clmSemestre;
        private DataGridViewTextBoxColumn clmHorarioEntrada;
        private DataGridViewTextBoxColumn clmHorarioSaida;
        private Label lblStatusDigital;
        private Button btnIniciarIdent;
        private Button btnPararIdent;
        private Panel panel1;
        private Label label1;
        private Label lblSemestreAluno;
        private Label label5;
        private Label lblNomeAluno;
        private Label label3;
        private Button btnConcluir;
        private Button btnManual;
        private System.Windows.Forms.Timer tmrCaptura;
    }
}