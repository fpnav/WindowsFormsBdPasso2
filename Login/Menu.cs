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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //Carregar a datagridview com dados dos usuários
            ConexaoBD conexao = new ConexaoBD();
            var lista = conexao.GetAll();

            dataGridView1.DataSource = lista;

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Usuario linha = dataGridView1.CurrentRow.DataBoundItem as Usuario; 
            MessageBox.Show(linha.Nome + " " + linha.Email + " " + linha.Senha, 
                "Captação", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information, 
                MessageBoxDefaultButton.Button1 );
        }
    }
}
