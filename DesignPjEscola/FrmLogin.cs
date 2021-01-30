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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        //Efetuar Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtEmail.Text, txtSenha.Text);
            if (usuario.EfetuarLogin(usuario))
            {
                this.Close();
                Program.usuarioLogado = usuario;
                //FrmPrincipal frmPrincipal = new FrmPrincipal();
                //frmPrincipal.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorreto!");
                Application.Restart();
            }
        }
        //Calcelar Login
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
