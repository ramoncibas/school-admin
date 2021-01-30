using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DesignPjEscola
{
    public class Turma
    {
        public int Id { get; set; }
        public Curso Curso { get; set; }
        public string Sigla { get; set; }        
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string DiaSemana { get; set; }
        public string Situacao { get; set; }
        
        public Turma()
        {

        }

        public Turma(int id, Curso curso, string sigla, DateTime dataInicio, DateTime dataTermino, string diaSemana, string situacao)
        {
            Id = id;
            Curso = curso;
            Sigla = sigla;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            DiaSemana = diaSemana;
            Situacao = situacao;
        }
        public Turma(Curso curso, string sigla, DateTime dataInicio, DateTime dataTermino, string diaSemana)
        { 
            Curso = curso;
            Sigla = sigla;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            DiaSemana = diaSemana;
        }

        /// <summary>
        ///     Inserindo uma turma no Banco de Dados
        /// </summary>
        /// <param name="inserirTurma">Recebe um objeto tipo turma e executa o metodo</param>
        public void InserirTurma(Turma turma)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_turma values(null, @sigla, @data_inicio, @data_termino, @dia_semana, @situacao);";
            cmd.Parameters.Add("@sigla", MySqlDbType.VarChar).Value = turma.Sigla;
            cmd.Parameters.Add("@hora_inicio", MySqlDbType.DateTime).Value = turma.DataInicio;
            cmd.Parameters.Add("@hora_termino", MySqlDbType.DateTime).Value = turma.DataTermino;
            cmd.Parameters.Add("@dia_semana", MySqlDbType.String).Value = turma.DiaSemana;
            cmd.Parameters.Add("@situacao", MySqlDbType.String).Value = turma.Situacao;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     Alterando informações da turma
        /// </summary>
        /// <param name="alterarTurma">Recebe um objeto tipo turma e executa o metodo</param>
        public void AlterarTurma(Turma turma)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_turma set data_inicio=@data_inicio, data_termino=@data_termino, dia_semana=@dia_semana, situacao=@situacao  where id_turma = @id;";
            cmd.Parameters.Add("@hora_inicio", MySqlDbType.DateTime).Value = turma.DataInicio;
            cmd.Parameters.Add("@hora_termino", MySqlDbType.DateTime).Value = turma.DataTermino;
            cmd.Parameters.Add("@dia_semana", MySqlDbType.String).Value = turma.DiaSemana;
            cmd.Parameters.Add("@situacao", MySqlDbType.String).Value = turma.Situacao;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     Obtendo informações da turma selecionada
        /// </summary>
        /// <param name="turmaPorId">Recebe o id da turma e executa o metodo</param>
        public void ObterPorIdTurma(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_turma where id_turma = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Sigla = dr.GetString(1);
                DataInicio = dr.GetDateTime(2);
                DataTermino = dr.GetDateTime(3);
                DiaSemana = dr.GetString(4);
                Situacao = dr.GetString(5);
            }
        }        
    }
}