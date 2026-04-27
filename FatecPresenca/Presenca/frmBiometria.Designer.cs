namespace FatecPresenca.Presenca
{
    partial class frmBiometria
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
            label3 = new Label();
            label4 = new Label();
            lblStatus = new Label();
            lblNomeAluno = new Label();
            cmbPosicaoDedo = new ComboBox();
            label1 = new Label();
            picCapturaUm = new PictureBox();
            picCapturaDois = new PictureBox();
            picCapturaTres = new PictureBox();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblQualidadeUm = new Label();
            lblQualidadeDois = new Label();
            lblQualidadeTres = new Label();
            btnCapturaUm = new Button();
            btnCapturaDois = new Button();
            btnCapturaTres = new Button();
            btnConcluir = new Button();
            btnCadastrar = new Button();
            btnVerificar = new Button();
            ((System.ComponentModel.ISupportInitialize)picCapturaUm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCapturaDois).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCapturaTres).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(419, 127);
            label3.Name = "label3";
            label3.Size = new Size(153, 46);
            label3.TabIndex = 4;
            label3.Text = "STATUS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(385, 184);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 17;
            label4.Text = "Biometria:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(502, 184);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(113, 25);
            lblStatus.TabIndex = 18;
            lblStatus.Text = "COLETADA";
            // 
            // lblNomeAluno
            // 
            lblNomeAluno.AutoSize = true;
            lblNomeAluno.Font = new Font("Segoe UI Black", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeAluno.ForeColor = Color.White;
            lblNomeAluno.Location = new Point(21, 29);
            lblNomeAluno.Name = "lblNomeAluno";
            lblNomeAluno.Size = new Size(410, 40);
            lblNomeAluno.TabIndex = 19;
            lblNomeAluno.Text = "MATHEUS YUJI SETOGUCHI";
            // 
            // cmbPosicaoDedo
            // 
            cmbPosicaoDedo.Anchor = AnchorStyles.Right;
            cmbPosicaoDedo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosicaoDedo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cmbPosicaoDedo.FormattingEnabled = true;
            cmbPosicaoDedo.Items.AddRange(new object[] { "Polegar Direito", "Indicador Direito", "Anelar Direito", "Médio Direito", "Minimo Direito", "Polegar Esquerdo", "Indicador Esquerdo", "Anelar Esquerdo", "Médio Esquerdo", "Minimo Esquerdo" });
            cmbPosicaoDedo.Location = new Point(741, 241);
            cmbPosicaoDedo.Name = "cmbPosicaoDedo";
            cmbPosicaoDedo.Size = new Size(261, 28);
            cmbPosicaoDedo.TabIndex = 29;
            cmbPosicaoDedo.Tag = "";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(795, 210);
            label1.Name = "label1";
            label1.Size = new Size(146, 28);
            label1.TabIndex = 30;
            label1.Text = "Posição Dedo";
            // 
            // picCapturaUm
            // 
            picCapturaUm.BackColor = Color.White;
            picCapturaUm.Location = new Point(141, 386);
            picCapturaUm.Name = "picCapturaUm";
            picCapturaUm.Size = new Size(206, 222);
            picCapturaUm.SizeMode = PictureBoxSizeMode.StretchImage;
            picCapturaUm.TabIndex = 31;
            picCapturaUm.TabStop = false;
            // 
            // picCapturaDois
            // 
            picCapturaDois.BackColor = Color.White;
            picCapturaDois.Location = new Point(409, 386);
            picCapturaDois.Name = "picCapturaDois";
            picCapturaDois.Size = new Size(206, 222);
            picCapturaDois.SizeMode = PictureBoxSizeMode.StretchImage;
            picCapturaDois.TabIndex = 32;
            picCapturaDois.TabStop = false;
            // 
            // picCapturaTres
            // 
            picCapturaTres.BackColor = Color.White;
            picCapturaTres.Location = new Point(664, 386);
            picCapturaTres.Name = "picCapturaTres";
            picCapturaTres.Size = new Size(206, 222);
            picCapturaTres.SizeMode = PictureBoxSizeMode.StretchImage;
            picCapturaTres.TabIndex = 33;
            picCapturaTres.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(154, 344);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 34;
            label2.Text = "Qualidade:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(435, 344);
            label5.Name = "label5";
            label5.Size = new Size(114, 25);
            label5.TabIndex = 35;
            label5.Text = "Qualidade:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(673, 344);
            label6.Name = "label6";
            label6.Size = new Size(114, 25);
            label6.TabIndex = 36;
            label6.Text = "Qualidade:";
            // 
            // lblQualidadeUm
            // 
            lblQualidadeUm.AutoSize = true;
            lblQualidadeUm.BackColor = Color.Transparent;
            lblQualidadeUm.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblQualidadeUm.ForeColor = Color.White;
            lblQualidadeUm.Location = new Point(263, 344);
            lblQualidadeUm.Name = "lblQualidadeUm";
            lblQualidadeUm.Size = new Size(60, 25);
            lblQualidadeUm.TabIndex = 37;
            lblQualidadeUm.Text = "100%";
            // 
            // lblQualidadeDois
            // 
            lblQualidadeDois.AutoSize = true;
            lblQualidadeDois.BackColor = Color.Transparent;
            lblQualidadeDois.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblQualidadeDois.ForeColor = Color.White;
            lblQualidadeDois.Location = new Point(543, 344);
            lblQualidadeDois.Name = "lblQualidadeDois";
            lblQualidadeDois.Size = new Size(60, 25);
            lblQualidadeDois.TabIndex = 38;
            lblQualidadeDois.Text = "100%";
            // 
            // lblQualidadeTres
            // 
            lblQualidadeTres.AutoSize = true;
            lblQualidadeTres.BackColor = Color.Transparent;
            lblQualidadeTres.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblQualidadeTres.ForeColor = Color.White;
            lblQualidadeTres.Location = new Point(782, 344);
            lblQualidadeTres.Name = "lblQualidadeTres";
            lblQualidadeTres.Size = new Size(60, 25);
            lblQualidadeTres.TabIndex = 39;
            lblQualidadeTres.Text = "100%";
            // 
            // btnCapturaUm
            // 
            btnCapturaUm.BackColor = Color.White;
            btnCapturaUm.FlatAppearance.BorderColor = Color.Black;
            btnCapturaUm.FlatAppearance.BorderSize = 3;
            btnCapturaUm.FlatStyle = FlatStyle.Flat;
            btnCapturaUm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCapturaUm.ForeColor = Color.Black;
            btnCapturaUm.Location = new Point(154, 628);
            btnCapturaUm.Name = "btnCapturaUm";
            btnCapturaUm.Size = new Size(169, 53);
            btnCapturaUm.TabIndex = 40;
            btnCapturaUm.Text = "1° Captura";
            btnCapturaUm.UseVisualStyleBackColor = false;
            btnCapturaUm.Click += btnCapturaUm_Click;
            // 
            // btnCapturaDois
            // 
            btnCapturaDois.BackColor = Color.White;
            btnCapturaDois.FlatAppearance.BorderColor = Color.Black;
            btnCapturaDois.FlatAppearance.BorderSize = 3;
            btnCapturaDois.FlatStyle = FlatStyle.Flat;
            btnCapturaDois.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCapturaDois.ForeColor = Color.Black;
            btnCapturaDois.Location = new Point(434, 628);
            btnCapturaDois.Name = "btnCapturaDois";
            btnCapturaDois.Size = new Size(169, 53);
            btnCapturaDois.TabIndex = 41;
            btnCapturaDois.Text = "2° Captura";
            btnCapturaDois.UseVisualStyleBackColor = false;
            btnCapturaDois.Click += btnCapturaDois_Click;
            // 
            // btnCapturaTres
            // 
            btnCapturaTres.BackColor = Color.White;
            btnCapturaTres.FlatAppearance.BorderColor = Color.Black;
            btnCapturaTres.FlatAppearance.BorderSize = 3;
            btnCapturaTres.FlatStyle = FlatStyle.Flat;
            btnCapturaTres.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCapturaTres.ForeColor = Color.Black;
            btnCapturaTres.Location = new Point(685, 628);
            btnCapturaTres.Name = "btnCapturaTres";
            btnCapturaTres.Size = new Size(169, 53);
            btnCapturaTres.TabIndex = 42;
            btnCapturaTres.Text = "3° Captura";
            btnCapturaTres.UseVisualStyleBackColor = false;
            btnCapturaTres.Click += btnCapturaTres_Click;
            // 
            // btnConcluir
            // 
            btnConcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConcluir.BackColor = Color.White;
            btnConcluir.FlatAppearance.BorderColor = Color.Black;
            btnConcluir.FlatAppearance.BorderSize = 3;
            btnConcluir.FlatStyle = FlatStyle.Flat;
            btnConcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConcluir.ForeColor = Color.Black;
            btnConcluir.Location = new Point(854, 741);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(169, 53);
            btnConcluir.TabIndex = 43;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = false;
            btnConcluir.Click += btnConcluir_Click;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.White;
            btnCadastrar.FlatAppearance.BorderColor = Color.Black;
            btnCadastrar.FlatAppearance.BorderSize = 3;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Location = new Point(664, 741);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(169, 53);
            btnCadastrar.TabIndex = 44;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnVerificar
            // 
            btnVerificar.BackColor = Color.White;
            btnVerificar.FlatAppearance.BorderColor = Color.Black;
            btnVerificar.FlatAppearance.BorderSize = 3;
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnVerificar.ForeColor = Color.Black;
            btnVerificar.Location = new Point(489, 741);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(169, 53);
            btnVerificar.TabIndex = 45;
            btnVerificar.Text = "Verificar";
            btnVerificar.UseVisualStyleBackColor = false;
            btnVerificar.Click += btnVerificar_Click;
            // 
            // frmBiometria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1035, 806);
            Controls.Add(btnVerificar);
            Controls.Add(btnCadastrar);
            Controls.Add(btnConcluir);
            Controls.Add(btnCapturaTres);
            Controls.Add(btnCapturaDois);
            Controls.Add(btnCapturaUm);
            Controls.Add(lblQualidadeTres);
            Controls.Add(lblQualidadeDois);
            Controls.Add(lblQualidadeUm);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(picCapturaTres);
            Controls.Add(picCapturaDois);
            Controls.Add(picCapturaUm);
            Controls.Add(label1);
            Controls.Add(cmbPosicaoDedo);
            Controls.Add(lblNomeAluno);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmBiometria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ((System.ComponentModel.ISupportInitialize)picCapturaUm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCapturaDois).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCapturaTres).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label4;
        private Label lblStatus;
        private Label lblNomeAluno;
        private ComboBox cmbPosicaoDedo;
        private Label label1;
        private PictureBox picCapturaUm;
        private PictureBox picCapturaDois;
        private PictureBox picCapturaTres;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label lblQualidadeUm;
        private Label lblQualidadeDois;
        private Label lblQualidadeTres;
        private Button btnCapturaUm;
        private Button btnCapturaDois;
        private Button btnCapturaTres;
        private Button btnConcluir;
        private Button btnCadastrar;
        private Button btnVerificar;
    }
}