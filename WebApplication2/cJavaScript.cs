using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;

namespace WebApplication2
{
    public class cJavaScript
    {
        public void EjecutarFuncionJS(String JavaScript)
        {
            if (HttpContext.Current.CurrentHandler is Page)
            {
                Page p = (Page)HttpContext.Current.CurrentHandler;

                if (ScriptManager.GetCurrent(p) != null)
                {
                    ScriptManager.RegisterStartupScript(p, typeof(Page), Guid.NewGuid().ToString(), JavaScript, true);
                }
                else
                {
                    p.ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), JavaScript, true);
                }
            }
        }
    }
}