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
    public partial class Delete : Form
    {
        public Usuario UsuarioAserDeletado { get; set; }

        public Delete()
        {
            InitializeComponent();
        }

        public Delete(Usuario user)
        {
            InitializeComponent();
            UsuarioAserDeletado = user;
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            textBox1.Text = UsuarioAserDeletado.Nome;
            textBox2.Text = UsuarioAserDeletado.Email;
            textBox3.Text = UsuarioAserDeletado.Senha;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("DESEJA REALMENTE DELETAR O USUARIO ACIMA?",
             "Delete",
             MessageBoxButtons.OKCancel,
             MessageBoxIcon.Question,
             MessageBoxDefaultButton.Button1);

            if (result == DialogResult.OK)
            {
                ConexaoBD conexao = new ConexaoBD();
                var resposta = conexao.Deletar(UsuarioAserDeletado);
                if (resposta)
                {
                    MessageBox.Show("Delete realizado com sucesso",
                    "Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }    
            }

            Menu menu = new Menu();
            menu.Show();

        }

        
    }
}
