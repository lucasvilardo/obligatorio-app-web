<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaConsultaEspecialista.aspx.cs" Inherits="ObligatorioAppWeb.AltaConsultaEspecialista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 481px;
        }
        .auto-style19 {
            width: 63%;
        }
        .auto-style17 {
            width: 32px;
        }
        .auto-style9 {
            width: 89px;
        }
        .auto-style7 {
            height: 30px;
        }
        .auto-style20 {
            height: 32px;
        }
        .auto-style26 {
            width: 155px;
            height: 28px;
        }
        .auto-style27 {
            width: 94px;
        }
        .auto-style29 {
            height: 28px;
        }
        .auto-style30 {
            font-size: 16pt;
        }
        .auto-style31 {
            width: 155px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style: align="center" class="auto-style1">
        <span class="auto-style30">ALTA DE CONSULTA ESPECIALISTA</span><br />
            <div style="  text-align: center">
            <table border="1" style: align="center" class="auto-style19">
                <tr>
                    <td style="white-space: nowrap; class="auto-style10" class="auto-style31" >Numero de Consultorio:</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txtNumCons" runat="server" Width="59px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        Doctor:</td>
                    <td class="auto-style27">
                        <asp:TextBox ID="txtDoctor" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26">
                        Fecha Y Hora:</td>
                    <td class="auto-style29" colspan="3">
                        <asp:TextBox ID="txtFechaYHora" runat="server" TextMode="DateTimeLocal" Width="254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26">
                        Cantidad Numeros:</td>
                    <td class="auto-style29" colspan="3">
                        <asp:TextBox ID="txtCantNumeros" runat="server" Width="153px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style29" colspan="2">
                        Especialización:</td>
                    <td class="auto-style29" colspan="2">
                        <asp:TextBox ID="txtEspecializacion" runat="server" Width="223px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" colspan="4">
                        <asp:Button ID="btnBuscarConsulta" runat="server" Text="Agregar Consulta" Width="300px" OnClick="btnBuscarConsulta_Click" />
                    &nbsp;
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" Width="129px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20" colspan="4">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
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
    
    </div>
    </form>
</body>
</html>
