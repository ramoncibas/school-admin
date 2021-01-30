using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPjEscola
{
    public partial class FrmAluno : Form
    {
        public FrmAluno()
        {
            InitializeComponent();
        }
        //Limpar Campos
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            cmbSexo.Text = "";
        }
        private void FrmAluno_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
        //Gravar Aluno
        private void btnGravar_Click(object sender, EventArgs e)
        {
            string sexo = cmbSexo.Text;
            sexo = sexo.Substring(0, 1);
            Aluno aluno = new Aluno(
                txtNome.Text, txtCpf.Text, sexo, txtEmail.Text, txtTelefone.Text
                );
            aluno.Inserir(aluno);
            MessageBox.Show("Aluno inserido com sucesso!");
        }
        //Alterar Aluno
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string sexo = cmbSexo.Text;
            sexo = sexo.Substring(0, 1);
            Aluno aluno = new Aluno();
            aluno.Id = int.Parse(txtId.Text);
            aluno.Nome = txtNome.Text;
            aluno.Sexo = sexo;
            aluno.Telefone = txtTelefone.Text;
            aluno.Alterar(aluno);
            MessageBox.Show("Aluno alterado com sucesso!");
        }
        //Buscar informaçoes do aluno pelo ID
        private void btnPegarId_Click(object sender, EventArgs e)
        {
            if (txtId.ReadOnly == true)
            {
                txtId.ReadOnly = false;
                btnPegarId.Text = "Buscar";
                txtId.Focus();
                LimparCampos();
            }
            else
            {
                if (txtId.Text != string.Empty)
                {
                    Aluno aluno = new Aluno();
                    aluno.ObterPorId(int.Parse(txtId.Text));
                    if (aluno.Id > 0)
                    {
                        txtNome.Text = aluno.Nome;
                        txtCpf.Text = aluno.Cpf;
                        if (aluno.Sexo == "M")
                        {
                            cmbSexo.SelectedIndex = 0;
                        }
                        else
                        {
                            cmbSexo.SelectedIndex = 1;
                        }
                        txtEmail.Text = aluno.Email;
                        txtTelefone.Text = aluno.Telefone;
                        txtId.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Aluno não cadastrado!");
                        txtId.Focus();
                    }

                }
            }
        }
        //Listando alunos
        private void btnListar_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Aluno aluno = new Aluno();
            foreach (var item in aluno.ListarTodos())
            {
                listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.Email + " - " + item.DataCadastro);
            }
        }
        //Atualizando lista de alunos
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Aluno aluno = new Aluno();
            foreach (var item in aluno.ListarTodos())
            {
                listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.Email + " - " + item.DataCadastro);
            }
        }
    }
}
