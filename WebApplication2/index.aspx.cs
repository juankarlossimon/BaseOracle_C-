using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace WebApplication2
{
    public partial class index : System.Web.UI.Page
    {
        string cadena = "Data Source=DESKTOP-4IONSRD;Persist Security Info=True;User ID=PROYECTOBD;Password=123456789;Unicode=True";
        OracleCommand cmd;
        OracleConnection conexion;
        OracleDataAdapter adapt;
        DataSet datos;
        Object resultado;
        int res;

        public void LlenarGridView()
        {
            conexion = new OracleConnection(cadena);
            conexion.Open();
            adapt = new OracleDataAdapter("Select * from Admin ", conexion);
            datos = new DataSet();
            adapt.Fill(datos, "Admin");

            GridView1.DataSource = datos;
            GridView1.DataBind();

            conexion.Close();

        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (BuscarAlumno(Int32.Parse(TextBox1.Text)) == false)
                {
                    conexion = new OracleConnection(cadena);
                    conexion.Open();

                    cmd = new OracleCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Admin (Id, NOMBRE,APELLIDO, PUESTO ) values( " + TextBox1.Text + ", '" + TextBox2.Text + "', '" + TextBox3.Text + "', " + TextBox4.Text + ")";
                    cmd.Connection = conexion;
                    res = cmd.ExecuteNonQuery();
                    conexion.Close();
                    LlenarGridView();

                    if (res != 0)
                    {
                        Response.Write("<script languager=javascript>");
                        Response.Write("alert('Registro ingresado')");
                        Response.Write("</script>");

                    }

                }
                else {
                    Response.Write("<script languager=javascript>");
                    Response.Write("alert('Registro ya existe')");
                    Response.Write("</script>");
                }
                   
               
            }
            catch (Exception ex)
            {

                Response.Write("" + ex.Message);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (BuscarAlumno(Int32.Parse(TextBox1.Text)) == true)
                {
                    conexion = new OracleConnection(cadena);
                    conexion.Open();

                    cmd = new OracleCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Admin  set Id=" + TextBox1.Text + ", NOMBRE= '" + TextBox2.Text + "', APELLIDO= '" + TextBox3.Text + "', PUESTO= " + TextBox4.Text + " where Id= " + TextBox1.Text + "";
                    cmd.Connection = conexion;
                    res = cmd.ExecuteNonQuery();
                    conexion.Close();
                    LlenarGridView();

                    if (res != 0)
                    {
                        Response.Write("<script languager=javascript>");
                        Response.Write("alert('Registro Actualizado')");
                        Response.Write("</script>");

                    }
                }
                else {
                    Response.Write("<script languager=javascript>");
                    Response.Write("alert('Registro no existe')");
                    Response.Write("</script>");

                }

            }
            catch (Exception ex)
            {

                Response.Write("" + ex.Message);
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (BuscarAlumno(Int32.Parse(TextBox1.Text)) == true)
                {
                    conexion = new OracleConnection(cadena);
                    conexion.Open();

                    cmd = new OracleCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Admin where Id= " + TextBox1.Text + "";
                    cmd.Connection = conexion;
                    res = cmd.ExecuteNonQuery();
                    conexion.Close();
                    LlenarGridView();

                    if (res != 0)
                    {
                        Response.Write("<script languager=javascript>");
                        Response.Write("alert('Registro Eliminado')");
                        Response.Write("</script>");

                    }
                }
                else {
                    Response.Write("<script languager=javascript>");
                    Response.Write("alert('Registro no existe')");
                    Response.Write("</script>");
                }

               
            }
            catch (Exception ex)
            {

                Response.Write("" + ex.Message);
            }
        }

        public Boolean BuscarAlumno(int clave)
        {
            try
            {
                conexion = new OracleConnection(cadena);
                conexion.Open();

                cmd = new OracleCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * from Admin  where Id= " + clave +"";
                cmd.Connection = conexion;

                resultado = new object();
                resultado = cmd.ExecuteOracleScalar();
                conexion.Close();
                LlenarGridView();

                if (resultado != null)
                {
                    return true;

                }
                else {
                    return false;
                        }
            }
            catch (Exception ex)
            {
             
                Response.Write("" + ex.Message);
                return true;

            }

            
        }
    }
}