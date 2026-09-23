using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class ConsultaEspecialista : Consulta
    {
        private string especialidad;

        public string Especialidad
        {
            get { return especialidad; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe elegir una especialidad");

                especialidad = value;
            }
        }

        public override string AMostrar
        {
            get { return "Num Consultorio: " + CantNumeros + " - " + Fecha + " - Consulta Especialista"; }
        }

        public ConsultaEspecialista(int pnumConsultorio, DateTime pfecha, string pmedico, int pcantNumeros, string pespecialidad)
            : base(pnumConsultorio, pfecha, pmedico, pcantNumeros)
        {
            Especialidad = pespecialidad;
        }

        public override string ToString()
        {
            return "Consulta Especialista: " + base.ToString() + "Especialidad: " + especialidad;
        }
    }
}
