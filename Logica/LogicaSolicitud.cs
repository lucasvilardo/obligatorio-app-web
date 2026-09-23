using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaSolicitud
    {
        public static int Agregar(Solicitud pSolicitud)
        {
            if (pSolicitud.Cons.Fecha.Date <= DateTime.Now.Date)
                throw new Exception("La fecha de vencimiento debe ser posterior al dia de hoy");

            return PersistenciaSolicitud.Agregar(pSolicitud);
        }

        public static void ConfirmarSolicitud(int numConsultorio, int numSolicitud)
        {
            PersistenciaSolicitud.ConfirmarSolicitud(numConsultorio, numSolicitud);
        }

        public static void ModificarAsistencia(int numConsultorio, int numSolicitud, bool asistenciaConfirmada)
        {
            if (numConsultorio <= 0 || numSolicitud <= 0)
                throw new Exception("Datos inválidos para modificar la asistencia.");

            PersistenciaSolicitud.ModificarAsistencia(numConsultorio, numSolicitud, asistenciaConfirmada);
        }

        public static List<Solicitud> ListarSolicitudesPorConsulta(int numConsultorio)
        {
            return PersistenciaSolicitud.ObtenerSolicitudesPorConsulta(numConsultorio);
        }
    }

    
}
