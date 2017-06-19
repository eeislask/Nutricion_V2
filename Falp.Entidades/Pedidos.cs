using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
    public class Pedidos:Utilidades
    {
       protected int id;
       protected int cod_paciente;
       protected string nom_paciente;
       protected int cod_cama;
       protected string num_cama;
       protected int cod_menu; 
       protected int dia;
       protected int regimen;
       protected string diagnostico;
       protected string amnesis_alim;
       protected string observaciones;
       protected string vigente;
       protected string user_crea;
       protected DateTime fecha_crea;
       protected string user_modifica;
       protected DateTime fecha_modifica;
       protected DateTime fecha_pedido;
    
       


       public int _Id
       {
           get { return id; }
           set { id = value; }
       }
       public int _Cod_paciente
       {
           get { return cod_paciente; }
           set { cod_paciente = value; }
       }

       public string _Nom_paciente
       {
           get { return nom_paciente; }
           set { nom_paciente = value; }
       }

       public int _Cod_cama
       {
           get { return cod_cama; }
           set { cod_cama = value; }
       }

       public string _Num_cama
       {
           get { return num_cama; }
           set { num_cama = value; }
       }

       public int _Cod_menu
       {
           get { return cod_menu; }
           set { cod_menu = value; }
       }

       public int _Dia
       {
           get { return dia; }
           set { dia = value; }
       }
       public int _Regimen
       {
           get { return regimen; }
           set { regimen = value; }
       }


       public string _Diagnostico
       {
           get { return diagnostico; }
           set { diagnostico = value; }
       }

       public string _Amnesis_alim
       {
           get { return amnesis_alim; }
           set { amnesis_alim = value; }
       }

       public string _Observaciones
       {
           get { return observaciones; }
           set { observaciones = value; }
       }

       public string _Vigente
       {
           get { return vigente; }
           set { vigente = value; }
       }
       public string _User_crea
       {
           get { return user_crea; }
           set { user_crea = value; }
       }

       public DateTime _Fecha_crea
       {
           get { return fecha_crea; }
           set { fecha_crea = value; }
       }

       public string _User_modifica
       {
           get { return user_modifica; }
           set { user_modifica = value; }
       }

       public DateTime _Fecha_modifica
       {
           get { return fecha_modifica; }
           set { fecha_modifica = value; }
       }

       public DateTime _Fecha_pedido
       {
           get { return fecha_pedido; }
           set { fecha_pedido = value; }
       }

       public Pedidos()
        { }

        public Pedidos(int id,int cod_paciente,string nom_paciente,
                          int cod_cama, string num_cama,
                          int dia, int regimen,
                          int cod_menu, string num_menu,
                          string  diagnostico, string amnesis_ali ,
                          string  observacion, string vigencia,
                          int cod_tipo_consistencia, string nom_tipo_consistencia,
                          int cod_tipo_digestabilidad, string nom_tipo_digestabilidad,
                          int cod_tipo_aporte_nutrientes, string nom_tipo_aporte_nutrientes,
                          int cod_tipo_volumen, string nom_tipo_volumen,
                          int cod_tipo_temperatura, string nom_tipo_temperatura,
                          int cod_tipo_sales, string nom_tipo_sales,
                          int cod_tipo_otros, string nom_tipo_otros,
                          int cod_tipo_nutrientes, string nom_tipo_nutrientes,
                          string  user_crea, DateTime fecha_crea  ,
                          string user_modifica, DateTime fecha_modifica,
                          DateTime fecha_pedido)

        {
            this._Id = id;
            this._Cod_paciente = cod_paciente;
            this._Nom_paciente = nom_paciente;
            this._Cod_cama = cod_cama;
            this._Num_cama = num_cama;
            this._Dia = dia;
            this._Regimen = regimen;
            this._Diagnostico = diagnostico;
            this._Amnesis_alim = amnesis_alim;
            this._Observaciones = observaciones;
            this._Cod_tipo_consistencia = cod_tipo_consistencia;
            this._Nom_tipo_consistencia = nom_tipo_consistencia;
            this._Cod_tipo_digestabilidad = cod_tipo_digestabilidad;
            this._Nom_tipo_digestabilidad = nom_tipo_digestabilidad;
            this._Cod_tipo_volumen = cod_tipo_volumen;
            this._Nom_tipo_volumen = nom_tipo_volumen;
            this._Cod_tipo_temperatura = cod_tipo_temperatura;
            this._Nom_tipo_temperatura = nom_tipo_temperatura;
            this._Cod_tipo_sales = cod_tipo_sales;
            this._Nom_tipo_sales = nom_tipo_sales;
            this._Cod_tipo_otros = cod_tipo_otros;
            this._Nom_tipo_otros = nom_tipo_otros;
            this._Cod_tipo_nutrientes = cod_tipo_nutrientes;
            this._Nom_tipo_nutrientes = nom_tipo_nutrientes;
            this._User_crea= user_crea;
            this._Fecha_crea =fecha_crea;
            this._User_modifica = user_modifica;
            this._Fecha_modifica =fecha_modifica;
            this._Fecha_pedido = fecha_pedido;
           
        }

    }
}
