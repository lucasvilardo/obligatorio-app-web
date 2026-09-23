using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class ConsultaComun : Consulta
    {
         private string enfermeria;

        public string Enfermeria
        {
            get { return enfermeria; }
            set
            {
                enfermeria = value;
               
            }
        }

        public override string AMostrar
        {
            get { return "Num Consultorio: " + CantNumeros + " - " + Fecha + " - Consulta Común"; }
        }

        public ConsultaComun(int pnumConsultorio, DateTime pfecha, string pmedico, int pcantNumeros, string penfermeria)
            : base(pnumConsultorio, pfecha, pmedico, pcantNumeros)
        {
            Enfermeria = penfermeria;
        }

        public override string ToString()
        {
            
            return "Consulta Común: " + base.ToString() + "Enfermería: " + enfermeria;
        }
    }
}
