using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAplication1 {
    public partial class Form1 : Form {
        List<Pessoa> pessoas;
       
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) {
            pessoas = Pessoa.ListarPessoas();
            gridPessoas.DataSource = pessoas;
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            Pessoa p = new Pessoa() {
                Codigo = Convert.ToInt32(txt_Codigo.Text),
                Nome = txt_Nome.Text,
                Telefone = txt_Telefone.Text
            };
            Pessoa.AdiconarPessoa(p);
            pessoas = Pessoa.ListarPessoas();
            gridPessoas.DataSource = pessoas;
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            if (gridPessoas.SelectedRows.Count > 0 ) {
                int indice = gridPessoas.SelectedRows[0].Index;
                Pessoa.ExcluirPessoa(pessoas[indice].Codigo);
                pessoas = Pessoa.ListarPessoas();
                gridPessoas.DataSource = pessoas;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e) {
            Pessoa p = new Pessoa() {
                Codigo = Convert.ToInt32(txt_Codigo.Text),
                Nome = txt_Nome.Text,
                Telefone = txt_Telefone.Text
            };
            Pessoa.EditarPessoa(p);
            pessoas = Pessoa.ListarPessoas();
            gridPessoas.DataSource = pessoas;
        }

        private void gridPessoas_DoubleClick(object sender, EventArgs e) {
            if (gridPessoas.SelectedRows.Count > 0) {
                int indice = gridPessoas.SelectedRows[0].Index;
                if (indice >= 0) {
                    txt_Codigo.Text = pessoas[indice].Codigo.ToString();
                    txt_Nome.Text = pessoas[indice].Nome;
                    txt_Telefone.Text = pessoas[indice].Telefone;
                }
            }
        }
    }
}
