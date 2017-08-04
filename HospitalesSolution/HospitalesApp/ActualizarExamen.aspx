<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarExamen.aspx.cs" Inherits="HospitalesApp.ActualizarExamen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 296px; width: 236px; margin-left: 440px; margin-top: 114px">
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Actualizar Examen"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="ID examen:"></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlExamenes" runat="server" Height="17px" OnSelectedIndexChanged="ddlExamenes_SelectedIndexChanged" Width="114px">
        </asp:DropDownList>
        <br />
        <br />
        <hr style="margin-top: 0px" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="ID: "></asp:Label>
        <asp:TextBox ID="tbNuevoID" runat="server" Width="130px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Tipo: "></asp:Label>
        <asp:TextBox ID="tbNuevoTipo" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Precio: "></asp:Label>
        <asp:TextBox ID="tbPrecio" runat="server" Width="105px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />
    
    </div>
    </form>
</body>
</html>
