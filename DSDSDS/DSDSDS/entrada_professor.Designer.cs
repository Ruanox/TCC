namespace DSDSDS
{
    partial class entrada_professor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(entrada_professor));
            panel1 = new Panel();
            panelcadSubMenu = new Panel();
            btn_info = new Button();
            btnSelect = new Button();
            panel_logo = new Panel();
            panel1.SuspendLayout();
            panelcadSubMenu.SuspendLayout();
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
            panel1.Size = new Size(250, 749);
            panel1.TabIndex = 3;
            // 
            // panelcadSubMenu
            // 
            panelcadSubMenu.BackColor = Color.FromArgb(243, 244, 246);
            panelcadSubMenu.Controls.Add(btn_info);
            panelcadSubMenu.Dock = DockStyle.Top;
            panelcadSubMenu.Location = new Point(0, 145);
            panelcadSubMenu.Name = "panelcadSubMenu";
            panelcadSubMenu.Size = new Size(250, 59);
            panelcadSubMenu.TabIndex = 2;
            // 
            // btn_info
            // 
            btn_info.BackColor = Color.FromArgb(250, 42, 85);
            btn_info.Dock = DockStyle.Top;
            btn_info.FlatAppearance.BorderSize = 0;
            btn_info.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btn_info.FlatStyle = FlatStyle.Flat;
            btn_info.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_info.ForeColor = Color.FromArgb(31, 41, 55);
            btn_info.Image = (Image)resources.GetObject("btn_info.Image");
            btn_info.ImageAlign = ContentAlignment.MiddleLeft;
            btn_info.Location = new Point(0, 0);
            btn_info.Name = "btn_info";
            btn_info.Padding = new Padding(35, 0, 0, 0);
            btn_info.Size = new Size(250, 47);
            btn_info.TabIndex = 0;
            btn_info.Text = "Cadastrar alunos";
            btn_info.TextAlign = ContentAlignment.MiddleLeft;
            btn_info.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_info.UseVisualStyleBackColor = false;
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
            // 
            // entrada_professor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            ClientSize = new Size(1370, 749);
            Controls.Add(panel1);
            Name = "entrada_professor";
            Text = "entrada_professor";
            Load += entrada_professor_Load;
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelcadSubMenu;
        private Button btnSelect;
        private Panel panel_logo;
        private Button btn_info;
    }
}