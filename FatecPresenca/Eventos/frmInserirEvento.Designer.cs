namespace FatecPresenca.Eventos
{
    partial class frmInserirEvento
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
            label1 = new Label();
            label = new Label();
            txtTitulo = new TextBox();
            label2 = new Label();
            mtxDataInicio = new MaskedTextBox();
            mtxDataFinal = new MaskedTextBox();
            label3 = new Label();
            mtxHorarioFinal = new MaskedTextBox();
            label4 = new Label();
            mtxHorarioInicio = new MaskedTextBox();
            label5 = new Label();
            txtDescricao = new TextBox();
            label6 = new Label();
            label7 = new Label();
            mtxSaidaInicio = new MaskedTextBox();
            label8 = new Label();
            mtxEntradaInicio = new MaskedTextBox();
            label9 = new Label();
            mtxSaidaFinal = new MaskedTextBox();
            mtxEntradaFinal = new MaskedTextBox();
            btnInserir = new Button();
            btnSair = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(39, 70);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 17;
            label1.Text = "Título do Evento:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.ForeColor = Color.White;
            label.Location = new Point(12, 9);
            label.Name = "label";
            label.Size = new Size(272, 46);
            label.TabIndex = 18;
            label.Text = "CRIAR EVENTO";
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.White;
            txtTitulo.BorderStyle = BorderStyle.None;
            txtTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtTitulo.ForeColor = Color.Black;
            txtTitulo.Location = new Point(39, 93);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(310, 25);
            txtTitulo.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(39, 127);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 20;
            label2.Text = "Data Início:";
            // 
            // mtxDataInicio
            // 
            mtxDataInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxDataInicio.Location = new Point(39, 150);
            mtxDataInicio.Mask = "00/00/0000";
            mtxDataInicio.Name = "mtxDataInicio";
            mtxDataInicio.Size = new Size(157, 32);
            mtxDataInicio.TabIndex = 21;
            mtxDataInicio.ValidatingType = typeof(DateTime);
            // 
            // mtxDataFinal
            // 
            mtxDataFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxDataFinal.Location = new Point(202, 150);
            mtxDataFinal.Mask = "00/00/0000";
            mtxDataFinal.Name = "mtxDataFinal";
            mtxDataFinal.Size = new Size(147, 32);
            mtxDataFinal.TabIndex = 23;
            mtxDataFinal.ValidatingType = typeof(DateTime);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(202, 127);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 22;
            label3.Text = "Data Final:";
            // 
            // mtxHorarioFinal
            // 
            mtxHorarioFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxHorarioFinal.Location = new Point(202, 218);
            mtxHorarioFinal.Mask = "00:00";
            mtxHorarioFinal.Name = "mtxHorarioFinal";
            mtxHorarioFinal.Size = new Size(147, 32);
            mtxHorarioFinal.TabIndex = 27;
            mtxHorarioFinal.ValidatingType = typeof(DateTime);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(202, 195);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 26;
            label4.Text = "Horário Final:";
            // 
            // mtxHorarioInicio
            // 
            mtxHorarioInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxHorarioInicio.Location = new Point(39, 218);
            mtxHorarioInicio.Mask = "00:00";
            mtxHorarioInicio.Name = "mtxHorarioInicio";
            mtxHorarioInicio.Size = new Size(157, 32);
            mtxHorarioInicio.TabIndex = 25;
            mtxHorarioInicio.ValidatingType = typeof(DateTime);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(39, 195);
            label5.Name = "label5";
            label5.Size = new Size(118, 20);
            label5.TabIndex = 24;
            label5.Text = "Horário Início:";
            // 
            // txtDescricao
            // 
            txtDescricao.BackColor = Color.White;
            txtDescricao.BorderStyle = BorderStyle.None;
            txtDescricao.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtDescricao.ForeColor = Color.Black;
            txtDescricao.Location = new Point(39, 291);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(310, 107);
            txtDescricao.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(39, 268);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 28;
            label6.Text = "Descrição:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(39, 420);
            label7.Name = "label7";
            label7.Size = new Size(261, 25);
            label7.TabIndex = 30;
            label7.Text = "Definir Horário de Captura";
            // 
            // mtxSaidaInicio
            // 
            mtxSaidaInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxSaidaInicio.Location = new Point(202, 485);
            mtxSaidaInicio.Mask = "00:00";
            mtxSaidaInicio.Name = "mtxSaidaInicio";
            mtxSaidaInicio.Size = new Size(147, 32);
            mtxSaidaInicio.TabIndex = 34;
            mtxSaidaInicio.ValidatingType = typeof(DateTime);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(202, 462);
            label8.Name = "label8";
            label8.Size = new Size(137, 20);
            label8.TabIndex = 33;
            label8.Text = "Saída de Captura:";
            // 
            // mtxEntradaInicio
            // 
            mtxEntradaInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxEntradaInicio.Location = new Point(39, 485);
            mtxEntradaInicio.Mask = "00:00";
            mtxEntradaInicio.Name = "mtxEntradaInicio";
            mtxEntradaInicio.Size = new Size(157, 32);
            mtxEntradaInicio.TabIndex = 32;
            mtxEntradaInicio.ValidatingType = typeof(DateTime);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(39, 462);
            label9.Name = "label9";
            label9.Size = new Size(131, 20);
            label9.TabIndex = 31;
            label9.Text = "Entrada Captura:";
            // 
            // mtxSaidaFinal
            // 
            mtxSaidaFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxSaidaFinal.Location = new Point(202, 523);
            mtxSaidaFinal.Mask = "00:00";
            mtxSaidaFinal.Name = "mtxSaidaFinal";
            mtxSaidaFinal.Size = new Size(147, 32);
            mtxSaidaFinal.TabIndex = 36;
            mtxSaidaFinal.Tag = "";
            mtxSaidaFinal.ValidatingType = typeof(DateTime);
            // 
            // mtxEntradaFinal
            // 
            mtxEntradaFinal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            mtxEntradaFinal.Location = new Point(39, 523);
            mtxEntradaFinal.Mask = "00:00";
            mtxEntradaFinal.Name = "mtxEntradaFinal";
            mtxEntradaFinal.Size = new Size(157, 32);
            mtxEntradaFinal.TabIndex = 35;
            mtxEntradaFinal.ValidatingType = typeof(DateTime);
            // 
            // btnInserir
            // 
            btnInserir.BackColor = Color.White;
            btnInserir.FlatAppearance.BorderColor = Color.Black;
            btnInserir.FlatAppearance.BorderSize = 3;
            btnInserir.FlatStyle = FlatStyle.Flat;
            btnInserir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInserir.ForeColor = Color.Black;
            btnInserir.Location = new Point(241, 640);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(162, 53);
            btnInserir.TabIndex = 37;
            btnInserir.Text = "Cadastrar";
            btnInserir.UseVisualStyleBackColor = false;
            btnInserir.Click += btnInserir_Click;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.White;
            btnSair.FlatAppearance.BorderColor = Color.Black;
            btnSair.FlatAppearance.BorderSize = 3;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSair.ForeColor = Color.Black;
            btnSair.Location = new Point(12, 652);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(144, 41);
            btnSair.TabIndex = 38;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            // 
            // frmInserirEvento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(419, 705);
            Controls.Add(btnSair);
            Controls.Add(btnInserir);
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
            Controls.Add(label);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmInserirEvento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label;
        private TextBox txtTitulo;
        private Label label2;
        private MaskedTextBox mtxDataInicio;
        private MaskedTextBox mtxDataFinal;
        private Label label3;
        private MaskedTextBox mtxHorarioFinal;
        private Label label4;
        private MaskedTextBox mtxHorarioInicio;
        private Label label5;
        private TextBox txtDescricao;
        private Label label6;
        private Label label7;
        private MaskedTextBox mtxSaidaInicio;
        private Label label8;
        private MaskedTextBox mtxEntradaInicio;
        private Label label9;
        private MaskedTextBox mtxSaidaFinal;
        private MaskedTextBox mtxEntradaFinal;
        private Button btnInserir;
        private Button btnSair;
    }
}