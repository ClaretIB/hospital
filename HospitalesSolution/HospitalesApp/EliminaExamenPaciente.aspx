<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminaExamenPaciente.aspx.cs" Inherits="HospitalesApp.EliminaExamenPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 243px; width: 293px; margin-left: 320px; margin-top: 129px">
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Eliminar examen de paciente"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Paciente: "></asp:Label>
        <asp:DropDownList ID="ddlPaciente" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlPaciente_SelectedIndexChanged" Width="119px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Examen: "></asp:Label>
        <asp:DropDownList ID="ddlExamen" runat="server" AutoPostBack="True" Height="17px" OnSelectedIndexChanged="ddlExamen_SelectedIndexChanged" Width="123px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="tbFechaExamen" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminarExamen" runat="server" OnClick="btnEliminarExamen_Click" Text="Eliminar" />
    
    </div>
    </form>
</body>
</html>
