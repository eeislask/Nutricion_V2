using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
   public  class Cama_Pacientes:Pacientes
    {
         private int id;
         private string num_cama;
         private string cod_cama;
         private string cod_habitacion;
         private string nom_habitacion;
         private string cod_servicio;
         private string nom_servicio;
         private string cod_paciente;
         private string nom_paciente;
         private string estado;
         private string estado_cama;
         private int cantidad;

        public int _Id
        {
            get { return id; }
            set { id = value; }
        }

        public string _Num_cama
        {
            get { return num_cama; }
            set { num_cama = value; }
        }
        public string _Cod_cama
        {
            get { return cod_cama; }
            set { cod_cama = value; }
        }

        public string _Cod_habitacion
        {
            get { return cod_habitacion; }
            set { cod_habitacion = value; }
        }

        public string _Nom_habitacion
        {
            get { return nom_habitacion; }
            set { nom_habitacion = value; }
        }

        public string _Cod_servicio
        {
            get { return cod_servicio; }
            set { cod_servicio = value; }
        }

        public string _Nom_servicio
        {
            get { return nom_servicio; }
            set { nom_servicio = value; }
        }


        public string _Cod_paciente
        {
            get { return cod_paciente; }
            set { cod_paciente = value; }
        }

        public string _Nom_paciente
        {
            get { return nom_paciente; }
            set { nom_paciente = value; }
        }

        public string _Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string _Estado_cama
        {
            get { return estado_cama; }
            set { estado_cama = value; }
        }

        public int _Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }



        public Cama_Pacientes()
        { }

        public Cama_Pacientes(int id, string cod_cama, string cod_habitacion, string nom_habitacion, string cod_servicio, string nom_servicio, string cod_paciente, string nom_paciente, string num_cama, string estado, int cantidad)
        {
            this._Id = id;
            this._Num_cama = num_cama;
            this._Cod_cama = cod_cama;
            this._Cod_habitacion = cod_habitacion;
            this._Nom_habitacion = nom_habitacion;
            this._Cod_servicio = cod_servicio;
            this._Nom_servicio = nom_servicio;
            this._Cod_paciente = cod_paciente;
            this._Nom_paciente = nom_paciente;
            this._Estado = estado;
            this._Cantidad = cantidad;
        }


    }
}
