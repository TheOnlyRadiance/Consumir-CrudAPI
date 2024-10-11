using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLDBHelper
    {
        //tabla donde vamos a guardar los registrar.
        DataTable Tabla;
        //esto es para usar el string de conexion
        SqlConnection strConexion = new SqlConnection("Data Source=DESKTOP-5QJ379G;Initial Catalog=BDUbicaciones;Integrated Security=True");
        //Cracion de objetos de cmd de tipo SqlCommand
        SqlCommand cmd = new SqlCommand();

        public bool EjecutarComandoSQL(SqlCommand strSQLCommand) 
        {
            //INSERTAR, MODIFICAR, BORRAR
            bool  Respuesta = true;
            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            cmd.Connection.Open();
            Respuesta = (cmd.ExecuteNonQuery() <= 0) ? false : true;
            strConexion.Close();
            return Respuesta;
        }

        public DataTable EjecutarSentenciaSQL(SqlCommand strSQLCommand) 
        {
            //seleccionar datos de la tabla
            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            strConexion.Open();
            Tabla = new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            strConexion.Close();
            return Tabla;
        }

    }
}
