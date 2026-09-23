using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaSolicitud
    {
        public static int Agregar(Solicitud pSolicitud)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarSolicitud", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@fechayhora", pSolicitud.Cons.Fecha);
            oComando.Parameters.AddWithValue("@numConsultorio", pSolicitud.Cons.NumConsultorio);
            oComando.Parameters.AddWithValue("@numSeleccionado", pSolicitud.NumSeleccionado);
            oComando.Parameters.AddWithValue("@cedula", pSolicitud.Paci.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("La cedula no esta asociada a ningun paciente");
                else if (resultado == -2)
                    throw new Exception("No existe una consulta para para el horario y/o consultario ingresado");
                else if (resultado == -3)
                    throw new Exception("El número seleccionado no está dentro del rango de la cantidad de números disponible la consulta");
                else if (resultado == -4)
                    throw new Exception("Ya existe un numero solicitado para el que has seleccionado");
                else if (resultado == -5)
                    throw new Exception("Ocurrió un error al insertar la solicitud");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return resultado;
        }

        public static void ConfirmarSolicitud(int numConsultorio, int numSolicitud)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ConfirmarSolicitud", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NumConsultorio", numConsultorio);
            oComando.Parameters.AddWithValue("@NumSolicitud", numSolicitud);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al confirmar la solicitud: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void ModificarAsistencia(int numConsultorio, int numSolicitud, bool asistenciaConfirmada)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarAsistencia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NumConsultorio", numConsultorio);
            oComando.Parameters.AddWithValue("@NumSolicitud", numSolicitud);
            oComando.Parameters.AddWithValue("@AsistenciaConfirmada", asistenciaConfirmada);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Solicitud> ObtenerSolicitudesPorConsulta(int numConsultorio)
        {


            List<Solicitud> solicitudes = new List<Solicitud>();
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerSolicitudesPorConsulta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NumConsultorio", numConsultorio);

            int pnumeroInterno, pnumSeleccionado;
            bool pasistio;
            DateTime pfechaYHora;
            Consulta cons;
            Paciente paci;


            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    
                    {
                        
                        pnumeroInterno = (int)oReader["NumeroInterno"]; 
                        pasistio = (bool)oReader["Asistio"];
                        pfechaYHora = (DateTime)oReader["FechaYHora"];
                        pnumSeleccionado = (int)oReader["NumSeleccionado"];
                        cons = (Consulta)oReader["Cons"];
                        paci = (Paciente)oReader["Paci"];

                        Solicitud solicitud = new Solicitud(pnumeroInterno, pasistio, pfechaYHora, pnumSeleccionado, cons, paci);
                        solicitudes.Add(solicitud);

                    }
                    
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener solicitudes: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return solicitudes;
        }

        //public static List<Solicitud> ListarSolicitudesPorAñoyCiNoAsis(int cedula, int anio)
        //{
        //    int numeroInterno;
        //    int asistio;
        //    DateTime fechayHora;
        //    int numeroSeleccionado;
        //    int cons;
        //    int paci;

        //    List<Solicitud> solicitudesNoAsis = new List<Solicitud>();
        //    SqlDataReader oReader;

        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("ListarSolicitudesNoAsistidas", oConexion);
        //    oComando.CommandType = CommandType.StoredProcedure;

        //    SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
        //    oRetorno.Direction = ParameterDirection.ReturnValue;
        //    oComando.Parameters.Add(oRetorno);


        //    try
        //    {
        //        oConexion.Open();
        //        oReader = oComando.ExecuteReader();

        //        if (oReader.HasRows)
        //        {
        //            while (oReader.Read())
        //            {
        //                numeroInterno = Convert.ToInt32(oReader["numeroInterno"]);
        //                asistio = Convert.ToInt32(oReader["asistio"]);
        //                fechayHora = Convert.ToDateTime(oReader["fechaYHora"]);
        //                numeroSeleccionado = Convert.ToInt32(oReader["numSeleccionado"]);
        //                cons = Convert.ToInt32(oReader["cons"]);
        //                paci = Convert.ToInt32(oReader["paci"]);

        //                Solicitud oSolicitud = new Solicitud(numeroInterno, asistio, fechayHora, numeroSeleccionado, cons, paci)
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        oConexion.Close();
        //    }
        //}


    }
}
