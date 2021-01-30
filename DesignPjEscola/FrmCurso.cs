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
    public partial class FrmCurso : Form
    {
        public FrmCurso()
        {
            InitializeComponent();
        }
        //Limbar campos apos busca
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtValorCurso.Clear();
            txtCargaHr.Clear();
        }
        //Gravando cursos
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso(
                txtNome.Text, int.Parse(txtCargaHr.Text), double.Parse(txtValorCurso.Text)
                );
            curso.InserirCurso(curso);
            MessageBox.Show("Curso inserido com sucesso!");
        }
        //Alterando Curso
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            curso.Id = int.Parse(txtId.Text);
            curso.Nome = txtNome.Text;
            //curso.CargaHoraria = txtCargaHr.Text;
            //curso.ValorCurso = txtValorCurso.Text;
            curso.AlterarCurso(curso);
            MessageBox.Show("Curso Alterado com sucesso!");
        }
        //Pegando dados do cursos pelo Id
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
                    Curso curso = new Curso();
                    curso.ObterPorIdCurso(int.Parse(txtId.Text));
                    if (curso.Id > 0)
                    {
                        txtNome.Text = curso.Nome;
                        //Problemas com buscar carga horaria e valor do curso no banco de dados
                        //txtCargaHr.Text = curso.CargaHoraria;
                        //txtValorCurso.Text =  curso.ValorCurso;
                        txtId.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Curso não cadastrado!");
                        txtId.Focus();
                    }

                }
            }
        }
        //Listando cursos Disponiveis
        private void btnListar_Click(object sender, EventArgs e)
        {
            {
                listBox2.Items.Clear();
                Curso curso = new Curso();
                foreach (var item in curso.ListarCursos())
                {
                    listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                        item.CargaHoraria + " - " + item.ValorCurso);
                }
            }
        }
        //Atualizando a lista de cursos
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            {
                listBox2.Items.Clear();
                Curso curso = new Curso();
                foreach (var item in curso.ListarCursos())
                {
                    listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                        item.CargaHoraria + " - " + item.ValorCurso);
                }
            }
        }
    }
}
