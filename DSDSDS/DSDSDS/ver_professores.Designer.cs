namespace DSDSDS
{
    partial class ver_professores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ver_professores));
            dataGridView1 = new DataGridView();
            btn_consultar = new Button();
            artanPanel1 = new ArtanPanel();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            artanPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(20, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(842, 424);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btn_consultar
            // 
            btn_consultar.BackgroundImage = (Image)resources.GetObject("btn_consultar.BackgroundImage");
            btn_consultar.BackgroundImageLayout = ImageLayout.Center;
            btn_consultar.Location = new Point(1005, 109);
            btn_consultar.Name = "btn_consultar";
            btn_consultar.Size = new Size(75, 40);
            btn_consultar.TabIndex = 1;
            btn_consultar.UseVisualStyleBackColor = true;
            btn_consultar.Click += btn_consultar_Click;
            // 
            // artanPanel1
            // 
            artanPanel1.BackColor = Color.White;
            artanPanel1.BorderRadius = 30;
            artanPanel1.Controls.Add(dataGridView1);
            artanPanel1.ForeColor = Color.Black;
            artanPanel1.GradientAngle = 90F;
            artanPanel1.GradientBottomColor = Color.CadetBlue;
            artanPanel1.GradientTopColor = Color.DodgerBlue;
            artanPanel1.Location = new Point(55, 62);
            artanPanel1.Name = "artanPanel1";
            artanPanel1.Padding = new Padding(20, 0, 20, 0);
            artanPanel1.Size = new Size(882, 424);
            artanPanel1.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Id";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Nome";
            Column2.Name = "Column2";
            // 
            // ver_professores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(artanPanel1);
            Controls.Add(btn_consultar);
            Name = "ver_professores";
            Text = "ver_professores";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            artanPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_consultar;
        private ArtanPanel artanPanel1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}