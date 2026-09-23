<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSolicitudesDeConsulta.aspx.cs" Inherits="ObligatorioAppWeb.ListadoSolicitudesDeConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 425px;
        }
    </style>
</head>
<body style="height: 388px">
    <form id="form1" runat="server">
    <div style: align="center" class="auto-style1">
        <span class="auto-style5">LISTADO DE SOLICITUDES POR CONSULTA<br />
    
        ---------------------------------------------------<br />
        Elija una consulta para listar sus solicitudes<br />
        ---------------------------------------------------<br />
        <asp:DropDownList ID="ddlConsultas" runat="server" Height="27px" OnSelectedIndexChanged="ddlConsultas_SelectedIndexChanged" Width="284px">
        </asp:DropDownList>
        <br />
        <br />
        SOLICITUDES<br />
        <asp:ListBox ID="lbxSolicitudes" runat="server" Height="124px" Width="616px"></asp:ListBox>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="hlnkVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
