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
    public partial class AltaConsultaComun : System.Web.UI.Page
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
           
            txtfecha.Text = "";

            txtCantNum.Text = "";

            rbtnEnfermeria.SelectedIndex = -1;
            

        }

        
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnAgregarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                int numConsultorio = Convert.ToInt32(txtNumCons.Text.Trim());
                DateTime fecha = DateTime.Parse(txtfecha.Text);
                string doctor = txtDoctor.Text.Trim();
                string enfermeria = rbtnEnfermeria.DataValueField;
                int cantNumeros = Convert.ToInt32(txtCantNum.Text.Trim());

                ConsultaComun consultaComun = new ConsultaComun(numConsultorio, fecha, doctor, cantNumeros, enfermeria);

                LogicaConsulta.Agregar(consultaComun);

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