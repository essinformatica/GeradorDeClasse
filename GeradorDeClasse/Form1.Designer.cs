namespace GeradorDeClasse
{
    partial class Form1
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
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lstTabela = new System.Windows.Forms.ListBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtCampos = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbEntidade = new System.Windows.Forms.RadioButton();
            this.rdbBll = new System.Windows.Forms.RadioButton();
            this.rdbDal = new System.Windows.Forms.RadioButton();
            this.txtProcedure = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(41, 27);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(278, 20);
            this.txtBanco.TabIndex = 0;
            // 
            // lstTabela
            // 
            this.lstTabela.FormattingEnabled = true;
            this.lstTabela.Location = new System.Drawing.Point(41, 65);
            this.lstTabela.Name = "lstTabela";
            this.lstTabela.Size = new System.Drawing.Size(278, 95);
            this.lstTabela.TabIndex = 1;
            this.lstTabela.SelectedValueChanged += new System.EventHandler(this.lstTabela_SelectedValueChanged);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(41, 13);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(41, 13);
            this.lblBanco.TabIndex = 2;
            this.lblBanco.Text = "Banco:";
            // 
            // txtCampos
            // 
            this.txtCampos.Location = new System.Drawing.Point(366, 27);
            this.txtCampos.Multiline = true;
            this.txtCampos.Name = "txtCampos";
            this.txtCampos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCampos.Size = new System.Drawing.Size(426, 210);
            this.txtCampos.TabIndex = 3;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(366, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(38, 13);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "Classe";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(41, 200);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 5;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbEntidade);
            this.groupBox1.Controls.Add(this.rdbBll);
            this.groupBox1.Controls.Add(this.rdbDal);
            this.groupBox1.Location = new System.Drawing.Point(149, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 34);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de Classes";
            // 
            // rdbEntidade
            // 
            this.rdbEntidade.AutoSize = true;
            this.rdbEntidade.Location = new System.Drawing.Point(92, 14);
            this.rdbEntidade.Name = "rdbEntidade";
            this.rdbEntidade.Size = new System.Drawing.Size(67, 17);
            this.rdbEntidade.TabIndex = 8;
            this.rdbEntidade.TabStop = true;
            this.rdbEntidade.Text = "Entidade";
            this.rdbEntidade.UseVisualStyleBackColor = true;
            // 
            // rdbBll
            // 
            this.rdbBll.AutoSize = true;
            this.rdbBll.Location = new System.Drawing.Point(50, 14);
            this.rdbBll.Name = "rdbBll";
            this.rdbBll.Size = new System.Drawing.Size(36, 17);
            this.rdbBll.TabIndex = 7;
            this.rdbBll.TabStop = true;
            this.rdbBll.Text = "Bll";
            this.rdbBll.UseVisualStyleBackColor = true;
            // 
            // rdbDal
            // 
            this.rdbDal.AutoSize = true;
            this.rdbDal.Location = new System.Drawing.Point(3, 14);
            this.rdbDal.Name = "rdbDal";
            this.rdbDal.Size = new System.Drawing.Size(41, 17);
            this.rdbDal.TabIndex = 0;
            this.rdbDal.TabStop = true;
            this.rdbDal.Text = "Dal";
            this.rdbDal.UseVisualStyleBackColor = true;
            this.rdbDal.CheckedChanged += new System.EventHandler(this.rdbDal_CheckedChanged);
            // 
            // txtProcedure
            // 
            this.txtProcedure.Location = new System.Drawing.Point(798, 27);
            this.txtProcedure.Multiline = true;
            this.txtProcedure.Name = "txtProcedure";
            this.txtProcedure.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProcedure.Size = new System.Drawing.Size(426, 210);
            this.txtProcedure.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(795, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Procedure";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 270);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProcedure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCampos);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.lstTabela);
            this.Controls.Add(this.txtBanco);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Classe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.ListBox lstTabela;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtCampos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbEntidade;
        private System.Windows.Forms.RadioButton rdbBll;
        private System.Windows.Forms.RadioButton rdbDal;
        private System.Windows.Forms.TextBox txtProcedure;
        private System.Windows.Forms.Label label1;
    }
}

