namespace FatecPresenca
{
    partial class frmEventos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblNomeEvento = new Label();
            btnExcluir = new Button();
            btnAlterar = new Button();
            btnInserir = new Button();
            dgvDadosRegistro = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colDescricao = new DataGridViewTextBoxColumn();
            clmDataInicio = new DataGridViewTextBoxColumn();
            clmDataFinal = new DataGridViewTextBoxColumn();
            lblDescricao = new Label();
            label2 = new Label();
            lblStatus = new Label();
            lblHorarioEntrada = new Label();
            label5 = new Label();
            lblHorarioSaida = new Label();
            label7 = new Label();
            btnConcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).BeginInit();
            SuspendLayout();
            // 
            // lblNomeEvento
            // 
            lblNomeEvento.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeEvento.ForeColor = Color.White;
            lblNomeEvento.Location = new Point(460, 9);
            lblNomeEvento.Name = "lblNomeEvento";
            lblNomeEvento.Size = new Size(429, 46);
            lblNomeEvento.TabIndex = 3;
            lblNomeEvento.Text = "EVENTO";
            lblNomeEvento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.White;
            btnExcluir.FlatAppearance.BorderColor = Color.Black;
            btnExcluir.FlatAppearance.BorderSize = 3;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.Black;
            btnExcluir.Location = new Point(24, 23);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(209, 53);
            btnExcluir.TabIndex = 12;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.White;
            btnAlterar.FlatAppearance.BorderColor = Color.Black;
            btnAlterar.FlatAppearance.BorderSize = 3;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAlterar.ForeColor = Color.Black;
            btnAlterar.Location = new Point(24, 82);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(209, 53);
            btnAlterar.TabIndex = 13;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnInserir
            // 
            btnInserir.BackColor = Color.White;
            btnInserir.FlatAppearance.BorderColor = Color.Black;
            btnInserir.FlatAppearance.BorderSize = 3;
            btnInserir.FlatStyle = FlatStyle.Flat;
            btnInserir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInserir.ForeColor = Color.Black;
            btnInserir.Location = new Point(24, 141);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(209, 53);
            btnInserir.TabIndex = 14;
            btnInserir.Text = "Cadastro";
            btnInserir.UseVisualStyleBackColor = false;
            btnInserir.Click += btnInserir_Click;
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
            dgvDadosRegistro.Columns.AddRange(new DataGridViewColumn[] { colName, colDescricao, clmDataInicio, clmDataFinal });
            dgvDadosRegistro.Location = new Point(12, 229);
            dgvDadosRegistro.Name = "dgvDadosRegistro";
            dgvDadosRegistro.ReadOnly = true;
            dgvDadosRegistro.RowHeadersWidth = 52;
            dgvDadosRegistro.Size = new Size(877, 299);
            dgvDadosRegistro.TabIndex = 15;
            dgvDadosRegistro.CellClick += dgvDadosRegistro_CellClick;
            dgvDadosRegistro.CellContentClick += dgvDadosRegistro_CellContentClick;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.HeaderText = "Nome";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colDescricao
            // 
            colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescricao.HeaderText = "Descricao";
            colDescricao.MinimumWidth = 6;
            colDescricao.Name = "colDescricao";
            colDescricao.ReadOnly = true;
            // 
            // clmDataInicio
            // 
            clmDataInicio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmDataInicio.HeaderText = "Data Início";
            clmDataInicio.MinimumWidth = 6;
            clmDataInicio.Name = "clmDataInicio";
            clmDataInicio.ReadOnly = true;
            // 
            // clmDataFinal
            // 
            clmDataFinal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmDataFinal.HeaderText = "Data Final";
            clmDataFinal.MinimumWidth = 6;
            clmDataFinal.Name = "clmDataFinal";
            clmDataFinal.ReadOnly = true;
            // 
            // lblDescricao
            // 
            lblDescricao.BackColor = Color.Transparent;
            lblDescricao.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescricao.ForeColor = Color.White;
            lblDescricao.Location = new Point(460, 56);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(429, 35);
            lblDescricao.TabIndex = 16;
            lblDescricao.Text = "DESCRIÇÃO DO EVENTO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(460, 91);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 17;
            label2.Text = "Status:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(525, 91);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(61, 20);
            lblStatus.TabIndex = 18;
            lblStatus.Text = "Inativo";
            // 
            // lblHorarioEntrada
            // 
            lblHorarioEntrada.AutoSize = true;
            lblHorarioEntrada.BackColor = Color.Transparent;
            lblHorarioEntrada.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHorarioEntrada.ForeColor = Color.White;
            lblHorarioEntrada.Location = new Point(536, 159);
            lblHorarioEntrada.Name = "lblHorarioEntrada";
            lblHorarioEntrada.Size = new Size(50, 20);
            lblHorarioEntrada.TabIndex = 22;
            lblHorarioEntrada.Text = "00:00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(460, 159);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 21;
            label5.Text = "Entrada:";
            // 
            // lblHorarioSaida
            // 
            lblHorarioSaida.AutoSize = true;
            lblHorarioSaida.BackColor = Color.Transparent;
            lblHorarioSaida.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHorarioSaida.ForeColor = Color.White;
            lblHorarioSaida.Location = new Point(536, 179);
            lblHorarioSaida.Name = "lblHorarioSaida";
            lblHorarioSaida.Size = new Size(50, 20);
            lblHorarioSaida.TabIndex = 24;
            lblHorarioSaida.Text = "00:00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(460, 179);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 23;
            label7.Text = "Saída:";
            // 
            // btnConcluir
            // 
            btnConcluir.BackColor = Color.White;
            btnConcluir.FlatAppearance.BorderColor = Color.Black;
            btnConcluir.FlatAppearance.BorderSize = 3;
            btnConcluir.FlatStyle = FlatStyle.Flat;
            btnConcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConcluir.ForeColor = Color.Black;
            btnConcluir.Location = new Point(680, 535);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(209, 53);
            btnConcluir.TabIndex = 26;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = false;
            btnConcluir.Click += btnConcluir_Click;
            // 
            // frmEventos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(918, 600);
            Controls.Add(btnConcluir);
            Controls.Add(lblHorarioSaida);
            Controls.Add(label7);
            Controls.Add(lblHorarioEntrada);
            Controls.Add(label5);
            Controls.Add(lblStatus);
            Controls.Add(label2);
            Controls.Add(lblDescricao);
            Controls.Add(dgvDadosRegistro);
            Controls.Add(btnInserir);
            Controls.Add(btnAlterar);
            Controls.Add(btnExcluir);
            Controls.Add(lblNomeEvento);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmEventos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNomeEvento;
        private Button btnExcluir;
        private Button btnAlterar;
        private Button btnInserir;
        private DataGridView dgvDadosRegistro;
        private DataGridViewTextBoxColumn clmSemestre;
        private DataGridViewTextBoxColumn clmStatusEntrada;
        private DataGridViewTextBoxColumn clmStatusSaida;
        private Label lblDescricao;
        private Label label2;
        private Label lblStatus;
        private Label label3;
        private Label lblHorarioEntrada;
        private Label label5;
        private Label lblHorarioSaida;
        private Label label7;
        private Button btnConcluir;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescricao;
        private DataGridViewTextBoxColumn clmDataInicio;
        private DataGridViewTextBoxColumn clmDataFinal;
    }
}