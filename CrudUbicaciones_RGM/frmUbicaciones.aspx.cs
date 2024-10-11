using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//capas
using BLL;
using DAL;
using Microsoft.SqlServer.Server;

namespace CrudUbicaciones_RGM
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        UbicacionesDAL oUbicacionesDAL;
        Ubicaciones_BLL oUbicacionesBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ListarUbicaciones();
            }
            
        }

        //Metodo encargado de listar los datos de la BD en un GridView
        public void ListarUbicaciones() 
        {
            oUbicacionesDAL = new UbicacionesDAL();
            gvUbicacion.DataSource = oUbicacionesDAL.Listar();
            gvUbicacion.DataBind();
        }

        //metodo encargado de recolectar los datos de nuestra interfaz 
        public Ubicaciones_BLL datosUbicacion() 
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new Ubicaciones_BLL();

            //Recolectar datos de la capa de presentacion
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones(); //Para mostrarlo en el gridview
        }

        protected void SeleccionRegistros(object sender, GridViewCommandEventArgs e)
        {
            int FilaSeleccionada = int.Parse(e.CommandArgument.ToString());

            txtID.Value = gvUbicacion.Rows[FilaSeleccionada].Cells[1].Text;
            txtUbicacion.Text = gvUbicacion.Rows[FilaSeleccionada].Cells[2].Text;
            txtLat.Text = gvUbicacion.Rows[FilaSeleccionada].Cells[3].Text;
            txtLong.Text = gvUbicacion.Rows[FilaSeleccionada].Cells[4].Text;

            //Ahora momento que demos click en "Seleccionar" habilitaremos
            //los Botones Eliminar y modificar, y a la vez, inhabilitaremos el boton agregar

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;    
            btnAgregar.Enabled = false;

           
        }
        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void LimpiarCampos(object sender, EventArgs e)
        {
            txtID.Value = string.Empty;
            txtLong.Text = "";
            txtLat.Text = "";

            btnAgregar.Enabled=true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
    }
}