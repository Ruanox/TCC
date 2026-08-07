namespace DSDSDS
{
    partial class Form_principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_principal));
            panel1 = new Panel();
            panelcadSubMenu = new Panel();
            btn_escola = new Button();
            btn_professor = new Button();
            btn_aluno = new Button();
            btnMedia = new Button();
            panel_logo = new Panel();
            panelSideMenu = new Panel();
            button1 = new Button();
            button4 = new Button();
            label9 = new Label();
            btn_aleatorio = new Button();
            label8 = new Label();
            btn_aleatorio2 = new Button();
            label7 = new Label();
            btn_aleatorio3 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panelcadSubMenu.SuspendLayout();
            panelSideMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(243, 244, 246);
            panel1.Controls.Add(panelcadSubMenu);
            panel1.Controls.Add(btnMedia);
            panel1.Controls.Add(panel_logo);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 950);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint_1;
            // 
            // panelcadSubMenu
            // 
            panelcadSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelcadSubMenu.Controls.Add(btn_escola);
            panelcadSubMenu.Controls.Add(btn_professor);
            panelcadSubMenu.Controls.Add(btn_aluno);
            panelcadSubMenu.Dock = DockStyle.Top;
            panelcadSubMenu.Location = new Point(0, 160);
            panelcadSubMenu.Name = "panelcadSubMenu";
            panelcadSubMenu.Size = new Size(250, 121);
            panelcadSubMenu.TabIndex = 2;
            // 
            // btn_escola
            // 
            btn_escola.BackColor = Color.FromArgb(243, 244, 246);
            btn_escola.Dock = DockStyle.Top;
            btn_escola.FlatAppearance.BorderSize = 0;
            btn_escola.FlatStyle = FlatStyle.Flat;
            btn_escola.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_escola.ForeColor = Color.FromArgb(31, 41, 55);
            btn_escola.Image = (Image)resources.GetObject("btn_escola.Image");
            btn_escola.ImageAlign = ContentAlignment.MiddleLeft;
            btn_escola.Location = new Point(0, 80);
            btn_escola.Name = "btn_escola";
            btn_escola.Padding = new Padding(35, 0, 0, 0);
            btn_escola.Size = new Size(250, 40);
            btn_escola.TabIndex = 2;
            btn_escola.Text = "Escola";
            btn_escola.TextAlign = ContentAlignment.MiddleLeft;
            btn_escola.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_escola.UseVisualStyleBackColor = false;
            btn_escola.Click += btn_escola_Click;
            // 
            // btn_professor
            // 
            btn_professor.BackColor = Color.FromArgb(243, 244, 246);
            btn_professor.Dock = DockStyle.Top;
            btn_professor.FlatAppearance.BorderSize = 0;
            btn_professor.FlatStyle = FlatStyle.Flat;
            btn_professor.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_professor.ForeColor = Color.FromArgb(31, 41, 55);
            btn_professor.Image = (Image)resources.GetObject("btn_professor.Image");
            btn_professor.ImageAlign = ContentAlignment.MiddleLeft;
            btn_professor.Location = new Point(0, 40);
            btn_professor.Name = "btn_professor";
            btn_professor.Padding = new Padding(35, 0, 0, 0);
            btn_professor.Size = new Size(250, 40);
            btn_professor.TabIndex = 1;
            btn_professor.Text = "Professor";
            btn_professor.TextAlign = ContentAlignment.MiddleLeft;
            btn_professor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_professor.UseVisualStyleBackColor = false;
            btn_professor.Click += button2_Click_1;
            // 
            // btn_aluno
            // 
            btn_aluno.BackColor = Color.FromArgb(243, 244, 246);
            btn_aluno.Dock = DockStyle.Top;
            btn_aluno.FlatAppearance.BorderSize = 0;
            btn_aluno.FlatStyle = FlatStyle.Flat;
            btn_aluno.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_aluno.ForeColor = Color.FromArgb(31, 41, 55);
            btn_aluno.Image = (Image)resources.GetObject("btn_aluno.Image");
            btn_aluno.ImageAlign = ContentAlignment.MiddleLeft;
            btn_aluno.Location = new Point(0, 0);
            btn_aluno.Name = "btn_aluno";
            btn_aluno.Padding = new Padding(35, 0, 0, 0);
            btn_aluno.Size = new Size(250, 40);
            btn_aluno.TabIndex = 0;
            btn_aluno.Text = "Aluno";
            btn_aluno.TextAlign = ContentAlignment.MiddleLeft;
            btn_aluno.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_aluno.UseVisualStyleBackColor = false;
            btn_aluno.Click += button1_Click_1;
            // 
            // btnMedia
            // 
            btnMedia.BackColor = Color.FromArgb(250, 42, 85);
            btnMedia.Dock = DockStyle.Top;
            btnMedia.FlatAppearance.BorderSize = 0;
            btnMedia.FlatStyle = FlatStyle.Flat;
            btnMedia.Font = new Font("Tahoma", 15F);
            btnMedia.ForeColor = SystemColors.Control;
            btnMedia.Image = (Image)resources.GetObject("btnMedia.Image");
            btnMedia.ImageAlign = ContentAlignment.MiddleLeft;
            btnMedia.Location = new Point(0, 115);
            btnMedia.Name = "btnMedia";
            btnMedia.Padding = new Padding(10, 0, 0, 0);
            btnMedia.Size = new Size(250, 45);
            btnMedia.TabIndex = 1;
            btnMedia.Text = "Login";
            btnMedia.TextAlign = ContentAlignment.MiddleLeft;
            btnMedia.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMedia.UseVisualStyleBackColor = false;
            btnMedia.Click += btnMedia_Click;
            // 
            // panel_logo
            // 
            panel_logo.BackgroundImage = (Image)resources.GetObject("panel_logo.BackgroundImage");
            panel_logo.BackgroundImageLayout = ImageLayout.Center;
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 115);
            panel_logo.TabIndex = 0;
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = Color.FromArgb(243, 244, 246);
            panelSideMenu.Controls.Add(button1);
            panelSideMenu.Controls.Add(button4);
            panelSideMenu.Controls.Add(label9);
            panelSideMenu.Controls.Add(btn_aleatorio);
            panelSideMenu.Controls.Add(label8);
            panelSideMenu.Controls.Add(btn_aleatorio2);
            panelSideMenu.Controls.Add(label7);
            panelSideMenu.Controls.Add(btn_aleatorio3);
            panelSideMenu.Controls.Add(label6);
            panelSideMenu.Controls.Add(label5);
            panelSideMenu.Controls.Add(label4);
            panelSideMenu.Controls.Add(label3);
            panelSideMenu.Controls.Add(label2);
            panelSideMenu.Controls.Add(label1);
            panelSideMenu.Controls.Add(panel2);
            panelSideMenu.Controls.Add(panel1);
            panelSideMenu.Dock = DockStyle.Fill;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.MaximumSize = new Size(1920, 1080);
            panelSideMenu.MinimumSize = new Size(920, 950);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(1370, 950);
            panelSideMenu.TabIndex = 2;
            panelSideMenu.Paint += panel3_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(250, 42, 85);
            button1.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(710, 603);
            button1.Name = "button1";
            button1.Size = new Size(342, 63);
            button1.TabIndex = 23;
            button1.Text = "SportCorp.com";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(250, 42, 85);
            button4.FlatAppearance.BorderSize = 0;
            button4.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.Location = new Point(723, 597);
            button4.Name = "button4";
            button4.Size = new Size(0, 0);
            button4.TabIndex = 22;
            button4.Text = "SportCorp.com \r\n";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(1012, 540);
            label9.Name = "label9";
            label9.Size = new Size(71, 25);
            label9.TabIndex = 21;
            label9.Text = "Escolas";
            // 
            // btn_aleatorio
            // 
            btn_aleatorio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_aleatorio.ForeColor = Color.FromArgb(250, 42, 85);
            btn_aleatorio.Image = (Image)resources.GetObject("btn_aleatorio.Image");
            btn_aleatorio.ImageAlign = ContentAlignment.TopCenter;
            btn_aleatorio.Location = new Point(985, 455);
            btn_aleatorio.Name = "btn_aleatorio";
            btn_aleatorio.Size = new Size(126, 114);
            btn_aleatorio.TabIndex = 20;
            btn_aleatorio.Text = "Administre \r\nEscolas";
            btn_aleatorio.TextAlign = ContentAlignment.BottomCenter;
            btn_aleatorio.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(833, 540);
            label8.Name = "label8";
            label8.Size = new Size(104, 25);
            label8.TabIndex = 19;
            label8.Text = "Professores";
            // 
            // btn_aleatorio2
            // 
            btn_aleatorio2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_aleatorio2.ForeColor = Color.FromArgb(250, 42, 85);
            btn_aleatorio2.Image = (Image)resources.GetObject("btn_aleatorio2.Image");
            btn_aleatorio2.ImageAlign = ContentAlignment.TopCenter;
            btn_aleatorio2.Location = new Point(823, 455);
            btn_aleatorio2.Name = "btn_aleatorio2";
            btn_aleatorio2.Size = new Size(126, 114);
            btn_aleatorio2.TabIndex = 18;
            btn_aleatorio2.Text = "Acompanhe\r\nProfessores";
            btn_aleatorio2.TextAlign = ContentAlignment.BottomCenter;
            btn_aleatorio2.UseVisualStyleBackColor = true;
            btn_aleatorio2.Click += button2_Click_2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(688, 540);
            label7.Name = "label7";
            label7.Size = new Size(67, 25);
            label7.TabIndex = 17;
            label7.Text = "Alunos";
            // 
            // btn_aleatorio3
            // 
            btn_aleatorio3.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_aleatorio3.ForeColor = Color.FromArgb(250, 42, 85);
            btn_aleatorio3.Image = (Image)resources.GetObject("btn_aleatorio3.Image");
            btn_aleatorio3.ImageAlign = ContentAlignment.TopCenter;
            btn_aleatorio3.Location = new Point(659, 455);
            btn_aleatorio3.Name = "btn_aleatorio3";
            btn_aleatorio3.Size = new Size(126, 114);
            btn_aleatorio3.TabIndex = 16;
            btn_aleatorio3.Text = "Gerencie\r\nAlunos\r\n";
            btn_aleatorio3.TextAlign = ContentAlignment.BottomCenter;
            btn_aleatorio3.UseVisualStyleBackColor = true;
            btn_aleatorio3.Click += button1_Click_3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Montserrat SemiBold", 17.9999981F, FontStyle.Bold);
            label6.Location = new Point(755, 352);
            label6.Name = "label6";
            label6.Size = new Size(253, 38);
            label6.TabIndex = 15;
            label6.Text = "profesores e escola";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat SemiBold", 17.9999981F, FontStyle.Bold);
            label5.Location = new Point(616, 300);
            label5.Name = "label5";
            label5.Size = new Size(513, 38);
            label5.TabIndex = 14;
            label5.Text = "Sitema completo para gestão de alunos,";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat SemiBold", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(250, 42, 85);
            label4.Location = new Point(890, 223);
            label4.Name = "label4";
            label4.Size = new Size(147, 38);
            label4.TabIndex = 13;
            label4.Text = "SportCorp!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat SemiBold", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(710, 223);
            label3.Name = "label3";
            label3.Size = new Size(196, 38);
            label3.TabIndex = 12;
            label3.Text = "Bem-vindo ao ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(250, 42, 85);
            label2.Location = new Point(642, 130);
            label2.Name = "label2";
            label2.Size = new Size(460, 25);
            label2.TabIndex = 11;
            label2.Text = "________________________________________________________";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(250, 42, 85);
            label1.Location = new Point(667, 43);
            label1.Name = "label1";
            label1.Size = new Size(383, 100);
            label1.TabIndex = 10;
            label1.Text = "SportCorp";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(250, -50);
            panel2.Name = "panel2";
            panel2.Size = new Size(541, 1000);
            panel2.TabIndex = 8;
            // 
            // Form_principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(panelSideMenu);
            Name = "Form_principal";
            Text = "tela inicial";
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            panelSideMenu.ResumeLayout(false);
            panelSideMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_menu;
        private Panel panel_subCadastro;
        private Button btn_cadastro;
        private Panel panel1;
        private Panel panelcadSubMenu;
        private Button btn_escola;
        private Button btn_professor;
        private Button btn_aluno;
        private Button btnMedia;
        private Panel panel_logo;
        private Panel panelSideMenu;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btn_aleatorio3;
        private Label label7;
        private Label label8;
        private Button btn_aleatorio2;
        private Label label9;
        private Button btn_aleatorio;
        private Button button4;
        private Button button1;
    }
}
