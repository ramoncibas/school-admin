using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace DesignPjEscola
{  
    public partial class FrmPrincipal : Form
    {
        private Form principalFormPai;
        public FrmPrincipal()
        {
            InitializeComponent();
            customizarDesign();
        }
        //Abrindo Formularios na panel principal
        private void AbrirFormPai(Form formPai)
        {
            //Abrindo somente um formulario
            if (this.panelPrincipalHome.Controls.Count > 0)
                this.panelPrincipalHome.Controls.RemoveAt(0);
            principalFormPai = formPai;
            formPai.TopLevel = false;
            formPai.FormBorderStyle = FormBorderStyle.None;
            formPai.Dock = DockStyle.Fill;//"full screen" - form pai
            panelPrincipalHome.Controls.Add(formPai);//adiciona objeto controle
            panelPrincipalHome.Tag = formPai;//objeto com o controle
            formPai.BringToFront();//z-index html
            formPai.Show();
        }
        //Escondendo panels ao iniciar a aplicaçao
        private void customizarDesign()
        {       
            panelCadastroSubMenu.Visible = false;
            panelOperacaoSubMenu.Visible = false;
            panelRelatorioSubMenu.Visible = false;
        }
        //Esconder sub menus apos clicar em outro menu
        private void esconderSubMenu()
        {
            if (panelCadastroSubMenu.Visible == true)            
                panelCadastroSubMenu.Visible = false;            
            if (panelOperacaoSubMenu.Visible == true)            
                panelOperacaoSubMenu.Visible = false;            
            if (panelRelatorioSubMenu.Visible == true)            
                panelRelatorioSubMenu.Visible = false;            
        }
        //Mostrar sub menus apos clicar em tal
        private void mostraSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                esconderSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #region CadastrosMenu           
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            mostraSubMenu(panelCadastroSubMenu);
        }
        private void btnAluno_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            AbrirFormPai(new FrmAluno());
        }
        private void btnProfessor_Click(object sender, EventArgs e)
        {       
            esconderSubMenu();
            AbrirFormPai(new FrmProfessor());
        }
        private void btnCurso_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            AbrirFormPai(new FrmCurso());
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            AbrirFormPai(new FrmUsuario());
        }
        private void btnTurma_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            AbrirFormPai(new FrmTurma());
        }
        #endregion
        #region OperaçõesMenu
        private void btnOperacao_Click(object sender, EventArgs e)
        {
            mostraSubMenu(panelOperacaoSubMenu);
        }
        private void btnMatricula_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            AbrirFormPai(new FrmMatricula());
        }
        #endregion
        #region RelatóriosMenu
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            mostraSubMenu(panelRelatorioSubMenu);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            //AbrirFormPai(new Frm...())
        }
        private void button6_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            //AbrirFormPai(new Frm..())
        }
#endregion

        //Sair da aplicação
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Voltar para o home principal
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (panelPrincipalHome != null)
                principalFormPai.Close();
        }

        //Exibindo qual usuario está logado
        private void panelHome_Paint(object sender, PaintEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            if (Program.usuarioLogado != null)
            {
                Text = "Olá, " + Program.usuarioLogado.Nome + " - Bem vindo!";
            }
        }

        private void panelPrincipalHome_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
