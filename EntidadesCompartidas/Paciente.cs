using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Paciente
    {
        int cedula;
        string nomCompleto;
        DateTime fechaNacimiento;


        public int Cedula
        {
            get { return cedula; }
            set
            {
                if (value.ToString().Length != 8)
                    throw new Exception("La cédula debe tener 8 caracteres");
                cedula = value;
            }
        }

        public string NomCompleto
        {
            get { return nomCompleto; }
            set
            {
                if (value == null || value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacío.");
                nomCompleto = value;
            }
        }

        public DateTime FechaNacimiento
        {
           
                get { return fechaNacimiento; }
                set
            { 
                    DateTime FechaActual = DateTime.Now;
                    if (value > FechaActual)
                        throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual.");

                    fechaNacimiento = value;
                }
            }

        public virtual string AMostrar
        {
            get { return cedula + " - Paciente"; }
        }

        public Paciente(int pcedula, string pnomCompleto, DateTime pfechaNacimiento)
        {
            Cedula = pcedula;
            NomCompleto = pnomCompleto;
            FechaNacimiento = pfechaNacimiento;
        }

        public override string ToString()
        {
           return "Paciente: " + nomCompleto + " Cédula: " + cedula + " Fecha de Nacimiento: " + fechaNacimiento;
        }
    }
}
