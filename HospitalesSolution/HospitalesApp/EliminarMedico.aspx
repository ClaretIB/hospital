<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarMedico.aspx.cs" Inherits="HospitalesApp.EliminarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 189px; width: 242px; margin-left: 480px; margin-top: 97px">
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Eliminar Médico"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="DNI Médico:"></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlMedicos" runat="server" Height="16px" Width="136px">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminarMedico" runat="server" OnClick="btnEliminarMedico_Click" Text="Eliminar" />
    
    </div>
    </form>
</body>
</html>
