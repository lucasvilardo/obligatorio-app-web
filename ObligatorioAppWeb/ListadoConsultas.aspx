<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoConsultas.aspx.cs" Inherits="ObligatorioAppWeb.ListadoConsultas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 479px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style: align="center" class="auto-style1">
        LISTADO DE CONSULTAS<br />
        <br />
        Elija un tipo de consulta para listar todas las disponibles<br />
        <br />
        <asp:DropDownList ID="ddlConsultas" runat="server" AutoPostBack="True" Height="17px" Width="159px" OnSelectedIndexChanged="ddlConsultas_SelectedIndexChanged">
            <asp:ListItem>-------------------------------</asp:ListItem>
            <asp:ListItem>Consulta Común</asp:ListItem>
            <asp:ListItem>Consulta Especialista</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:ListBox ID="lbxConsultas" runat="server" Height="197px" Width="863px"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="hlnkVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
