<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="HospitalesApp.Pacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 470px;
        }
    </style>

    <meta name="viewport" content="width=device-width, initial -scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
		<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 372px; margin-left: 15px">
    
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="Label1" runat="server" Text="Vista Pacietes" Font-Italic="True" Font-Size="24pt" Font-Bold="True"></asp:Label>
    
            </div>

             <div style="height: 120px; width: 685px; margin-left: 11px; margin-top: 8px">
    
                 <asp:Label ID="Label2" runat="server" Font-Size="18pt" Text="Elija un opción:"></asp:Label>
                 <br />
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="btnInsertar" runat="server" OnClick="btnInsertar_Click">Insertar Paciente</asp:LinkButton>
&nbsp;
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="btnActualizar" runat="server" OnClick="btnActualizar_Click">Actualizar Información</asp:LinkButton>
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar Paciente</asp:LinkButton>
                 <br />
                 <br />
                 <br />
    
            </div>
            <div style="height: 127px">



                <br />
                <asp:Label ID="Label3" runat="server" Text="Seleccione un paciente"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:DropDownList ID="ddlPaciente" runat="server" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlPaciente_SelectedIndexChanged">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="Button1_Click"  class="btn btn-primary" Enabled="False" />

                &nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="Actulizar" class="btn btn-primary" Enabled="False" OnClick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" class="btn btn-primary" Enabled="False" OnClick="btnDelete_Click" />

                <br />



            </div>
            <div style="height: 656px">

                 <div class="row">
                	<div class="col-sm-3">
                    
                    	<asp:TextBox ID="tbNumero" runat="server"  Width="300px" AutoPostBack="True" placeholder="Número de Paciente" class="form-control" Enabled="False" ></asp:TextBox>
                     </div>
                     
                    <div class="col-sm-3">
                    	<asp:TextBox ID="tbDNI" runat="server" Width="300px" AutoPostBack="True" placeholder="Cédula" class="form-control" Enabled="False" ></asp:TextBox>
                    	
                    </div>
                     <div class="col-sm-3"></div>
                     <div class="col-sm-3"></div>
                 </div>
                <div class="row">
                	<div class="col-sm-6">
                    
                    	<asp:TextBox ID="tbNombre" runat="server"  Width="300px" AutoPostBack="True" placeholder="Nombre Completo" class="form-control" Enabled="False" ></asp:TextBox>
                     </div>
                     
                    <div class="col-sm-6">
                    	<asp:TextBox ID="tbDireccion" runat="server" Width="300px" AutoPostBack="True" placeholder="Dirección" class="form-control" Enabled="False"></asp:TextBox>
                    	
                    </div>
                     <div class="col-sm-3"></div>
                     <div class="col-sm-3"></div>
                 </div>
                <div class="row">
                	<div class="col-sm-3">
                    
                    	<asp:TextBox ID="tbTelefono" runat="server"  Width="300px" AutoPostBack="True" placeholder="Télefono" class="form-control" Enabled="False" TextMode="Phone"></asp:TextBox>
                     </div>
                     
                    <div class="col-sm-3">
                    	<asp:TextBox ID="tbCompania" runat="server" Width="300px" AutoPostBack="True" placeholder="Compañía" class="form-control" Enabled="False"></asp:TextBox>
                    	
                    </div>
                     <div class="col-sm-3"></div>
                     <div class="col-sm-3"></div>
                 </div>
                <div class="row">
                	<div class="col-sm-3">
                    
                    	<asp:TextBox ID="tbTipoSeguro" runat="server"  Width="300px" AutoPostBack="True" placeholder="Tipo de Seguro Social" class="form-control" Enabled="False" ></asp:TextBox>
                     </div>
                     
                    <div class="col-sm-3">
                    	<asp:TextBox ID="tbNSS" runat="server" Width="300px" AutoPostBack="True" placeholder="Número de Seguro Social" class="form-control" Enabled="False"></asp:TextBox>
                    	
                    </div>
                     <div class="col-sm-3"></div>
                     <div class="col-sm-3"></div>
                 </div>
                <div class="row">
                	<div class="col-sm-3">
                    
                    	<asp:TextBox ID="tbMontoCobertura" runat="server"  Width="300px" AutoPostBack="True" placeholder="Monto de Cobertura" class="form-control" Enabled="False"></asp:TextBox>
                     </div>
                     
                    <div class="col-sm-3"></div>
                     <div class="col-sm-3"></div>
                     <div class="col-sm-3"></div>
                 </div> 

            </div>
    </form>
</body>
</html>
