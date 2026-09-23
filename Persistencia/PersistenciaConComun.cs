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
    public class PersistenciaConComun
    {
        public static ConsultaComun Buscar(int pnumConsultorio, DateTime pfecha)
        {
            string medico;
            int cantNumeros;
            string enfermeria;

            ConsultaComun oConComun = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarConsultaComun", oConexion);
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
                        enfermeria = (string)oReader["enfermería"];

                        oConComun = new ConsultaComun(pnumConsultorio, pfecha, medico, cantNumeros, enfermeria);
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
            return oConComun;
        }

        public static void Agregar(ConsultaComun pConsultaComun)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarConsultaComun", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numConsultorio", pConsultaComun.NumConsultorio);
            oComando.Parameters.AddWithValue("@fecha", pConsultaComun.Fecha);
            oComando.Parameters.AddWithValue("@nomMedico", pConsultaComun.Medico);
            oComando.Parameters.AddWithValue("@enfermeria", pConsultaComun.Enfermeria);
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

        public static void Modificar(ConsultaComun pConsultaComun)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarConsultaComun", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numConsultorio", pConsultaComun.NumConsultorio);
            oComando.Parameters.AddWithValue("@fecha", pConsultaComun.Fecha);
            oComando.Parameters.AddWithValue("@nomMedico", pConsultaComun.Medico);
            oComando.Parameters.AddWithValue("@enfermeria", pConsultaComun.Enfermeria);
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

        public static void Eliminar(ConsultaComun pConsultaComun)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarConsulta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numConsultorio", pConsultaComun.NumConsultorio);
            oComando.Parameters.AddWithValue("@fecha", pConsultaComun.Fecha);
           

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

        public static List<ConsultaComun> ListarConsultasComunes()
        {
            int numConsultorio, cantNumeros;
            string doctor, enfermeria;
            DateTime fecha;

            List<ConsultaComun> colConsultaComun = new List<ConsultaComun>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarConsultasComunes", oConexion);
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
                        Console.Write(Convert.ToInt32(oReader["numConsultorio"]));
                        Console.Write(numConsultorio);
                        cantNumeros = Convert.ToInt32(oReader["cantNumeros"]);
                        enfermeria = oReader["enfermería"].ToString();
                        doctor = oReader["nomMedico"].ToString();
                        fecha = Convert.ToDateTime(oReader["fechaYHoraID"]);

                        ConsultaComun oConsultaComun = new ConsultaComun(numConsultorio, fecha, doctor, cantNumeros, enfermeria);
                        colConsultaComun.Add(oConsultaComun);
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
            return colConsultaComun;

        }

      


        }
    }
