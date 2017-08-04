<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiagnosticoCrud.aspx.cs" Inherits="HospitalesApp.DiagnosticoCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
    <div class="col-md-offset-3 col-md-6">
        <h3>Diagnostico del paciente</h3>
        <br />
    
        Seleccione un paciente:<br />
        <br />
    
    
        <asp:DropDownList ID="ddl_paciente" runat="server" AutoPostBack="True" class="form-control">
        </asp:DropDownList>
        <br />
        <br />
        Seleccione un medico:<br />
        <br />
        <asp:DropDownList ID="ddl_medico" runat="server" AutoPostBack="True" class="form-control">
        </asp:DropDownList>
        <br />
        <br />
        Seleccione un Hospital:<br />
        <br />
        <asp:DropDownList ID="ddl_hospital" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_hospital_SelectedIndexChanged" class="form-control">
        </asp:DropDownList>
        <br />
        <br />
        Seleccione un estado:<br />
        <br />
        <asp:DropDownList ID="ddl_estado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_estado_SelectedIndexChanged" class="form-control">
        </asp:DropDownList>
        <br />
        <br />
        Diagnostico del paciente:<br />
        <br />
        <textarea id="TextArea1" cols="20" name="S1" class="form-control"></textarea><br />
        <br />
        Seleccione la fecha de la cita:<br />
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Page_Load"></asp:Calendar>
        <br />
        <br />
        <asp:Button ID="btn_agregar" runat="server" OnClick="btn_agregar_Click" Text="Agregar" class="btn btn-info" />
        <br />
        <br />
        <asp:Label ID="lbl_agregar" runat="server"></asp:Label>
        </div>
      </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
	<!-- Latest compiled and minified JavaScript -->
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
	
</body>
</html>
