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
            cmbDataEvento = new ComboBox();
            dgvDadosRegistro = new DataGridView();
            clmName = new DataGridViewTextBoxColumn();
            clmSemestre = new DataGridViewTextBoxColumn();
            clmMetodo = new DataGridViewTextBoxColumn();
            clmPontuacao = new DataGridViewTextBoxColumn();
            label4 = new Label();
            lblStatusAlunos = new Label();
            btnExportar = new Button();
            btnConcluir = new Button();
            label5 = new Label();
            label6 = new Label();
            lblContagemPresentes = new Label();
            lblContagemAusentes = new Label();
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
            label3.Size = new Size(88, 35);
            label3.TabIndex = 22;
            label3.Text = "DATA";
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
            // cmbDataEvento
            // 
            cmbDataEvento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDataEvento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cmbDataEvento.FormattingEnabled = true;
            cmbDataEvento.Items.AddRange(new object[] { "6° Semestre" });
            cmbDataEvento.Location = new Point(306, 137);
            cmbDataEvento.Name = "cmbDataEvento";
            cmbDataEvento.Size = new Size(232, 28);
            cmbDataEvento.TabIndex = 31;
            cmbDataEvento.Tag = "";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 190);
            label4.Name = "label4";
            label4.Size = new Size(237, 35);
            label4.TabIndex = 33;
            label4.Text = "TOTAL DE ALUNOS:";
            // 
            // lblStatusAlunos
            // 
            lblStatusAlunos.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusAlunos.ForeColor = Color.White;
            lblStatusAlunos.Location = new Point(255, 190);
            lblStatusAlunos.Name = "lblStatusAlunos";
            lblStatusAlunos.Size = new Size(73, 35);
            lblStatusAlunos.TabIndex = 34;
            lblStatusAlunos.Text = "120";
            lblStatusAlunos.TextAlign = ContentAlignment.MiddleCenter;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(341, 190);
            label5.Name = "label5";
            label5.Size = new Size(152, 35);
            label5.TabIndex = 37;
            label5.Text = "PRESENTES:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(571, 190);
            label6.Name = "label6";
            label6.Size = new Size(143, 35);
            label6.TabIndex = 38;
            label6.Text = "AUSENTES:";
            // 
            // lblContagemPresentes
            // 
            lblContagemPresentes.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContagemPresentes.ForeColor = Color.White;
            lblContagemPresentes.Location = new Point(499, 190);
            lblContagemPresentes.Name = "lblContagemPresentes";
            lblContagemPresentes.Size = new Size(66, 35);
            lblContagemPresentes.TabIndex = 39;
            lblContagemPresentes.Text = "0";
            lblContagemPresentes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContagemAusentes
            // 
            lblContagemAusentes.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContagemAusentes.ForeColor = Color.White;
            lblContagemAusentes.Location = new Point(720, 190);
            lblContagemAusentes.Name = "lblContagemAusentes";
            lblContagemAusentes.Size = new Size(66, 35);
            lblContagemAusentes.TabIndex = 40;
            lblContagemAusentes.Text = "0";
            lblContagemAusentes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmRelatorio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(968, 630);
            Controls.Add(lblContagemAusentes);
            Controls.Add(lblContagemPresentes);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnConcluir);
            Controls.Add(btnExportar);
            Controls.Add(lblStatusAlunos);
            Controls.Add(label4);
            Controls.Add(dgvDadosRegistro);
            Controls.Add(cmbDataEvento);
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
        private ComboBox cmbDataEvento;
        private DataGridView dgvDadosRegistro;
        private Label label4;
        private Label lblStatusAlunos;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewTextBoxColumn clmSemestre;
        private DataGridViewTextBoxColumn clmMetodo;
        private DataGridViewTextBoxColumn clmPontuacao;
        private Button btnExportar;
        private Button btnConcluir;
        private Label label5;
        private Label label6;
        private Label lblContagemPresentes;
        private Label lblContagemAusentes;
    }
}