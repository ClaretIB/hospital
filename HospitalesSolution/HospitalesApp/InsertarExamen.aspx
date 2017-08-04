<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarExamen.aspx.cs" Inherits="HospitalesApp.InsertarExamen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 262px; width: 232px; margin-left: 520px; margin-top: 103px">
    
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="True" Font-Size="Larger" Text="Insertar Examen"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="ID: "></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="tbIdExamen" runat="server" Width="134px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Tipo: "></asp:Label>
        <asp:TextBox ID="tbTipo" runat="server" Width="136px" ></asp:TextBox>
    
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Precio: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="122px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnInsertarExamen" runat="server" Text="Insertar" />
    
    </div>
    </form>
</body>
</html>
