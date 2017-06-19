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
    public class UtilidadesDA
    {

        OracleCommand cmd = new OracleCommand();
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;


        public List<Utilidades> Cargarservicio()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_SERVICIOS");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_servicio = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_servicio = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargarestado()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_ESTADO");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_estado = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_estado = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


   

        public List<Utilidades> Cargar_tipo_bus()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_BUSQUEDA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_bus = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_bus = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_doc()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DOC");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_doc = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_doc = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


        public List<Utilidades> Cargar_tipo_consistencia()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_CONSISTENCIA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_consistencia = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_consistencia = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_digestabilidad()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DIGESTABILIDAD");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_digestabilidad = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_digestabilidad = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_aporte_nutrientes()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_APORTE_NUTRI");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_aporte_nutrientes = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_aporte_nutrientes = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_volumen()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_VOLUMEN");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_volumen = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_volumen = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_temperatura()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_TEMPERATURA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_temperatura = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_temperatura = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_sales()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_SALES");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_sales = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_sales = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_otros()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_OTROS");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_otros = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_otros = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


        public List<Utilidades> Cargar_tipo_dulzor()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DULZOR");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_dulzor = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_dulzor = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_lactosa()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_LACTOSA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_lactosa = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_lactosa = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_nutrientes()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_NUTRIENTES");
               


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_nutrientes = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_nutrientes = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


        public List<Utilidades> Cargarinstitucion()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_INSTITUCION");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_institucion = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_institucion = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


        public List<Utilidades> Cargarprevision()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PREVISION");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_prevision = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_prevision = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargarplanprevisional()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PLAN_PREVISIONAL");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_plan_previsional = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_plan_previsional = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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
        public List<Utilidades> Cargar_tipo_nutrientes_pedido(int cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_NUTRIENTES_PED");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();
                    var._Id_tipo_nutrientes = lector["ID_NUT"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_NUT"]);
                    var._Cod_tipo_nutrientes = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_nutrientes = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Est_tipo_nutrientes = lector["VIGENTE"].Equals(DBNull.Value) ? string.Empty : lector["VIGENTE"].ToString();

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

        public List<Utilidades> Cargar_alimentos_pedido(int cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_COMIDAS_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();
                    var._Cod_tipo_comida = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_comida = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

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


        public List<Utilidades> Cargar_tipo_comida()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_COM");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_comida= lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_comida = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_distribucion(int cod_tipo_comida)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DISTR");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_distribucion = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_distribucion = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargarregimen()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_REGIMEN");


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_regimen = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_regimen = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


        public List<Utilidades> Cargarbandeja()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_BANDEJA");


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_bandeja = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_bandeja = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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
        public List<Utilidades> Cargaraislamiento()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_AISLAMIENTO");


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_aislamiento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_aislamiento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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



        public List<Utilidades> Cargar_tipo_alimento(int cod_tipo_distribucion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM");
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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



        public List<Utilidades> Cargar_alimentos_menu(string fecha,int cod_tipo_comida,int cod_tipo_distribucion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_DIA");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha , DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

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


        public List<Utilidades> Cargar_alimentos_menu_extra(string fecha, int cod_tipo_comida, int cod_tipo_distribucion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIMENTOS_EXTRAS");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

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


        public List<Utilidades> Cargar_alimentos_menu_extra_extra( int cod_tipo_distribucion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIMENTOS_EXTR_EXTR");
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

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


    }
}
