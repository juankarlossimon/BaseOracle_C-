using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;

namespace WebApplication2
{
    public partial class ingreso_usuarios : System.Web.UI.Page
    {
        string cadena = "Data Source=DESKTOP-4IONSRD;Persist Security Info=True;User ID=PROYECTOBD;Password=123456789;Unicode=True";
        OracleCommand cmd;
        OracleConnection conexion;
        OracleDataAdapter adapt;
        DataSet datos;
        Object resultado;
        int res;
        cAlert mensaje = new cAlert();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            //    cargarPuestos();
                cargarGrid();
            }
            

        }

        protected void dgBusquda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgBusquda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "select":
                    //BuscarComentario(Convert.ToInt32(e.CommandArgument));
                    break;

                case "Crear":
                    Editar(Convert.ToInt32(e.CommandArgument));
                    break;

                default:
                    break;
            }

        }

        protected void Editar(Int32 Id_usuario)
        {
            try
            {
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                adapt = new OracleDataAdapter("select  * from EMPLEADOS where codigo_empleado= " + Id_usuario + "", conexion);
                adapt.Fill(dt, "usuarios");
                if (dt.Tables[1].Rows.Count > 0)
                {
                    txt_idUsuario.Text = dt.Tables[1].Rows[0][0].ToString();
                    txt_Nombre.Text = dt.Tables[1].Rows[0][1].ToString();
                    txt_Apaterno.Text= dt.Tables[1].Rows[0][2].ToString();
                    txt_Materno.Text= dt.Tables[1].Rows[0][3].ToString();
                    txt_codigo_empleado.Text = txt_idUsuario.Text;
                    //txt_Direccion.Text= dt.Tables[1].Rows[0][4].ToString();
                    //txt_telefono.Text= dt.Tables[1].Rows[0][5].ToString();
                    //txt_correo.Text=dt.Tables[1].Rows[0][6].ToString();
                    //ddl_ocupacion.SelectedValue = dt.Tables[1].Rows[0][7].ToString();
                    btn_Guardar.Visible = false;
                    btn_Actualizar.Visible = true;
                }
                else
                {
                    mensaje.AlertInfo("No hay registros para mostrar en la tabla ");
                }
            }
            catch(Exception ex)
            {
                mensaje.AlertError("error al seleccionar usuario" + ex.Message);
            }

        }
        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 perfil = Convert.ToInt32(txt_Apaterno.Text);
               // perfil = Convert.ToInt32(ddl_ocupacion.SelectedValue);

                conexion = new OracleConnection(cadena);
                    conexion.Open();

                    cmd = new OracleCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "Insert into tb_usuarios ( id_usuario, nombre, apellido_paterno, APELLIDO_MATERNO, direcion, telefono, correo, cargo) values(  id_usuarios.nextval, '" + txt_Nombre.Text + "', '" + txt_Apaterno.Text + "', '" + txt_Materno.Text + "', '" + txt_Direccion.Text + "', '" + txt_telefono.Text + "', '"+  txt_correo.Text +  "'," + perfil +")";
                cmd.CommandText = "Insert into empleados (CODIGO_EMPLEADO, NOMBRE_EMPLEADO, CODIGO_DEPTO, FECHA_NACIMIENTO) values( "+ txt_codigo_empleado.Text + ", '" + txt_Nombre.Text + "', " + perfil + ", to_date('" + txt_Materno.Text + "', 'DD-MM-YYYY'))";
                cmd.Connection = conexion;
                    res = cmd.ExecuteNonQuery();
                    conexion.Close();
                    cargarGrid();
                    limpiarCampos();
                   // LlenarGridView();

                    if (res != 0)
                    {
                    mensaje.AlertInfo("Registro Ingresado");                    

                    }

                

            }
            catch (Exception ex)
            {
                mensaje.AlertError("El registro no se ingreso " + ex.Message);
       
            }

        }

        protected void cargarPuestos()
        {
            try {
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                adapt = new OracleDataAdapter("select id_cargo, descripcion from tb_cargos where estado='ALTA' ", conexion);
                adapt.Fill(dt, "PUESTOS");
               /* ddl_ocupacion.Items.Clear();
                ddl_ocupacion.AppendDataBoundItems = true;
                ddl_ocupacion.DataTextField = "descripcion";
                ddl_ocupacion.DataValueField = "id_cargo";
                ddl_ocupacion.DataSource = dt.Tables[1];
                ddl_ocupacion.DataBind();*/
            }
            catch(Exception ex){

                mensaje.AlertError("no se pudo recuperar informacion de los puestos" + ex.Message);
                }
         

        }
        protected void cargarGrid()
        {
            try
            {
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                /*  adapt = new OracleDataAdapter("select " +
                     "a.id_usuario," +
                     " a.nombre, a.apellido_paterno, " +
                     "a.apellido_materno, a.direcion, a.telefono," +
                     " a.correo, b.descripcion from tb_usuarios A," +
                     " tb_cargos b " +
                     "where A.CARGO=b.ID_CARGO", conexion);*/

                adapt = new OracleDataAdapter("select * from empleados", conexion);


                adapt.Fill(dt, "empleados");
                if (dt.Tables[1].Rows.Count > 0)
                {
                    dgBusqueda.DataSource = dt.Tables[1];
                    dgBusqueda.DataBind();
                }
                else
                {
                    mensaje.AlertInfo("No hay registros para mostrar en la tabla ");
                }



            }
            catch (Exception ex)
            {
                mensaje.AlertError("No se pudo recuperar la información de los usuarios" + ex.Message);
            }
        }


        protected void limpiarCampos()
        {
            txt_Nombre.Text = "";
            txt_Apaterno.Text = "";
            txt_Materno.Text = "";
            txt_codigo_empleado.Text = "";
            /*txt_Direccion.Text = "";
            txt_telefono.Text = "";
            txt_correo.Text = "";
            ddl_ocupacion.SelectedIndex = -1;*/

        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            btn_Guardar.Visible = true;
            btn_Actualizar.Visible = false;
        }

        protected void btn_Actualizar_Click(object sender, EventArgs e)
        {

            try
            {
                Int32 perfil = 0, Usuario;
                //perfil = Convert.ToInt32(ddl_ocupacion.SelectedValue);
                Usuario = Convert.ToInt32(txt_idUsuario.Text);
                conexion = new OracleConnection(cadena);
                conexion.Open();

                cmd = new OracleCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                /* cmd.CommandText = "update  tb_usuarios set " +
                     "nombre='"+ txt_Nombre.Text +"', apellido_paterno='" + txt_Apaterno.Text +"', " +
                     "apellido_materno='" + txt_Materno.Text +"', direcion='" + txt_Direccion.Text +"', " +
                     "telefono='" + txt_telefono.Text +"', correo='" + txt_correo.Text +"', " +
                     "cargo=" + perfil + " where id_usuario=" + Usuario + "";*/

                cmd.CommandText = "update  empleados set " +
                    "nombre_empleado='" + txt_Nombre.Text + "', codigo_depto=" + txt_Apaterno.Text + ", " +
                    "fecha_nacimiento= to_date('" + txt_Materno.Text + "', 'DD-MM-YYYY') where codigo_empleado=" + Usuario + "";
                cmd.Connection = conexion;
                res = cmd.ExecuteNonQuery();
                conexion.Close();
                cargarGrid();
                mensaje.AlertInfo("Registro actualizado correctamente");
                limpiarCampos();
                btn_Guardar.Visible = true;
                btn_Actualizar.Visible = false;
            }
            catch (Exception ex)
            {
                mensaje.AlertError("Error al actualizar los datos" + ex.Message);
                limpiarCampos();
                btn_Guardar.Visible = true;
                btn_Actualizar.Visible = false;
            }
           
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 Usuario = 0;
                
                
                if (txt_idUsuario.Text == "0" || txt_idUsuario.Text == "")
                {
                    mensaje.AlertInfo("Seleccione primero al usuario que desea eliminar");
                    return;
                }
                else {
                    Usuario = Convert.ToInt32(txt_idUsuario.Text);
                    conexion = new OracleConnection(cadena);
                    conexion.Open();
                    cmd = new OracleCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from empleados  where codigo_empleado= " + Usuario+ "";
                    cmd.Connection = conexion;
                    res = cmd.ExecuteNonQuery();
                    conexion.Close();
                    cargarGrid();
                    mensaje.AlertInfo("Registro Eliminado exitosamente");
                    limpiarCampos();
                    btn_Guardar.Visible = true;
                    btn_Actualizar.Visible = false;
                }
            
            }
            catch(Exception ex)
            {
                mensaje.AlertError("Error al eliminar el registro " + ex.Message);
            }
        }
    }
}