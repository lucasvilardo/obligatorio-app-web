<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSolicitudesDeConsultaPaciente.aspx.cs" Inherits="ObligatorioAppWeb.ListadoSolicitudesDeConsultaPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 53%;
        }
        .auto-style2 {
            width: 167px;
        }
        .auto-style3 {
            width: 227px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style: align="center">
        <span class="auto-style5">LISTADO DE SOLICITUDES DE CONSULTA POR PACIENTE Y SU AÑO<br />
        <br />
        <table border="1" class="auto-style1">
            <tr>
                <td class="auto-style2">Cédula:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtCi" runat="server" Width="156px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Elegir un año:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtAnio" runat="server" Width="96px"></asp:TextBox>
                </td>
                <td>
        <span class="auto-style5">
        <asp:RadioButtonList ID="rbtnSolicitudes" runat="server" Width="199px">
            <asp:ListItem>Solicitudes Asistidas</asp:ListItem>
            <asp:ListItem>Solicitudes No Asistidas</asp:ListItem>
        </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="165px" OnClick="btnBuscar_Click" />
                <br />
        <br />
        <asp:ListBox ID="lbxSolicitudes" runat="server" Height="115px" Width="390px"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
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
