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
   public  class Menu_tipo_alimentosDA
    {
        OracleCommand cmd = new OracleCommand();
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public string Registrar_Tipo_Alimento(Menu_tipo_alimento var,string cod_cama)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO_A");

                conn.ParametroBD("PIN_COD_MENU", var._Cod_pedido_reg_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", var._Vigencia, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_ESTADO", var._Estado, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", Convert.ToString(var._Fecha_crea), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CAMA", cod_cama, DbType.Int32, ParameterDirection.Input);

                conn.ParametroBD("POUT_PEDIDO_ALIMENTO", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PEDIDO_ALIMENTO").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }


        public string Registrar_Tipo_Alimento(Menu_tipo_alimento var)
        {
          /*  try
            {*/
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_REGISTRAR_TIPO_ALIMENTO");

                conn.ParametroBD("PIN_COD_DISTRIBUCION", var._Cod_pedido_reg_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", var._Vigencia, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_ESTADO", var._Estado, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", Convert.ToString(var._Fecha_crea), DbType.String, ParameterDirection.Input);




                int registro = conn.ExecuteNonQuery();
                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
                }

                conn.Cerrar();

                return res;
          /*  }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }*/
        }

        public string Modificar_Tipo_Alimento(Menu_tipo_alimento var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_TIPO_ALIMENTO");

                conn.ParametroBD("PIN_COD_DISTRIBUCION", var._Cod_pedido_reg_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", var._Vigencia, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_ESTADO", var._Estado, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", Convert.ToString(var._Fecha_crea), DbType.String, ParameterDirection.Input);




                int registro = conn.ExecuteNonQuery();
                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
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
