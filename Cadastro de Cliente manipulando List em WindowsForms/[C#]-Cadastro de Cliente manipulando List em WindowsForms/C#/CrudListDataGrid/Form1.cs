using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CrudListDataGrid
{
    public partial class Form1 : Form
    {
        //Utilizei os seguinte controles
        //dois textbox com nome txtNome, txtNomefilme
        //um maskedTextBox com nome mskData
        //button btnSalvar, btnAlterar, btnExcluir
        //DataGridView dgvClientes, com a opção selectionMode para fullrollselect



        public Form1()
        {
            InitializeComponent();
        }

        //Classe cliente e seus atributos....
        public class Cliente
        {
            public int Codigo { get; set; }
            public String Nome { get; set; }
            public string NomeFilme { get; set; }
            public DateTime Data { get; set; }
        }

        //lista de cliente que será manipulada
        private List<Cliente> lista = new List<Cliente>();

        //variáel que servirá de controle para saber 
        //se está alterando ou adicionando um objeto
        private int codigo = -1;

        //Evento load do formulário
        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaDataGridView();
        }

        //Método que carrega o gridview
        private void CarregaDataGridView()
        {
            //Atribuo a lista ordenando por data ...
            dgvCliente.DataSource = lista.OrderBy(x => x.Data).ToList();
        }

        //método que retorna o proximo codigo
        //como se fosse um autoincremeto
        private int ObterCodigo()
        {
            int retorno = 0;
            //se a lista estiver vazia retorna o código 1
            if (lista.Count == 0)
            {
                retorno = 1;
                return retorno;
            }
            //senão retona o maior código da lista mais 1
            else
            {
                retorno = lista.Max(x => x.Codigo) + 1;
                return retorno;
            }
        }

        //método para limpar o textbox e maskedbox
        private void LimpaControles()
        {
            txtNome.Text = "";
            txtNomeFilme.Text = "";
            mskData.Text = "";

        }

        //Click do botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //se a variável codigo for -1 é porque é um novo 
            //cliente a ser cadastrado
            if (codigo == -1)
            {
                //instância do objeto cliente
                var cliente = new Cliente();
                //passo os valores para o objeto
                cliente.Codigo = ObterCodigo();
                cliente.Nome = txtNome.Text;
                cliente.NomeFilme = txtNomeFilme.Text;
                cliente.Data = Convert.ToDateTime(mskData.Text);
                //adiciono o objeto a lista
                lista.Add(cliente);
                ////chamo o método que carrega o grid
                CarregaDataGridView();
                //limpo os controles
                LimpaControles();
                //exibo a mensagem de sucesso
                MessageBox.Show("Cliente inserido com sucesso!");
            }
            //senão é uma alteração
            else
            {
                //pego o codigo do cliente que está na celula 0 do grid
                int cod = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value);
                //capturo o cliente a ser alterado
                var cliente = lista.SingleOrDefault(x => x.Codigo == cod);
                //faço as alterações no mesmo 
                cliente.Nome = txtNome.Text;
                cliente.NomeFilme = txtNomeFilme.Text;
                cliente.Data = Convert.ToDateTime(mskData.Text);
                //carrego o grid
                CarregaDataGridView();
                //limpo controles
                LimpaControles();
                //E atribuo -1 a variável de controle de alteração/inserção...
                codigo = -1;
                //mensagem de sucesso
                MessageBox.Show("Cliente Alterado com sucesso!");
            }
        }

        //clieck do botão alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //verifico se o grid há linhas selecionadas
            if (dgvCliente.CurrentRow != null)
            {
               //capturo o codigo da grid
                int cod = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value);
                //passo o código par aa variável codigo de controle
                codigo = cod;
                //recupero o cliente que desejo alterar
                var cliente = lista.SingleOrDefault(x => x.Codigo == cod);
                //insiro seus valores nos controles
                txtNome.Text = cliente.Nome;
                txtNomeFilme.Text = cliente.NomeFilme;
                mskData.Text = cliente.Data.ToShortDateString();
            }
            //senão exibo a mensagem de seleção
            else
            {
                MessageBox.Show("Você deve selecionar um cliente!");
            }
        }

        //Click do botão excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCliente.CurrentRow != null)
            {
                int cod = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value);
                var cliente = lista.SingleOrDefault(x => x.Codigo == cod);
                //recupero o objeto cliente e excluo ele da lista recarrego
                //o grid e exibo a mensagem de sucesso
                lista.Remove(cliente);
                CarregaDataGridView();
                MessageBox.Show("Cliente Excluído com sucesso");
            }
            //senão exibo a mensagem de seleção
            else
            {
                MessageBox.Show("Você deve selecionar um cliente!");
            }
        }
    }
}
