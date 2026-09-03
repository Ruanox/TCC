namespace DSDSDS
{
    partial class criacaoTurmas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(criacaoTurmas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label2 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            btn_aleatorio3 = new Button();
            panel3 = new Panel();
            cmdHorarioTurmas = new ComboBox();
            label8 = new Label();
            numIdadeTurma = new NumericUpDown();
            label9 = new Label();
            cmbTurno = new ComboBox();
            chkSegunda = new PinkCheckBox();
            label6 = new Label();
            chkSabado = new PinkCheckBox();
            label5 = new Label();
            chkSexta = new PinkCheckBox();
            label4 = new Label();
            chkQuinta = new PinkCheckBox();
            label3 = new Label();
            chkQuarta = new PinkCheckBox();
            buttonPanel1 = new ButtonPanel();
            label1 = new Label();
            chkTerca = new PinkCheckBox();
            txtbox_NomeTurma = new TextBox();
            panelArredondado1 = new PanelArredondado();
            panelArredondado2 = new PanelArredondado();
            customPanel1 = new CustomPanel();
            lblSelecionados = new Label();
            label15 = new Label();
            txtPesquisarAluno = new TextBox();
            artanPanel1 = new ArtanPanel();
            dgvAlunos = new DataGridView();
            label11 = new Label();
            lbl_Aluno = new Label();
            buttonPanel2 = new ButtonPanel();
            label10 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIdadeTurma).BeginInit();
            buttonPanel1.SuspendLayout();
            panelArredondado1.SuspendLayout();
            panelArredondado2.SuspendLayout();
            customPanel1.SuspendLayout();
            artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
            buttonPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(250, 42, 85);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(197, 0);
            label2.Name = "label2";
            label2.Size = new Size(363, 55);
            label2.TabIndex = 1;
            label2.Text = "Criar nova turma   \r\n";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(btn_aleatorio3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(189, 746);
            panel2.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(451, 592);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 17;
            label7.Text = "Alunos";
            // 
            // btn_aleatorio3
            // 
            btn_aleatorio3.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_aleatorio3.ForeColor = Color.FromArgb(250, 42, 85);
            btn_aleatorio3.Image = (Image)resources.GetObject("btn_aleatorio3.Image");
            btn_aleatorio3.ImageAlign = ContentAlignment.TopCenter;
            btn_aleatorio3.Location = new Point(417, 505);
            btn_aleatorio3.Name = "btn_aleatorio3";
            btn_aleatorio3.Size = new Size(126, 114);
            btn_aleatorio3.TabIndex = 16;
            btn_aleatorio3.Text = "Gerencie\r\nAlunos\r\n";
            btn_aleatorio3.TextAlign = ContentAlignment.BottomCenter;
            btn_aleatorio3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(189, 646);
            panel3.Name = "panel3";
            panel3.Size = new Size(1181, 100);
            panel3.TabIndex = 11;
            // 
            // cmdHorarioTurmas
            // 
            cmdHorarioTurmas.FormattingEnabled = true;
            cmdHorarioTurmas.Items.AddRange(new object[] { "8:00", "9:00", "10:00", "11:00", "12:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" });
            cmdHorarioTurmas.Location = new Point(23, 310);
            cmdHorarioTurmas.Name = "cmdHorarioTurmas";
            cmdHorarioTurmas.Size = new Size(125, 23);
            cmdHorarioTurmas.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(11, 282);
            label8.Name = "label8";
            label8.Size = new Size(168, 25);
            label8.TabIndex = 21;
            label8.Text = "Horário dos treinos";
            // 
            // numIdadeTurma
            // 
            numIdadeTurma.Location = new Point(23, 220);
            numIdadeTurma.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIdadeTurma.Name = "numIdadeTurma";
            numIdadeTurma.Size = new Size(125, 23);
            numIdadeTurma.TabIndex = 19;
            numIdadeTurma.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(200, 282);
            label9.Name = "label9";
            label9.Size = new Size(135, 25);
            label9.TabIndex = 22;
            label9.Text = "Dia da semana";
            // 
            // cmbTurno
            // 
            cmbTurno.FormattingEnabled = true;
            cmbTurno.Items.AddRange(new object[] { "Manha", "Tarde", "Noite" });
            cmbTurno.Location = new Point(200, 220);
            cmbTurno.Name = "cmbTurno";
            cmbTurno.Size = new Size(125, 23);
            cmbTurno.TabIndex = 18;
            cmbTurno.SelectedIndexChanged += cmdTurno_SelectedIndexChanged;
            // 
            // chkSegunda
            // 
            chkSegunda.AutoSize = true;
            chkSegunda.FlatAppearance.BorderSize = 0;
            chkSegunda.FlatStyle = FlatStyle.Flat;
            chkSegunda.Font = new Font("Segoe UI", 10F);
            chkSegunda.ForeColor = Color.FromArgb(30, 30, 30);
            chkSegunda.Location = new Point(200, 335);
            chkSegunda.Name = "chkSegunda";
            chkSegunda.Size = new Size(78, 23);
            chkSegunda.TabIndex = 23;
            chkSegunda.Text = "Segunda";
            chkSegunda.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Image = (Image)resources.GetObject("label6.Image");
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(191, 192);
            label6.Name = "label6";
            label6.Size = new Size(174, 25);
            label6.TabIndex = 17;
            label6.Text = "Turno da turma        ";
            // 
            // chkSabado
            // 
            chkSabado.FlatAppearance.BorderSize = 0;
            chkSabado.FlatStyle = FlatStyle.Flat;
            chkSabado.Font = new Font("Segoe UI", 10F);
            chkSabado.ForeColor = Color.FromArgb(30, 30, 30);
            chkSabado.Location = new Point(287, 394);
            chkSabado.Name = "chkSabado";
            chkSabado.Size = new Size(78, 23);
            chkSabado.TabIndex = 24;
            chkSabado.Text = "Sabado";
            chkSabado.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.ImageAlign = ContentAlignment.MiddleRight;
            label5.Location = new Point(7, 192);
            label5.Name = "label5";
            label5.Size = new Size(168, 25);
            label5.TabIndex = 16;
            label5.Text = "Idade da turma       ";
            // 
            // chkSexta
            // 
            chkSexta.FlatAppearance.BorderSize = 0;
            chkSexta.FlatStyle = FlatStyle.Flat;
            chkSexta.Font = new Font("Segoe UI", 10F);
            chkSexta.ForeColor = Color.FromArgb(30, 30, 30);
            chkSexta.Location = new Point(287, 364);
            chkSexta.Name = "chkSexta";
            chkSexta.Size = new Size(78, 23);
            chkSexta.TabIndex = 25;
            chkSexta.Text = "Sexta";
            chkSexta.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 87);
            label4.Name = "label4";
            label4.Size = new Size(206, 25);
            label4.TabIndex = 13;
            label4.Text = "Nome da turma/equipe\r\n";
            // 
            // chkQuinta
            // 
            chkQuinta.AutoSize = true;
            chkQuinta.FlatAppearance.BorderSize = 0;
            chkQuinta.FlatStyle = FlatStyle.Flat;
            chkQuinta.Font = new Font("Segoe UI", 10F);
            chkQuinta.ForeColor = Color.FromArgb(30, 30, 30);
            chkQuinta.Location = new Point(287, 335);
            chkQuinta.Name = "chkQuinta";
            chkQuinta.Size = new Size(67, 23);
            chkQuinta.TabIndex = 26;
            chkQuinta.Text = "Quinta";
            chkQuinta.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(80, 27);
            label3.Name = "label3";
            label3.Size = new Size(222, 30);
            label3.TabIndex = 12;
            label3.Text = "Informação da turma";
            // 
            // chkQuarta
            // 
            chkQuarta.AutoSize = true;
            chkQuarta.FlatAppearance.BorderSize = 0;
            chkQuarta.FlatStyle = FlatStyle.Flat;
            chkQuarta.Font = new Font("Segoe UI", 10F);
            chkQuarta.ForeColor = Color.FromArgb(30, 30, 30);
            chkQuarta.Location = new Point(200, 394);
            chkQuarta.Name = "chkQuarta";
            chkQuarta.Size = new Size(68, 23);
            chkQuarta.TabIndex = 27;
            chkQuarta.Text = "Quarta";
            chkQuarta.UseVisualStyleBackColor = true;
            // 
            // buttonPanel1
            // 
            buttonPanel1.BackColor = Color.FromArgb(250, 42, 85);
            buttonPanel1.BorderColor = Color.Transparent;
            buttonPanel1.BorderRadius = 12;
            buttonPanel1.BorderSize = 0;
            buttonPanel1.Controls.Add(label1);
            buttonPanel1.HoverColor = Color.FromArgb(250, 42, 85);
            buttonPanel1.Location = new Point(34, 20);
            buttonPanel1.Name = "buttonPanel1";
            buttonPanel1.NormalColor = Color.FromArgb(250, 42, 85);
            buttonPanel1.PressedColor = Color.FromArgb(250, 42, 85);
            buttonPanel1.Size = new Size(40, 40);
            buttonPanel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 5);
            label1.Name = "label1";
            label1.Size = new Size(23, 33);
            label1.TabIndex = 12;
            label1.Text = "1";
            // 
            // chkTerca
            // 
            chkTerca.FlatAppearance.BorderSize = 0;
            chkTerca.FlatStyle = FlatStyle.Flat;
            chkTerca.Font = new Font("Segoe UI", 10F);
            chkTerca.ForeColor = Color.FromArgb(30, 30, 30);
            chkTerca.Location = new Point(200, 364);
            chkTerca.Name = "chkTerca";
            chkTerca.Size = new Size(78, 23);
            chkTerca.TabIndex = 28;
            chkTerca.Text = "Terça";
            chkTerca.UseVisualStyleBackColor = true;
            // 
            // txtbox_NomeTurma
            // 
            txtbox_NomeTurma.Location = new Point(34, 115);
            txtbox_NomeTurma.Name = "txtbox_NomeTurma";
            txtbox_NomeTurma.PlaceholderText = "Ex:  Sub-17-A";
            txtbox_NomeTurma.Size = new Size(223, 23);
            txtbox_NomeTurma.TabIndex = 14;
            // 
            // panelArredondado1
            // 
            panelArredondado1.BackColor = Color.White;
            panelArredondado1.Controls.Add(txtbox_NomeTurma);
            panelArredondado1.Controls.Add(chkTerca);
            panelArredondado1.Controls.Add(buttonPanel1);
            panelArredondado1.Controls.Add(chkQuarta);
            panelArredondado1.Controls.Add(label3);
            panelArredondado1.Controls.Add(chkQuinta);
            panelArredondado1.Controls.Add(label4);
            panelArredondado1.Controls.Add(chkSexta);
            panelArredondado1.Controls.Add(label5);
            panelArredondado1.Controls.Add(chkSabado);
            panelArredondado1.Controls.Add(label6);
            panelArredondado1.Controls.Add(chkSegunda);
            panelArredondado1.Controls.Add(cmbTurno);
            panelArredondado1.Controls.Add(label9);
            panelArredondado1.Controls.Add(numIdadeTurma);
            panelArredondado1.Controls.Add(label8);
            panelArredondado1.Controls.Add(cmdHorarioTurmas);
            panelArredondado1.CorBorda = Color.FromArgb(250, 42, 85);
            panelArredondado1.EspessuraBorda = 1;
            panelArredondado1.Location = new Point(195, 58);
            panelArredondado1.Name = "panelArredondado1";
            panelArredondado1.Padding = new Padding(20);
            panelArredondado1.Raio = 34;
            panelArredondado1.Size = new Size(374, 594);
            panelArredondado1.TabIndex = 12;
            // 
            // panelArredondado2
            // 
            panelArredondado2.BackColor = Color.White;
            panelArredondado2.Controls.Add(customPanel1);
            panelArredondado2.Controls.Add(label15);
            panelArredondado2.Controls.Add(txtPesquisarAluno);
            panelArredondado2.Controls.Add(artanPanel1);
            panelArredondado2.Controls.Add(label11);
            panelArredondado2.Controls.Add(lbl_Aluno);
            panelArredondado2.Controls.Add(buttonPanel2);
            panelArredondado2.CorBorda = Color.FromArgb(230, 230, 230);
            panelArredondado2.EspessuraBorda = 1;
            panelArredondado2.Location = new Point(575, 12);
            panelArredondado2.Name = "panelArredondado2";
            panelArredondado2.Padding = new Padding(20);
            panelArredondado2.Raio = 20;
            panelArredondado2.Size = new Size(874, 631);
            panelArredondado2.TabIndex = 13;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderColor = Color.Black;
            customPanel1.BorderRadius = 15;
            customPanel1.BorderSize = 0;
            customPanel1.Controls.Add(lblSelecionados);
            customPanel1.Location = new Point(10, 49);
            customPanel1.Name = "customPanel1";
            customPanel1.ShadowColor = Color.FromArgb(35, 0, 0, 0);
            customPanel1.ShadowSize = 8;
            customPanel1.Size = new Size(809, 78);
            customPanel1.TabIndex = 22;
            // 
            // lblSelecionados
            // 
            lblSelecionados.AutoSize = true;
            lblSelecionados.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelecionados.ForeColor = Color.FromArgb(250, 42, 85);
            lblSelecionados.Location = new Point(23, 27);
            lblSelecionados.Name = "lblSelecionados";
            lblSelecionados.Size = new Size(136, 25);
            lblSelecionados.TabIndex = 23;
            lblSelecionados.Text = "Selecionados: 0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Montserrat", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Image = (Image)resources.GetObject("label15.Image");
            label15.ImageAlign = ContentAlignment.MiddleLeft;
            label15.Location = new Point(395, 13);
            label15.Name = "label15";
            label15.Size = new Size(204, 30);
            label15.TabIndex = 21;
            label15.Text = "      Pesquisar alunos";
            // 
            // txtPesquisarAluno
            // 
            txtPesquisarAluno.Location = new Point(605, 16);
            txtPesquisarAluno.Name = "txtPesquisarAluno";
            txtPesquisarAluno.PlaceholderText = "Pesquise pelos alunos ";
            txtPesquisarAluno.Size = new Size(150, 23);
            txtPesquisarAluno.TabIndex = 20;
            txtPesquisarAluno.TextChanged += txtPesquisarAluno_TextChanged;
            // 
            // artanPanel1
            // 
            artanPanel1.BackColor = Color.White;
            artanPanel1.BorderRadius = 30;
            artanPanel1.Controls.Add(dgvAlunos);
            artanPanel1.ForeColor = Color.Black;
            artanPanel1.GradientAngle = 90F;
            artanPanel1.GradientBottomColor = Color.FromArgb(255, 128, 128);
            artanPanel1.GradientTopColor = Color.FromArgb(250, 42, 85);
            artanPanel1.Location = new Point(196, 142);
            artanPanel1.Name = "artanPanel1";
            artanPanel1.Padding = new Padding(10, 0, 10, 20);
            artanPanel1.Size = new Size(543, 424);
            artanPanel1.TabIndex = 19;
            // 
            // dgvAlunos
            // 
            dgvAlunos.AllowUserToAddRows = false;
            dgvAlunos.AllowUserToDeleteRows = false;
            dgvAlunos.AllowUserToResizeColumns = false;
            dgvAlunos.AllowUserToResizeRows = false;
            dgvAlunos.BackgroundColor = Color.White;
            dgvAlunos.BorderStyle = BorderStyle.None;
            dgvAlunos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAlunos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 42, 85);
            dataGridViewCellStyle1.Font = new Font("Montserrat SemiBold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 42, 85);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAlunos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAlunos.ColumnHeadersHeight = 45;
            dgvAlunos.Dock = DockStyle.Fill;
            dgvAlunos.EnableHeadersVisualStyles = false;
            dgvAlunos.GridColor = Color.White;
            dgvAlunos.Location = new Point(10, 0);
            dgvAlunos.MultiSelect = false;
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAlunos.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvAlunos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvAlunos.RowTemplate.DividerHeight = 1;
            dgvAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunos.Size = new Size(523, 404);
            dgvAlunos.TabIndex = 0;
            dgvAlunos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Montserrat SemiBold", 14.25F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(250, 42, 85);
            label11.Location = new Point(196, 16);
            label11.Name = "label11";
            label11.Size = new Size(80, 30);
            label11.TabIndex = 14;
            label11.Text = "Alunos";
            // 
            // lbl_Aluno
            // 
            lbl_Aluno.AutoSize = true;
            lbl_Aluno.Font = new Font("Montserrat SemiBold", 14.25F, FontStyle.Bold);
            lbl_Aluno.Location = new Point(70, 16);
            lbl_Aluno.Name = "lbl_Aluno";
            lbl_Aluno.RightToLeft = RightToLeft.No;
            lbl_Aluno.Size = new Size(134, 30);
            lbl_Aluno.TabIndex = 13;
            lbl_Aluno.Text = "Selecione os";
            // 
            // buttonPanel2
            // 
            buttonPanel2.BackColor = Color.FromArgb(250, 42, 85);
            buttonPanel2.BorderColor = Color.Transparent;
            buttonPanel2.BorderRadius = 12;
            buttonPanel2.BorderSize = 0;
            buttonPanel2.Controls.Add(label10);
            buttonPanel2.HoverColor = Color.FromArgb(250, 42, 85);
            buttonPanel2.Location = new Point(24, 7);
            buttonPanel2.Name = "buttonPanel2";
            buttonPanel2.NormalColor = Color.FromArgb(250, 42, 85);
            buttonPanel2.PressedColor = Color.FromArgb(250, 42, 85);
            buttonPanel2.Size = new Size(40, 40);
            buttonPanel2.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Montserrat", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(9, 6);
            label10.Name = "label10";
            label10.Size = new Size(27, 33);
            label10.TabIndex = 12;
            label10.Text = "2";
            // 
            // criacaoTurmas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 746);
            Controls.Add(panelArredondado2);
            Controls.Add(panelArredondado1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label2);
            Name = "criacaoTurmas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "panel";
            Load += criacaoTurmas_Load_1;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIdadeTurma).EndInit();
            buttonPanel1.ResumeLayout(false);
            buttonPanel1.PerformLayout();
            panelArredondado1.ResumeLayout(false);
            panelArredondado1.PerformLayout();
            panelArredondado2.ResumeLayout(false);
            panelArredondado2.PerformLayout();
            customPanel1.ResumeLayout(false);
            customPanel1.PerformLayout();
            artanPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).EndInit();
            buttonPanel2.ResumeLayout(false);
            buttonPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Panel panel2;
        private Label label7;
        private Button btn_aleatorio3;
        private Panel panel3;
        private ComboBox cmdHorarioTurmas;
        private Label label8;
        private NumericUpDown numIdadeTurma;
        private Label label9;
        private ComboBox cmbTurno;
        private PinkCheckBox chkSegunda;
        private Label label6;
        private PinkCheckBox chkSabado;
        private Label label5;
        private PinkCheckBox chkSexta;
        private Label label4;
        private PinkCheckBox chkQuinta;
        private Label label3;
        private PinkCheckBox chkQuarta;
        private ButtonPanel buttonPanel1;
        private Label label1;
        private PinkCheckBox chkTerca;
        private TextBox txtbox_NomeTurma;
        private PanelArredondado panelArredondado1;
        private PanelArredondado panelArredondado2;
        private ButtonPanel buttonPanel2;
        private Label label10;
        private Label label11;
        private Label lbl_Aluno;
        private ArtanPanel artanPanel1;
        private DataGridView dgvAlunos;
        private Label label15;
        private TextBox txtPesquisarAluno;
        private CustomPanel customPanel1;
        private Label lblSelecionados;
    }
}