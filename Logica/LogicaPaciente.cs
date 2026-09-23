using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPaciente
    {
        public static Paciente Buscar(int pcedula)
        {
            Paciente oPaciente = PersistenciaPaciente.Buscar(pcedula);

            return oPaciente;
        }

        public static void Modificar(Paciente pPaciente)
        {
           
                LogicaPaciente.Modificar((Paciente)pPaciente);
        }

        public static void Agregar(Paciente pPaciente)
        {
            LogicaPaciente.Agregar((Paciente) pPaciente);
                
        }

        public static void Eliminar(Paciente pPaciente)
        {
            LogicaPaciente.Eliminar((Paciente)pPaciente);
        }

        public static List<Paciente> ListarPacientes()
        {
            List<Paciente> colAuxiliar = new List<Paciente>();

            colAuxiliar.AddRange(PersistenciaPaciente.ListarPacientes());
            

            return colAuxiliar;
        }
    }
}
