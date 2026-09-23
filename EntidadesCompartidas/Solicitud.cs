using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Solicitud
    {
        int numeroInterno;
        bool asistio;
        DateTime fechaYHora;
        int numSeleccionado;

        Consulta cons;
        Paciente paci;

        public int NumeroInterno
        {
            get { return numeroInterno; }
            set
            {
                value = numeroInterno;
            }
        }

        public bool Asistio
        {
            get { return asistio; }
            set
            {
                asistio = value;
            }
        } 

        public DateTime FechaYHora
        {
            get { return fechaYHora; }
            set
            {
                fechaYHora = value;
            }
        }

        public int NumSeleccionado
        {
            get { return numSeleccionado; }
            set
            {
                numSeleccionado = value;
            }
        }

        public Consulta Cons
        {
            get { return cons; }
            set
            {
                if (value == null)
                    throw new Exception("No puede haber una solicitud que no corresponda a ninguna consulta.");

                cons = value;
            }
        }

        public Paciente Paci
        {
            get { return paci; }
            set
            {
                if (value == null)
                    throw new Exception("No puede haber una solicitud que no corresponda a ningun paciente.");

                paci = value;
            }
        }



        public Solicitud(int pnumeroInterno, bool pasistio, DateTime pfechaYHora, int pnumSeleccionado, Consulta pcons, Paciente ppaci)
        {
            NumeroInterno = pnumeroInterno;
            Asistio = pasistio;
            FechaYHora = pfechaYHora;
            NumSeleccionado = pnumSeleccionado;
            Cons = pcons;
            Paci = ppaci;
        }

        public override string ToString()
        {
            //string asistiobool = asistio ? "SI" : "NO";

            return "SOLICITUD - Paciente: " + paci + " - Número interno: " + numeroInterno + " - Fecha y Hora: " + fechaYHora
                    + " - Número seleccionado: " + numSeleccionado + " - Asistió: " + asistio + " - Consulta: " + cons;  
        }


    }
}
