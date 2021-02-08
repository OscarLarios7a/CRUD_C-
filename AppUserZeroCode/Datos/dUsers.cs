using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AppUserZeroCode.Logica;
using System.Windows.Forms;

namespace AppUserZeroCode.Datos
{
    class dUsers
    {
        private SqlCommand cnx = new SqlCommand();
        //private int idUsr;
        //Metodo para Insertar Datos a la DB
        public bool insert(lUsers dtUser)
        {
            try
            {
                ConexionDB.open();
                cnx = new SqlCommand("insert_usuario", ConexionDB.sqlcnx);
                cnx.CommandType = CommandType.StoredProcedure;
                cnx.Parameters.AddWithValue("@Usuarios",dtUser.usuarios);
                cnx.Parameters.AddWithValue("@Password", dtUser.pass);
                cnx.Parameters.AddWithValue("@Icono", dtUser.icono);
                cnx.Parameters.AddWithValue("@Estado", dtUser.estado);

                if(cnx.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionDB.close();
            }
        }

        //Metodo para Mostar Datos de la DB
        public DataTable view()
        {
            try
            {
                ConexionDB.open();
                cnx = new SqlCommand("view_usuario",ConexionDB.sqlcnx);
                if (cnx.ExecuteNonQuery()!=0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cnx);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                ConexionDB.close();
            }
        }

        //Metodo para Editar Datos de la DB
        public bool edit(lUsers dtUser)
        {
            try
            {
                ConexionDB.open();
                cnx = new SqlCommand("edit_usuario", ConexionDB.sqlcnx);
                cnx.CommandType = CommandType.StoredProcedure;
                cnx.Parameters.AddWithValue("@Id_Usuarios", dtUser.idusarios);
                cnx.Parameters.AddWithValue("@Usuarios", dtUser.usuarios);
                cnx.Parameters.AddWithValue("@Password", dtUser.pass);
                cnx.Parameters.AddWithValue("@Icono", dtUser.icono);
                cnx.Parameters.AddWithValue("@Estado", dtUser.estado);

                if (cnx.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionDB.close();
            }
        }

        //Metodo para eliminar Datos de la DB
        public bool delete(lUsers dtUser)
        {
            try
            {
                ConexionDB.open();
                cnx = new SqlCommand("delete_usuario", ConexionDB.sqlcnx);
                cnx.CommandType = CommandType.StoredProcedure;
                cnx.Parameters.AddWithValue("@Id_Usuarios", dtUser.idusarios);

                if (cnx.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionDB.close();
            }
        }

        //metodo para Buscar Datos en DB
        public DataTable search(string parametro)
        {
            try
            {
                ConexionDB.open();
                cnx = new SqlCommand("search_usuario", ConexionDB.sqlcnx);
                cnx.CommandType = CommandType.StoredProcedure;
                cnx.Parameters.AddWithValue("@search", parametro);
                if (cnx.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cnx);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                ConexionDB.close();
            }
        }
    }
}
