using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Update : Form
    {
        public Usuario user { get; set; }

        private void Update_Load(object sender, EventArgs e)
        {
            textBox1.Text = user.Nome;
            textBox2.Text = user.Email;
            textBox3.Text = user.Senha;
        }

        public Update()
        {
            InitializeComponent();
        }

        public Update(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nomeAlter = textBox1.Text;
            var emailAlter = textBox2.Text;
            var senhaAlter = textBox3.Text;

            Usuario usuarioAserAlterado = new Usuario();
            usuarioAserAlterado.Nome = nomeAlter;
            usuarioAserAlterado.Email = emailAlter;
            usuarioAserAlterado.Senha = senhaAlter;

            ConexaoBD conexao = new ConexaoBD();
            var resposta = conexao.Alterar(usuarioAserAlterado, user.Id);

            if (resposta)
            {
                MessageBox.Show("Alteração realizada com sucesso",
                "Update",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
        }



    }
}
