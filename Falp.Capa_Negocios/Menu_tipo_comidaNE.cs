using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
   public  class Menu_tipo_comidaNE
    {
        string res = "";
        Menu_tipo_comidaDA var = new Menu_tipo_comidaDA();
        Menu_tipo_comida mtc = new Menu_tipo_comida();

        public string Registrar_Tipo_Comida(int cod_menu, int cod_tipo_comida, string user, string fecha)
        {

            mtc._Cod_pedido = cod_menu;
            mtc._Cod_tipo_comida = cod_tipo_comida;
            mtc._User_crea = user;
            mtc._Fecha_crea = Convert.ToDateTime(fecha);

            return var.Registrar_Tipo_Comida(mtc);
        }
    }
}
