using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            String Usuario, Pass;

            try
            {
                Usuario = user.Text;
                Pass = password.Text;

                if (Usuario == "admin" && Pass == "123")
                {
                    Response.Redirect("/home.aspx");
                }
                else
                {
                    cAlert a = new cAlert();
                    a.AlertWarning("Datos Invalidos");
                }
            }
            catch (Exception ex)
            { }
        }
    }
}