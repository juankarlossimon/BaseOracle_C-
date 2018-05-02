<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearTramites.aspx.cs" Inherits="WebApplication2.CrearTramites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="css/EstilosMenuPrincipal.css" rel="stylesheet" />
    <link href="css/EstilosCrearTramites.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="General"style="width:100%;" >
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
 
       <div id="Nombre_Completo" class="input-group" style="width:33%;">           
           <span class="input-group-addon"></span>
           <asp:TextBox ID="txt_NombreCompleto" class="form-control" placeholder="Nombre Completo" runat="server"></asp:TextBox>
           
       </div>

        <div id="No_Credito" class="input-group" style="width:33%;">           
           <span class="input-group-addon"></span>
           <asp:TextBox ID="txt_NoCredito" class="form-control" placeholder="Número de Crédito 20 digitos" runat="server"></asp:TextBox>
           
       </div>

        <div id="Datos_RFC" class="input-group"style="width:33%;">          
           <span class="input-group-addon"></span>
           <asp:TextBox ID="txt_nit" class="form-control" placeholder="NIT" runat="server"></asp:TextBox>           
       </div>

        <div id="Correo_Electronico" class="input-group"style="width:33%;">          
           <span class="input-group-addon"></span>
           <asp:TextBox ID="txt_Correo" class="form-control" placeholder="Mail" runat="server"></asp:TextBox>           
       </div>

             <div id="Celular" class="input-group"style="width:33%;">           
           <span class="input-group-addon"></span>
           <asp:TextBox ID="txt_Celular" class="form-control" placeholder="Celular" runat="server"></asp:TextBox>           
       </div>
            <div id="Tel_Casa" class="input-group"style="width:33%;">          
           <span class="input-group-addon"></span>
           <asp:TextBox ID="txt_TelefonoCasa" class="form-control" placeholder="Teléfono de Casa" runat="server"></asp:TextBox>           
       </div>
      
       <div id="Solicita_Tramites" class="input-group"style="width:33%;">          
           <span class="input-group-addon">TipoSeguro</span>
           <asp:DropDownList runat="server" ID="ddl_tipoSeguro" class="form-control" placeholder="Tipo de Seguro">              
           </asp:DropDownList>          
       </div>

        <div id="Dirc_depar" class="input-group"style="width:33%;">          
           <span class="input-group-addon">Departamento</span>
           <asp:DropDownList runat="server" ID="ddl_Departamento" class="form-control" placeholder="Tipo de Seguro" AutoPostBack="true" OnSelectedIndexChanged="ddl_Departamento_SelectedIndexChanged">              
           </asp:DropDownList>          
       </div>

       <div id="Dirc_Muni" class="input-group"style="width:33%;">          
           <span class="input-group-addon">Municipio</span>
           <asp:DropDownList runat="server" ID="ddl_municipio" class="form-control" placeholder="Tipo de Seguro">              
           </asp:DropDownList>          
       </div>
   
            <asp:TextBox  ID="txt_idTramite" runat="server" Visible="false"></asp:TextBox>
             <div  class="input-group"style="width:100%;">
                    <div class="col-lg-offset-2 col-lg-10">
                        <asp:Button ID="btn_Guardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btn_Guardar_Click"  />
                        <asp:Button ID="btn_limpiar" runat="server" Text="Limpiar Campos" CssClass="btn btn-success" OnClick="btn_limpiar_Click"  />
                         <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CssClass="btn btn-success" visible="false" OnClick="btn_modificar_Click" />
                          <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btn_eliminar_Click"  />
                          <asp:Button ID="btn_buscar" runat="server" Text="Buscar" CssClass="btn btn-info"  />
                    </div>
                </div>

             <div class="form-group">
                    <div id="DatosGrid" class="form-group" style="padding-left: 1%; padding-right: 1%; padding-top: 20px">
                                <div id="grid">
                                    <asp:GridView ID="dgBusqueda" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin Resultados"
                                        class="table table-striped table-bordered table-condensed table-hover" AllowPaging="True" PageSize="8"  OnRowCommand="dgBusquda_RowCommand"   AutoPostBack="true" OnSelectedIndexChanged="dgBusqueda_SelectedIndexChanged">

                                        <HeaderStyle BackColor="#89D1F3" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="Opciones">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Crear" CommandArgument='<%# Eval("ID_TRAMITE") %>' CssClass="btn btn-info" Text="Crear Tramite">Seleccionar&nbsp; </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID_TRAMITE" HeaderText="ID_TRAMITE" SortExpression="ID_TRAMITE" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE"></asp:BoundField>
                                            <asp:BoundField DataField="NIT" HeaderText="NIT" SortExpression="NIT"></asp:BoundField>
                                            <asp:BoundField DataField="MAIL" HeaderText="MAIL" SortExpression="MAIL"></asp:BoundField>
                                            <asp:BoundField DataField="CELULAR" HeaderText="CELULAR" SortExpression="CELULAR"></asp:BoundField>
                                            <asp:BoundField DataField="TELEFONO_CASA" HeaderText="TELEFONO_CASA" SortExpression="TELEFONO_CASA"></asp:BoundField>
                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="DESCRIPCION"></asp:BoundField>
                                            <asp:BoundField DataField="NOMBRE_DEPARTAMENTO" HeaderText="NOMBRE_DEPARTAMENTO" SortExpression="NOMBRE_DEPARTAMENTO"></asp:BoundField>
                                            <asp:BoundField DataField="NOMBRE_MUNICIPIO" HeaderText="NOMBRE_MUNICIPIO" SortExpression="NOMBRE_MUNICIPIO"></asp:BoundField>
                                        </Columns>
                                        <RowStyle Wrap="True" />
                                    </asp:GridView>

                                </div>               
                    </div>

                </div>
           
        </ContentTemplate>
     </asp:UpdatePanel>
   
    </div>
</asp:Content>
