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
    public partial class AltaConsultaEspecialista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";


            if (!IsPostBack)
            {
                LimpioFormulario();
            }
        }

        private void LimpioFormulario()
        {


            txtNumCons.Text = "";

            txtDoctor.Text = "";

            txtFechaYHora.Text = "";

            txtEspecializacion.Text = "";


        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnBuscarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                int numConsultorio = Convert.ToInt32(txtNumCons.Text.Trim());
                DateTime fecha = DateTime.Parse(txtFechaYHora.Text);
                string doctor = txtDoctor.Text.Trim();
                string especialidad = txtEspecializacion.Text.Trim();
                int cantNumeros = Convert.ToInt32(txtCantNumeros.Text.Trim());

                ConsultaEspecialista consultaEspecialista = new ConsultaEspecialista(numConsultorio, fecha, doctor, cantNumeros, especialidad);

                LogicaConsulta.Agregar(consultaEspecialista);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Agregado con exito";

                LimpioFormulario();

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;

            }
        }
    }
}