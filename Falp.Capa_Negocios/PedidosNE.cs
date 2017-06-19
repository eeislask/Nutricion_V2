using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
   public  class PedidosNE
    {
        string res = "";
        PedidosDA var = new PedidosDA();
       Pedidos ped=new Pedidos() ;


        public Pedidos Cargar_pedidos(int cod_pedido)
        {
            return var.Cargar_pedidos(cod_pedido);
        }
        public Pedidos Cargar_pedidos2(int cod_paciente)
        {
            return var.Cargar_pedidos2(cod_paciente);
        }

        public List<Pedidos> Cargar_alimentos_pedidos(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            return var.Cargar_alimentos_pedidos(fecha, cod_tipo_comida, cod_tipo_distribucion, cod_pedido);
        }

        public int Validar_alimento_pedido(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            return var.Validar_alimento_pedido(fecha, cod_tipo_comida, cod_tipo_distribucion, cod_pedido);
        }



        public string Registrar_Pedido(string consistencia,string digestabilidad,string aporte_nutrientes, string volumen,
              string temperatura, string tipo_sales, string tipo_otros, string diagnostico, string amnesis, string observacion, string user, string cod_cama, string cod_paciente)
        {

            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_aporte_nutrientes = Convert.ToInt32(aporte_nutrientes);
            ped._Cod_tipo_volumen = Convert.ToInt32(volumen);
            ped._Cod_tipo_temperatura = Convert.ToInt32(temperatura);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Cod_tipo_otros = Convert.ToInt32(tipo_otros);
            ped._Diagnostico = diagnostico;
            ped._Amnesis_alim = amnesis;
            ped._User_crea = user;
            ped._Observaciones = observacion;
            ped._Cod_cama = Convert.ToInt32(cod_cama);
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
    


            return var.Registrar_Pedido(ped);
        }

        public string Registrar_Pedido( string user, string cod_cama, string cod_paciente)
        {


            ped._User_crea = user;
            ped._Cod_cama = Convert.ToInt32(cod_cama);
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);



            return var.Registrar_Pedido_nue(ped);
        }


        public string Registrar_Nutrientes(int cod_menu, string cod_nutrientes)
        {

            ped._Id = cod_menu;
            ped._Nom_tipo_nutrientes = cod_nutrientes;


            return var.Registrar_Nutrientes(ped);
        }


        public string Modificar_Pedido(string cod_pedido,string consistencia, string digestabilidad, string aporte_nutrientes, string volumen,
             string temperatura, string tipo_sales, string tipo_otros, string diagnostico, string amnesis, string observacion, string user, string cod_cama, string cod_paciente)
        {
            ped._Id = Convert.ToInt32(cod_pedido);
            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_aporte_nutrientes = Convert.ToInt32(aporte_nutrientes);
            ped._Cod_tipo_volumen = Convert.ToInt32(volumen);
            ped._Cod_tipo_temperatura = Convert.ToInt32(temperatura);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Cod_tipo_otros = Convert.ToInt32(tipo_otros);
            ped._Diagnostico = diagnostico;
            ped._Amnesis_alim = amnesis;
            ped._User_modifica = user;
            ped._Observaciones = observacion;
            ped._Cod_cama = Convert.ToInt32(cod_cama);
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);



            return var.Modificar_Pedido(ped);
        }



        public string Modificar_Nutrientes(int cod_menu, string cod_nutrientes,string estado)
        {

            ped._Id = cod_menu;
            ped._Cod_tipo_nutrientes = Convert.ToInt32(cod_nutrientes);
            ped._Est_tipo_nutrientes = estado;
            return var.Modificar_Nutrientes(ped);
        }



        public string Eliminar_Nutrientes(int cod_pedido)
        {
            return var.Eliminar_Nutrientes(cod_pedido);
        }
    }
}
