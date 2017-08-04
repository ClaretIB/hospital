<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarExamen.aspx.cs" Inherits="HospitalesApp.EliminarExamen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 139px; width: 193px; margin-left: 520px; margin-top: 131px">
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Eliminar Examen"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="ID: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="128px">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminarExamen" runat="server" Text="Eliminar" />
    
    </div>
    </form>
</body>
</html>
