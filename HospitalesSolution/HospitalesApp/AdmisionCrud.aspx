<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmisionCrud.aspx.cs" Inherits="HospitalesApp.AdmisionCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
    <div class="col-md-offset-3 col-md-6">
    
        <h3>Admision de paciente</h3>
        <p>
            Seleccione un paciente:</p>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" class="form-control">
        </asp:DropDownList>
        <br />
        <br />
        Seleccione un Hospital:<br />
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" class="form-control">
        </asp:DropDownList>
        <br />
        <br />
        Seleccione un numero de sala:<br />
        <br />
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" class="form-control">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Btn_Agregar" runat="server" OnClick="Btn_Agregar_Click" Text="Agregar" class="btn btn-info"/>
&nbsp;<br />
        <asp:Label ID="lbl_agregar" runat="server"></asp:Label>
        <br />
        <br/>
        <h4>Si se desea eliminar o&nbsp; actualizar una admision presione una opcion:</h4>
        <p>
&nbsp;&nbsp;
            <asp:Button ID="btn_borrar" runat="server" OnClick="btn_borrar_Click" Text="Eliminar"  class="btn btn-info"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:DropDownList ID="ddl_eliminar" runat="server" AutoPostBack="True" class="form-control">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="btn_Accion_eliminar" runat="server" OnClick="btn_Accion_eliminar_Click" Text="Borrar" class="btn btn-info"/>
        </p>
        <p>
            <asp:Button ID="btn_actualizar" runat="server" OnClick="btn_actualizar_Click" Text="Actualizar" class="btn btn-info"/>
        </p>
        <p>
            <asp:Label ID="lb_paciente" runat="server" Text="Si desea cambiar el paciente seleccione alguna de estas opciones:"></asp:Label>
        </p>
        
        

&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCambiaPaciente" runat="server"  class="form-control">
        </asp:DropDownList>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lb_hospital" runat="server" Text="Si desea cambiar el hospital seleccione alguna de las siguientes opciones: "></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl_cambia_hospital" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_cambia_hospital_SelectedIndexChanged"  class="form-control">
        </asp:DropDownList>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lb_sala" runat="server" Text="Si desea cambiar la sala seleccione alguna de las siguientes opciones:"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl_cambia_sala" runat="server"  class="form-control">
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Accion_Actualizar" runat="server" OnClick="btn_Accion_Actualizar_Click" Text="Actualizar" class="btn btn-info"/>
    
        </div>
     </form>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
	<!-- Latest compiled and minified JavaScript -->
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
	
    </body>
</html>
