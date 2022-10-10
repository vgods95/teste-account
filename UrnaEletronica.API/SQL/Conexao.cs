using Microsoft.Data.SqlClient;

namespace UrnaEletronica.API.SQL
{
    public class Conexao
    {
        public SqlConnection StringConexao()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=william\naserver;Initial Catalog=UrnaEletronica;Integrated Security=True");

            return conexao;
        }

        public SqlCommand ComandoSql(string procedure)
        {
            SqlConnection conexao = StringConexao();
            conexao.Open();
            return new SqlCommand(procedure, conexao);
        }


    }
}
