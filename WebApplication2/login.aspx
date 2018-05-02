<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.login" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Base de Datos 2</title>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE10" />        
    <script src="js/sweetalert-dev.js"></script>
    <script src="js/sweetalert.min.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/ValidacionesForm.js" type="text/javascript"></script>
    <script src="js/Validaciones.js"></script>
    <link href="css/EstilosLoginSistema.css" rel="stylesheet" type="text/css"/>
     <style type="text/css">
        #foto {
            width: 435px;
        }
    </style>
</head>
<body>
    <div id="fotologion" >
        <img  class="img-rounded" alt="Cinque Terre" src="Imagenes/img.png"/>
    </div>
  <div class="login">
	<h1>Ingreso de Usuario</h1>
    <form method="post" runat="server">
        <%--<input type="text" name="u" placeholder="Username" required="required" />--%>
    	<asp:TextBox ID="user" name="u" runat="server"></asp:TextBox>
        <%--<input type="password" name="p" placeholder="Password" required="required" />--%>
        <asp:TextBox ID="password" name="p" runat="server" TextMode="Password"></asp:TextBox>       
         <%--<button type="submit" class="btn btn-primary btn-block btn-large">Let me in.</button>--%>
        <asp:Button ID="BtnAceptar" Text="Aceptar" CssClass="btn btn-primary btn-block btn-large" runat="server" OnClientClick="return validar();" OnClick="BtnAceptar_Click"  /> <!--OnClick="BtnAceptar_Click"-->
    </form>
</div>

</body>
</html>
