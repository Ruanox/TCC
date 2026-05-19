namespace TCC
{
    partial class Form1
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
            gradient_panel1 = new gradient_panel();
            label1 = new Label();
            gradient_panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gradient_panel1
            // 
            gradient_panel1.ColorBottom = Color.FromArgb(26, 0, 43);
            gradient_panel1.ColorTop = Color.FromArgb(178, 45, 201);
            gradient_panel1.Controls.Add(label1);
            gradient_panel1.Dock = DockStyle.Left;
            gradient_panel1.Location = new Point(0, 0);
            gradient_panel1.Name = "gradient_panel1";
            gradient_panel1.Size = new Size(403, 724);
            gradient_panel1.TabIndex = 0;
            gradient_panel1.Paint += gradient_panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 76);
            label1.Name = "label1";
            label1.Size = new Size(75, 27);
            label1.TabIndex = 1;
            label1.Text = "Login";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 724);
            Controls.Add(gradient_panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            gradient_panel1.ResumeLayout(false);
            gradient_panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private gradient_panel gradient_panel1;
        private Label label1;
    }
}
