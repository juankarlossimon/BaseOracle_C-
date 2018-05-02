<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div>
            Id :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div>
            Nombre :<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            Apellido:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>

        <div>
            Puesto:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>

         <div>
           
        </div>

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="Editar" OnClick="Button2_Click" />
        </div>
        
        <div>
            <asp:Button ID="Button3" runat="server" Text="Eliminar" OnClick="Button3_Click" />
        </div>

        <div>
            <asp:Button ID="Button4" runat="server" Text="Buscar" />
            </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </form>

        
</body>
</html>
