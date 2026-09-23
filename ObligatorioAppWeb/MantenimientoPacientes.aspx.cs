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
    public partial class MantenimientoPacientes : System.Web.UI.Page
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
            btnAlta.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnBuscar.Enabled = true;

            txtCi.Text = "";
            txtCi.Enabled = true;
            txtNombre.Text = "";
            txtNombre.Enabled = false;
            txtFechaNac.Text = "";
            txtFechaNac.Enabled = false;
        }

        private void ActivoBotones(bool esAlta = true)
        {
            btnAlta.Enabled = !esAlta;
            btnEliminar.Enabled = !esAlta;
            btnModificar.Enabled = !esAlta;
            btnBuscar.Enabled = false;

            txtCi.Enabled = false;
            txtFechaNac.Enabled = true;
            txtNombre.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int cedula = Convert.ToInt32(txtCi.Text);

                if (cedula <= 0)
                    throw new Exception("La cédula no puede ser negativa ni 0");

                Paciente pac = LogicaPaciente.Buscar(cedula);

                if (pac != null)
                {
                    txtFechaNac.Text = pac.FechaNacimiento.ToString("yyyy-MM-dd HH:mm");
                    txtNombre.Text = pac.NomCompleto;

                    ActivoBotones(false);

                    Session["Paciente"] = pac;
                }
                else
                {
                    ActivoBotones();

                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No hay pacientes con esa cédula. Puede agregar uno si desea con esa cédula.";

                    Session["Paciente"] = null;


                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = (Paciente)Session["Paciente"];

                paciente.NomCompleto = txtNombre.Text.Trim();
                paciente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text.Trim());

                LogicaPaciente.Modificar(paciente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Modificación exitosa";

                LimpioFormulario();

            }
            catch (Exception ex)
            {

                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = (Paciente)Session["Paciente"];

                LogicaPaciente.Eliminar(paciente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Eliminación exitosa";

                LimpioFormulario();
            }
            catch (Exception ex)
            {

                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int cedula = Convert.ToInt32(txtCi.Text);
                string nomCompleto = txtNombre.Text.Trim();
                DateTime fecha = DateTime.Parse(txtFechaNac.Text);

                Paciente paciente = new Paciente(cedula, nomCompleto, fecha);

                LogicaPaciente.Agregar(paciente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Alta con éxito";

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