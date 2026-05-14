namespace DSDSDS
{
    partial class escola
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
            panel1 = new Panel();
            panelcadSubMenu = new Panel();
            btn_escola = new Button();
            btnSelect = new Button();
            panel_logo = new Panel();
            panel1.SuspendLayout();
            panelcadSubMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 7, 17);
            panel1.Controls.Add(panelcadSubMenu);
            panel1.Controls.Add(btnSelect);
            panel1.Controls.Add(panel_logo);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 751);
            panel1.TabIndex = 2;
            // 
            // panelcadSubMenu
            // 
            panelcadSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelcadSubMenu.Controls.Add(btn_escola);
            panelcadSubMenu.Dock = DockStyle.Top;
            panelcadSubMenu.Location = new Point(0, 145);
            panelcadSubMenu.Name = "panelcadSubMenu";
            panelcadSubMenu.Size = new Size(250, 45);
            panelcadSubMenu.TabIndex = 2;
            // 
            // btn_escola
            // 
            btn_escola.Dock = DockStyle.Top;
            btn_escola.FlatAppearance.BorderSize = 0;
            btn_escola.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 8, 98);
            btn_escola.FlatStyle = FlatStyle.Flat;
            btn_escola.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_escola.ForeColor = SystemColors.ButtonFace;
            btn_escola.Location = new Point(0, 0);
            btn_escola.Name = "btn_escola";
            btn_escola.Padding = new Padding(35, 0, 0, 0);
            btn_escola.Size = new Size(250, 40);
            btn_escola.TabIndex = 1;
            btn_escola.Text = "Documentação";
            btn_escola.TextAlign = ContentAlignment.MiddleLeft;
            btn_escola.UseVisualStyleBackColor = false;
            btn_escola.Click += btn_escola_Click_1;
            // 
            // btnSelect
            // 
            btnSelect.Dock = DockStyle.Top;
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Font = new Font("Tahoma", 15F);
            btnSelect.ForeColor = SystemColors.Control;
            btnSelect.Location = new Point(0, 100);
            btnSelect.Name = "btnSelect";
            btnSelect.Padding = new Padding(10, 0, 0, 0);
            btnSelect.Size = new Size(250, 45);
            btnSelect.TabIndex = 1;
            btnSelect.Text = "Escola";
            btnSelect.TextAlign = ContentAlignment.MiddleLeft;
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // panel_logo
            // 
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 100);
            panel_logo.TabIndex = 0;
            // 
            // escola
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 751);
            Controls.Add(panel1);
            Name = "escola";
            Text = "escola";
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelcadSubMenu;
        private Button btn_escola;
        private Button btnSelect;
        private Panel panel_logo;
    }
}