using CRUD_Alumnos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Alumnos.Vistas
{
    public partial class V_Materias : Form
    {
        static private N_Alumnos negocioAlumno;
        static private N_Materias negocioMateria;

        public V_Materias()
        {
            negocioAlumno = new N_Alumnos();
            negocioMateria = new N_Materias();
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarAlumno();
        }

        private void buscarAlumno()
        {
            try
            {
                Alumno alumno = negocioAlumno.buscarAlumnoModificar(
                    Convert.ToInt32(txtIDAlumno.Text));
                if (alumno.Id != 0)
                {
                    this.txtNombre.Text = alumno.Nombre;
                    this.txtApPaterno.Text = alumno.ApPaterno;
                    this.txtApMaterno.Text = alumno.ApMaterno;
                    this.txtEdad.Text = Convert.ToString(alumno.Edad);
                    this.txtGrado.Text = Convert.ToString(alumno.Grado);
                    this.txtGrupo.Text = Convert.ToString(alumno.Grupo);

                    List<Materia> listMateria = negocioMateria.materiasPorAlumno(
                        Convert.ToInt32(txtIDAlumno.Text));
                    dgMaterias.Rows.Clear();
                    for (int i = 0; i < listMateria.Count; i++)
                    {
                        dgMaterias.Rows.Add(
                            listMateria[i].Nombre,
                            listMateria[i].Status
                        );
                        if (listMateria[i].Status == 1)
                        {
                            dgMaterias.Rows[i].Cells[1].Value = "Aprobado";
                        }
                        else
                        {
                            dgMaterias.Rows[i].Cells[1].Value = "Reprobado";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El usuario que ingresaste no existe");
                    txtIDAlumno.Focus();
                }
            }
            catch
            {
                MessageBox.Show("No ingresaste un ID");
            }
        }

        private void txtIDAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscarAlumno();
            }
        }
    }
}
