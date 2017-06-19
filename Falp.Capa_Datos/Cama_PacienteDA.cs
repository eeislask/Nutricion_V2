using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;
using System.Data.Common;
using Falp.Entidades;



namespace Falp.Capa_Datos
{
   public  class Cama_PacienteDA
    {
     

        OracleCommand cmd = new OracleCommand();
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public List<Cama_Pacientes> ListadoCamaPacientes(string rut,int cod_servicio,int cod_estado)
        {
            try
            {
             
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_LISTADO_CAMAS_PAC");
                conn.ParametroBD("PIN_RUT", rut, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SERVICIO", cod_servicio, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_ESTADO", cod_estado, DbType.Int64, ParameterDirection.Input);
         

                IDataReader lector = conn.ExecuteReader();

                List<Cama_Pacientes> lista = new List<Cama_Pacientes>();

                while (lector.Read())
                {
                    Cama_Pacientes var = new Cama_Pacientes();
                    var._Correlativo = lector["CORRELATIVO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CORRELATIVO"]);
                    var._Id = lector["CAMA_ID"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CAMA_ID"]);
                    var._Id_pac = lector["PAC_ID"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["PAC_ID"]);
                    var._Cod_nhc = lector["NHC"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["NHC"]);
                    var._Num_cama = lector["NUM_CAMA"].Equals(DBNull.Value) ? string.Empty : lector["NUM_CAMA"].ToString();
                    var._Cod_habitacion = lector["COD_HABITACION"].Equals(DBNull.Value) ? string.Empty : lector["COD_HABITACION"].ToString();
                    var._Nom_habitacion = lector["NOM_HABITACION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_HABITACION"].ToString();
                    var._Cod_servicio = lector["COD_SERVICIO"].Equals(DBNull.Value) ? string.Empty : lector["COD_SERVICIO"].ToString();
                    var._Nom_servicio = lector["NOM_SERVICIO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_SERVICIO"].ToString();
                    var._Cod_cama = lector["COD_CAMA"].Equals(DBNull.Value) ? string.Empty : lector["COD_CAMA"].ToString();
                    var._Num_doc = lector["RUT"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["RUT"]);
                    var._Nombres = lector["NOMBRES"].Equals(DBNull.Value) ? string.Empty : lector["NOMBRES"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();
                    var._Estado_cama = lector["CAMA_ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["CAMA_ESTADO"].ToString();

                    lista.Add(var);
                }
                conn.Cerrar();

                return lista;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public List<Cama_Pacientes> Listadoestadistico()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGO_ESTADISTICA");



                IDataReader lector = conn.ExecuteReader();

                List<Cama_Pacientes> lista = new List<Cama_Pacientes>();

                while (lector.Read())
                {
                    Cama_Pacientes var = new Cama_Pacientes();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : (string)lector["ESTADO"];
                    var._Cantidad= lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
           

                    lista.Add(var);
                }
                conn.Cerrar();

                return lista;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Liberar_cama(string cod_cama,string cod_paciente)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_LIBERAR_CAMA");

                conn.ParametroBD("PIN_COD_CAMA", cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", cod_paciente, DbType.Int64, ParameterDirection.Input);
           

                int registro = conn.ExecuteNonQuery();
                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {
                    res = "Error";
                }
                conn.Cerrar();

                return res;

            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

    }
}
