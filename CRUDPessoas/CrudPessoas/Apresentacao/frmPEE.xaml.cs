using CrudPessoas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrudPessoas.Apresentacao
{
    /// <summary>
    /// Lógica interna para frmPEE.xaml
    /// </summary>
    public partial class frmPEE : Window
    {
        public frmPEE()
        {
            InitializeComponent();
        }

        private void btnPesquisarId_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            List<string> listaDadosPessoa = new List<string>();
            listaDadosPessoa.Add(txbId.Text);
            Pessoa pessoa = controle.PesquisarPessoaPorId(listaDadosPessoa);
            if (controle.mensagem.Equals(""))
            {
                txbNome.Text = pessoa.Nome;
                txbRg.Text = pessoa.Rg;
                txbCpf.Text = pessoa.Cpf;
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            List<String> listaDadosPessoa = new List<string>();
            listaDadosPessoa.Add(txbId.Text);
            listaDadosPessoa.Add(txbNome.Text);
            listaDadosPessoa.Add(txbRg.Text);
            listaDadosPessoa.Add(txbCpf.Text);
            Controle controle = new Controle();
            controle.EditarPessoa(listaDadosPessoa);
            MessageBox.Show(controle.mensagem);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            List<string> listaDadosPessoa = new List<string>();
            listaDadosPessoa.Add(txbId.Text);
            if (MessageBox.Show("Deseja excluir?", "Excluir", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                controle.ExcluirPessoa(listaDadosPessoa);
                MessageBox.Show(controle.mensagem);
                txbId.Text = "";
                txbNome.Text = "";
                txbRg.Text = "";
                txbCpf.Text = "";
            }

        }
    }
}
