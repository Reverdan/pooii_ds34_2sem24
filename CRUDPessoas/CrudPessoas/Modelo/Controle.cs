using CrudPessoas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPessoas.Modelo
{
    public class Controle
    {
        public String mensagem;

        public void CadastrarPessoa(List<string> listaDadosPessoa)
        {
            this.mensagem = "";
            Validacao validacao = new Validacao();
            validacao.ValidarPessoa(listaDadosPessoa);
            this.mensagem = validacao.mensagem;
            if (this.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = validacao.id;
                pessoa.Nome = listaDadosPessoa[1];
                pessoa.Rg = listaDadosPessoa[2];
                pessoa.Cpf = listaDadosPessoa[3];
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.CadastrarPessoa(pessoa);
                this.mensagem = pessoaDAO.mensagem;
            }
        }

        public Pessoa PesquisarPessoaPorId(List<string> listaDadosPessoa)
        {
            this.mensagem = "";
            Pessoa pessoa = new Pessoa();
            Validacao validacao = new Validacao();
            validacao.validarId(listaDadosPessoa[0]);
            this.mensagem = validacao.mensagem;
            if (validacao.mensagem.Equals(""))
            {
                pessoa.Id = validacao.id;
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoa = pessoaDAO.PesquisarPessoaPorId(pessoa);
            }
            return pessoa;
        }

        public void EditarPessoa(List<string> listaDadosPessoa)
        {
            this.mensagem = "";
            Validacao validacao = new Validacao();
            validacao.ValidarPessoa(listaDadosPessoa);
            this.mensagem = validacao.mensagem;
            if (this.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = validacao.id;
                pessoa.Nome = listaDadosPessoa[1];
                pessoa.Rg = listaDadosPessoa[2];
                pessoa.Cpf = listaDadosPessoa[3];
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.EditarPessoa(pessoa);
                this.mensagem = pessoaDAO.mensagem;
            }
        }

        public void ExcluirPessoa(List<string> listaDadosPessoa)
        {
            this.mensagem = "";
            Pessoa pessoa = new Pessoa();
            Validacao validacao = new Validacao();
            validacao.validarId(listaDadosPessoa[0]);
            this.mensagem = validacao.mensagem;
            if (validacao.mensagem.Equals(""))
            {
                pessoa.Id = validacao.id;
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.ExcluirPessoa(pessoa);
                this.mensagem = pessoaDAO.mensagem;
            }
        }
    }
}
