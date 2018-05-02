<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ingreso_usuarios.aspx.cs" Inherits="WebApplication2.ingreso_usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/ValidacionesForm.js" type="text/javascript"></script>
    <script src="js/Validaciones.js"></script>
    <link href="css/EstilosMenuPrincipal.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div id="fotologion" >
        <img  class="img-rounded" alt="Cinque Terre" src="Imagenes/img.png"/>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <div id="usuarios" class="ContenedorElementos">
        <div class="panel panel-info">
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label class="col-lg-2 control-label">Nombre</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="txt_Nombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label">Codigo Departamento</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="txt_Apaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label">Fecha Nacimiento</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="txt_Materno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                  <div class="form-group">
                        <label class="col-lg-2 control-label">codigo empleado</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="txt_codigo_empleado" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <%--  <div class="form-group">
                        <label class="col-lg-2 control-label">Telefono</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-lg-2 control-label">Correo</label>
                        <div class="col-xs-3">
                            <asp:TextBox ID="txt_correo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label">Perfil</label>
                        <div class="col-xs-3">
                            <asp:DropDownList ID="ddl_ocupacion" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>--%>

                    <asp:TextBox ID="txt_idUsuario" runat="server" Visible="false"></asp:TextBox>
                    <div class="form-group">
                        <div class="col-lg-offset-2 col-lg-10">
                            <asp:Button ID="btn_Guardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btn_Guardar_Click"  Visible="true"/>
                            <asp:Button ID="btn_Actualizar" runat="server" Text="Editar" CssClass="btn btn-success" OnClick="btn_Actualizar_Click" Visible="false" />
                            <asp:Button ID="btn_limpiar" runat="server" Text="Limpiar Campos" CssClass="btn btn-success" OnClick="btn_limpiar_Click" />
                            <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btn_eliminar_Click" />
                            <asp:Button ID="btn_buscar" runat="server" Text="Buscar" CssClass="btn btn-info" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div id="DatosGrid" class="form-group" style="padding-left: 1%; padding-right: 1%; padding-top: 20px">
                                <div id="grid">
                                    <asp:GridView ID="dgBusqueda" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin Resultados"
                                        class="table table-striped table-bordered table-condensed table-hover" AllowPaging="True" PageSize="25" OnSelectedIndexChanged="dgBusquda_SelectedIndexChanged" OnRowCommand="dgBusquda_RowCommand"   AutoPostBack="true">

                                        <HeaderStyle BackColor="#89D1F3" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="Opciones">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Crear" CommandArgument='<%# Eval("CODIGO_EMPLEADO") %>' CssClass="btn btn-info" Text="Crear Tramite">Seleccionar&nbsp; </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CODIGO_EMPLEADO" HeaderText="CODIGO_EMPLEADO" SortExpression="CODIGO_EMPLEADO" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="NOMBRE_EMPLEADO" HeaderText="NOMBRE_EMPLEADO" SortExpression="NOMBRE_EMPLEADO"></asp:BoundField>
                                            <asp:BoundField DataField="CODIGO_DEPTO" HeaderText="CODIGO_DEPTO" SortExpression="CODIGO_DEPTO"></asp:BoundField>
                                            <asp:BoundField DataField="FECHA_NACIMIENTO" HeaderText="FECHA_NACIMIENTO" SortExpression="FECHA_NACIMIENTO"></asp:BoundField>
                                          <%--  <asp:BoundField DataField="DIRECION" HeaderText="DIRECION" SortExpression="DIRECION"></asp:BoundField>
                                            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" SortExpression="TELEFONO"></asp:BoundField>
                                            <asp:BoundField DataField="CORREO" HeaderText="CORREO" SortExpression="CORREO"></asp:BoundField>
                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="PUESTO"></asp:BoundField>--%>
                                        </Columns>
                                        <RowStyle Wrap="True" />
                                    </asp:GridView>

                                </div>               
                    </div>

                </div>
            </div>
        </div>
    </div>

        </ContentTemplate>
    </asp:UpdatePanel> 
    
   


</asp:Content>

