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
    public class PedidosDA
    {
        OracleCommand cmd = new OracleCommand();
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public Pedidos Cargar_pedidos(int cod_pedido)
        {
            try
            {
                Pedidos var = new Pedidos(); 
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                if (lector.Read())
                {

                    var._Id = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_paciente = lector["COD_PACIENTE"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_cama = lector["COD_CAMA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_tipo_aporte_nutrientes = lector["COD_APORTE_NUTRIENTES"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_APORTE_NUTRIENTES"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_sales = lector["COD_TIPO_SALES"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_SALES"]);
                    var._Cod_tipo_otros = lector["COD_OTROS"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_OTROS"]);
                    var._Diagnostico = lector["DIAGNOSTICO"].Equals(DBNull.Value) ? string.Empty : (string)lector["DIAGNOSTICO"];
                    var._Amnesis_alim = lector["AMNESIS"].Equals(DBNull.Value) ? string.Empty : (string)lector["AMNESIS"];
                    var._Observaciones = lector["OBSERVACIONES"].Equals(DBNull.Value) ? string.Empty : (string)lector["OBSERVACIONES"];
                }
                else
                {
                    var._Id = 0;
                }
                conn.Cerrar();

                return var;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public Pedidos Cargar_pedidos2(int cod_paciente)
        {
            try
            {
                Pedidos var = new Pedidos();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PEDIDO_PACIENTE");

                conn.ParametroBD("PIN_COD_PACIENTE", cod_paciente, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                if (lector.Read())
                {

                    var._Id = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_paciente = lector["COD_PACIENTE"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_cama = lector["COD_CAMA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_tipo_aporte_nutrientes = lector["COD_APORTE_NUTRIENTES"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_APORTE_NUTRIENTES"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_sales = lector["COD_TIPO_SALES"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_SALES"]);
                    var._Cod_tipo_otros = lector["COD_OTROS"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_OTROS"]);
                    var._Diagnostico = lector["DIAGNOSTICO"].Equals(DBNull.Value) ? string.Empty : (string)lector["DIAGNOSTICO"];
                    var._Amnesis_alim = lector["AMNESIS"].Equals(DBNull.Value) ? string.Empty : (string)lector["AMNESIS"];
                    var._Observaciones = lector["OBSERVACIONES"].Equals(DBNull.Value) ? string.Empty : (string)lector["OBSERVACIONES"];
                }
                else
                {
                    var._Id = 0;
                }
                conn.Cerrar();

                return var;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public List<Pedidos> Cargar_alimentos_pedidos(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_PEDIDO");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PEDIDOS", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                while (lector.Read())
                {
                    Pedidos var = new Pedidos();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();
                    var._Id_tipo_distribucion = lector["ID_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_DISTRIBUCION"]);

                    var._Cod_tipo_distribucion = lector["DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["DISTRIBUCION"]);
                    var._Cod_tipo_comida = lector["TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["TIPO_COMIDA"]);
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

        public int Validar_alimento_pedido(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            try
            {
                int cont = 0;
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_PEDIDO");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PEDIDOS", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();


                while (lector.Read())
                {
                    cont++;
                }
               
                conn.Cerrar();

                return cont;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_Pedido(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO");

                conn.ParametroBD("PIN_CONSISTENCIA", var._Cod_tipo_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", var._Cod_tipo_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_APORTE_NUTRIENTES", var._Cod_tipo_aporte_nutrientes, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VOLUMEN", var._Cod_tipo_volumen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TEMPERATURA", var._Cod_tipo_temperatura, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_SALES", var._Cod_tipo_sales, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OTROS", var._Cod_tipo_otros, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CAMA", var._Cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIAGNOSTICO", var._Diagnostico.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_AMNESIS", var._Amnesis_alim.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("POUT_PED_ID", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PED_ID").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_Pedido_nue(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO_NUE");

     
                conn.ParametroBD("PIN_COD_CAMA", var._Cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);         
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("POUT_PED_ID", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PED_ID").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_Nutrientes(Pedidos var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_NUTRIENTES");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Id, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_NUTRIENTES", var._Nom_tipo_nutrientes, DbType.Int64, ParameterDirection.Input);


                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                if (registro > 0)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
                }

                return res;

            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Modificar_Pedido(Pedidos var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Id, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", var._Cod_tipo_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", var._Cod_tipo_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_APORTE_NUTRIENTES", var._Cod_tipo_aporte_nutrientes, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VOLUMEN", var._Cod_tipo_volumen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TEMPERATURA", var._Cod_tipo_temperatura, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_SALES", var._Cod_tipo_sales, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OTROS", var._Cod_tipo_otros, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CAMA", var._Cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIAGNOSTICO", var._Diagnostico.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_AMNESIS", var._Amnesis_alim.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_modifica.ToUpper(), DbType.String, ParameterDirection.Input);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                if (registro > -1)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
                }

                return res;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Modificar_Nutrientes(Pedidos var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_NUTRIENTES");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Id, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_NUTRIENTES", var._Cod_tipo_nutrientes, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENTE", var._Est_tipo_nutrientes, DbType.String, ParameterDirection.Input);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
                }

                return res;

            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Eliminar_Nutrientes(int cod_pedido)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_ELIMINAR_NUTRIENTES");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
            
                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
                }

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
