package DAL;


public class Conexao 
{
    public Connection con;
    public String mensagem;
    
    public Connection conectar()
    {
        mensagem = "";
        try
        {
            if (con == null || con.isClosed())
            {
                con = DriverManager.getConnection(
                "jdbc:sqlserver://localhost\\DESKTOP-LG3SAV4\\SQLEXPRESS:1433;databaseName=ALPOO", 
                "sa", "rever");
            }
            
        }
        catch (SQLException e)
        {
            mensagem = "Erro de conexão com BD";
        }
        return con;
    }
    
    public void desconectar()
    {
        try
        {
            if (!con.isClosed())
            {
                con.close();
            }
        }
        catch (SQLException e)
        {
            mensagem = "Erro ao fechar conexão";
        }
    }
}
