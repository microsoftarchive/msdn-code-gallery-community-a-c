using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxProfessorDrausio
{
    public partial class FrmCaixaMensagem : Form
    {
        public FrmCaixaMensagem()
        {
            InitializeComponent();
        }

        private void buttonCaixaMensagemSimples_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mensagem Simples");
        }

        private void buttonCaixaMensagemAtencao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atenção, campo X obrigatório", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonCaixaMensagemErro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Erro ao cadastrar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonCaixaMensagemInformacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCaixaMensagemPergunta_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                //Ação/código caso o usuário aperte o botão Yes (se o idioma do computador for em português será SIM )
                MessageBox.Show("Apertou Sim");
            }
            else
            {
                //Ação/código caso o usuário aperte o botão No (se o idioma do computador for em português será NÃO )
                MessageBox.Show("Apertou Não");
            }
        }

        private void linkLabelSiteProfessorDrausio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.youtube.com/user/professordrausio");
        }


    }
}
