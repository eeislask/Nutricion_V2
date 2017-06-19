using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
   public  class UtilidadesNE
    {
        string res = "";
        UtilidadesDA var = new UtilidadesDA();
       

        public List<Utilidades> Cargartipo_bus() 
        {
            return var.Cargar_tipo_bus();
        }

        public List<Utilidades> Cargartipo_doc()
        {
            return var.Cargar_tipo_doc();
        }

        public List<Utilidades> Cargartipo_consistencia()
        {
            return var.Cargar_tipo_consistencia();
        }

        public List<Utilidades> Cargartipo_digestabilidad()
        {
            return var.Cargar_tipo_digestabilidad();
        }

        public List<Utilidades> Cargartipo_aporte_nutrientes()
        {
            return var.Cargar_tipo_aporte_nutrientes();
        }

        public List<Utilidades> Cargartipo_volumen()
        {
            return var.Cargar_tipo_volumen();
        }

        public List<Utilidades> Cargartipo_temperatura()
        {
            return var.Cargar_tipo_temperatura();
        }

        public List<Utilidades> Cargartipo_dulzor()
        {
            return var.Cargar_tipo_dulzor();
        }

        public List<Utilidades> Cargartipo_lactosa()
        {
            return var.Cargar_tipo_lactosa();
        }

        public List<Utilidades> Cargartipo_sales()
        {
            return var.Cargar_tipo_sales();
        }

        public List<Utilidades> Cargartipo_otros()
        {
            return var.Cargar_tipo_otros();
        }

        public List<Utilidades> Cargarservicio()
        {
            return var.Cargarservicio();
        }

        public List<Utilidades> Cargarestado()
        {
            return var.Cargarestado();
        }
        public List<Utilidades> Cargartipo_nutrientes()
        {
            return var.Cargar_tipo_nutrientes();
        }

        public List<Utilidades> Cargarinstitucion()
        {
            return var.Cargarinstitucion();
        }

        public List<Utilidades> Cargarprevision()
        {
            return var.Cargarprevision();
        }

        public List<Utilidades> Cargarplanprevisional()
        {
            return var.Cargarplanprevisional();
        }

        public List<Utilidades> Cargarregimen()
        {
            return var.Cargarregimen();
        }

        public List<Utilidades> Cargarbandeja()
        {
            return var.Cargarbandeja();
        }

        public List<Utilidades> Cargaraislamiento()
        {
            return var.Cargaraislamiento();
        }

        public List<Utilidades> Cargartipo_nutrientes_pedido(int cod_pedido)
        {
            return var.Cargar_tipo_nutrientes_pedido(cod_pedido);
        }

        public List<Utilidades> Cargartipo_comida()
        {
            return var.Cargar_tipo_comida();
        }
        public List<Utilidades> Cargaralimentos_pedido(int cod_pedido)
        {
            return var.Cargar_alimentos_pedido(cod_pedido);
        }

        public List<Utilidades> Cargartipo_distribucion(int cod_tipo_comida)
        {
            return var.Cargar_tipo_distribucion(cod_tipo_comida);
        }

        public List<Utilidades> Cargartipo_alimento(int cod_tipo_distribucion)
        {
            return var.Cargar_tipo_alimento(cod_tipo_distribucion);
        }

        public List<Utilidades> Cargar_alimentos_menu(string fecha,int cod_tipo_comida,int cod_tipo_distribucion)
        {
            return var.Cargar_alimentos_menu( fecha, cod_tipo_comida, cod_tipo_distribucion);
        }

        public List<Utilidades> Cargar_alimentos_menu_extra(string fecha, int cod_tipo_comida, int cod_tipo_distribucion)
        {
            return var.Cargar_alimentos_menu_extra(fecha, cod_tipo_comida, cod_tipo_distribucion);
        }

        public List<Utilidades> Cargar_alimentos_menu_extra_extra(int cod_tipo_distribucion)
        {
            return var.Cargar_alimentos_menu_extra_extra( cod_tipo_distribucion);
        }



       





      
    }
}
