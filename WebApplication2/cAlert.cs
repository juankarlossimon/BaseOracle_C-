using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class cAlert
    {
        cJavaScript oJS = new cJavaScript();
        public void AlertError(String Mensaje)
        {
            Mensaje = Mensaje.Replace("'", @"\'").Replace("\n", String.Empty).Replace("\r", String.Empty).Replace("'", String.Empty);
            String sScript = "setTimeout(function(){CustomizedAlertError('" + Mensaje + "','Error')},100);";
            oJS.EjecutarFuncionJS(sScript);
        }
        public void AlertWarning(String Mensaje)
        {
            Mensaje = Mensaje.Replace("'", @"\'").Replace("\n", String.Empty).Replace("\r", String.Empty).Replace("'", String.Empty);
            String sScript = "setTimeout(function(){CustomizedAlertWarning('" + Mensaje + "','warning')},100);";
            oJS.EjecutarFuncionJS(sScript);
        }
        public void AlertInfo(String Mensaje)
        {
            Mensaje = Mensaje.Replace("'", @"\'").Replace("\n", String.Empty).Replace("\r", String.Empty).Replace("'", String.Empty);
            String sScript = "setTimeout(function(){CustomizedAlertInfo('" + Mensaje + "','info')},100);";
            oJS.EjecutarFuncionJS(sScript);
        }
        public void AlertSucces(String Mensaje)
        {
            Mensaje = Mensaje.Replace("'", @"\'").Replace("\n", String.Empty).Replace("\r", String.Empty).Replace("'", String.Empty);
            String sScript = "setTimeout(function(){CustomizedAlertSuccess('" + Mensaje + "','success')},100);";
            oJS.EjecutarFuncionJS(sScript);
        }
        public void AlertConfirm(String Titulo, String Mensaje)
        {
            Mensaje = Mensaje.Replace("'", @"\'").Replace("\n", String.Empty).Replace("\r", String.Empty).Replace("'", String.Empty);
            String sScript = "setTimeout(function(){CustomizedConfirm('" + Mensaje + "','" + Titulo + "')},100);";
            oJS.EjecutarFuncionJS(sScript);
        }

        public void Modal()
        {
            String sScript = "setTimeout( function Modal_MotivoLlamada(newModal) {$('#Modal_MotivoLlamada').modal('show');},100);";
            oJS.EjecutarFuncionJS(sScript);
        }
    }
}