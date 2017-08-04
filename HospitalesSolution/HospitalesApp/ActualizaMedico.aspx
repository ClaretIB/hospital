<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizaMedico.aspx.cs" Inherits="HospitalesApp.ActualizaMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 332px; margin-left: 440px; margin-top: 49px">
    
        <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Actualiza Médico"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="DNI médico:  "></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlMedicosModificar" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlMedicosModificar_SelectedIndexChanged" Width="120px">
        </asp:DropDownList>
        <br />
        <hr />
        <br />
        <asp:Label ID="Label3" runat="server" Text="DNI: "></asp:Label>
&nbsp;
        <asp:TextBox ID="tbNuevoDNI" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Especialidad: "></asp:Label>
&nbsp;<asp:TextBox ID="tbNuevaEspecialidad" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Fecha Ingreso: "></asp:Label>
        <asp:TextBox ID="tbNuevaFechaIngreso" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Monto especialidad: "></asp:Label>
&nbsp;<asp:TextBox ID="tbNuevoMonto" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Estado: "></asp:Label>
&nbsp;<asp:TextBox ID="tbNuevoEstado" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnActualizaMedico" runat="server" OnClick="btnActualizaMedico_Click" Text="Actualizar" />
    
    </div>
    </form>
</body>
</html>
