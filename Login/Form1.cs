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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ir ate o BD para buscar os valores e comparar
            ConexaoBD con = new ConexaoBD();
            var user = con.Buscar(textBox1.Text);

            if (user == null)
            {
                MessageBox.Show("Usuário não encontrado");
            }
            else
            {
                if (user.Email == textBox1.Text && user.Senha==textBox2.Text)
                {
                    MessageBox.Show("Login e senha OK");
                    Menu menu = new Menu();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Login ou senha não conferem");
                }

                

            }

        }
    }
}
