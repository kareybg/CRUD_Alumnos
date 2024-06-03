using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Alumnos.Datos;
using Npgsql;

namespace CRUD_Alumnos.Negocio
{
    public class N_Alumnos
    {
        private ConexionPostgreSQL datos;

        public N_Alumnos()
        {
            datos = new ConexionPostgreSQL();

            datos.conexionDB();
        }
        public List<Alumno> mostrar()
        {
            datos.validarConexion();
            List<Alumno> listAlumno = datos.mostrar();
            datos.validarConexion();
            return listAlumno;
        }
        public void insertar(string nombre, string apPaterno, string apMaterno, int edad, int grado, int grupo, string telefono)
        {
            datos.validarConexion();
            datos.insertar(nombre, apPaterno, apMaterno, edad, grado, grupo, telefono);
            datos.validarConexion();
        }
        public void eliminar(int id)
        {
            datos.validarConexion();
            datos.eliminar(id); 
            datos.validarConexion();
        }
        public Alumno buscarAlumnoModificar(int id)
        {
            datos.validarConexion();
            Alumno alumno = datos.buscarAlumnoModificar(id);
            datos.validarConexion();
            return alumno;
        }
        public void modificar(int id, string nombre, string apPaterno, string apMaterno, int edad, int grado, int grupo, string telefono)
        {
            datos.validarConexion();
            datos.modificar(id, nombre, apPaterno, apMaterno, edad, grado, grupo, telefono);
            datos.validarConexion();

        }
    }
}
