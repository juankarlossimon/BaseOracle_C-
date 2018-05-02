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
    public partial class CrearTramites : System.Web.UI.Page
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
            if(!IsPostBack)
            {

                cargarSeguros();
                cargarDepartamentos();
                llenarGridDatos();
            }
        }

        protected void cargarSeguros()
        {
            try
            {
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                adapt = new OracleDataAdapter("select id_tipo_seguro, descripcion from tb_tipo_seguro where estado='ALTA'", conexion);
                adapt.Fill(dt, "TIPO_SEGURO");
                ddl_tipoSeguro.Items.Clear();
                ddl_tipoSeguro.AppendDataBoundItems = true;
                ddl_tipoSeguro.DataTextField = "descripcion";
                ddl_tipoSeguro.DataValueField = "id_tipo_seguro";
                ddl_tipoSeguro.DataSource = dt.Tables[1];
                ddl_tipoSeguro.DataBind();
            }
            catch (Exception ex)
            {

                mensaje.AlertError("no se pudo recuperar informacion de los seguros" + ex.Message);
            }

        }

        protected void cargarDepartamentos()
        {
            try
            {
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                adapt = new OracleDataAdapter("select id_departamento, nombre_departamento from tb_departamento where estado='ALTA'", conexion);
                adapt.Fill(dt, "departamento");
                ddl_Departamento.Items.Clear();
                ddl_Departamento.AppendDataBoundItems = true;
                ddl_Departamento.DataTextField = "nombre_departamento";
                ddl_Departamento.DataValueField = "id_departamento";
                ddl_Departamento.DataSource = dt.Tables[1];
                ddl_Departamento.DataBind();
                ddl_Departamento.Items.Insert(0, "Seleccione el Departamento");
                ddl_Departamento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                mensaje.AlertError("no se pudo recuperar informacion de los departamentos" + ex.Message);
            }

        }

        protected void ddl_Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 id_departamento = 0;
                id_departamento = Convert.ToInt32(ddl_Departamento.SelectedValue);
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                adapt = new OracleDataAdapter("select id_municipio, nombre_municipio from tb_municipios where id_departamento= "+ id_departamento + " and estado='ALTA'", conexion);
                adapt.Fill(dt, "municipio");
                ddl_municipio.Items.Clear();
                ddl_municipio.AppendDataBoundItems = true;
                ddl_municipio.DataTextField = "nombre_municipio";
                ddl_municipio.DataValueField = "id_municipio";
                ddl_municipio.DataSource = dt.Tables[1];
                ddl_municipio.DataBind();
            }
            catch (Exception ex)
            {

                mensaje.AlertError("no se pudo recuperar informacion de los departamentos" + ex.Message);
            }
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiardatos();

        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try {

                Int32 tipoSeguro=0, departamento=0, municipio=0;
                tipoSeguro = Convert.ToInt32(ddl_tipoSeguro.SelectedValue);
                departamento = Convert.ToInt32(ddl_Departamento.SelectedValue);
                municipio = Convert.ToInt32(ddl_municipio.SelectedValue);

                conexion = new OracleConnection(cadena);
                conexion.Open();

                cmd = new OracleCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into tb_tramites " +
                    "(id_tramite, nombre, nit, mail, celular, telefono_casa, tipo_seguro, departamento, municipio) " +
                    "values(tb_tramites_conteo.nextval, '"+ txt_NombreCompleto.Text + "', '"+ txt_nit.Text +"', '" + txt_Correo.Text +"', '" + txt_Celular.Text +"', '" + txt_TelefonoCasa.Text + "', " + tipoSeguro +", " + departamento +", " + municipio +")";
                cmd.Connection = conexion;
                res = cmd.ExecuteNonQuery();
                conexion.Close();
                limpiardatos();
                llenarGridDatos();

                // LlenarGridView();

                if (res != 0)
                {
                    mensaje.AlertInfo("Registro Ingresado");

                }
            }
            catch (Exception ex)
            {
                mensaje.AlertError("Erro al guardar los datos" + ex.Message);
            }
        }

        private void limpiardatos()
        {
            txt_NombreCompleto.Text = "";
            txt_NoCredito.Text = "";
            txt_nit.Text = "";
            txt_Correo.Text = "";
            txt_Celular.Text = "";
            txt_TelefonoCasa.Text = "";
            ddl_Departamento.SelectedIndex = -1;
            ddl_municipio.Controls.Clear();
        }

        private void llenarGridDatos()
        {

            try
            {
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                adapt = new OracleDataAdapter("SELECT  A.ID_TRAMITE," +
                    " A.NOMBRE, A.NIT, A.MAIL, A.CELULAR, A.TELEFONO_CASA, " +
                    "B.DESCRIPCION, C.NOMBRE_DEPARTAMENTO, " +
                    "D.NOMBRE_MUNICIPIO FROM TB_TRAMITES A " +
                    "INNER JOIN TB_TIPO_SEGURO B ON A.TIPO_SEGURO = B.ID_TIPO_SEGURO " +
                    "INNER JOIN TB_DEPARTAMENTO C ON A.DEPARTAMENTO = C.ID_DEPARTAMENTO " +
                    "INNER JOIN TB_MUNICIPIOS D ON C.ID_DEPARTAMENTO = D.ID_DEPARTAMENTO AND A.MUNICIPIO = D.ID_MUNICIPIO", conexion);
                adapt.Fill(dt, "usuarios");
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
            catch (Exception ex) {
                mensaje.AlertError("No se puede mostrar los datos de los tramites" + ex.Message);
            }
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

        protected void Editar(Int32 id_tramite)
        {
            try
            {
                DataSet dt = new DataSet();
                conexion = new OracleConnection(cadena);
                conexion.Open();
                adapt = new OracleDataAdapter("SELECT  A.ID_TRAMITE, A.NOMBRE, A.NIT, A.MAIL, A.CELULAR, A.TELEFONO_CASA, A.TIPO_SEGURO, A.DEPARTAMENTO, A.MUNICIPIO FROM TB_TRAMITES A" +                    
                    " WHERE ID_TRAMITE =" + id_tramite + "", conexion);
                adapt.Fill(dt, "tramites");
                if (dt.Tables[1].Rows.Count > 0)
                {
                    txt_idTramite.Text = dt.Tables[1].Rows[0][0].ToString();
                    txt_NombreCompleto.Text = dt.Tables[1].Rows[0][1].ToString();
                    txt_nit.Text = dt.Tables[1].Rows[0][2].ToString();
                    txt_Correo.Text = dt.Tables[1].Rows[0][3].ToString();
                    txt_Celular.Text = dt.Tables[1].Rows[0][4].ToString();
                    txt_TelefonoCasa.Text = dt.Tables[1].Rows[0][5].ToString();
                    ddl_tipoSeguro.SelectedValue= dt.Tables[1].Rows[0][6].ToString();
                    ddl_municipio.Controls.Clear();
                    cargarDepartamentos();
                    btn_Guardar.Visible = false;
                    btn_modificar.Visible = true;
                }
                else
                {
                    mensaje.AlertInfo("No hay registros para mostrar en la tabla ");
                }
            }
            catch (Exception ex)
            {
                mensaje.AlertError("error al seleccionar usuario" + ex.Message);
            }

        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 tipoSeguro = 0, departamento = 0, municipio = 0, idtramitemod=0;
                tipoSeguro = Convert.ToInt32(ddl_tipoSeguro.SelectedValue);
                departamento = Convert.ToInt32(ddl_Departamento.SelectedValue);
                municipio = Convert.ToInt32(ddl_municipio.SelectedValue);
                idtramitemod = Convert.ToInt32(txt_idTramite.Text);


                conexion = new OracleConnection(cadena);
                conexion.Open();
                cmd = new OracleCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update TB_TRAMITES " +
                    "set nombre='" + txt_NombreCompleto.Text + "', nit='"+ txt_nit.Text+"', " +
                    "mail='"+ txt_Correo.Text +"', celular='"+ txt_Celular.Text +"', telefono_casa = '"+ txt_TelefonoCasa.Text +"', " +
                    "tipo_seguro = "+ tipoSeguro +", departamento = "+ departamento +", municipio = "+ municipio +" where ID_TRAMITE =" + idtramitemod + "";
                cmd.Connection = conexion;
                res = cmd.ExecuteNonQuery();
                conexion.Close();
                llenarGridDatos();
                mensaje.AlertInfo("Registro actualizado correctamente");
                limpiardatos();
                btn_Guardar.Visible = true;
                btn_modificar.Visible = false;
            }
            catch (Exception ex)
            {
                mensaje.AlertError("Error al actualizar los datos" + ex.Message);
                limpiardatos();
                btn_Guardar.Visible = true;
                btn_modificar.Visible = false;
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 tramite = 0;


                if (txt_idTramite.Text == "0" || txt_idTramite.Text == "")
                {
                    mensaje.AlertInfo("Seleccione primero el tramite que desea eliminar");
                    return;
                }
                else
                {
                    tramite = Convert.ToInt32(txt_idTramite.Text);
                    conexion = new OracleConnection(cadena);
                    conexion.Open();
                    cmd = new OracleCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from tb_tramites where id_tramite= " + tramite + "";
                    cmd.Connection = conexion;
                    res = cmd.ExecuteNonQuery();
                    conexion.Close();
                    llenarGridDatos();
                    mensaje.AlertInfo("Registro Eliminado exitosamente");
                    limpiardatos();
                    ddl_municipio.Controls.Clear();
                    btn_Guardar.Visible = true;
                    btn_modificar.Visible = false;
                }

            }
            catch (Exception ex)
            {
                mensaje.AlertError("Error al eliminar el registro " + ex.Message);
            }
        }

        protected void dgBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}