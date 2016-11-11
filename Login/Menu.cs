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
            //Se botão direito -> deletar
            if (e.Button == MouseButtons.Right)
            {
                Usuario user = dataGridView1.CurrentRow.DataBoundItem as Usuario;
                Delete delete = new Delete(user);
                delete.Show();
            }
            else //alterar
            {
                Usuario user = dataGridView1.CurrentRow.DataBoundItem as Usuario;
                Update update = new Update(user);
                update.Show();
            }

            

          
        }
    }
}
