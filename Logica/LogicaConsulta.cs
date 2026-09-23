using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaConsulta
    {
        public static Consulta Buscar(int pnumConsultorio, DateTime pfecha)
        {
            Consulta oConsulta = PersistenciaConComun.Buscar(pnumConsultorio, pfecha);

            if (oConsulta == null)
                oConsulta = PersistenciaConEspe.Buscar(pnumConsultorio, pfecha);

            return oConsulta;
        }

        public static void Agregar(Consulta pConsulta)
        {
            if (pConsulta is ConsultaComun)
                PersistenciaConComun.Agregar((ConsultaComun)pConsulta);

            else
                PersistenciaConEspe.Agregar((ConsultaEspecialista)pConsulta);
        }

        public static List<Consulta> ListarConsultas()
        {
            List<Consulta> colAuxiliar = new List<Consulta>();

            colAuxiliar.AddRange(PersistenciaConComun.ListarConsultasComunes());
            colAuxiliar.AddRange(PersistenciaConEspe.ListarConsultasEspecialistas());

            return colAuxiliar;
        }


    }
}
