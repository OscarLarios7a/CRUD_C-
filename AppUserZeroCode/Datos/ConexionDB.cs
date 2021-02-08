using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AppUserZeroCode.Datos
{
    internal static class ConexionDB
    {
        public static SqlConnection sqlcnx = new SqlConnection(@"Data Source=(localdb)\AT_OAXACA; initial catalog=UsersDB; integrated Security=true;");

        //creacion de Rutinas
        public static void open()
        {
            if (sqlcnx.State == ConnectionState.Closed)
            {
                sqlcnx.Open();

            }
        }
        public static void close()
        {
            if (sqlcnx.State == ConnectionState.Open)
            {
                sqlcnx.Close();
            }
        }
    }
}
