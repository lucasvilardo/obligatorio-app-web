<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ObligatorioAppWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: 16pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="  text-align: center">
        <span class="auto-style1">POLICLÍNICA RODRIGO</span><br />
        <br />
        <asp:HyperLink ID="hlnkABMPacientes" runat="server" BorderColor="Black" NavigateUrl="~/MantenimientoPacientes.aspx">Mantenimiento de Pacientes</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="hlnkAltaConsultaComun" runat="server" NavigateUrl="~/AltaConsultaComun.aspx">Alta de Consulta Común</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="hlnkAltaConsultaEspecialista" runat="server" NavigateUrl="~/AltaConsultaEspecialista.aspx">Alta de Consulta Especialista</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="hlnkAgregarSolicitud" runat="server" NavigateUrl="~/AgregarSolicitud.aspx">Agregar Solicitud</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="hlnkMarcarAsistenciaSolicitudDeNumero" runat="server" NavigateUrl="~/MarcarAsistenciaSolicitudNumero.aspx">Marcar Asistencia de Solicitud de Número</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="hlnkListadoSolicitudesDeConsulta" runat="server" NavigateUrl="~/ListadoSolicitudesDeConsulta.aspx">Listado de Solicitudes de Consulta</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="hlnkListadoConsultas" runat="server" NavigateUrl="~/ListadoConsultas.aspx">Listado de Consultas</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="hlnkListadoSolicitudesDeConsultaDePaciente" runat="server" NavigateUrl="~/ListadoSolicitudesDeConsultaPaciente.aspx">Listado de Solicitudes de Consulta de Paciente</asp:HyperLink>
        <br />
        <br />
    </form>
</body>
</html>
