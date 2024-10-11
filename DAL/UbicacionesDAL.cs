using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class UbicacionesDAL
    {
        SQLDBHelper oConexion;
        //Inicializar la conexion a la BD(Con constructor)
        public UbicacionesDAL() {
            oConexion = new SQLDBHelper();
        }

        public bool Agregar(Ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "iNSERT INTO Direcciones (Ubicacion,Latitud,Longitud) VALUES (@Ubicacion,@Latitud,@Longitud)";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Eliminar(Ubicaciones_BLL OubicacionBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "Delete from Direcciones WHERE ID=@ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = OubicacionBLL.ID;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Modificar(Ubicaciones_BLL OubicacionBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "UPDATE Direcciones Set Ubicacion = @Ubicacion, Latitud = @Latitud, Longitud = @Longitud where ID = @ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = OubicacionBLL.ID;
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionBLL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }


        //Seleccionar los registros de la tabla mediante un SELECT
        public DataTable Listar() {
            SqlCommand cmdcommand = new SqlCommand();
            //sentencia SQL para traer todos los registros de la tabla "Direcciones"
            cmdcommand.CommandText = "SELECT * FROM Direcciones";
            //tipo de comando ya sea: texto, sp, etc.
            cmdcommand.CommandType = CommandType.Text;

            DataTable TablaResultado = oConexion.EjecutarSentenciaSQL(cmdcommand);

            return TablaResultado;
        }

    }
}
