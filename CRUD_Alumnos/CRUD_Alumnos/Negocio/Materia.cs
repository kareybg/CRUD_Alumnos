using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_Alumnos.Negocio
{
    public class Materia
    {
        private string nombre;
        private int status;

        public Materia(
            string nombre, 
            int status)
        {
            this.Nombre = nombre;
            this.Status = status;
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

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
