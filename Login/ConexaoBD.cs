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
            //var caminho = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alunos\Documents\UsersDB.mdf;Integrated Security=True;Connect Timeout=30";
            var caminho =   @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alunos\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30";
                            
            conexao = new SqlConnection(caminho);
            conexao.Open();

            //if (ConnectionState.Open == conexao.State)
            //{
                
            //}
        }

        public Usuario Buscar(string email)
        {
            var sql = "select * from Usuario where email=@email";
            var comando = new SqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@email", email);

            SqlDataReader rdr = comando.ExecuteReader();
            Usuario usuario = null;
            while (rdr.Read())
            {
                usuario = new Usuario();
                usuario.Id = Convert.ToInt32(rdr["id"]);
                usuario.Nome = rdr["nome"].ToString();
                usuario.Email = rdr["email"].ToString();
                usuario.Senha = rdr["senha"].ToString();
            }

            return usuario;
        }


        public List<Usuario> GetAll()
        {
            var sql = "select * from Usuario";
            var comando = new SqlCommand(sql, conexao);

            SqlDataReader rdr = comando.ExecuteReader();
            Usuario usuario = null;
            List<Usuario> listUsuarios = new List<Usuario>();
            while (rdr.Read())
            {
                usuario = new Usuario();
                usuario.Id = Convert.ToInt32(rdr["id"]);
                usuario.Nome = rdr["nome"].ToString();
                usuario.Email = rdr["email"].ToString();
                usuario.Senha = rdr["senha"].ToString();
                listUsuarios.Add(usuario);
            }
            return listUsuarios;
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

        public bool Alterar(Usuario usuario, int idAserAlterado)
        {
            var sql = "Update usuario set nome = @nome, "+
                "email = @email, senha = @senha WHERE id = @id";
           
            var comando = new SqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@id", idAserAlterado);
            var retorno = comando.ExecuteNonQuery();
            if (retorno > 0)
                return true;
            else
                return false;
        }

        public bool Deletar(Usuario usuario)
        {
            var sql = "Delete from usuario where id = @id";

            var comando = new SqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@id", usuario.Id);
            var retorno = comando.ExecuteNonQuery();
            if (retorno > 0)
                return true;
            else
                return false;
        }
        
    }
}
