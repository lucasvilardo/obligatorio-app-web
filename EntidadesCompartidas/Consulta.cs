using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public abstract class Consulta
    {
        int numConsultorio;
        DateTime fecha;
        string medico;
        int cantNumeros;

        public int NumConsultorio
        {
            get { return numConsultorio; }
            set
            {
                if (value < 1 || value > 40)
                    throw new Exception("El número de consultorio debe ser entre 1 y 40");

                numConsultorio = value;
            }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (value < DateTime.Now)
                    throw new Exception("La fecha de la consulta debe ser a futuro.");

                fecha = value;
            }
        }

        public string Medico
        {
            get { return medico; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe ingresar el nombre del médico.");

                medico = value;
            }
        }
        public int CantNumeros
        {
            get { return cantNumeros; }
            set
            {
                cantNumeros = value;
            }
            
        }

        public virtual string AMostrar
        {
            get { return "Num Consultorio:" + cantNumeros + " - " + fecha + " - Consulta"; }
        }

       
        public Consulta(int pnumConsultorio, DateTime pfecha, string pmedico, int pcantNumeros)
        {
            NumConsultorio = pnumConsultorio;
            Fecha = pfecha;
            Medico = pmedico;
            CantNumeros = pcantNumeros;
        }

        public override string ToString()
        {
            return "Consultorio Nº: " + numConsultorio + "- Hora: " + fecha + " -Con el medico: " + medico + "- Con " + cantNumeros + "- números.";
        }
    }
}
