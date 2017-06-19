using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
    public class Cama_PacienteNE
    {

        string res = "";
        Cama_Pacientes cam_pac = new Cama_Pacientes();
        Cama_PacienteDA var = new Cama_PacienteDA();

        public List<Cama_Pacientes> ListadoCamaPacientes(string rut, int cod_servicio, int cod_estado )
        {
            return var.ListadoCamaPacientes(rut, cod_servicio,cod_estado);
        }

        public List<Cama_Pacientes> Listadoestadistico()
        {
            return var.Listadoestadistico();
        }
        public string Liberar_cama(string cod_cama,string cod_paciente)
        {
            return var.Liberar_cama(cod_cama,cod_paciente);
        }
    }
}
