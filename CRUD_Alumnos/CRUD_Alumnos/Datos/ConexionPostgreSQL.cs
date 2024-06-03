using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using Datos;
using Newtonsoft.Json;
using CRUD_Alumnos.Negocio;


namespace CRUD_Alumnos.Datos
{
    public class ConexionPostgreSQL
    {
        static NpgsqlConnection conexion;
        public void conexionDB()
        {
            StreamReader read = new StreamReader(@"C:\Users\brianda.benitez\Documents\Visual Studio 2015\Projects\Conexion.json");
            string jsonString = read.ReadToEnd();
            ConexionJson jConexion = JsonConvert.DeserializeObject<ConexionJson>(jsonString);

            string cadenaConexion = "server=" + jConexion.Server + ";" + "port=" + jConexion.Port + ";"
                + "user id=" + jConexion.User + ";" + "password=" + jConexion.Password + ";"
                + "database=" + jConexion.Db + ";";
            conexion = new NpgsqlConnection(cadenaConexion);
            
        }
        public void validarConexion() {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                else
                {
                    conexion.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void insertar(string nombre, string apPaterno, string apMaterno, int edad, int grado, int grupo, string telefono)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "fun_agregaralumno";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cnombre", nombre);
            cmd.Parameters.AddWithValue("@capellidopaterno", apPaterno);
            cmd.Parameters.AddWithValue("@capellidomaterno", apMaterno);
            cmd.Parameters.AddWithValue("@iedad", edad);
            cmd.Parameters.AddWithValue("@igrado", grado);
            cmd.Parameters.AddWithValue("@igrupo", grupo);
            cmd.Parameters.AddWithValue("@ctelefono", telefono);
            cmd.ExecuteNonQuery();
        }
        public List<Alumno> mostrar()
        {
            List<Alumno> listAlumno = new List<Alumno>();
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlDataReader reader;
            cmd.CommandText = "fun_mostraralumno";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Alumno alumno = new Alumno(
                    Convert.ToInt32(reader[0]),
                    Convert.ToString(reader[1]),
                    Convert.ToString(reader[2]),
                    Convert.ToString(reader[3]),
                    Convert.ToInt32(reader[4]),
                    Convert.ToInt32(reader[5]),
                    Convert.ToInt32(reader[6]),
                    Convert.ToString(reader[7])
                    );
                listAlumno.Add(alumno);
            }
            return listAlumno;
        }

        public void eliminar(int id)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = "fun_eliminaralumno";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;
            cmd.Parameters.AddWithValue("@idalumno", id);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
        }
        public void modificar(int idalumno, string nombre, string apPaterno, string apMaterno, int edad, int grado, int grupo, string telefono)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "fun_modificaralumno";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idalumno", idalumno);
            cmd.Parameters.AddWithValue("@cnombre", nombre);
            cmd.Parameters.AddWithValue("@capellidopaterno", apPaterno);
            cmd.Parameters.AddWithValue("@capellidomaterno", apMaterno);
            cmd.Parameters.AddWithValue("@iedad", edad);
            cmd.Parameters.AddWithValue("@igrado", grado);
            cmd.Parameters.AddWithValue("@igrupo", grupo);
            cmd.Parameters.AddWithValue("@ctelefono", telefono);
            cmd.ExecuteNonQuery();
        }
        //Busca un alumno por id para el metodo de modificar
        public Alumno buscarAlumnoModificar(int id)
        {
            Alumno alumno = new Alumno();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "fun_buscaralumno";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idalumno", id);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                    alumno.Id = Convert.ToInt32(reader[0]);
                    alumno.Nombre = Convert.ToString(reader[1]);
                    alumno.ApPaterno = Convert.ToString(reader[2]);
                    alumno.ApMaterno = Convert.ToString(reader[3]);
                    alumno.Edad = Convert.ToInt32(reader[4]);
                    alumno.Grado = Convert.ToInt32(reader[5]);
                    alumno.Grupo = Convert.ToInt32(reader[6]);
                    alumno.Telefono = Convert.ToString(reader[7]);
            }
            return alumno;
        }
        public List<Materia> materiasPorAlumno(int idAlumno)
        {
            List<Materia> listMateria = new List<Materia>();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = "fun_mostrarmaterias";
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_alumno", idAlumno);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Materia materia = new Materia(
                    Convert.ToString(reader[0]),
                    Convert.ToInt32(reader[1]));
                listMateria.Add(materia);
            }
            return listMateria;
        }
    }
}
