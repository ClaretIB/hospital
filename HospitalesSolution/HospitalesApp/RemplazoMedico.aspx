<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemplazoMedico.aspx.cs" Inherits="HospitalesApp.RemplazoMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Remplazo de medicos<br />
        <br />
        Seleccione el medico a remplazar:<br />
    
    </div>
        <asp:DropDownList ID="ddl_medicos" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Ingrese el nombre del medico nuevo:
        <asp:TextBox ID="tb_medico" runat="server" Width="238px"></asp:TextBox>
        <br />
        <br />
        Ingrese la especialidad:<asp:TextBox ID="tb_especialidad" runat="server" Width="161px"></asp:TextBox>
        <br />
        <br />
        Ingrese el monto de la especilidad:
        <asp:TextBox ID="tb_monto_especilidad" runat="server" Width="207px"></asp:TextBox>
        <br />
        <br />
        Seleccione la fecha de ingreso:<br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="20px" NextPrevFormat="FullMonth" Width="356px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
        <br />
        <br />
        Ingrese el estado del medico:
        <asp:TextBox ID="tb_estado" runat="server" Width="163px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btn_remplazar" runat="server" OnClick="btn_remplazar_Click" Text="Reemplazar" />
    </form>
</body>
</html>
