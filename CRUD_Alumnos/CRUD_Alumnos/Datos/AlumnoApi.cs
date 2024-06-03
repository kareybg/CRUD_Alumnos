using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Alumnos.Datos
{
    class AlumnoApi
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public int Grado { get; set; }
        public int Grupo { get; set; }
        public int Status { get; set; }
        public string Telefono { get; set; }
        public AlumnoApi(int id, string nombre, string apPaterno, string apMaterno, int grado, int grupo, int status, string telefono)
        {
            Id = id;
            Nombre = nombre;
            ApPaterno = apPaterno;
            ApMaterno = apMaterno;
            Grado = grado;
            Grupo = grupo;
            Status = status;
            Telefono = telefono;
        }
    }
}
