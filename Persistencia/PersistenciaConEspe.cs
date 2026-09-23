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
    public class PersistenciaConEspe
    {
        public static ConsultaEspecialista Buscar(int pnumConsultorio, DateTime pfecha)
        {
            string medico, especialidad;
            int cantNumeros;
            

            ConsultaEspecialista oConEspe = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarConsultaEspecialista", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numConsul", pnumConsultorio);
            oComando.Parameters.AddWithValue("@fecha", pfecha);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        medico = (string)oReader["nomMedico"];
                        cantNumeros = (int)oReader["cantNumeros"];
                        especialidad = (string)oReader["especialidad"];

                        oConEspe = new ConsultaEspecialista(pnumConsultorio, pfecha, medico, cantNumeros, especialidad);
                    }
                }
                oReader.Close();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return oConEspe;
        }

        public static void Agregar(ConsultaEspecialista pConsultaComun)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarConsultaEspecialista", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numConsultorio", pConsultaComun.NumConsultorio);
            oComando.Parameters.AddWithValue("@fecha", pConsultaComun.Fecha);
            oComando.Parameters.AddWithValue("@nomMedico", pConsultaComun.Medico);
            oComando.Parameters.AddWithValue("@especialidad", pConsultaComun.Especialidad);
            oComando.Parameters.AddWithValue("@cantNumeros", pConsultaComun.CantNumeros);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("Ya existe una consulta con esos datos.");

                else if (resultado == 2)
                    throw new Exception("Ocurrió un error inesperado.");

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

        public static void Modificar(ConsultaEspecialista pConsultaEspecialista)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarConsultaComun", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numConsultorio", pConsultaEspecialista.NumConsultorio);
            oComando.Parameters.AddWithValue("@fecha", pConsultaEspecialista.Fecha);
            oComando.Parameters.AddWithValue("@nomMedico", pConsultaEspecialista.Medico);
            oComando.Parameters.AddWithValue("@especialidad", pConsultaEspecialista.Especialidad);
            oComando.Parameters.AddWithValue("@cantNumeros", pConsultaEspecialista.CantNumeros);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe una consulta con esos datos.");

                else if (resultado == 2)
                    throw new Exception("Ocurrió un error inesperado.");

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

        public static void Eliminar(ConsultaEspecialista pConsultaEspe)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarConsulta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numConsultorio", pConsultaEspe.NumConsultorio);
            oComando.Parameters.AddWithValue("@fecha", pConsultaEspe.Fecha);


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe una consulta con esos datos.");

                else if (resultado == -2)
                    throw new Exception("Tiene una solicitud asociada, no puede ser eliminada.");

                else if (resultado == -3)
                    throw new Exception("Ocurrió un error inesperado");

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

        public static List<ConsultaEspecialista> ListarConsultasEspecialistas()
        {
            int numConsultorio, cantNumeros;
            string doctor, especialidad;
            DateTime fecha;

            List<ConsultaEspecialista> colConsultaEspecialista = new List<ConsultaEspecialista>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarConsultasEspecialistas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        numConsultorio = Convert.ToInt32(oReader["numConsultorio"]);
                        cantNumeros = Convert.ToInt32(oReader["cantNumeros"]);
                        especialidad = oReader["especialidad"].ToString();
                        doctor = oReader["nomMedico"].ToString();
                        fecha = Convert.ToDateTime(oReader["fechaYHoraID"]);

                        ConsultaEspecialista oConsultaEspecialista = new ConsultaEspecialista(numConsultorio, fecha, especialidad, cantNumeros, doctor);
                        colConsultaEspecialista.Add(oConsultaEspecialista);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return colConsultaEspecialista;

        }
    }
}
