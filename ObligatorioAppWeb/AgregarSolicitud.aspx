<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSolicitud.aspx.cs" Inherits="ObligatorioAppWeb.AgregarSolicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 41%;
            height: 86px;
        }
        .auto-style2 {
            width: 130px;
        }
        .auto-style3 {
            width: 130px;
            height: 27px;
        }
        .auto-style4 {
            height: 27px;
        }
        .auto-style5 {
            font-size: 16pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style: align="center">
        <span class="auto-style5">AGREGAR SOLICITUD</span><br />
        <br />
        <asp:DropDownList ID="ddlConsultas" runat="server" Height="22px" Width="166px" style="overflow:auto" AutoPostBack="True" OnSelectedIndexChanged="ddlConsultas_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPacientes" runat="server" Height="22px" Width="166px" style="overflow:auto">
        </asp:DropDownList>
        <br />
        <table border="1" class="auto-style1">
            <tr>
                <td class="auto-style2">Fecha y hora:</td>
                <td>
                    <asp:Label ID="lblFechaYHora" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Seleccionar número:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlNumeroSol" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Solicitud" Width="327px" OnClick="btnAgregar_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:HyperLink ID="hlnkVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
