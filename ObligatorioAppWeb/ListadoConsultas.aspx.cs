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
    public partial class ListadoConsultas : System.Web.UI.Page
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

                    if (colConsultas.Count == 0)
                    {
                        ddlConsultas.Enabled = false;
                        throw new Exception("No hay publicaciones disponibles");
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
                if (Session["TodasLasConsultas"] == null)
                    throw new Exception("No se pudo cargar la lista de consultas. Por favor, recargue la página.");

                List<Consulta> colConsultas = (List<Consulta>)Session["TodasLasConsultas"];

                lbxConsultas.Items.Clear();

                if (ddlConsultas.SelectedIndex == 0)
                    throw new Exception("Seleccione una opción");

                else if (ddlConsultas.SelectedIndex == 1)
                    foreach (Consulta c in colConsultas)
                    {
                        if (c is ConsultaComun)
                            lbxConsultas.Items.Add(c.ToString());
                    }
                else
                {
                    foreach (Consulta c in colConsultas)
                    {
                        if (c is ConsultaEspecialista)
                        {
                            lbxConsultas.Items.Add(c.ToString());
                        }
                    }
                }
                if (lbxConsultas.Items.Count == 0)
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No hay consultas " + (ddlConsultas.SelectedIndex == 1 ? "especialistas" : "comúnes") + " para mostrar.";
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