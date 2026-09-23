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
    public class PersistenciaPaciente
    {
        public static Paciente Buscar(int pcedula)
        {
            string nomCompleto;
            DateTime fechaNac;

            Paciente oPaciente = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarPaciente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pcedula);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nomCompleto = (string)oReader["nomCompleto"];
                        fechaNac = (DateTime)oReader["fechNacimiento"];

                        oPaciente = new Paciente(pcedula, nomCompleto, fechaNac);

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
            return oPaciente;


        }

        public static void Agregar(Paciente pcedula)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarPaciente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pcedula.Cedula);
            oComando.Parameters.AddWithValue("@nomCompleto", pcedula.NomCompleto);
            oComando.Parameters.AddWithValue("@fecha", pcedula.FechaNacimiento);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("Ya existe un paciente con esa cédula.");

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

        public static void Modificar(Paciente pcedula)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarPaciente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pcedula.Cedula);
            oComando.Parameters.AddWithValue("@nomCompleto", pcedula.NomCompleto);
            oComando.Parameters.AddWithValue("@fecha", pcedula.FechaNacimiento);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("");

                else if (resultado == 2)
                    throw new Exception("");

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

        public static void Eliminar(Paciente pcedula)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("eliminarPaciente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pcedula.Cedula);
            


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe un paciente con esos datos.");

                else if (resultado == -2)
                    throw new Exception("Tiene una solicitud asociada, no puede ser eliminado.");

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

        public static List<Paciente> ListarPacientes()
        {
            int cedula;
            string nomCompleto;
            DateTime fechaNac;

            List<Paciente> colPacientes = new List<Paciente>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarPacientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        cedula = Convert.ToInt32(oReader["cédula"]);
                        nomCompleto = oReader["nomCompleto"].ToString();
                        fechaNac = Convert.ToDateTime(oReader["fechNacimiento"]);

                        Paciente oPaciente = new Paciente(cedula, nomCompleto, fechaNac);
                        colPacientes.Add(oPaciente);
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
            return colPacientes;
        }
    }
}
