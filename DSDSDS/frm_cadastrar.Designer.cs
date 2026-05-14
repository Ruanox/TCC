namespace DSDSDS
{
    partial class frm_cadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cadastrar));
            panel1 = new Panel();
            lbl_home = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            btn_professor = new Button();
            btn_aluno = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 150, 136);
            panel1.Controls.Add(lbl_home);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1269, 76);
            panel1.TabIndex = 3;
            // 
            // lbl_home
            // 
            lbl_home.AutoSize = true;
            lbl_home.Font = new Font("Verdana", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_home.ForeColor = SystemColors.ButtonHighlight;
            lbl_home.Location = new Point(612, 18);
            lbl_home.Name = "lbl_home";
            lbl_home.Size = new Size(310, 45);
            lbl_home.TabIndex = 1;
            lbl_home.Text = "CADASTRE-SE";
            lbl_home.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(51, 51, 76);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(252, 80);
            panel3.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Controls.Add(btn_professor);
            panel2.Controls.Add(btn_aluno);
            panel2.Dock = DockStyle.Left;
            panel2.ForeColor = Color.Black;
            panel2.Location = new Point(0, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 673);
            panel2.TabIndex = 4;
            // 
            // btn_professor
            // 
            btn_professor.BackColor = Color.SteelBlue;
            btn_professor.BackgroundImageLayout = ImageLayout.Center;
            btn_professor.Dock = DockStyle.Top;
            btn_professor.FlatAppearance.BorderSize = 0;
            btn_professor.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 68, 249);
            btn_professor.FlatStyle = FlatStyle.Flat;
            btn_professor.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_professor.ForeColor = Color.MidnightBlue;
            btn_professor.Image = (Image)resources.GetObject("btn_professor.Image");
            btn_professor.ImageAlign = ContentAlignment.MiddleLeft;
            btn_professor.Location = new Point(0, 60);
            btn_professor.Name = "btn_professor";
            btn_professor.Size = new Size(252, 60);
            btn_professor.TabIndex = 1;
            btn_professor.Text = "Professor";
            btn_professor.TextAlign = ContentAlignment.MiddleLeft;
            btn_professor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_professor.UseVisualStyleBackColor = false;
            btn_professor.Click += btn_professor_Click;
            // 
            // btn_aluno
            // 
            btn_aluno.BackColor = Color.SteelBlue;
            btn_aluno.BackgroundImageLayout = ImageLayout.Center;
            btn_aluno.Dock = DockStyle.Top;
            btn_aluno.FlatAppearance.BorderSize = 0;
            btn_aluno.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 39, 250);
            btn_aluno.FlatStyle = FlatStyle.Flat;
            btn_aluno.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_aluno.ForeColor = Color.Red;
            btn_aluno.Image = (Image)resources.GetObject("btn_aluno.Image");
            btn_aluno.ImageAlign = ContentAlignment.MiddleLeft;
            btn_aluno.Location = new Point(0, 0);
            btn_aluno.Name = "btn_aluno";
            btn_aluno.Size = new Size(252, 60);
            btn_aluno.TabIndex = 0;
            btn_aluno.Text = "Aluno";
            btn_aluno.TextAlign = ContentAlignment.MiddleLeft;
            btn_aluno.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_aluno.UseVisualStyleBackColor = false;
            btn_aluno.Click += btn_aluno_Click;
            // 
            // frm_cadastrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1269, 749);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frm_cadastrar";
            Text = "frm_cadastrar";
            Load += frm_cadastrar_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbl_home;
        private Panel panel3;
        private Panel panel2;
        private Button btn_aluno;
        private Button btn_professor;
    }
}