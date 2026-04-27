namespace FatecPresenca.Presenca
{
    partial class frmInserirAluno
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
            txtNome = new TextBox();
            label1 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            dgvDadosRegistro = new DataGridView();
            clmName = new DataGridViewTextBoxColumn();
            clmEmail = new DataGridViewTextBoxColumn();
            btnCancelar = new Button();
            btnCadastrar = new Button();
            btnInserir = new Button();
            btnExportarDados = new Button();
            btnAlterar = new Button();
            btnDeletar = new Button();
            btnLimpar = new Button();
            txtPesquisar = new TextBox();
            label5 = new Label();
            btnVerificarDados = new Button();
            label = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).BeginInit();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.White;
            txtNome.BorderStyle = BorderStyle.None;
            txtNome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtNome.ForeColor = Color.Black;
            txtNome.Location = new Point(12, 173);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(310, 25);
            txtNome.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 150);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 20;
            label1.Text = "Nome:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(12, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(310, 25);
            txtEmail.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 214);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 22;
            label2.Text = "Email:";
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
            dgvDadosRegistro.Columns.AddRange(new DataGridViewColumn[] { clmName, clmEmail });
            dgvDadosRegistro.Location = new Point(12, 400);
            dgvDadosRegistro.Name = "dgvDadosRegistro";
            dgvDadosRegistro.ReadOnly = true;
            dgvDadosRegistro.RowHeadersWidth = 52;
            dgvDadosRegistro.Size = new Size(800, 262);
            dgvDadosRegistro.TabIndex = 31;
            dgvDadosRegistro.CellClick += dgvDadosRegistro_CellClick;
            // 
            // clmName
            // 
            clmName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmName.HeaderText = "Nome";
            clmName.MinimumWidth = 6;
            clmName.Name = "clmName";
            clmName.ReadOnly = true;
            // 
            // clmEmail
            // 
            clmEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmEmail.HeaderText = "Email";
            clmEmail.MinimumWidth = 6;
            clmEmail.Name = "clmEmail";
            clmEmail.ReadOnly = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.Black;
            btnCancelar.FlatAppearance.BorderSize = 3;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(12, 692);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 53);
            btnCancelar.TabIndex = 33;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.White;
            btnCadastrar.FlatAppearance.BorderColor = Color.Black;
            btnCadastrar.FlatAppearance.BorderSize = 3;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Location = new Point(672, 692);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(140, 53);
            btnCadastrar.TabIndex = 34;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnInserir
            // 
            btnInserir.BackColor = Color.White;
            btnInserir.FlatAppearance.BorderColor = Color.Black;
            btnInserir.FlatAppearance.BorderSize = 3;
            btnInserir.FlatStyle = FlatStyle.Flat;
            btnInserir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInserir.ForeColor = Color.Black;
            btnInserir.Location = new Point(623, 223);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(189, 53);
            btnInserir.TabIndex = 35;
            btnInserir.Text = "Inserir";
            btnInserir.UseVisualStyleBackColor = false;
            btnInserir.Click += btnInserir_Click;
            // 
            // btnExportarDados
            // 
            btnExportarDados.BackColor = Color.White;
            btnExportarDados.FlatAppearance.BorderColor = Color.Black;
            btnExportarDados.FlatAppearance.BorderSize = 3;
            btnExportarDados.FlatStyle = FlatStyle.Flat;
            btnExportarDados.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExportarDados.ForeColor = Color.Black;
            btnExportarDados.Location = new Point(623, 12);
            btnExportarDados.Name = "btnExportarDados";
            btnExportarDados.Size = new Size(189, 53);
            btnExportarDados.TabIndex = 36;
            btnExportarDados.Text = "Exportar Dados";
            btnExportarDados.UseVisualStyleBackColor = false;
            btnExportarDados.Click += btnExportarDados_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.White;
            btnAlterar.FlatAppearance.BorderColor = Color.Black;
            btnAlterar.FlatAppearance.BorderSize = 3;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAlterar.ForeColor = Color.Black;
            btnAlterar.Location = new Point(623, 164);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(189, 53);
            btnAlterar.TabIndex = 37;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnDeletar
            // 
            btnDeletar.BackColor = Color.White;
            btnDeletar.FlatAppearance.BorderColor = Color.Black;
            btnDeletar.FlatAppearance.BorderSize = 3;
            btnDeletar.FlatStyle = FlatStyle.Flat;
            btnDeletar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDeletar.ForeColor = Color.Black;
            btnDeletar.Location = new Point(623, 105);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(189, 53);
            btnDeletar.TabIndex = 38;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = false;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.White;
            btnLimpar.FlatAppearance.BorderColor = Color.Black;
            btnLimpar.FlatAppearance.BorderSize = 3;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.Black;
            btnLimpar.Location = new Point(12, 338);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(189, 42);
            btnLimpar.TabIndex = 39;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.BackColor = Color.White;
            txtPesquisar.BorderStyle = BorderStyle.None;
            txtPesquisar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtPesquisar.ForeColor = Color.Black;
            txtPesquisar.Location = new Point(623, 355);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(189, 25);
            txtPesquisar.TabIndex = 40;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(623, 332);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 42;
            label5.Text = "Procurar:";
            // 
            // btnVerificarDados
            // 
            btnVerificarDados.BackColor = Color.White;
            btnVerificarDados.FlatAppearance.BorderColor = Color.Black;
            btnVerificarDados.FlatAppearance.BorderSize = 3;
            btnVerificarDados.FlatStyle = FlatStyle.Flat;
            btnVerificarDados.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnVerificarDados.ForeColor = Color.Black;
            btnVerificarDados.Location = new Point(472, 692);
            btnVerificarDados.Name = "btnVerificarDados";
            btnVerificarDados.Size = new Size(183, 53);
            btnVerificarDados.TabIndex = 43;
            btnVerificarDados.Text = "Verificar Dados";
            btnVerificarDados.UseVisualStyleBackColor = false;
            btnVerificarDados.Click += btnVerificarDados_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.ForeColor = Color.White;
            label.Location = new Point(12, 12);
            label.Name = "label";
            label.Size = new Size(383, 46);
            label.TabIndex = 44;
            label.Text = "CADASTRAR ALUNOS";
            // 
            // frmInserirAluno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(837, 766);
            Controls.Add(label);
            Controls.Add(btnVerificarDados);
            Controls.Add(label5);
            Controls.Add(txtPesquisar);
            Controls.Add(btnLimpar);
            Controls.Add(btnDeletar);
            Controls.Add(btnAlterar);
            Controls.Add(btnExportarDados);
            Controls.Add(btnInserir);
            Controls.Add(btnCadastrar);
            Controls.Add(btnCancelar);
            Controls.Add(dgvDadosRegistro);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmInserirAluno";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private Label label1;
        private TextBox txtEmail;
        private Label label2;
        private DataGridView dgvDadosRegistro;
        private Button btnCancelar;
        private Button btnCadastrar;
        private Button btnInserir;
        private Button btnExportarDados;
        private Button btnAlterar;
        private Button btnDeletar;
        private Button btnLimpar;
        private TextBox txtPesquisar;
        private Label label5;
        private Button btnVerificarDados;
        private Label label;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewTextBoxColumn clmEmail;
    }
}