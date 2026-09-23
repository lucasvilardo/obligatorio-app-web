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
    public partial class MarcarAsistenciaSolicitudNumero : System.Web.UI.Page
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
                        lbConsultas.DataSource = colConsultas;
                        lbConsultas.DataTextField = "AMostrar"; 
                        lbConsultas.DataValueField = "NumConsultorio"; 
                        lbConsultas.DataBind();
                    }
                    else
                    {
                        lbConsultas.Enabled = false;
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

        

        protected void lbConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbConsultas.SelectedIndex >= 0)
                {
                    int consultaSeleccionada = Convert.ToInt32(lbConsultas.SelectedValue);

                    List<Consulta> colConsultas = (List<Consulta>)Session["TodasLasConsultas"];
                    Consulta consulta = colConsultas.FirstOrDefault(c => c.NumConsultorio == consultaSeleccionada);

                    if (consulta != null)
                    {
                        List<int> numerosSolicitud = new List<int>();
                        for (int i = 1; i <= consulta.CantNumeros; i++)
                        {
                            numerosSolicitud.Add(i);
                        }

                        DropDownList1.DataSource = numerosSolicitud;
                        DropDownList1.DataBind();
                        DropDownList1.Items.Insert(0, new ListItem("Seleccione un número de solicitud", "0"));
                    }
                    else
                    {
                        DropDownList1.Items.Clear();
                        DropDownList1.Items.Insert(0, new ListItem("No se pudo cargar las solicitudes.", "0"));
                    }
                }
                else
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Insert(0, new ListItem("Seleccione una consulta", "0"));
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al cargar los números de solicitud: " + ex.Message;
            }
        }

        protected void btnMarcarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList1.SelectedIndex > 0)
                {
                    int numSolicitud = Convert.ToInt32(DropDownList1.SelectedValue);
                    int consultaSeleccionada = Convert.ToInt32(lbConsultas.SelectedValue);

                    
                    List<Consulta> colConsultas = (List<Consulta>)Session["TodasLasConsultas"];
                    Consulta consulta = colConsultas.FirstOrDefault(c => c.NumConsultorio == consultaSeleccionada);

                    if (consulta != null)
                    {
                        if (numSolicitud >= 1 && numSolicitud <= consulta.CantNumeros)
                        {
                            LogicaSolicitud.ModificarAsistencia(consulta.NumConsultorio, numSolicitud, true);

                            lblError.ForeColor = Color.Green;
                            lblError.Text = "Solicitud confirmada con éxito.";


                        }
                        else
                        {
                            throw new Exception("El número de solicitud no es válido para esta consulta.");
                        }
                    }
                    else
                    {
                        throw new Exception("Consulta no encontrada.");
                    }
                }
                else
                {
                    throw new Exception("Debe seleccionar un número de solicitud.");
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