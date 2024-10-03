using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

//Data Source=REVER-NOTE\SQLEXPRESS;Initial Catalog=CrudPessoas;Persist Security Info=True;User ID=sa;Password=***********;Encrypt=False
//Data Source=DESKTOP-CJH0B9P;Initial Catalog=aulaADS;Persist Security Info=True;User ID=sa;Password=rever;Encrypt=False

namespace CrudPessoas.DAL
{
    public class Conexao
    {
        public static SqlConnection con = new SqlConnection();
        public static String mensagem = "";
        public static String stringConexao = @"Data Source=REVER-NOTE\SQLEXPRESS;Initial Catalog=CrudPessoas;Persist Security Info=True;User ID=sa;Password=rever;Encrypt=False";
        
        public static SqlConnection Conectar()
        {
            mensagem = "";
            con.ConnectionString = stringConexao;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch(SqlException e)
            {
                mensagem = "Erro ao conectar com BD: " + e.Message;
            }
            return con;
        }

        public static void Desconectar()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (SqlException e)
            {
                mensagem = "Erro ao desconectar o BD: " + e.Message;
            }
        }
    }
}
