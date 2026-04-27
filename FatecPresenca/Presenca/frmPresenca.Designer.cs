namespace FatecPresenca.Presenca
{
    partial class frmPresenca
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
            dgvDadosRegistro = new DataGridView();
            clmName = new DataGridViewTextBoxColumn();
            cmlEmail = new DataGridViewTextBoxColumn();
            btnInserir = new Button();
            btnAlterar = new Button();
            btnExcluir = new Button();
            btnBiometria = new Button();
            btnConcluir = new Button();
            txtPesquisar = new TextBox();
            label7 = new Label();
            label = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).BeginInit();
            SuspendLayout();
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
            dgvDadosRegistro.Columns.AddRange(new DataGridViewColumn[] { clmName, cmlEmail });
            dgvDadosRegistro.Location = new Point(33, 306);
            dgvDadosRegistro.Name = "dgvDadosRegistro";
            dgvDadosRegistro.ReadOnly = true;
            dgvDadosRegistro.RowHeadersVisible = false;
            dgvDadosRegistro.RowHeadersWidth = 52;
            dgvDadosRegistro.Size = new Size(968, 331);
            dgvDadosRegistro.TabIndex = 30;
            dgvDadosRegistro.SelectionChanged += dgvDadosRegistro_SelectionChanged;
            // 
            // clmName
            // 
            clmName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmName.HeaderText = "Nome";
            clmName.MinimumWidth = 6;
            clmName.Name = "clmName";
            clmName.ReadOnly = true;
            // 
            // cmlEmail
            // 
            cmlEmail.HeaderText = "Email";
            cmlEmail.MinimumWidth = 6;
            cmlEmail.Name = "cmlEmail";
            cmlEmail.ReadOnly = true;
            // 
            // btnInserir
            // 
            btnInserir.BackColor = Color.White;
            btnInserir.FlatAppearance.BorderColor = Color.Black;
            btnInserir.FlatAppearance.BorderSize = 3;
            btnInserir.FlatStyle = FlatStyle.Flat;
            btnInserir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInserir.ForeColor = Color.Black;
            btnInserir.Location = new Point(33, 200);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(209, 53);
            btnInserir.TabIndex = 29;
            btnInserir.Text = "Cadastro";
            btnInserir.UseVisualStyleBackColor = false;
            btnInserir.Click += btnInserir_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.White;
            btnAlterar.FlatAppearance.BorderColor = Color.Black;
            btnAlterar.FlatAppearance.BorderSize = 3;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAlterar.ForeColor = Color.Black;
            btnAlterar.Location = new Point(33, 141);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(209, 53);
            btnAlterar.TabIndex = 28;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.White;
            btnExcluir.FlatAppearance.BorderColor = Color.Black;
            btnExcluir.FlatAppearance.BorderSize = 3;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.Black;
            btnExcluir.Location = new Point(33, 82);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(209, 53);
            btnExcluir.TabIndex = 27;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnBiometria
            // 
            btnBiometria.BackColor = Color.White;
            btnBiometria.FlatAppearance.BorderColor = Color.Black;
            btnBiometria.FlatAppearance.BorderSize = 3;
            btnBiometria.FlatStyle = FlatStyle.Flat;
            btnBiometria.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBiometria.ForeColor = Color.Black;
            btnBiometria.Location = new Point(656, 12);
            btnBiometria.Name = "btnBiometria";
            btnBiometria.Size = new Size(345, 53);
            btnBiometria.TabIndex = 31;
            btnBiometria.Text = "Biometria";
            btnBiometria.UseVisualStyleBackColor = false;
            btnBiometria.Click += btnBiometria_Click;
            // 
            // btnConcluir
            // 
            btnConcluir.BackColor = Color.White;
            btnConcluir.FlatAppearance.BorderColor = Color.Black;
            btnConcluir.FlatAppearance.BorderSize = 3;
            btnConcluir.FlatStyle = FlatStyle.Flat;
            btnConcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConcluir.ForeColor = Color.Black;
            btnConcluir.Location = new Point(802, 648);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(199, 53);
            btnConcluir.TabIndex = 33;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = false;
            btnConcluir.Click += btnConcluir_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.BackColor = Color.White;
            txtPesquisar.BorderStyle = BorderStyle.None;
            txtPesquisar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtPesquisar.ForeColor = Color.Black;
            txtPesquisar.Location = new Point(808, 261);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(184, 25);
            txtPesquisar.TabIndex = 34;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(808, 233);
            label7.Name = "label7";
            label7.Size = new Size(102, 25);
            label7.TabIndex = 35;
            label7.Text = "Pesquisar";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.ForeColor = Color.White;
            label.Location = new Point(33, 12);
            label.Name = "label";
            label.Size = new Size(362, 46);
            label.TabIndex = 40;
            label.Text = "GESTÃO DE ALUNOS";
            // 
            // frmPresenca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1035, 713);
            Controls.Add(label);
            Controls.Add(label7);
            Controls.Add(txtPesquisar);
            Controls.Add(btnConcluir);
            Controls.Add(btnBiometria);
            Controls.Add(dgvDadosRegistro);
            Controls.Add(btnInserir);
            Controls.Add(btnAlterar);
            Controls.Add(btnExcluir);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPresenca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDadosRegistro;
        private Button btnInserir;
        private Button btnAlterar;
        private Button btnExcluir;
        private Button btnBiometria;
        private Button btnConcluir;
        private TextBox txtPesquisar;
        private Label label7;
        private Label label;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewTextBoxColumn cmlEmail;
    }
}