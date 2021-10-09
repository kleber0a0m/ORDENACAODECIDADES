using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public partial class FrmVetor : Form
    {
        List<String> nomes = new List<String>();

        public FrmVetor()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVetor_Load(object sender, EventArgs e)
        {

        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            btnBuscaBinaria.Visible = true;
            nomes.Sort();
            mostra();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            int p = nomes.IndexOf(txtEntrada.Text);
            if (p == -1)
                MessageBox.Show("Não encontrado :(");
            else
            {
                MessageBox.Show("Encontrado na posicao:" + p);
                listDados.SelectedIndex = p;
            }
               
                
        }

        private void BtnBuscaBinaria_Click(object sender, EventArgs e)
        {
            int p = nomes.BinarySearch(txtEntrada.Text);
            if (p < 0)
                MessageBox.Show("Não encontrado :(");
            else
            {
                MessageBox.Show("Encontrado na posicao:" + p);
                listDados.SelectedIndex = p;
            }
               

        }

        private void BtnCarregar_Click(object sender, EventArgs e)
        {
            StreamReader arquivo = new StreamReader("cidadeMG.txt");
            int TotalLinhas = File.ReadLines("cidadeMG.txt").Count();
            MessageBox.Show("Linhas:" + TotalLinhas);
            string linha;
            int c = 0;
            do
            {
                linha = arquivo.ReadLine();
                listDados.Items.Add(linha); // listCidades é um ListBox
                nomes.Add(linha);// cidades é um vetor, declarado como variável global da classe
                c++;
            } while (c < TotalLinhas); // n é a quantidade de elementos do arquivo
            arquivo.Close();
            MessageBox.Show("Dados Carregados");
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            StreamWriter arquivo = new StreamWriter("ordenado.txt");
            foreach (string c in nomes)
                arquivo.WriteLine(c);
            MessageBox.Show("Dados Salvos!");
            arquivo.Close();
        }

        private void listCidades_SelectedValueChanged(object sender, EventArgs e)
        {

        }


        void mostra()
        {
            listDados.Items.Clear();
            foreach (String n in nomes)
                listDados.Items.Add(n);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnBuscaBinaria.Visible = false;
            nomes.Add(txtEntrada.Text);
            mostra();
            txtEntrada.Clear();
            txtEntrada.Focus();
        }
    }
}
