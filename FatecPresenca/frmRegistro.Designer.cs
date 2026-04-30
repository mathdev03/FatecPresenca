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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            dgvDadosRegistro = new DataGridView();
            clmName = new DataGridViewTextBoxColumn();
            clmHorarioEntrada = new DataGridViewTextBoxColumn();
            clmHorarioSaida = new DataGridViewTextBoxColumn();
            lblStatusDigital = new Label();
            btnIniciarIdent = new Button();
            btnPararIdent = new Button();
            panel1 = new Panel();
            lblNomeAluno = new Label();
            label3 = new Label();
            lblStatusPresenca = new Label();
            btnConcluir = new Button();
            btnManual = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(121, 12);
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
            dgvDadosRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvDadosRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDadosRegistro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDadosRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDadosRegistro.Columns.AddRange(new DataGridViewColumn[] { clmName, clmHorarioEntrada, clmHorarioSaida });
            dgvDadosRegistro.Location = new Point(673, 12);
            dgvDadosRegistro.Name = "dgvDadosRegistro";
            dgvDadosRegistro.ReadOnly = true;
            dgvDadosRegistro.RowHeadersVisible = false;
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
            lblStatusDigital.Location = new Point(22, 294);
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
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblNomeAluno);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblStatusPresenca);
            panel1.Location = new Point(12, 550);
            panel1.Name = "panel1";
            panel1.Size = new Size(613, 199);
            panel1.TabIndex = 43;
            // 
            // lblNomeAluno
            // 
            lblNomeAluno.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeAluno.ForeColor = Color.Black;
            lblNomeAluno.Location = new Point(102, 100);
            lblNomeAluno.Name = "lblNomeAluno";
            lblNomeAluno.Size = new Size(508, 95);
            lblNomeAluno.TabIndex = 46;
            lblNomeAluno.Text = "ALUNO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(3, 101);
            label3.Name = "label3";
            label3.Size = new Size(101, 35);
            label3.TabIndex = 45;
            label3.Text = "NOME:";
            // 
            // lblStatusPresenca
            // 
            lblStatusPresenca.Font = new Font("Segoe UI Black", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusPresenca.ForeColor = Color.Green;
            lblStatusPresenca.Location = new Point(10, 18);
            lblStatusPresenca.Name = "lblStatusPresenca";
            lblStatusPresenca.Size = new Size(451, 46);
            lblStatusPresenca.TabIndex = 44;
            lblStatusPresenca.Text = "REGISTRO SUCESSO: 08:12:10";
            lblStatusPresenca.TextAlign = ContentAlignment.MiddleLeft;
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
        private Label lblStatusDigital;
        private Button btnIniciarIdent;
        private Button btnPararIdent;
        private Panel panel1;
        private Label lblStatusPresenca;
        private Label lblNomeAluno;
        private Label label3;
        private Button btnConcluir;
        private Button btnManual;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewTextBoxColumn clmHorarioEntrada;
        private DataGridViewTextBoxColumn clmHorarioSaida;
    }
}