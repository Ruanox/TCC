namespace DSDSDS
{
    partial class Documentos_escola
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
            group_Escola = new GroupBox();
            txtbox_bairro = new TextBox();
            lbl_bairro = new Label();
            txtbox_rua = new TextBox();
            lbl_rua = new Label();
            txtbox_estado = new TextBox();
            label3 = new Label();
            txtbox_cidade = new TextBox();
            lbl_cidade = new Label();
            label1 = new Label();
            btn_seguinte = new Button();
            msk_tel = new MaskedTextBox();
            lbl_tel = new Label();
            txtbox_email = new TextBox();
            lbl_email = new Label();
            txtbox_nome = new TextBox();
            lbl_nome = new Label();
            txtbox_senha = new TextBox();
            panel1.SuspendLayout();
            panelcadSubMenu.SuspendLayout();
            group_Escola.SuspendLayout();
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
            panel1.TabIndex = 3;
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
            btn_escola.BackColor = Color.FromArgb(50, 8, 98);
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
            // 
            // panel_logo
            // 
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(250, 100);
            panel_logo.TabIndex = 0;
            // 
            // group_Escola
            // 
            group_Escola.BackColor = SystemColors.ButtonHighlight;
            group_Escola.Controls.Add(txtbox_senha);
            group_Escola.Controls.Add(txtbox_bairro);
            group_Escola.Controls.Add(lbl_bairro);
            group_Escola.Controls.Add(txtbox_rua);
            group_Escola.Controls.Add(lbl_rua);
            group_Escola.Controls.Add(txtbox_estado);
            group_Escola.Controls.Add(label3);
            group_Escola.Controls.Add(txtbox_cidade);
            group_Escola.Controls.Add(lbl_cidade);
            group_Escola.Controls.Add(label1);
            group_Escola.Controls.Add(btn_seguinte);
            group_Escola.Controls.Add(msk_tel);
            group_Escola.Controls.Add(lbl_tel);
            group_Escola.Controls.Add(txtbox_email);
            group_Escola.Controls.Add(lbl_email);
            group_Escola.Controls.Add(txtbox_nome);
            group_Escola.Controls.Add(lbl_nome);
            group_Escola.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            group_Escola.Location = new Point(256, 145);
            group_Escola.Name = "group_Escola";
            group_Escola.Size = new Size(1092, 334);
            group_Escola.TabIndex = 4;
            group_Escola.TabStop = false;
            group_Escola.Text = "Informe as seguintes informações";
            // 
            // txtbox_bairro
            // 
            txtbox_bairro.Location = new Point(561, 228);
            txtbox_bairro.Name = "txtbox_bairro";
            txtbox_bairro.Size = new Size(311, 26);
            txtbox_bairro.TabIndex = 18;
            // 
            // lbl_bairro
            // 
            lbl_bairro.AutoSize = true;
            lbl_bairro.Location = new Point(466, 234);
            lbl_bairro.Name = "lbl_bairro";
            lbl_bairro.Size = new Size(52, 18);
            lbl_bairro.TabIndex = 17;
            lbl_bairro.Text = "Bairro";
            lbl_bairro.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtbox_rua
            // 
            txtbox_rua.Location = new Point(561, 169);
            txtbox_rua.Name = "txtbox_rua";
            txtbox_rua.Size = new Size(311, 26);
            txtbox_rua.TabIndex = 16;
            // 
            // lbl_rua
            // 
            lbl_rua.AutoSize = true;
            lbl_rua.Location = new Point(466, 169);
            lbl_rua.Name = "lbl_rua";
            lbl_rua.Size = new Size(36, 18);
            lbl_rua.TabIndex = 15;
            lbl_rua.Text = "Rua";
            // 
            // txtbox_estado
            // 
            txtbox_estado.Location = new Point(561, 109);
            txtbox_estado.Name = "txtbox_estado";
            txtbox_estado.Size = new Size(311, 26);
            txtbox_estado.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(466, 117);
            label3.Name = "label3";
            label3.Size = new Size(59, 18);
            label3.TabIndex = 13;
            label3.Text = "Estado";
            // 
            // txtbox_cidade
            // 
            txtbox_cidade.Location = new Point(561, 57);
            txtbox_cidade.Name = "txtbox_cidade";
            txtbox_cidade.Size = new Size(311, 26);
            txtbox_cidade.TabIndex = 12;
            // 
            // lbl_cidade
            // 
            lbl_cidade.AutoSize = true;
            lbl_cidade.Location = new Point(466, 65);
            lbl_cidade.Name = "lbl_cidade";
            lbl_cidade.Size = new Size(58, 18);
            lbl_cidade.TabIndex = 11;
            lbl_cidade.Text = "Cidade";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 227);
            label1.Name = "label1";
            label1.Size = new Size(54, 18);
            label1.TabIndex = 7;
            label1.Text = "Senha";
            // 
            // btn_seguinte
            // 
            btn_seguinte.Location = new Point(954, 155);
            btn_seguinte.Name = "btn_seguinte";
            btn_seguinte.Size = new Size(132, 32);
            btn_seguinte.TabIndex = 6;
            btn_seguinte.Text = "Salvar";
            btn_seguinte.UseVisualStyleBackColor = true;
            btn_seguinte.Click += btn__Click;
            // 
            // msk_tel
            // 
            msk_tel.Location = new Point(117, 166);
            msk_tel.Mask = "(00)-00000-0000";
            msk_tel.Name = "msk_tel";
            msk_tel.Size = new Size(311, 26);
            msk_tel.TabIndex = 5;
            // 
            // lbl_tel
            // 
            lbl_tel.AutoSize = true;
            lbl_tel.Location = new Point(22, 169);
            lbl_tel.Name = "lbl_tel";
            lbl_tel.Size = new Size(69, 18);
            lbl_tel.TabIndex = 4;
            lbl_tel.Text = "Telefone";
            // 
            // txtbox_email
            // 
            txtbox_email.Location = new Point(117, 109);
            txtbox_email.Name = "txtbox_email";
            txtbox_email.Size = new Size(311, 26);
            txtbox_email.TabIndex = 3;
            txtbox_email.TextChanged += txtbox_email_TextChanged;
            txtbox_email.KeyPress += txtbox_email_KeyPress;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Location = new Point(22, 117);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(47, 18);
            lbl_email.TabIndex = 2;
            lbl_email.Text = "Email";
            // 
            // txtbox_nome
            // 
            txtbox_nome.Location = new Point(117, 52);
            txtbox_nome.Name = "txtbox_nome";
            txtbox_nome.Size = new Size(311, 26);
            txtbox_nome.TabIndex = 1;
            // 
            // lbl_nome
            // 
            lbl_nome.AutoSize = true;
            lbl_nome.Location = new Point(22, 60);
            lbl_nome.Name = "lbl_nome";
            lbl_nome.Size = new Size(53, 18);
            lbl_nome.TabIndex = 0;
            lbl_nome.Text = "Nome";
            // 
            // txtbox_senha
            // 
            txtbox_senha.Location = new Point(117, 231);
            txtbox_senha.Name = "txtbox_senha";
            txtbox_senha.Size = new Size(311, 26);
            txtbox_senha.TabIndex = 19;
            // 
            // Documentos_escola
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(group_Escola);
            Controls.Add(panel1);
            Name = "Documentos_escola";
            Text = "Documentos_escola";
            panel1.ResumeLayout(false);
            panelcadSubMenu.ResumeLayout(false);
            group_Escola.ResumeLayout(false);
            group_Escola.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelcadSubMenu;
        private Button btn_escola;
        private Button btnSelect;
        private Panel panel_logo;
        private GroupBox group_Escola;
        private MaskedTextBox msk_tel;
        private Label lbl_tel;
        private TextBox txtbox_email;
        private Label lbl_email;
        private TextBox txtbox_nome;
        private Label lbl_nome;
        private Label label1;
        private Button btn_seguinte;
        private TextBox txtbox_bairro;
        private Label lbl_bairro;
        private TextBox txtbox_rua;
        private Label lbl_rua;
        private TextBox txtbox_estado;
        private Label label3;
        private TextBox txtbox_cidade;
        private Label lbl_cidade;
        private TextBox txtbox_senha;
    }
}