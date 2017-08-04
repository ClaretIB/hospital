<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarExamenPaciente.aspx.cs" Inherits="HospitalesApp.InsertarExamenPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 294px; margin-left: 480px; margin-top: 184px">
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Nuevo Examen"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Paciente: "></asp:Label>
        <asp:DropDownList ID="ddlPacientes" runat="server" Height="17px" Width="144px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Fecha Cita: "></asp:Label>
        <asp:TextBox ID="tbFechaCita" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Exámenes"></asp:Label>
        :<br />
        <br />
        <asp:ListBox ID="lbExamenesAgregar" runat="server" Width="89px" SelectionMode="Multiple"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lbExamenesElegidos" runat="server" Width="89px" SelectionMode="Multiple"></asp:ListBox>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregarExamen" runat="server" OnClick="btnAgregarExamen_Click" Text="Agregar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminarExamenes" runat="server" Text="Descartar" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Hospital: "></asp:Label>
        <asp:DropDownList ID="ddlHospitales" runat="server" Height="18px" Width="139px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Fecha a realizar:"></asp:Label>
&nbsp;
        <asp:TextBox ID="tbFecha" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregarExamenPaciente" runat="server" OnClick="btnAgregarExamenPaciente_Click" Text="Insertar" />
    
    </div>
    </form>
</body>
</html>
