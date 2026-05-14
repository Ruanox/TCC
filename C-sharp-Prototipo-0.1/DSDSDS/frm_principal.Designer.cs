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
            panelSideMenu = new Panel();
            panel1 = new Panel();
            panelcadSubMenu = new Panel();
            btn_escola = new Button();
            btn_professor = new Button();
            btn_aluno = new Button();
            btnMedia = new Button();
            panel_logo = new Panel();
            panelSideMenu.SuspendLayout();
            panel1.SuspendLayout();
            panelcadSubMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = Color.White;
            panelSideMenu.Controls.Add(panel1);
            panelSideMenu.Dock = DockStyle.Fill;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.MinimumSize = new Size(900, 950);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(1308, 950);
            panelSideMenu.TabIndex = 2;
            panelSideMenu.Paint += panel3_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 7, 17);
            panel1.Controls.Add(panelcadSubMenu);
            panel1.Controls.Add(btnMedia);
            panel1.Controls.Add(panel_logo);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 950);
            panel1.TabIndex = 0;
            // 
            // panelcadSubMenu
            // 
            panelcadSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelcadSubMenu.Controls.Add(btn_escola);
            panelcadSubMenu.Controls.Add(btn_professor);
            panelcadSubMenu.Controls.Add(btn_aluno);
            panelcadSubMenu.Dock = DockStyle.Top;
            panelcadSubMenu.Location = new Point(0, 145);
            panelcadSubMenu.Name = "panelcadSubMenu";
            panelcadSubMenu.Size = new Size(250, 121);
            panelcadSubMenu.TabIndex = 2;
            // 
            // btn_escola
            // 
            btn_escola.Dock = DockStyle.Top;
            btn_escola.FlatAppearance.BorderSize = 0;
            btn_escola.FlatStyle = FlatStyle.Flat;
            btn_escola.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_escola.ForeColor = SystemColors.ButtonFace;
            btn_escola.Location = new Point(0, 80);
            btn_escola.Name = "btn_escola";
            btn_escola.Padding = new Padding(35, 0, 0, 0);
            btn_escola.Size = new Size(250, 40);
            btn_escola.TabIndex = 2;
            btn_escola.Text = "Escola";
            btn_escola.TextAlign = ContentAlignment.MiddleLeft;
            btn_escola.UseVisualStyleBackColor = true;
            btn_escola.Click += btn_escola_Click;
            // 
            // btn_professor
            // 
            btn_professor.Dock = DockStyle.Top;
            btn_professor.FlatAppearance.BorderSize = 0;
            btn_professor.FlatStyle = FlatStyle.Flat;
            btn_professor.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_professor.ForeColor = SystemColors.ButtonFace;
            btn_professor.Location = new Point(0, 40);
            btn_professor.Name = "btn_professor";
            btn_professor.Padding = new Padding(35, 0, 0, 0);
            btn_professor.Size = new Size(250, 40);
            btn_professor.TabIndex = 1;
            btn_professor.Text = "Professor";
            btn_professor.TextAlign = ContentAlignment.MiddleLeft;
            btn_professor.UseVisualStyleBackColor = true;
            btn_professor.Click += button2_Click_1;
            // 
            // btn_aluno
            // 
            btn_aluno.Dock = DockStyle.Top;
            btn_aluno.FlatAppearance.BorderSize = 0;
            btn_aluno.FlatStyle = FlatStyle.Flat;
            btn_aluno.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_aluno.ForeColor = SystemColors.ButtonFace;
            btn_aluno.Location = new Point(0, 0);
            btn_aluno.Name = "btn_aluno";
            btn_aluno.Padding = new Padding(35, 0, 0, 0);
            btn_aluno.Size = new Size(250, 40);
            btn_aluno.TabIndex = 0;
            btn_aluno.Text = "Aluno";
            btn_aluno.TextAlign = ContentAlignment.MiddleLeft;
            btn_aluno.UseVisualStyleBackColor = true;
            btn_aluno.Click += button1_Click_1;
            // 
            // btnMedia
            // 
            btnMedia.Dock = DockStyle.Top;
            btnMedia.FlatAppearance.BorderSize = 0;
            btnMedia.FlatStyle = FlatStyle.Flat;
            btnMedia.Font = new Font("Tahoma", 15F);
            btnMedia.ForeColor = SystemColors.Control;
            btnMedia.Location = new Point(0, 100);
            btnMedia.Name = "btnMedia";
            btnMedia.Padding = new Padding(10, 0, 0, 0);
            btnMedia.Size = new Size(250, 45);
            btnMedia.TabIndex = 1;
            btnMedia.Text = "Cadastro";
            btnMedia.TextAlign = ContentAlignment.MiddleLeft;
            btnMedia.UseVisualStyleBackColor = true;
            btnMedia.Click += btnMedia_Click;
            // 
            // panel_logo
            // 
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 100);
            panel_logo.TabIndex = 0;
            // 
            // Form_principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 749);
            Controls.Add(panelSideMenu);
            Name = "Form_principal";
            Text = "tela inicial";
            Load += Form1_Load;
            panelSideMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_menu;
        private Panel panel_subCadastro;
        private Button btn_professor;
        private Button btn_aluno;
        private Button btn_cadastro;
        private Panel panelSideMenu;
        private Panel panel1;
        private Panel panelcadSubMenu;   
        private Button btnMedia;
        private Panel panel_logo;
        private Button btn_escola;
    }
}
