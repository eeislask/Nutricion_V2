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
   public  class Menu_tipo_comidaDA
    {
        OracleCommand cmd = new OracleCommand();
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public string Registrar_Tipo_Comida(Menu_tipo_comida var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_REG_COMIDA");

                conn.ParametroBD("PIN_COD_MENU", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", Convert.ToString(var._Fecha_crea), DbType.String, ParameterDirection.Input);

                conn.ParametroBD("POUT_REG_COMIDA", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_REG_COMIDA").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }
    }
}
