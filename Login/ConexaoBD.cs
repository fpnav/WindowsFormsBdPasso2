using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class ConexaoBD
    {
        public SqlConnection conexao { get; set; }

        public ConexaoBD()
        {
            //C:\Users\Alunos\Source\Repos\WindowsFormsBdPasso2\Login\Banco
            //var caminho = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alunos\Documents\UsersDB.mdf;Integrated Security=True;Connect Timeout=30";
            var caminho = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alunos\Source\Repos\WindowsFormsBdPasso2\Login\Banco\UsersDB.mdf;Integrated Security=True;Connect Timeout=30";
            conexao = new SqlConnection(caminho);
            conexao.Open();

            //if (ConnectionState.Open == conexao.State)
            //{
                
            //}
        }

        public bool Inserir(string nome, string email, string senha)
        {
            var sql = "Insert into usuario (nome,email,senha) "+
                          "values (@nome,@email,@senha)";
                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@senha", senha);
                var retorno = comando.ExecuteNonQuery();
                if (retorno > 0)
                    return true;
                else
                    return false;
        }



        
    }
}
