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
    public partial class ListadoSolicitudesDeConsultaPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int cedula = Convert.ToInt32(txtCi.Text.Trim());
            DateTime anio = Convert.ToDateTime(txtAnio.Text.Trim());
           

            
                

        }
    }
}