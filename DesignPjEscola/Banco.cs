using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DesignPjEscola
{
    public static class Banco
    {
        //Efetuando conexão com o Banco de dados
        public static string StrCon = @"";
        public static MySqlCommand AbriConexao()
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection cn = new MySqlConnection(StrCon);
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (Exception)
            {

            }
            return cmd;
        }
    }
}