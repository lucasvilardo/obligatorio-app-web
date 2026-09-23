using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Drawing;

namespace ObligatorioAppWeb
{
    public partial class ListadoSolicitudesDeConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";

                if (!IsPostBack)
                {
                    List<Consulta> colConsultas = LogicaConsulta.ListarConsultas();
                    Session["TodasLasConsultas"] = colConsultas;

                    if (colConsultas.Count > 0)
                    {
                        ddlConsultas.DataSource = colConsultas;
                        ddlConsultas.DataTextField = "AMostrar";
                        ddlConsultas.DataValueField = "NumConsultorio";
                        ddlConsultas.DataBind();

                        ddlConsultas.Items.Insert(0, new ListItem("Seleccione una consulta", "0"));
                    }
                    else
                    {
                        lbxSolicitudes.Enabled = false;
                        throw new Exception("No hay consultas disponibles.");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;

            }
        }

        protected void ddlConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlConsultas.SelectedIndex >= 0)
                {
                    int consultaSeleccionada = Convert.ToInt32(ddlConsultas.SelectedValue);

                    List<Consulta> colConsultas = (List<Consulta>)Session["TodasLasConsultas"];
                    Consulta consulta = colConsultas.FirstOrDefault(c => c.NumConsultorio == consultaSeleccionada);

                    if (consulta != null)
                    {
                        // Obtener las solicitudes asociadas a esta consulta
                        List<Solicitud> solicitudes = LogicaSolicitud.ListarSolicitudesPorConsulta(consultaSeleccionada);

                        if (solicitudes.Count > 0)
                        {
                            // Mostrar las solicitudes en el ListBox
                            lbxSolicitudes.DataSource = solicitudes;
                            lbxSolicitudes.DataTextField = "ToString"; 
                            lbxSolicitudes.DataValueField = "numeroInterno"; 
                            lbxSolicitudes.DataBind();
                            lbxSolicitudes.Enabled = true;
                        }
                        else
                        {
                            lbxSolicitudes.Items.Clear();
                            lbxSolicitudes.Items.Add(new ListItem("No hay solicitudes asociadas.", "0"));
                            lbxSolicitudes.Enabled = false;
                        }
                    }
                    else
                    {
                        throw new Exception("Consulta no encontrada.");
                    }
                }
                else
                {
                    lbxSolicitudes.Items.Clear();
                    lbxSolicitudes.Items.Add(new ListItem("Seleccione una consulta primero.", "0"));
                    lbxSolicitudes.Enabled = false;
                }
            }


            
            catch (Exception ex)
            {

                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }
    }
}