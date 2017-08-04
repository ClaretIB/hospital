<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarMedico.aspx.cs" Inherits="HospitalesApp.InsertarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 378px; width: 291px; margin-left: 480px; margin-top: 72px">
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Insertar Médico"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="DNI:"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="tbDNI" runat="server" Height="18px" style="margin-top: 7px" Width="196px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Especialidad: "></asp:Label>
&nbsp;<asp:TextBox ID="tbEspecialidad" runat="server" style="margin-top: 7px" Width="153px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Monto especialidad: "></asp:Label>
&nbsp;<asp:TextBox ID="tbMonto" runat="server" Width="107px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Estado: "></asp:Label>
        <asp:TextBox ID="tbEstado" runat="server" Width="60px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnInsertarMedico" runat="server" OnClick="btnInsertarMedico_Click" Text="Insertar" />
    
    </div>
    </form>
</body>
</html>
