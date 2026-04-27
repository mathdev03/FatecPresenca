namespace FatecPresenca
{
    partial class frmRelatorio
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbEvento = new ComboBox();
            cmbSemestre = new ComboBox();
            dgvDadosRegistro = new DataGridView();
            label4 = new Label();
            lblStatusDigital = new Label();
            clmName = new DataGridViewTextBoxColumn();
            clmSemestre = new DataGridViewTextBoxColumn();
            clmMetodo = new DataGridViewTextBoxColumn();
            clmPontuacao = new DataGridViewTextBoxColumn();
            btnExportar = new Button();
            btnConcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(354, 40);
            label1.TabIndex = 20;
            label1.Text = "RELATÓRIO GERENCIAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(116, 35);
            label2.TabIndex = 21;
            label2.Text = "EVENTO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(306, 99);
            label3.Name = "label3";
            label3.Size = new Size(143, 35);
            label3.TabIndex = 22;
            label3.Text = "SEMESTRE";
            // 
            // cmbEvento
            // 
            cmbEvento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEvento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cmbEvento.FormattingEnabled = true;
            cmbEvento.Items.AddRange(new object[] { "Fatec Aberta" });
            cmbEvento.Location = new Point(12, 137);
            cmbEvento.Name = "cmbEvento";
            cmbEvento.Size = new Size(218, 28);
            cmbEvento.TabIndex = 30;
            cmbEvento.Tag = "";
            // 
            // cmbSemestre
            // 
            cmbSemestre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSemestre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cmbSemestre.FormattingEnabled = true;
            cmbSemestre.Items.AddRange(new object[] { "6° Semestre" });
            cmbSemestre.Location = new Point(306, 137);
            cmbSemestre.Name = "cmbSemestre";
            cmbSemestre.Size = new Size(232, 28);
            cmbSemestre.TabIndex = 31;
            cmbSemestre.Tag = "";
            // 
            // dgvDadosRegistro
            // 
            dgvDadosRegistro.AllowUserToAddRows = false;
            dgvDadosRegistro.AllowUserToDeleteRows = false;
            dgvDadosRegistro.AllowUserToResizeColumns = false;
            dgvDadosRegistro.AllowUserToResizeRows = false;
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
            dgvDadosRegistro.Columns.AddRange(new DataGridViewColumn[] { clmName, clmSemestre, clmMetodo, clmPontuacao });
            dgvDadosRegistro.Location = new Point(12, 238);
            dgvDadosRegistro.Name = "dgvDadosRegistro";
            dgvDadosRegistro.ReadOnly = true;
            dgvDadosRegistro.RowHeadersWidth = 52;
            dgvDadosRegistro.Size = new Size(944, 304);
            dgvDadosRegistro.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 190);
            label4.Name = "label4";
            label4.Size = new Size(195, 35);
            label4.TabIndex = 33;
            label4.Text = "Total de alunos:";
            // 
            // lblStatusDigital
            // 
            lblStatusDigital.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusDigital.ForeColor = Color.White;
            lblStatusDigital.Location = new Point(200, 190);
            lblStatusDigital.Name = "lblStatusDigital";
            lblStatusDigital.Size = new Size(73, 35);
            lblStatusDigital.TabIndex = 34;
            lblStatusDigital.Text = "120";
            lblStatusDigital.TextAlign = ContentAlignment.MiddleCenter;
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
            // clmMetodo
            // 
            clmMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmMetodo.HeaderText = "Método";
            clmMetodo.MinimumWidth = 6;
            clmMetodo.Name = "clmMetodo";
            clmMetodo.ReadOnly = true;
            // 
            // clmPontuacao
            // 
            clmPontuacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmPontuacao.HeaderText = "Pontuação";
            clmPontuacao.MinimumWidth = 6;
            clmPontuacao.Name = "clmPontuacao";
            clmPontuacao.ReadOnly = true;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.White;
            btnExportar.FlatAppearance.BorderColor = Color.Black;
            btnExportar.FlatAppearance.BorderSize = 3;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExportar.ForeColor = Color.Black;
            btnExportar.Location = new Point(12, 548);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(209, 53);
            btnExportar.TabIndex = 35;
            btnExportar.Text = "Exportar Excel";
            btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnConcluir
            // 
            btnConcluir.BackColor = Color.White;
            btnConcluir.FlatAppearance.BorderColor = Color.Black;
            btnConcluir.FlatAppearance.BorderSize = 3;
            btnConcluir.FlatStyle = FlatStyle.Flat;
            btnConcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConcluir.ForeColor = Color.Black;
            btnConcluir.Location = new Point(776, 568);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(180, 50);
            btnConcluir.TabIndex = 36;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = false;
            // 
            // frmRelatorio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(968, 630);
            Controls.Add(btnConcluir);
            Controls.Add(btnExportar);
            Controls.Add(lblStatusDigital);
            Controls.Add(label4);
            Controls.Add(dgvDadosRegistro);
            Controls.Add(cmbSemestre);
            Controls.Add(cmbEvento);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRelatorio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbEvento;
        private ComboBox cmbSemestre;
        private DataGridView dgvDadosRegistro;
        private Label label4;
        private Label lblStatusDigital;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewTextBoxColumn clmSemestre;
        private DataGridViewTextBoxColumn clmMetodo;
        private DataGridViewTextBoxColumn clmPontuacao;
        private Button btnExportar;
        private Button btnConcluir;
    }
}