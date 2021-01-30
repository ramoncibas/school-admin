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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }
        //Limpando Campos
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtSituacao.Clear();
        }
        //Gravar usuario
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(
                txtNome.Text, txtEmail.Text, txtSenha.Text, txtSituacao.Text
                );
            usuario.InserirUser(usuario);
            MessageBox.Show("Usuario inserido com sucesso!");
        }
        //Alterar usuario
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Id = int.Parse(txtId.Text);
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Situacao = txtSituacao.Text;
            usuario.AlterarUser(usuario);
            MessageBox.Show("Usuario alterado com sucesso!");
        }
        //Pegar informaçoes do usuario pelo Id
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
                    Usuario usuario = new Usuario();
                    usuario.ObterPorIdUser(int.Parse(txtId.Text));
                    if (usuario.Id > 0)
                    {
                        txtNome.Text = usuario.Nome;
                        txtEmail.Text = usuario.Email;
                        txtSenha.Text = usuario.Senha;
                        txtSituacao.Text = usuario.Situacao;
                        txtId.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Usuario não cadastrado!");
                        txtId.Focus();
                    }

                }
            }
        }
        //Listando usuarios
        private void btnListar_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Usuario usuario = new Usuario();
            foreach (var item in usuario.ListarTodosUser())
            {
                listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.Email + " - " + item.Senha + " - " + item.Situacao);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Usuario usuario = new Usuario();
            foreach (var item in usuario.ListarTodosUser())
            {
                listBox2.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.Email + " - " + item.Senha + " - " + item.Situacao);
            }
        }
    }
}
