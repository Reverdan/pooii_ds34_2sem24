using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPessoas.Modelo
{
    public class Validacao
    {
        public String mensagem;
        public int id;

        public void validarId(String identificacao)
        {
            this.mensagem = "";
            try
            {
                this.id = Convert.ToInt32(identificacao);
            }
            catch (FormatException e)
            {
                this.mensagem = "Erro de id";
            }
        }

        public void ValidarPessoa(List<string> listaDadosPessoa)
        {
            this.mensagem = "";
            validarId(listaDadosPessoa[0]);
            if (listaDadosPessoa[1].Length < 3)
                this.mensagem += "Nome deve ter mais que 3 caracteres\n";
            if (listaDadosPessoa[1].Length > 50)
                this.mensagem += "Nome com mais que 50 caracteres\n";
            if (listaDadosPessoa[2].Length > 10)
                this.mensagem += "RG deve ter menos que 10 caracteres\n";
            if (listaDadosPessoa[3].Length > 12)
                this.mensagem += "CPF deve ter menos que 12 caracteres\n";

        }
    }
}
