using CrudPessoas.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPessoas.DAL
{
    public class PessoaDAO
    {
        public String mensagem;

        public void CadastrarPessoa(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();
            String sql = @"insert into Pessoas (nome, rg, cpf)
                        values(@nome, @rg, @cpf)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@rg", pessoa.Rg);
            cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
            try
            {
                cmd.ExecuteNonQuery();
                this.mensagem = "Pessoa cadastrada";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro no cadastro";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public Pessoa PesquisarPessoaPorId(Pessoa pessoa)
        {
            SqlDataReader dr;
            SqlConnection con = Conexao.Conectar();
            String sql = @"select * from pessoas where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", pessoa.Id);
            try
            {
                //cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    pessoa.Nome = dr["nome"].ToString();
                    pessoa.Rg = dr["rg"].ToString();
                    pessoa.Cpf = dr["cpf"].ToString();
                    dr.Close();
                }
                else
                {
                    this.mensagem = "Id não existe";
                }
            }
            catch (Exception e)
            {
                this.mensagem = "Erro na pesquisa";
            }
            finally
            {
                Conexao.Desconectar();
            }
            return pessoa;
        }

        public void EditarPessoa(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();
            String sql = @"update pessoas set nome = @nome, rg = @rg, cpf = @cpf 
                            where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", pessoa.Id);
            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@rg", pessoa.Rg);
            cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
            try
            {
                cmd.ExecuteNonQuery();
                this.mensagem = "Pessoa editada";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro na edição";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public void ExcluirPessoa(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();
            String sql = @"delete from pessoas where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", pessoa.Id);
            try
            {
                cmd.ExecuteNonQuery();
                this.mensagem = "Pessoa excluida";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro na exclusão";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
