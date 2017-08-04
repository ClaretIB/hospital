<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaCitas.aspx.cs" Inherits="HospitalesApp.VistaCitas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 604px;
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
                 <asp:Label ID="Label1" runat="server" Text="Vista Citas" Font-Italic="True" Font-Size="24pt" Font-Bold="True"></asp:Label>
    
            </div>

             <div style="height: 120px; width: 685px; margin-left: 11px; margin-top: 8px">
    
                 <asp:Label ID="Label2" runat="server" Font-Size="18pt" Text="Elija un opción:"></asp:Label>
                 <br />
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="btnInsertar" runat="server" OnClick="btnInsertar_Click">Insertar Cita</asp:LinkButton>
&nbsp;
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="btnActualizar" runat="server" OnClick="btnActualizar_Click">Actualizar Información</asp:LinkButton>
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar Cita</asp:LinkButton>
                 <br />
                 <br />
                 <br />
    
            </div>
            <div style="height: 200px">



                   <div class="row">

                        <div class="col-sm-4">

                            <asp:Label ID="Label3" runat="server" Text="Seleccione un Paciente"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlPacienteViejo" runat="server" AutoPostBack="True" Enabled="false" >
                            </asp:DropDownList>
                    	                    	
                        &nbsp;&nbsp;
                    	                    	
                        </div>

                        <div class="col-sm-4">

                            <asp:Label ID="Label8" runat="server" Text="Seleccione una fecha"></asp:Label>
                            <br />
                           <asp:TextBox ID="tbFechaVieja" runat="server"  Width="300px" AutoPostBack="True" class="form-control" Enabled="False" TextMode="Date" ></asp:TextBox>
                    	                    	
                        </div>

                        <div class="col-sm-4">

                            <asp:Label ID="Label10" runat="server" Text="Seleccione una hora"></asp:Label>
                            <br />
                             <asp:TextBox ID="tbHoraVieja" runat="server"  Width="300px" AutoPostBack="True" class="form-control" Enabled="False" TextMode="Time" ></asp:TextBox>
                    	                    	
                        </div>

                   </div>
                <br />

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="Button1_Click"  class="btn btn-primary" Enabled="False" />

                &nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="Actulizar" class="btn btn-primary" Enabled="False" OnClick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" class="btn btn-primary" Enabled="False" OnClick="btnDelete_Click" />

                <br />

            </div>
            <div class="row">

                <div class="col-sm-2">

                    <asp:Label ID="Label4" runat="server" Text="Seleccione un hospital"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlHospitales" runat="server" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="ddlHospitales_SelectedIndexChanged">
                    </asp:DropDownList>
                    	                    	
                &nbsp;&nbsp;
                    	                    	
                </div>

                <div class="col-sm-2">

                    <asp:Label ID="Label9" runat="server" Text="Seleccione un paciente"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlPacientes" runat="server" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="ddlPacientes_SelectedIndexChanged">
                    </asp:DropDownList>
                    	                    	
                </div>

                <div class="col-sm-2">

                    <asp:Label ID="Label5" runat="server" Text="Seleccione un medico"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
                    </asp:DropDownList>
                    	                    	
                </div>

                <div class="col-sm-3">

                    <asp:Label ID="Label6" runat="server" Text="Seleccione un Fecha"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbFecha" runat="server"  Width="300px" AutoPostBack="True" class="form-control" Enabled="False" TextMode="Date" OnTextChanged="tbFecha_TextChanged" ></asp:TextBox>
                    	                    	
                </div>

                <div class="col-sm-3">

                    <asp:Label ID="Label7" runat="server" Text="Seleccione una hara " ></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlHoras" runat="server" AutoPostBack="True">
                   </asp:DropDownList>                   	
                </div>
            </div>
    </form>
</body>
</html>