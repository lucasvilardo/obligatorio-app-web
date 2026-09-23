<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaConsultaComun.aspx.cs" Inherits="ObligatorioAppWeb.AltaConsultaComun" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style7 {
            height: 30px;
        }
        .auto-style9 {
            width: 89px;
        }
        .auto-style12 {
            width: 127px;
            height: 28px;
        }
        .auto-style16 {
            height: 28px;
        }
        .auto-style17 {
            width: 32px;
        }
        .auto-style19 {
            width: 70%;
        }
        .auto-style20 {
            height: 32px;
        }
        .auto-style21 {
            width: 127px;
        }
        .auto-style22 {
            font-size: 16pt;
        }
        .auto-style23 {
            width: 95px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div style="  text-align: center">
            <span class="auto-style22">ALTA DE CONSULTA COMÚN</span><br />
            <br />
            <div style="  text-align: center">
            <table border="1" style: align="center" class="auto-style19">
                <tr>
                    <td style="white-space: nowrap; class="auto-style10" class="auto-style21" >Numero de Consultorio:</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txtNumCons" runat="server" Width="59px"></asp:TextBox>
                    </td>
                    <td class="auto-style23">
                        Fecha Y Hora:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtfecha" runat="server" TextMode="DateTimeLocal" Width="145px"></asp:TextBox>
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        Doctor:</td>
                    <td class="auto-style16" colspan="3">
                        <asp:TextBox ID="txtDoctor" runat="server" Width="235px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        Enfermería:</td>
                    <td class="auto-style16" colspan="3">
        <span class="auto-style5">
        <asp:RadioButtonList ID="rbtnEnfermeria" runat="server" RepeatDirection="Horizontal" Width="243px">
            <asp:ListItem>SI</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        Cantidad Numeros:</td>
                    <td class="auto-style16" colspan="3">
                        <asp:TextBox ID="txtCantNum" runat="server" Width="259px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" colspan="4">
                        <asp:Button ID="btnAgregarConsulta" runat="server" Text="Agregar Consulta" Width="300px" OnClick="btnAgregarConsulta_Click" />
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" Width="116px" />
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
