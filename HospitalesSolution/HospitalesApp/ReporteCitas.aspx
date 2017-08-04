<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCitas.aspx.cs" Inherits="HospitalesApp.ReporteCitas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Reporte de Citas"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Paciente: "></asp:Label>
        <asp:DropDownList ID="ddlPacientes" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlPacientes_SelectedIndexChanged" Width="138px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvCitas" runat="server" Height="121px" Width="339px">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
