using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DesignPjEscola
{
    public class Aluno
    { 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

        public Aluno()
        {

        }
        public Aluno(string nome, string cpf, string sexo, string email, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Email = email;
            Telefone = telefone;
        }
        public Aluno(int id, string nome, string cpf, string sexo, string email, string telefone, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Email = email;
            Telefone = telefone;
            DataCadastro = dataCadastro;
        }

        /// <summary>
        ///     Metodo efetuar login
        /// </summary>
        /// <param name="efetuarLogin">Recebe um objeto tipo aluno e executa o metodo</param>        
        public bool EfetuarLogin(Aluno aluno)
        {
            return true;
        }

        /// <summary>
        ///     Metodo Inserir um ALuno
        /// </summary>
        /// <param name="inserirAluno">Recebe um objeto tipo aluno e executa o metodo</param>
        public void Inserir(Aluno aluno)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_aluno values(null, @nome, @cpf, @sexo, @email, @telefone, default);";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = aluno.Nome;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = aluno.Cpf;
            cmd.Parameters.Add("@sexo", MySqlDbType.VarChar).Value = aluno.Sexo;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = aluno.Email;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = aluno.Telefone;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     Metodo Alterar informações do Aluno
        /// </summary>
        /// <param name="alterarAluno">Recebe um objeto tipo aluno e executa o metodo</param>
        public void Alterar(Aluno aluno)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_aluno set nome_aluno=@nome, sexo_aluno = @sexo, telefone_aluno=@telefone where id_aluno =@id";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = aluno.Nome;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = aluno.Id;
            cmd.Parameters.Add("@sexo", MySqlDbType.VarChar).Value = aluno.Sexo;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = aluno.Telefone;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     Metodo Lista todos os Alunos
        /// </summary>
        /// <param name="listarTodosAlunos">Recebe uma lista de objetos do tipo usuario e executa o metodo</param>
        public List<Aluno> ListarTodos()
        {
            List<Aluno> alunos = new List<Aluno>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_aluno ";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                alunos.Add(
                    new Aluno(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetDateTime(6)
                        ));
            }
            return alunos;
        }

        /// <summary>
        ///     Metodo retorna o aluno cujo seus respectivo "Id"
        /// </summary>
        /// <param name="obterPorId">Recebe um objeto tipo id e executa o metodo</param>
        public void ObterPorId(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_aluno where id_aluno = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Cpf = dr.GetString(2);
                Sexo = dr.GetString(3);
                Email = dr.GetString(4);
                Telefone = dr.GetString(5);
                DataCadastro = dr.GetDateTime(6);
            }
        }

    }
}