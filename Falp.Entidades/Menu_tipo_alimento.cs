using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
    public class Menu_tipo_alimento
    {
        protected int id;
        protected int cod_pedido_reg_det;
        protected int cod_tipo_alimentos;
        protected string nom_tipo_alimentos;
        protected int cantidad;
        protected string vigencia;
        protected string estado;
        protected string user_crea;
        protected DateTime fecha_crea;
        protected string user_modifica;
        protected DateTime fecha_modifica;

        public int _Id
        {
            get { return id; }
            set { id = value; }
        }
        public int _Cod_pedido_reg_det
        {
            get { return cod_pedido_reg_det; }
            set { cod_pedido_reg_det= value; }
        }

        public int _Cod_tipo_alimentos
        {
            get { return cod_tipo_alimentos; }
            set { cod_tipo_alimentos = value; }
        }

        public string _Nom_tipo_alimentos
        {
            get { return nom_tipo_alimentos; }
            set { nom_tipo_alimentos = value; }
        }
        public int _Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public string _Vigencia
        {
            get { return vigencia; }
            set { vigencia = value; }
        }

        public string _Estado
        {
            get { return estado; }
            set { estado = value; }
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

         public Menu_tipo_alimento()
        { }

         public Menu_tipo_alimento(int id, int cod_pedido_reg_det, int cod_tipo_alimentos, string nom_tipo_alimentos,int cantidad,string vigencia, string estado,
                                   string user_crea, DateTime fecha_crea,
                                   string user_modifica, DateTime fecha_modifica)
         {
             this._Id = id;
             this._Cod_pedido_reg_det = cod_pedido_reg_det;
             this._Cod_tipo_alimentos = cod_tipo_alimentos;
             this._Nom_tipo_alimentos = nom_tipo_alimentos;
             this._Cantidad = cantidad;
             this._Vigencia=vigencia;
             this._Estado = estado;
             this._User_crea = user_crea;
             this._Fecha_crea = fecha_crea;
             this._User_modifica = user_modifica;
             this._Fecha_modifica = fecha_modifica;
         }
    }
}
