namespace FatecPresenca
{
    partial class frmDashBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            msMenu = new MenuStrip();
            consultaToolStripMenuItem = new ToolStripMenuItem();
            presençaToolStripMenuItem = new ToolStripMenuItem();
            eventoToolStripMenuItem = new ToolStripMenuItem();
            relatórioToolStripMenuItem = new ToolStripMenuItem();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            ajudaToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            lblNomeEvento = new Label();
            label2 = new Label();
            lblHorarioInicio = new Label();
            label3 = new Label();
            label4 = new Label();
            lblData = new Label();
            lblHorarioFinal = new Label();
            panel1 = new Panel();
            lblHorarioAtual = new Label();
            lblStatusRegistro = new Label();
            dgvDadosRegistro = new DataGridView();
            clmName = new DataGridViewTextBoxColumn();
            clmStatusEntrada = new DataGridViewTextBoxColumn();
            clmStatusSaida = new DataGridViewTextBoxColumn();
            btnRegistrar = new Button();
            btnSair = new Button();
            txtPesquisar = new TextBox();
            tmrHorarioAtual = new System.Windows.Forms.Timer(components);
            cmbEventos = new ComboBox();
            msMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).BeginInit();
            SuspendLayout();
            // 
            // msMenu
            // 
            msMenu.BackColor = Color.FromArgb(171, 0, 0);
            msMenu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            msMenu.ImageScalingSize = new Size(20, 20);
            msMenu.Items.AddRange(new ToolStripItem[] { consultaToolStripMenuItem, sobreToolStripMenuItem, ajudaToolStripMenuItem });
            msMenu.Location = new Point(0, 0);
            msMenu.Name = "msMenu";
            msMenu.Size = new Size(996, 28);
            msMenu.TabIndex = 0;
            msMenu.Text = "menuStrip1";
            // 
            // consultaToolStripMenuItem
            // 
            consultaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { presençaToolStripMenuItem, eventoToolStripMenuItem, relatórioToolStripMenuItem });
            consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            consultaToolStripMenuItem.Size = new Size(80, 24);
            consultaToolStripMenuItem.Text = "Consulta";
            // 
            // presençaToolStripMenuItem
            // 
            presençaToolStripMenuItem.Name = "presençaToolStripMenuItem";
            presençaToolStripMenuItem.Size = new Size(153, 26);
            presençaToolStripMenuItem.Text = "Presença";
            presençaToolStripMenuItem.Click += presençaToolStripMenuItem_Click;
            // 
            // eventoToolStripMenuItem
            // 
            eventoToolStripMenuItem.Name = "eventoToolStripMenuItem";
            eventoToolStripMenuItem.Size = new Size(153, 26);
            eventoToolStripMenuItem.Text = "Evento";
            eventoToolStripMenuItem.Click += eventoToolStripMenuItem_Click;
            // 
            // relatórioToolStripMenuItem
            // 
            relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
            relatórioToolStripMenuItem.Size = new Size(153, 26);
            relatórioToolStripMenuItem.Text = "Relatório";
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.Size = new Size(62, 24);
            sobreToolStripMenuItem.Text = "Sobre";
            // 
            // ajudaToolStripMenuItem
            // 
            ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            ajudaToolStripMenuItem.Size = new Size(62, 24);
            ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 55);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 1;
            label1.Text = "Evento:";
            // 
            // lblNomeEvento
            // 
            lblNomeEvento.AutoSize = true;
            lblNomeEvento.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeEvento.ForeColor = Color.White;
            lblNomeEvento.Location = new Point(100, 55);
            lblNomeEvento.Name = "lblNomeEvento";
            lblNomeEvento.Size = new Size(151, 25);
            lblNomeEvento.TabIndex = 2;
            lblNomeEvento.Text = "FATEC ABERTA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(168, 25);
            label2.TabIndex = 3;
            label2.Text = "Início do Evento:";
            // 
            // lblHorarioInicio
            // 
            lblHorarioInicio.AutoSize = true;
            lblHorarioInicio.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHorarioInicio.ForeColor = Color.White;
            lblHorarioInicio.Location = new Point(186, 93);
            lblHorarioInicio.Name = "lblHorarioInicio";
            lblHorarioInicio.Size = new Size(62, 25);
            lblHorarioInicio.TabIndex = 4;
            lblHorarioInicio.Text = "08:00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(295, 55);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 5;
            label3.Text = "Data:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(295, 93);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 6;
            label4.Text = "Fim de Evento:";
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblData.ForeColor = Color.White;
            lblData.Location = new Point(363, 55);
            lblData.Name = "lblData";
            lblData.Size = new Size(118, 25);
            lblData.TabIndex = 7;
            lblData.Text = "07/06/2026";
            // 
            // lblHorarioFinal
            // 
            lblHorarioFinal.AutoSize = true;
            lblHorarioFinal.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHorarioFinal.ForeColor = Color.White;
            lblHorarioFinal.Location = new Point(450, 93);
            lblHorarioFinal.Name = "lblHorarioFinal";
            lblHorarioFinal.Size = new Size(58, 25);
            lblHorarioFinal.TabIndex = 8;
            lblHorarioFinal.Text = "11:30";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblHorarioAtual);
            panel1.Controls.Add(lblStatusRegistro);
            panel1.Location = new Point(689, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 75);
            panel1.TabIndex = 9;
            // 
            // lblHorarioAtual
            // 
            lblHorarioAtual.AutoSize = true;
            lblHorarioAtual.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHorarioAtual.ForeColor = Color.Black;
            lblHorarioAtual.Location = new Point(111, 36);
            lblHorarioAtual.Name = "lblHorarioAtual";
            lblHorarioAtual.Size = new Size(66, 28);
            lblHorarioAtual.TabIndex = 10;
            lblHorarioAtual.Text = "00:00";
            // 
            // lblStatusRegistro
            // 
            lblStatusRegistro.AutoSize = true;
            lblStatusRegistro.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusRegistro.ForeColor = Color.Red;
            lblStatusRegistro.Location = new Point(49, 11);
            lblStatusRegistro.Name = "lblStatusRegistro";
            lblStatusRegistro.Size = new Size(202, 25);
            lblStatusRegistro.TabIndex = 10;
            lblStatusRegistro.Text = "REGISTRO FECHADO";
            // 
            // dgvDadosRegistro
            // 
            dgvDadosRegistro.AllowUserToAddRows = false;
            dgvDadosRegistro.AllowUserToDeleteRows = false;
            dgvDadosRegistro.AllowUserToResizeColumns = false;
            dgvDadosRegistro.AllowUserToResizeRows = false;
            dgvDadosRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDadosRegistro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDadosRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDadosRegistro.Columns.AddRange(new DataGridViewColumn[] { clmName, clmStatusEntrada, clmStatusSaida });
            dgvDadosRegistro.Location = new Point(12, 206);
            dgvDadosRegistro.Name = "dgvDadosRegistro";
            dgvDadosRegistro.ReadOnly = true;
            dgvDadosRegistro.RowHeadersWidth = 52;
            dgvDadosRegistro.Size = new Size(964, 316);
            dgvDadosRegistro.TabIndex = 10;
            // 
            // clmName
            // 
            clmName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmName.HeaderText = "Nome";
            clmName.MinimumWidth = 6;
            clmName.Name = "clmName";
            clmName.ReadOnly = true;
            // 
            // clmStatusEntrada
            // 
            clmStatusEntrada.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmStatusEntrada.HeaderText = "Status Entrada";
            clmStatusEntrada.MinimumWidth = 6;
            clmStatusEntrada.Name = "clmStatusEntrada";
            clmStatusEntrada.ReadOnly = true;
            // 
            // clmStatusSaida
            // 
            clmStatusSaida.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmStatusSaida.HeaderText = "Status Saída";
            clmStatusSaida.MinimumWidth = 6;
            clmStatusSaida.Name = "clmStatusSaida";
            clmStatusSaida.ReadOnly = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.White;
            btnRegistrar.FlatAppearance.BorderColor = Color.Black;
            btnRegistrar.FlatAppearance.BorderSize = 3;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.Black;
            btnRegistrar.Location = new Point(12, 546);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(209, 53);
            btnRegistrar.TabIndex = 11;
            btnRegistrar.Text = "Registrar Presença";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.White;
            btnSair.FlatAppearance.BorderColor = Color.Black;
            btnSair.FlatAppearance.BorderSize = 3;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSair.ForeColor = Color.Black;
            btnSair.Location = new Point(877, 546);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(99, 53);
            btnSair.TabIndex = 12;
            btnSair.Text = "SAIR";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.BackColor = Color.White;
            txtPesquisar.BorderStyle = BorderStyle.None;
            txtPesquisar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtPesquisar.ForeColor = Color.Black;
            txtPesquisar.Location = new Point(12, 154);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(168, 25);
            txtPesquisar.TabIndex = 13;
            // 
            // tmrHorarioAtual
            // 
            tmrHorarioAtual.Enabled = true;
            tmrHorarioAtual.Interval = 500;
            tmrHorarioAtual.Tick += tmrHorarioAtual_Tick;
            // 
            // cmbEventos
            // 
            cmbEventos.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbEventos.FormattingEnabled = true;
            cmbEventos.Location = new Point(689, 154);
            cmbEventos.Name = "cmbEventos";
            cmbEventos.Size = new Size(287, 33);
            cmbEventos.TabIndex = 14;
            // 
            // frmDashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(996, 638);
            Controls.Add(cmbEventos);
            Controls.Add(txtPesquisar);
            Controls.Add(btnSair);
            Controls.Add(btnRegistrar);
            Controls.Add(dgvDadosRegistro);
            Controls.Add(panel1);
            Controls.Add(lblHorarioFinal);
            Controls.Add(lblData);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblHorarioInicio);
            Controls.Add(label2);
            Controls.Add(lblNomeEvento);
            Controls.Add(label1);
            Controls.Add(msMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = msMenu;
            MaximizeBox = false;
            Name = "frmDashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FATEC PRESENÇA";
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDadosRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMenu;
        private ToolStripMenuItem consultaToolStripMenuItem;
        private ToolStripMenuItem presençaToolStripMenuItem;
        private ToolStripMenuItem eventoToolStripMenuItem;
        private ToolStripMenuItem relatórioToolStripMenuItem;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripMenuItem ajudaToolStripMenuItem;
        private Label label1;
        private Label lblNomeEvento;
        private Label label2;
        private Label lblHorarioInicio;
        private Label label3;
        private Label label4;
        private Label lblData;
        private Label lblHorarioFinal;
        private Panel panel1;
        private Label lblHorarioAtual;
        private Label lblStatusRegistro;
        private DataGridView dgvDadosRegistro;
        private Button btnRegistrar;
        private Button btnSair;
        private TextBox txtPesquisar;
        private System.Windows.Forms.Timer tmrHorarioAtual;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewTextBoxColumn clmStatusEntrada;
        private DataGridViewTextBoxColumn clmStatusSaida;
        private ComboBox cmbEventos;
    }
}
