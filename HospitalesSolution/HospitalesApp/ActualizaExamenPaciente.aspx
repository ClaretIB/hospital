<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizaExamenPaciente.aspx.cs" Inherits="HospitalesApp.ActualizaExamenPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 66px;
        }
        #txtResultado {
            height: 81px;
        }
    </style>
</head>
<body style="margin-top: 32px">
    <form id="form1" runat="server">
    <div style="width: 310px; margin-left: 440px; margin-top: 82px">
    
        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="Larger" Text="Actualiza examen"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Paciente: "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlPaciente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaciente_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Examen: "></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlExamen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExamen_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Fecha a realizar examen:"></asp:Label>
&nbsp;<asp:TextBox ID="tbFechaExamen" runat="server"></asp:TextBox>
        <br />
        <br />
        <hr />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Fecha cita:"></asp:Label>
&nbsp;
        <asp:TextBox ID="tbFechaCita" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Hospital: "></asp:Label>
&nbsp;
        <asp:TextBox ID="tbHospital" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Estado: "></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlEstado" runat="server">
            <asp:ListItem>P</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Resultado: "></asp:Label>
        <br />
        <textarea id="txtResultado" runat="server" cols="20" name="S1"></textarea><br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnActualizarExamen" runat="server" Text="Actualizar" OnClick="btnActualizarExamen_Click" />
        <br />
    
    </div>
    </form>
</body>
</html>
