<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarcarAsistenciaSolicitudNumero.aspx.cs" Inherits="ObligatorioAppWeb.MarcarAsistenciaSolicitudNumero" %>

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
<body>
    <form id="form1" runat="server">
    <div style: align="center" class="auto-style1">
         <span class="auto-style5">MARCAR ASISTENCIA POR SOLICITUD<br />
         <br />
         Elija su Consulta<br />
         <asp:ListBox ID="lbConsultas" runat="server" Height="130px" Width="336px" AutoPostBack="True" OnSelectedIndexChanged="lbConsultas_SelectedIndexChanged"></asp:ListBox>
         <br />
         Marque su Número de solicitud</span><br />
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="269px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
         </asp:DropDownList>
         <br />
         <br />
         <asp:Button ID="btnMarcarAsistencia" runat="server" Text="Marcar Asistencia" Width="170px" OnClick="btnMarcarAsistencia_Click" />
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
