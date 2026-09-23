<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoPacientes.aspx.cs" Inherits="ObligatorioAppWeb.MantenimientoPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 307px;
        }
        .auto-style3 {
            width: 48%;
            height: 152px;
        }
        .auto-style4 {
            height: 28px;
            width: 102px;
        }
        .auto-style7 {
            height: 28px;
            width: 126px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            height: 28px;
            width: 274px;
        }
        .auto-style14 {
            height: 27px;
        }
        .auto-style16 {
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="  text-align: center" class="auto-style1">
        <strong><span style="font-size: 16pt; color:black; ">Mantenimiento de Pacientes</span></strong>
    
        <table border="1" class="auto-style3" style: align="center">
            <tr>
                <td class="auto-style7">Cédula:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtCi" runat="server" CssClass="auto-style10" Height="18px" Width="187px"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Nombre y Apellido:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtNombre" runat="server" Width="188px" Height="27px"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">Fecha Nacimiento:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtFechaNac" runat="server" Width="188px" Height="26px" TextMode="DateTimeLocal"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style14">
                    <asp:Button ID="btnAlta" runat="server" Height="20px" Text="Alta" Width="70px" OnClick="btnAlta_Click" />
&nbsp;
                    <asp:Button ID="btnModificar" runat="server" Height="20px" Text="Modificar" Width="70px" OnClick="btnModificar_Click" />
&nbsp;
                    <asp:Button ID="btnEliminar" runat="server" Height="20px" Text="Eliminar" Width="70px" OnClick="btnEliminar_Click" />
                </td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16" colspan="3">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
        <asp:HyperLink ID="hlnkVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
