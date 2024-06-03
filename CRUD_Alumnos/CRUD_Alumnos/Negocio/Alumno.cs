using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Alumnos.Negocio
{
    public class Alumno
    {
        private int id;
        private string nombre;
        private string apPaterno;
        private string apMaterno;
        private int edad;
        private int grado;
        private int grupo;
        private string telefono;

        public Alumno(
        int id,
        string nombre,
        string apPaterno,
        string apMaterno,
        int edad,
        int grado,
        int grupo,
        string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apPaterno = apPaterno;
            this.apMaterno = apMaterno;
            this.edad = edad;
            this.grado = grado;
            this.grupo = grupo;
            this.telefono = telefono;
        }
        public Alumno()
        {

        }
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string ApPaterno
        {
            get
            {
                return apPaterno;
            }

            set
            {
                apPaterno = value;
            }
        }

        public string ApMaterno
        {
            get
            {
                return apMaterno;
            }

            set
            {
                apMaterno = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
            }
        }

        public int Grado
        {
            get
            {
                return grado;
            }

            set
            {
                grado = value;
            }
        }

        public int Grupo
        {
            get
            {
                return grupo;
            }

            set
            {
                grupo = value;
            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }
    }
}
