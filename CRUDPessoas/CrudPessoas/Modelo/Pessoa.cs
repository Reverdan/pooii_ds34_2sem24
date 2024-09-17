using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPessoas.Modelo
{
    public class Pessoa
    {
		private int id;
		private string nome;
		private string rg;
		private string cpf;

		public string Cpf
		{
			get { return cpf; }
			set { cpf = value; }
		}


		public string Rg
		{
			get { return rg; }
			set { rg = value; }
		}


		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}


		public int Id
		{
			get { return id; }
			set { id = value; }
		}

	}
}
