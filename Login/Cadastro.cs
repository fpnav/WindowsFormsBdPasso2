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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nomeTxt = textBox1.Text;
            var emailTxt = textBox2.Text;
            var senhaTxt = textBox3.Text;

            ConexaoBD bd = new ConexaoBD();
            var resultado = bd.Inserir(nomeTxt, emailTxt, senhaTxt);
            if (resultado)
            {
                MessageBox.Show("Inserção OK");
            }
            else
            {
                MessageBox.Show("Falha na inserção, faça novamente");
            }
            this.Close();
        }
    }
}
