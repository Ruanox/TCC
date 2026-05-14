namespace DSDSDS
{
    partial class info_prof
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
            btn_info = new Button();
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
            panel1.TabIndex = 3;
            // 
            // panelcadSubMenu
            // 
            panelcadSubMenu.BackColor = Color.FromArgb(255, 128, 0);
            panelcadSubMenu.Controls.Add(btn_info);
            panelcadSubMenu.Dock = DockStyle.Top;
            panelcadSubMenu.Location = new Point(0, 145);
            panelcadSubMenu.Name = "panelcadSubMenu";
            panelcadSubMenu.Size = new Size(250, 44);
            panelcadSubMenu.TabIndex = 2;
            // 
            // btn_info
            // 
            btn_info.BackColor = Color.FromArgb(192, 0, 0);
            btn_info.Dock = DockStyle.Top;
            btn_info.FlatAppearance.BorderSize = 0;
            btn_info.FlatStyle = FlatStyle.Flat;
            btn_info.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_info.ForeColor = SystemColors.ButtonFace;
            btn_info.Location = new Point(0, 0);
            btn_info.Name = "btn_info";
            btn_info.Padding = new Padding(35, 0, 0, 0);
            btn_info.Size = new Size(250, 44);
            btn_info.TabIndex = 0;
            btn_info.Text = "Documentos";
            btn_info.TextAlign = ContentAlignment.MiddleLeft;
            btn_info.UseVisualStyleBackColor = false;
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
            btnSelect.Text = "Professor";
            btnSelect.TextAlign = ContentAlignment.MiddleLeft;
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // panel_logo
            // 
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 100);
            panel_logo.TabIndex = 0;
            // 
            // info_prof
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 751);
            Controls.Add(panel1);
            Name = "info_prof";
            Text = "info_prof";
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelcadSubMenu;
        private Button btn_info;
        private Button btnSelect;
        private Panel panel_logo;
    }
}