namespace FatecPresenca.Eventos
{
    partial class frmAlterarEvento
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
            btnSair = new Button();
            btnAlterar = new Button();
            mtxSaidaFinal = new MaskedTextBox();
            mtxEntradaFinal = new MaskedTextBox();
            mtxSaidaInicio = new MaskedTextBox();
            label8 = new Label();
            mtxEntradaInicio = new MaskedTextBox();
            label9 = new Label();
            label7 = new Label();
            txtDescricao = new TextBox();
            label6 = new Label();
            mtxHorarioFinal = new MaskedTextBox();
            label4 = new Label();
            mtxHorarioInicio = new MaskedTextBox();
            label5 = new Label();
            mtxDataFinal = new MaskedTextBox();
            label3 = new Label();
            mtxDataInicio = new MaskedTextBox();
            label2 = new Label();
            txtTitulo = new TextBox();
            lblTituloJanela = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.White;
            btnSair.FlatAppearance.BorderColor = Color.Black;
            btnSair.FlatAppearance.BorderSize = 3;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSair.ForeColor = Color.Black;
            btnSair.Location = new Point(14, 653);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(144, 41);
            btnSair.TabIndex = 60;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.White;
            btnAlterar.FlatAppearance.BorderColor = Color.Black;
            btnAlterar.FlatAppearance.BorderSize = 3;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAlterar.ForeColor = Color.Black;
            btnAlterar.Location = new Point(243, 641);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(162, 53);
            btnAlterar.TabIndex = 59;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // mtxSaidaFinal
            // 
            mtxSaidaFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxSaidaFinal.Location = new Point(204, 524);
            mtxSaidaFinal.Mask = "00:00";
            mtxSaidaFinal.Name = "mtxSaidaFinal";
            mtxSaidaFinal.Size = new Size(147, 32);
            mtxSaidaFinal.TabIndex = 58;
            mtxSaidaFinal.Tag = "";
            mtxSaidaFinal.ValidatingType = typeof(DateTime);
            // 
            // mtxEntradaFinal
            // 
            mtxEntradaFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxEntradaFinal.Location = new Point(41, 524);
            mtxEntradaFinal.Mask = "00:00";
            mtxEntradaFinal.Name = "mtxEntradaFinal";
            mtxEntradaFinal.Size = new Size(157, 32);
            mtxEntradaFinal.TabIndex = 57;
            mtxEntradaFinal.ValidatingType = typeof(DateTime);
            // 
            // mtxSaidaInicio
            // 
            mtxSaidaInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxSaidaInicio.Location = new Point(204, 486);
            mtxSaidaInicio.Mask = "00:00";
            mtxSaidaInicio.Name = "mtxSaidaInicio";
            mtxSaidaInicio.Size = new Size(147, 32);
            mtxSaidaInicio.TabIndex = 56;
            mtxSaidaInicio.ValidatingType = typeof(DateTime);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(204, 463);
            label8.Name = "label8";
            label8.Size = new Size(137, 20);
            label8.TabIndex = 55;
            label8.Text = "Saída de Captura:";
            // 
            // mtxEntradaInicio
            // 
            mtxEntradaInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxEntradaInicio.Location = new Point(41, 486);
            mtxEntradaInicio.Mask = "00:00";
            mtxEntradaInicio.Name = "mtxEntradaInicio";
            mtxEntradaInicio.Size = new Size(157, 32);
            mtxEntradaInicio.TabIndex = 54;
            mtxEntradaInicio.ValidatingType = typeof(DateTime);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(41, 463);
            label9.Name = "label9";
            label9.Size = new Size(131, 20);
            label9.TabIndex = 53;
            label9.Text = "Entrada Captura:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(41, 421);
            label7.Name = "label7";
            label7.Size = new Size(261, 25);
            label7.TabIndex = 52;
            label7.Text = "Definir Horário de Captura";
            // 
            // txtDescricao
            // 
            txtDescricao.BackColor = Color.White;
            txtDescricao.BorderStyle = BorderStyle.None;
            txtDescricao.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtDescricao.ForeColor = Color.Black;
            txtDescricao.Location = new Point(41, 292);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(310, 107);
            txtDescricao.TabIndex = 51;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(41, 269);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 50;
            label6.Text = "Descrição:";
            // 
            // mtxHorarioFinal
            // 
            mtxHorarioFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxHorarioFinal.Location = new Point(204, 219);
            mtxHorarioFinal.Mask = "00:00";
            mtxHorarioFinal.Name = "mtxHorarioFinal";
            mtxHorarioFinal.Size = new Size(147, 32);
            mtxHorarioFinal.TabIndex = 49;
            mtxHorarioFinal.ValidatingType = typeof(DateTime);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(204, 196);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 48;
            label4.Text = "Horário Final:";
            // 
            // mtxHorarioInicio
            // 
            mtxHorarioInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxHorarioInicio.Location = new Point(41, 219);
            mtxHorarioInicio.Mask = "00:00";
            mtxHorarioInicio.Name = "mtxHorarioInicio";
            mtxHorarioInicio.Size = new Size(157, 32);
            mtxHorarioInicio.TabIndex = 47;
            mtxHorarioInicio.ValidatingType = typeof(DateTime);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(41, 196);
            label5.Name = "label5";
            label5.Size = new Size(118, 20);
            label5.TabIndex = 46;
            label5.Text = "Horário Início:";
            // 
            // mtxDataFinal
            // 
            mtxDataFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxDataFinal.Location = new Point(204, 151);
            mtxDataFinal.Mask = "00/00/0000";
            mtxDataFinal.Name = "mtxDataFinal";
            mtxDataFinal.Size = new Size(147, 32);
            mtxDataFinal.TabIndex = 45;
            mtxDataFinal.ValidatingType = typeof(DateTime);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(204, 128);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 44;
            label3.Text = "Data Final:";
            // 
            // mtxDataInicio
            // 
            mtxDataInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxDataInicio.Location = new Point(41, 151);
            mtxDataInicio.Mask = "00/00/0000";
            mtxDataInicio.Name = "mtxDataInicio";
            mtxDataInicio.Size = new Size(157, 32);
            mtxDataInicio.TabIndex = 43;
            mtxDataInicio.ValidatingType = typeof(DateTime);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(41, 128);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 42;
            label2.Text = "Data Início:";
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.White;
            txtTitulo.BorderStyle = BorderStyle.None;
            txtTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtTitulo.ForeColor = Color.Black;
            txtTitulo.Location = new Point(41, 94);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(310, 25);
            txtTitulo.TabIndex = 41;
            // 
            // lblTituloJanela
            // 
            lblTituloJanela.AutoSize = true;
            lblTituloJanela.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloJanela.ForeColor = Color.White;
            lblTituloJanela.Location = new Point(14, 10);
            lblTituloJanela.Name = "lblTituloJanela";
            lblTituloJanela.Size = new Size(324, 46);
            lblTituloJanela.TabIndex = 40;
            lblTituloJanela.Text = "ALTERAR EVENTO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 71);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 39;
            label1.Text = "Título do Evento:";
            // 
            // frmAlterarEvento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(419, 705);
            Controls.Add(btnSair);
            Controls.Add(btnAlterar);
            Controls.Add(mtxSaidaFinal);
            Controls.Add(mtxEntradaFinal);
            Controls.Add(mtxSaidaInicio);
            Controls.Add(label8);
            Controls.Add(mtxEntradaInicio);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(txtDescricao);
            Controls.Add(label6);
            Controls.Add(mtxHorarioFinal);
            Controls.Add(label4);
            Controls.Add(mtxHorarioInicio);
            Controls.Add(label5);
            Controls.Add(mtxDataFinal);
            Controls.Add(label3);
            Controls.Add(mtxDataInicio);
            Controls.Add(label2);
            Controls.Add(txtTitulo);
            Controls.Add(lblTituloJanela);
            Controls.Add(label1);
            Name = "frmAlterarEvento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSair;
        private Button btnAlterar;
        private MaskedTextBox mtxSaidaFinal;
        private MaskedTextBox mtxEntradaFinal;
        private MaskedTextBox mtxSaidaInicio;
        private Label label8;
        private MaskedTextBox mtxEntradaInicio;
        private Label label9;
        private Label label7;
        private TextBox txtDescricao;
        private Label label6;
        private MaskedTextBox mtxHorarioFinal;
        private Label label4;
        private MaskedTextBox mtxHorarioInicio;
        private Label label5;
        private MaskedTextBox mtxDataFinal;
        private Label label3;
        private MaskedTextBox mtxDataInicio;
        private Label label2;
        private TextBox txtTitulo;
        private Label lblTituloJanela;
        private Label label1;
    }
}