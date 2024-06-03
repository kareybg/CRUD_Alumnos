using CRUD_Alumnos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Alumnos.Negocio
{
    class N_Materias
    {
        private ConexionPostgreSQL datos;
        public N_Materias()
        {
            datos = new ConexionPostgreSQL();
        }
        public List<Materia> materiasPorAlumno(int id)
        {
            datos.validarConexion();
            List<Materia> alumno = datos.materiasPorAlumno(id);
            datos.validarConexion();
            return alumno;
        }
    }
}
