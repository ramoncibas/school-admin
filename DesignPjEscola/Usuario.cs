using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DesignPjEscola
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Situacao { get; set; }
        public Usuario()
        {
        }
        public Usuario(int id, string nome, string email, string senha, string situacao)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Email = email;
            Situacao = situacao;
        }
        public Usuario(string nome, string email, string senha, string situacao)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Situacao = situacao;
        }
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
        }
        public Usuario(string email, string senha)
        {
            Senha = senha;
            Email = email;
        }

        //Inserir Usuario
        /// <summary>
        ///     Metodo Inserir usuario para registro no db MySql
        /// </summary>
        /// <param name="inserirUsuario">Recebe um objeto tipo usuario e executa o metodo</param>
        public void InserirUser(Usuario usuario)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_usuario values(null, @nome, @email, md5(@senha), @situacao);";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.Nome;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.Email;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.Senha;
            cmd.Parameters.Add("@situacao", MySqlDbType.VarChar).Value = usuario.Situacao;
            cmd.ExecuteNonQuery();
        }

        //Alterar usuario
        /// <summary>
        ///     Metodo Alterar informações do usuario
        /// </summary>
        /// <param name="alterarUsuario">Recebe um objeto tipo usuario e executa o metodo</param>
        public void AlterarUser(Usuario usuario)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_usuario set nome_usuario=@nome, senha_usuario=@senha ,situacao_usuario=@situacao where id_usuario =@id;";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = usuario.Id;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.Nome;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.Senha;
            cmd.Parameters.Add("@situacao", MySqlDbType.VarChar).Value = usuario.Situacao;
            cmd.ExecuteNonQuery();
        }
        
        /// <summary>
        ///     Metedo Efetuar login
        /// </summary>
        /// <param name="efetuarLogin">Recebe um objeto tipo usuario e excuta o metodo</param>
        /// <returns></returns>
        public bool EfetuarLogin(Usuario usuario)
        {
            bool valido = false;
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario where senha_usuario = md5(@senha) and email_usuario = @email;";
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.Senha;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.Email;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Situacao = dr.GetString(4);
                valido = true;
            }
            return valido;
        }

        //Listar usuarios
        /// <summary>
        ///     Metodo Listar todos os usuario registrados
        /// </summary>
        /// <param name="listarTodosUsuarios">Recebe um objeto tipo usuario e executa o metodo</param>"
        /// <returns></returns>
        public List<Usuario> ListarTodosUser()
        {
            List<Usuario> usuarios = new List<Usuario>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario ";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usuarios.Add(new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4)));
            }
            return usuarios;
        }
        
        /// <summary>
        ///     Metodo obter dados do usuario por id via db MySql
        /// </summary>
        /// <param name="obterUsuarioPorId">Recebe um objeto do tipo usuario para executar o metodo</param>
        public void ObterPorIdUser(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario where id_usuario = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Email = dr.GetString(2);
                Senha = dr.GetString(3);
                Situacao = dr.GetString(4);
            }
        }
    }
}
