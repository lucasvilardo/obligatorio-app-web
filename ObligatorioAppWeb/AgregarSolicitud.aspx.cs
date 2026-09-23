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
    public partial class AgregarSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                CargoDatos();

            }
        }

        private void CargoDatos()
        {
            try
            {
                List<Consulta> colConsultas = LogicaConsulta.ListarConsultas();
                Session["Consultas"] = colConsultas;

                if (colConsultas.Count > 0)
                {
                    ddlConsultas.DataSource = colConsultas;
                    ddlConsultas.DataTextField = "AMostrar";
                    ddlConsultas.DataValueField = "numConsultorio";
                    //ddlConsultas.DataValueField = "fecha";

                    ddlConsultas.DataBind();
                    ddlConsultas.Items.Insert(0, new ListItem("--------------------"));
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existe ninguna consulta disponible";

                    ddlConsultas.Enabled = false;
                    ddlNumeroSol.Enabled = false;
                }


            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;

            }

            try
            {
                List<Paciente> colPacientes = LogicaPaciente.ListarPacientes();
                Session["Pacientes"] = colPacientes;

                if (colPacientes.Count > 0)
                {
                    ddlPacientes.DataSource = colPacientes;
                    ddlPacientes.DataTextField = "AMostrar";
                    ddlPacientes.DataValueField = "cedula";

                    ddlPacientes.DataBind();
                    ddlPacientes.Items.Insert(0, new ListItem("--------------------"));
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existe ningun paciente disponible";

                    ddlPacientes.Enabled = false;
                    ddlNumeroSol.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;

            }

            try
            {
                List<Consulta> colConsultas = LogicaConsulta.ListarConsultas();
                Session["Consultas"] = colConsultas;

                if (colConsultas.Count > 1)
                {
                    List<int> numerosSolicitud = new List<int>();

                    // Recorrer cada consulta y agregar números consecutivos según CantNumeros
                    foreach (var consulta in colConsultas)
                    {
                        for (int i = 1; i <= consulta.CantNumeros; i++)
                        {
                            numerosSolicitud.Add(i);
                        }
                    }

                    // Asignar la lista generada como fuente de datos del ddlNumeroSol
                    ddlNumeroSol.DataSource = numerosSolicitud;
                    ddlNumeroSol.DataBind();
                    //ddlNumeroSol.DataSource = colConsultas;
                    //ddlNumeroSol.DataValueField = "cantNumeros";
                    //ddlNumeroSol.DataBind();
                    ddlNumeroSol.Items.Insert(0, new ListItem("--------------------"));
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existe ninguna consulta disponible";
                }

                ddlNumeroSol.Items.Clear();
                ddlNumeroSol.Items.Insert(0, new ListItem("--------------------", "0"));
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int numSeleccionado;
                int consultaSele;
                int pacienteSele;

                List<Consulta> colConsultas = (List<Consulta>)Session["Consultas"];
                Consulta oConsulta = null;

                List<Paciente> colPacientes = (List<Paciente>)Session["Pacientes"];
                Paciente oPaciente = null;

                
                

                if (ddlConsultas.SelectedIndex != 0)
                    consultaSele = Convert.ToInt32(ddlConsultas.SelectedValue);
                else
                    throw new Exception("Seleccione una consulta.");

                foreach (Consulta c in colConsultas)
                {
                    if (c.NumConsultorio == consultaSele)
                    {
                        oConsulta = c;
                        break;
                    }
                }

                if (ddlPacientes.SelectedIndex != 0)
                    pacienteSele = Convert.ToInt32(ddlPacientes.SelectedValue);
                else
                    throw new Exception("Seleccione un paciente");

                foreach (Paciente p in colPacientes)
                {
                    if (p.Cedula == pacienteSele)
                    {
                        oPaciente = p;
                        break;
                    }
                }

                if (ddlNumeroSol.SelectedIndex != 0)
                {
                    numSeleccionado = Convert.ToInt32(ddlNumeroSol.SelectedValue);
                }
                else
                {
                    throw new Exception("Seleccione un número de solicitud.");
                }

                Solicitud oSolicitud = new Solicitud(0, false, DateTime.Now, numSeleccionado, oConsulta, oPaciente);

                int numero = LogicaSolicitud.Agregar(oSolicitud);

                lblFechaYHora.Text = Convert.ToString(DateTime.Now ); 

                lblError.ForeColor = Color.Green;
                lblError.Text = "Solicitud hecha con éxito, numero automatico: " + numero;

                ddlConsultas.SelectedIndex = 0;
                ddlNumeroSol.SelectedIndex = 0;
                ddlPacientes.SelectedIndex = 0;

                CargoDatos();



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
                if (ddlConsultas.SelectedIndex > 0)
                {
                    // Recuperar consultas desde sesión
                    List<Consulta> colConsultas = (List<Consulta>)Session["Consultas"];

                    // Obtener el valor seleccionado (numConsultorio o identificador único)
                    string selectedValue = ddlConsultas.SelectedValue;

                    // Buscar la consulta seleccionada
                    Consulta selectedConsulta = colConsultas.FirstOrDefault(c => c.NumConsultorio.ToString() == selectedValue);

                    if (selectedConsulta != null)
                    {
                        // Usar CantNumeros para llenar ddlNumeroSol
                        ddlNumeroSol.Items.Clear();
                        for (int i = 1; i <= selectedConsulta.CantNumeros; i++)
                        {
                            ddlNumeroSol.Items.Add(new ListItem(i.ToString(), i.ToString()));
                        }
                        ddlNumeroSol.Items.Insert(0, new ListItem("--------------------", "0"));
                    }
                }
                else
                {
                    // Limpiar ddlNumeroSol si no se seleccionó nada válido
                    ddlNumeroSol.Items.Clear();
                    ddlNumeroSol.Items.Insert(0, new ListItem("--------------------", "0"));
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al actualizar los números de solicitud: " + ex.Message;
            }
        }
        }
}