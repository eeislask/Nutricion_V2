using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;


namespace Falp.Capa_Negocios
{
   public  class Menu_tipo_alimentosNE
    {
        string res = "";
        Menu_tipo_alimentosDA var = new Menu_tipo_alimentosDA();
        Menu_tipo_alimento mtc = new Menu_tipo_alimento();

        public string Registrar_Tipo_Alimento(int cod_pedido_reg_det, int cod_tipo_alimentos,int cantidad, string vigencia, string estado, string user, string fecha,string cod_cama)
        {

            mtc._Cod_pedido_reg_det = cod_pedido_reg_det;
            mtc._Cod_tipo_alimentos = cod_tipo_alimentos;
            mtc._Cantidad=cantidad;
            mtc._Vigencia = vigencia;
            mtc._Estado = estado;

            mtc._User_crea = user;
            mtc._Fecha_crea = Convert.ToDateTime(fecha);

            return var.Registrar_Tipo_Alimento(mtc,cod_cama);
        }

        public string Registrar_Tipo_Alimento(int cod_dis, int cod_ali, int cant, string vig, string est, string user, string fecha)
        {
            mtc._Cod_pedido_reg_det = cod_dis;
            mtc._Cod_tipo_alimentos = cod_ali;
            mtc._Cantidad = cant;
            mtc._Vigencia = vig;
            mtc._Estado = est;

            mtc._User_crea = user;
            mtc._Fecha_crea = Convert.ToDateTime(fecha);

            return var.Registrar_Tipo_Alimento(mtc);
        }


        public string Modificar_Tipo_Alimento(int cod_dis, int cod_ali, int cant, string vig, string est, string user, string fecha)
        {
            mtc._Cod_pedido_reg_det = cod_dis;
            mtc._Cod_tipo_alimentos = cod_ali;
            mtc._Cantidad = cant;
            mtc._Vigencia = vig;
            mtc._Estado = est;

            mtc._User_crea = user;
            mtc._Fecha_crea = Convert.ToDateTime(fecha);

            return var.Modificar_Tipo_Alimento(mtc);
        }
    }
}
