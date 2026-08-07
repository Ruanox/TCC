namespace DSDSDS
{
    partial class professor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(professor));
            panel1 = new Panel();
            panelcadSubMenu = new Panel();
            btn_menu = new Button();
            btn_info = new Button();
            btnSelect = new Button();
            panel_logo = new Panel();
            panel2 = new Panel();
            txtbox_senha = new TextBox();
            txtbox_usuario = new TextBox();
            pictureBox1 = new PictureBox();
            btn_confirmar = new Button();
            label3 = new Label();
            lbl_senha = new Label();
            lbl_usuario = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panelcadSubMenu.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panelcadSubMenu);
            panel1.Controls.Add(btnSelect);
            panel1.Controls.Add(panel_logo);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 1041);
            panel1.TabIndex = 2;
            // 
            // panelcadSubMenu
            // 
            panelcadSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelcadSubMenu.Controls.Add(btn_menu);
            panelcadSubMenu.Controls.Add(btn_info);
            panelcadSubMenu.Dock = DockStyle.Top;
            panelcadSubMenu.Location = new Point(0, 145);
            panelcadSubMenu.Name = "panelcadSubMenu";
            panelcadSubMenu.Size = new Size(250, 78);
            panelcadSubMenu.TabIndex = 2;
            // 
            // btn_menu
            // 
            btn_menu.BackColor = Color.WhiteSmoke;
            btn_menu.Dock = DockStyle.Top;
            btn_menu.FlatAppearance.BorderSize = 0;
            btn_menu.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btn_menu.FlatStyle = FlatStyle.Flat;
            btn_menu.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_menu.ForeColor = Color.FromArgb(31, 41, 55);
            btn_menu.Image = (Image)resources.GetObject("btn_menu.Image");
            btn_menu.Location = new Point(0, 41);
            btn_menu.Name = "btn_menu";
            btn_menu.Padding = new Padding(35, 0, 0, 0);
            btn_menu.Size = new Size(250, 37);
            btn_menu.TabIndex = 1;
            btn_menu.Text = "Menu";
            btn_menu.TextAlign = ContentAlignment.MiddleLeft;
            btn_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_menu.UseVisualStyleBackColor = false;
            btn_menu.Click += button1_Click_1;
            // 
            // btn_info
            // 
            btn_info.BackColor = Color.FromArgb(250, 42, 85);
            btn_info.Dock = DockStyle.Top;
            btn_info.FlatAppearance.BorderSize = 0;
            btn_info.FlatStyle = FlatStyle.Flat;
            btn_info.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_info.ForeColor = Color.FromArgb(31, 41, 55);
            btn_info.Image = (Image)resources.GetObject("btn_info.Image");
            btn_info.Location = new Point(0, 0);
            btn_info.Name = "btn_info";
            btn_info.Padding = new Padding(35, 0, 0, 0);
            btn_info.Size = new Size(250, 41);
            btn_info.TabIndex = 0;
            btn_info.Text = "Login";
            btn_info.TextAlign = ContentAlignment.MiddleLeft;
            btn_info.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_info.UseVisualStyleBackColor = false;
            btn_info.Click += btn_info_Click;
            // 
            // btnSelect
            // 
            btnSelect.Dock = DockStyle.Top;
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Font = new Font("Tahoma", 15F);
            btnSelect.ForeColor = SystemColors.ControlText;
            btnSelect.Image = (Image)resources.GetObject("btnSelect.Image");
            btnSelect.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelect.Location = new Point(0, 100);
            btnSelect.Name = "btnSelect";
            btnSelect.Padding = new Padding(10, 0, 0, 0);
            btnSelect.Size = new Size(250, 45);
            btnSelect.TabIndex = 1;
            btnSelect.Text = "Professor";
            btnSelect.TextAlign = ContentAlignment.MiddleLeft;
            btnSelect.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // panel_logo
            // 
            panel_logo.BackgroundImage = (Image)resources.GetObject("panel_logo.BackgroundImage");
            panel_logo.BackgroundImageLayout = ImageLayout.Center;
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 100);
            panel_logo.TabIndex = 0;
            panel_logo.Paint += panel_logo_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtbox_senha);
            panel2.Controls.Add(txtbox_usuario);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btn_confirmar);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lbl_senha);
            panel2.Controls.Add(lbl_usuario);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(741, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(556, 1080);
            panel2.TabIndex = 12;
            // 
            // txtbox_senha
            // 
            txtbox_senha.Location = new Point(84, 515);
            txtbox_senha.Name = "txtbox_senha";
            txtbox_senha.Size = new Size(305, 27);
            txtbox_senha.TabIndex = 6;
            // 
            // txtbox_usuario
            // 
            txtbox_usuario.Location = new Point(84, 373);
            txtbox_usuario.Name = "txtbox_usuario";
            txtbox_usuario.Size = new Size(305, 27);
            txtbox_usuario.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(237, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 86);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btn_confirmar
            // 
            btn_confirmar.BackColor = Color.FromArgb(250, 42, 85);
            btn_confirmar.ForeColor = Color.White;
            btn_confirmar.Location = new Point(105, 725);
            btn_confirmar.Name = "btn_confirmar";
            btn_confirmar.Size = new Size(352, 45);
            btn_confirmar.TabIndex = 10;
            btn_confirmar.Text = "Confirmar";
            btn_confirmar.UseVisualStyleBackColor = false;
            btn_confirmar.Click += btn_confirmar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(221, 114);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(139, 29);
            label3.TabIndex = 2;
            label3.Text = "Faça Login";
            // 
            // lbl_senha
            // 
            lbl_senha.AutoSize = true;
            lbl_senha.BackColor = Color.Transparent;
            lbl_senha.Font = new Font("Montserrat", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_senha.Image = (Image)resources.GetObject("lbl_senha.Image");
            lbl_senha.ImageAlign = ContentAlignment.MiddleLeft;
            lbl_senha.Location = new Point(84, 470);
            lbl_senha.Name = "lbl_senha";
            lbl_senha.Size = new Size(145, 42);
            lbl_senha.TabIndex = 7;
            lbl_senha.Text = "      Senha";
            lbl_senha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_usuario
            // 
            lbl_usuario.AutoSize = true;
            lbl_usuario.Font = new Font("Montserrat", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_usuario.Image = (Image)resources.GetObject("lbl_usuario.Image");
            lbl_usuario.ImageAlign = ContentAlignment.MiddleLeft;
            lbl_usuario.Location = new Point(84, 317);
            lbl_usuario.Name = "lbl_usuario";
            lbl_usuario.Size = new Size(156, 42);
            lbl_usuario.TabIndex = 5;
            lbl_usuario.Text = "     Usuario";
            lbl_usuario.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(175, 162);
            label2.Name = "label2";
            label2.Size = new Size(248, 24);
            label2.TabIndex = 1;
            label2.Text = "acesse sua conta para continuar\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(-4, 187);
            label1.Name = "label1";
            label1.Size = new Size(732, 25);
            label1.TabIndex = 0;
            label1.Text = "__________________________________________________________________________________________";
            // 
            // professor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "professor";
            Text = "Professor";
            Load += professor_Load;
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelcadSubMenu;
        private Button btn_info;
        private Button btnSelect;
        private Panel panel_logo;
        private Panel panel2;
        private TextBox txtbox_senha;
        private TextBox txtbox_usuario;
        private PictureBox pictureBox1;
        private Button btn_confirmar;
        private Label label3;
        private Label lbl_senha;
        private Label lbl_usuario;
        private Label label2;
        private Label label1;
        private Button btn_menu;
    }
}