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
    /// Lógica interna para frmCadastro.xaml
    /// </summary>
    public partial class frmCadastro : Window
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            List<String> listaDadosPessoa = new List<string>();
            listaDadosPessoa.Add("0");
            listaDadosPessoa.Add(txbNome.Text);
            listaDadosPessoa.Add(txbRg.Text);
            listaDadosPessoa.Add(txbCpf.Text);
            Controle controle = new Controle();
            controle.CadastrarPessoa(listaDadosPessoa);
            MessageBox.Show(controle.mensagem);
        }
    }
}
