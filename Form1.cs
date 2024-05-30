using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_de_dados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=bd_pokemon;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_pokemon", conn);

            // DAtaTable = armazenar os resultados da consulta
            DataTable dt = new DataTable();
            conn.Open();

            // MySqlDataAdapter = preencher o DataTable com os resultados da consulta
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            // Vincule o DataTable ao DataGridView para exibir os dados na grade
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = txtpesquisa.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=bd_pokemon;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_pokemon where nome like '%"+pesquisa+"%'", conn);

            // DAtaTable = armazenar os resultados da consulta
            DataTable dt = new DataTable();
            conn.Open();

            // MySqlDataAdapter = preencher o DataTable com os resultados da consulta
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            // Vincule o DataTable ao DataGridView para exibir os dados na grade
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fcadastro = new Form2();
            fcadastro.Show();
        }
    }
}
