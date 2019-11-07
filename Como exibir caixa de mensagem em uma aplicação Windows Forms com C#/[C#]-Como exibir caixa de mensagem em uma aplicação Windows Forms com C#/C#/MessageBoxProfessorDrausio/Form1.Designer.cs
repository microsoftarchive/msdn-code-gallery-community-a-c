namespace MessageBoxProfessorDrausio
{
    partial class FrmCaixaMensagem
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
            this.linkLabelSiteProfessorDrausio = new System.Windows.Forms.LinkLabel();
            this.buttonCaixaMensagemSimples = new System.Windows.Forms.Button();
            this.buttonCaixaMensagemAtencao = new System.Windows.Forms.Button();
            this.buttonCaixaMensagemErro = new System.Windows.Forms.Button();
            this.buttonCaixaMensagemInformacao = new System.Windows.Forms.Button();
            this.buttonCaixaMensagemPergunta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabelSiteProfessorDrausio
            // 
            this.linkLabelSiteProfessorDrausio.AutoSize = true;
            this.linkLabelSiteProfessorDrausio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelSiteProfessorDrausio.Location = new System.Drawing.Point(12, 232);
            this.linkLabelSiteProfessorDrausio.Name = "linkLabelSiteProfessorDrausio";
            this.linkLabelSiteProfessorDrausio.Size = new System.Drawing.Size(335, 20);
            this.linkLabelSiteProfessorDrausio.TabIndex = 0;
            this.linkLabelSiteProfessorDrausio.TabStop = true;
            this.linkLabelSiteProfessorDrausio.Text = "http://www.youtube.com/user/professordrausio";
            this.linkLabelSiteProfessorDrausio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSiteProfessorDrausio_LinkClicked);
            // 
            // buttonCaixaMensagemSimples
            // 
            this.buttonCaixaMensagemSimples.Location = new System.Drawing.Point(16, 30);
            this.buttonCaixaMensagemSimples.Name = "buttonCaixaMensagemSimples";
            this.buttonCaixaMensagemSimples.Size = new System.Drawing.Size(266, 23);
            this.buttonCaixaMensagemSimples.TabIndex = 1;
            this.buttonCaixaMensagemSimples.Text = "Caixa de Mensagem Simples";
            this.buttonCaixaMensagemSimples.UseVisualStyleBackColor = true;
            this.buttonCaixaMensagemSimples.Click += new System.EventHandler(this.buttonCaixaMensagemSimples_Click);
            // 
            // buttonCaixaMensagemAtencao
            // 
            this.buttonCaixaMensagemAtencao.Location = new System.Drawing.Point(16, 59);
            this.buttonCaixaMensagemAtencao.Name = "buttonCaixaMensagemAtencao";
            this.buttonCaixaMensagemAtencao.Size = new System.Drawing.Size(266, 23);
            this.buttonCaixaMensagemAtencao.TabIndex = 2;
            this.buttonCaixaMensagemAtencao.Text = "Caixa de Mensagem Atenção";
            this.buttonCaixaMensagemAtencao.UseVisualStyleBackColor = true;
            this.buttonCaixaMensagemAtencao.Click += new System.EventHandler(this.buttonCaixaMensagemAtencao_Click);
            // 
            // buttonCaixaMensagemErro
            // 
            this.buttonCaixaMensagemErro.Location = new System.Drawing.Point(16, 88);
            this.buttonCaixaMensagemErro.Name = "buttonCaixaMensagemErro";
            this.buttonCaixaMensagemErro.Size = new System.Drawing.Size(266, 23);
            this.buttonCaixaMensagemErro.TabIndex = 3;
            this.buttonCaixaMensagemErro.Text = "Caixa de Mensagem Erro";
            this.buttonCaixaMensagemErro.UseVisualStyleBackColor = true;
            this.buttonCaixaMensagemErro.Click += new System.EventHandler(this.buttonCaixaMensagemErro_Click);
            // 
            // buttonCaixaMensagemInformacao
            // 
            this.buttonCaixaMensagemInformacao.Location = new System.Drawing.Point(16, 117);
            this.buttonCaixaMensagemInformacao.Name = "buttonCaixaMensagemInformacao";
            this.buttonCaixaMensagemInformacao.Size = new System.Drawing.Size(266, 23);
            this.buttonCaixaMensagemInformacao.TabIndex = 4;
            this.buttonCaixaMensagemInformacao.Text = "Caixa de Mensagem Informação";
            this.buttonCaixaMensagemInformacao.UseVisualStyleBackColor = true;
            this.buttonCaixaMensagemInformacao.Click += new System.EventHandler(this.buttonCaixaMensagemInformacao_Click);
            // 
            // buttonCaixaMensagemPergunta
            // 
            this.buttonCaixaMensagemPergunta.Location = new System.Drawing.Point(16, 146);
            this.buttonCaixaMensagemPergunta.Name = "buttonCaixaMensagemPergunta";
            this.buttonCaixaMensagemPergunta.Size = new System.Drawing.Size(266, 23);
            this.buttonCaixaMensagemPergunta.TabIndex = 5;
            this.buttonCaixaMensagemPergunta.Text = "Caixa de Mensagem Pergunta ( Confirmação )";
            this.buttonCaixaMensagemPergunta.UseVisualStyleBackColor = true;
            this.buttonCaixaMensagemPergunta.Click += new System.EventHandler(this.buttonCaixaMensagemPergunta_Click);
            // 
            // FrmCaixaMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 261);
            this.Controls.Add(this.buttonCaixaMensagemPergunta);
            this.Controls.Add(this.buttonCaixaMensagemInformacao);
            this.Controls.Add(this.buttonCaixaMensagemErro);
            this.Controls.Add(this.buttonCaixaMensagemAtencao);
            this.Controls.Add(this.buttonCaixaMensagemSimples);
            this.Controls.Add(this.linkLabelSiteProfessorDrausio);
            this.Name = "FrmCaixaMensagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Professor Drausio - Exemplo Caixa de Mensagem ( MessageBox )";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelSiteProfessorDrausio;
        private System.Windows.Forms.Button buttonCaixaMensagemSimples;
        private System.Windows.Forms.Button buttonCaixaMensagemAtencao;
        private System.Windows.Forms.Button buttonCaixaMensagemErro;
        private System.Windows.Forms.Button buttonCaixaMensagemInformacao;
        private System.Windows.Forms.Button buttonCaixaMensagemPergunta;
    }
}

