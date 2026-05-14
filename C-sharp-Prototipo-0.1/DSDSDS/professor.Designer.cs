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
            panel1 = new Panel();
            panelcadSubMenu = new Panel();
            btn_info = new Button();
            btnSelect = new Button();
            panel_logo = new Panel();
            groupBox2 = new GroupBox();
            lbl_numCasa = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            txtbox_estado = new TextBox();
            label1 = new Label();
            txtbox_bairro = new TextBox();
            label2 = new Label();
            txtbox_cidade = new TextBox();
            lbl_cidade = new Label();
            lbl_rua = new Label();
            txtbox_rua = new TextBox();
            groupBox1 = new GroupBox();
            lbl_idade = new Label();
            msk_cpf = new MaskedTextBox();
            lbl_cpf = new Label();
            txtbox_senhaProf = new TextBox();
            lbl_senha = new Label();
            txtbox_emailAluno = new TextBox();
            lbl_email = new Label();
            lbl_nome = new Label();
            txtbox_nome = new TextBox();
            msk_tel_prof = new MaskedTextBox();
            panel1.SuspendLayout();
            panelcadSubMenu.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
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
            panel1.Size = new Size(250, 749);
            panel1.TabIndex = 2;
            // 
            // panelcadSubMenu
            // 
            panelcadSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelcadSubMenu.Controls.Add(btn_info);
            panelcadSubMenu.Dock = DockStyle.Top;
            panelcadSubMenu.Location = new Point(0, 145);
            panelcadSubMenu.Name = "panelcadSubMenu";
            panelcadSubMenu.Size = new Size(250, 44);
            panelcadSubMenu.TabIndex = 2;
            // 
            // btn_info
            // 
            btn_info.Dock = DockStyle.Top;
            btn_info.FlatAppearance.BorderSize = 0;
            btn_info.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btn_info.FlatStyle = FlatStyle.Flat;
            btn_info.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_info.ForeColor = SystemColors.ButtonFace;
            btn_info.Location = new Point(0, 0);
            btn_info.Name = "btn_info";
            btn_info.Padding = new Padding(35, 0, 0, 0);
            btn_info.Size = new Size(250, 40);
            btn_info.TabIndex = 0;
            btn_info.Text = "Documentos";
            btn_info.TextAlign = ContentAlignment.MiddleLeft;
            btn_info.UseVisualStyleBackColor = true;
            btn_info.Click += btn_info_Click;
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
            btnSelect.Click += btnSelect_Click;
            // 
            // panel_logo
            // 
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 100);
            panel_logo.TabIndex = 0;
            panel_logo.Paint += panel_logo_Paint;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ButtonHighlight;
            groupBox2.Controls.Add(lbl_numCasa);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(txtbox_estado);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtbox_bairro);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtbox_cidade);
            groupBox2.Controls.Add(lbl_cidade);
            groupBox2.Controls.Add(lbl_rua);
            groupBox2.Controls.Add(txtbox_rua);
            groupBox2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(258, 429);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1018, 252);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Endereço";
            // 
            // lbl_numCasa
            // 
            lbl_numCasa.AutoSize = true;
            lbl_numCasa.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_numCasa.Location = new Point(409, 57);
            lbl_numCasa.Name = "lbl_numCasa";
            lbl_numCasa.Size = new Size(98, 18);
            lbl_numCasa.TabIndex = 12;
            lbl_numCasa.Text = "N° da casa";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(503, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(73, 27);
            textBox1.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(923, 123);
            button1.Name = "button1";
            button1.Size = new Size(89, 28);
            button1.TabIndex = 11;
            button1.Text = "Avançar";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtbox_estado
            // 
            txtbox_estado.Location = new Point(82, 194);
            txtbox_estado.Name = "txtbox_estado";
            txtbox_estado.Size = new Size(311, 27);
            txtbox_estado.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 197);
            label1.Name = "label1";
            label1.Size = new Size(64, 18);
            label1.TabIndex = 8;
            label1.Text = "Estado";
            // 
            // txtbox_bairro
            // 
            txtbox_bairro.Location = new Point(82, 150);
            txtbox_bairro.Name = "txtbox_bairro";
            txtbox_bairro.Size = new Size(311, 27);
            txtbox_bairro.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 153);
            label2.Name = "label2";
            label2.Size = new Size(56, 18);
            label2.TabIndex = 6;
            label2.Text = "Bairro";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtbox_cidade
            // 
            txtbox_cidade.Location = new Point(82, 97);
            txtbox_cidade.Name = "txtbox_cidade";
            txtbox_cidade.Size = new Size(311, 27);
            txtbox_cidade.TabIndex = 6;
            // 
            // lbl_cidade
            // 
            lbl_cidade.AutoSize = true;
            lbl_cidade.Location = new Point(6, 106);
            lbl_cidade.Name = "lbl_cidade";
            lbl_cidade.Size = new Size(64, 18);
            lbl_cidade.TabIndex = 5;
            lbl_cidade.Text = "Cidade";
            // 
            // lbl_rua
            // 
            lbl_rua.AutoSize = true;
            lbl_rua.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_rua.Location = new Point(11, 57);
            lbl_rua.Name = "lbl_rua";
            lbl_rua.Size = new Size(39, 18);
            lbl_rua.TabIndex = 3;
            lbl_rua.Text = "Rua";
            // 
            // txtbox_rua
            // 
            txtbox_rua.Location = new Point(82, 48);
            txtbox_rua.Name = "txtbox_rua";
            txtbox_rua.Size = new Size(311, 27);
            txtbox_rua.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(msk_tel_prof);
            groupBox1.Controls.Add(lbl_idade);
            groupBox1.Controls.Add(msk_cpf);
            groupBox1.Controls.Add(lbl_cpf);
            groupBox1.Controls.Add(txtbox_senhaProf);
            groupBox1.Controls.Add(lbl_senha);
            groupBox1.Controls.Add(txtbox_emailAluno);
            groupBox1.Controls.Add(lbl_email);
            groupBox1.Controls.Add(lbl_nome);
            groupBox1.Controls.Add(txtbox_nome);
            groupBox1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(258, 113);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1018, 252);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "  ";
            // 
            // lbl_idade
            // 
            lbl_idade.AutoSize = true;
            lbl_idade.Location = new Point(440, 54);
            lbl_idade.Name = "lbl_idade";
            lbl_idade.Size = new Size(77, 18);
            lbl_idade.TabIndex = 13;
            lbl_idade.Text = "Telefone";
            lbl_idade.Click += lbl_idade_Click;
            // 
            // msk_cpf
            // 
            msk_cpf.Location = new Point(84, 199);
            msk_cpf.Mask = "000.000.000-00";
            msk_cpf.Name = "msk_cpf";
            msk_cpf.Size = new Size(309, 27);
            msk_cpf.TabIndex = 11;
            // 
            // lbl_cpf
            // 
            lbl_cpf.AutoSize = true;
            lbl_cpf.Location = new Point(20, 197);
            lbl_cpf.Name = "lbl_cpf";
            lbl_cpf.Size = new Size(38, 18);
            lbl_cpf.TabIndex = 8;
            lbl_cpf.Text = "CPF";
            // 
            // txtbox_senhaProf
            // 
            txtbox_senhaProf.Location = new Point(82, 150);
            txtbox_senhaProf.Name = "txtbox_senhaProf";
            txtbox_senhaProf.Size = new Size(311, 27);
            txtbox_senhaProf.TabIndex = 7;
            // 
            // lbl_senha
            // 
            lbl_senha.AutoSize = true;
            lbl_senha.Location = new Point(20, 153);
            lbl_senha.Name = "lbl_senha";
            lbl_senha.Size = new Size(58, 18);
            lbl_senha.TabIndex = 6;
            lbl_senha.Text = "Senha";
            // 
            // txtbox_emailAluno
            // 
            txtbox_emailAluno.Location = new Point(82, 97);
            txtbox_emailAluno.Name = "txtbox_emailAluno";
            txtbox_emailAluno.Size = new Size(311, 27);
            txtbox_emailAluno.TabIndex = 6;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Location = new Point(22, 100);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(53, 18);
            lbl_email.TabIndex = 5;
            lbl_email.Text = "Email";
            // 
            // lbl_nome
            // 
            lbl_nome.AutoSize = true;
            lbl_nome.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_nome.Location = new Point(22, 51);
            lbl_nome.Name = "lbl_nome";
            lbl_nome.Size = new Size(55, 18);
            lbl_nome.TabIndex = 3;
            lbl_nome.Text = "Nome";
            // 
            // txtbox_nome
            // 
            txtbox_nome.Location = new Point(82, 48);
            txtbox_nome.Name = "txtbox_nome";
            txtbox_nome.Size = new Size(311, 27);
            txtbox_nome.TabIndex = 4;
            // 
            // msk_tel_prof
            // 
            msk_tel_prof.Location = new Point(523, 51);
            msk_tel_prof.Mask = "(00)-00000-0000";
            msk_tel_prof.Name = "msk_tel_prof";
            msk_tel_prof.Size = new Size(311, 27);
            msk_tel_prof.TabIndex = 15;
            // 
            // professor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1370, 749);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "professor";
            Text = "Professor";
            Load += professor_Load;
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelcadSubMenu;
        private Button btn_info;
        private Button btnSelect;
        private Panel panel_logo;
        private GroupBox groupBox2;
        private Label lbl_numCasa;
        private TextBox textBox1;
        private Button button1;
        private TextBox txtbox_estado;
        private Label label1;
        private TextBox txtbox_bairro;
        private Label label2;
        private TextBox txtbox_cidade;
        private Label lbl_cidade;
        private Label lbl_rua;
        private TextBox txtbox_rua;
        private GroupBox groupBox1;
        private Label lbl_idade;
        private MaskedTextBox msk_cpf;
        private Label lbl_cpf;
        private TextBox txtbox_senhaProf;
        private Label lbl_senha;
        private TextBox txtbox_emailAluno;
        private Label lbl_email;
        private Label lbl_nome;
        private TextBox txtbox_nome;
        private MaskedTextBox msk_tel_prof;
    }
}