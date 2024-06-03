using CRUD_Alumnos.Datos;
using CRUD_Alumnos.Negocio;
using Datos;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Alumnos.Vistas
{
    public partial class V_Alumnos : Form
    {
        static private N_Alumnos negocio;
        //ConexionApi conexApi = new ConexionApi();
        //BindingSource source = new BindingSource();
        public V_Alumnos()
        {
            InitializeComponent();
            Clipboard.Clear();
            negocio = new N_Alumnos();
            mostrar();
            //conexApi.consultaDatos(dgAlumnos);
        }

        private void mostrar()
        {
            List<Alumno> listAlumno = new List<Alumno>();
            //Reply oReply = new Reply();
            //oReply = await ConsumoApi.Execute<List<AlumnoApi>>("http://localhost:8080/api/v1/alumnos", methodHttp.GET, listAlumno);
            dgAlumnos.Rows.Clear();
            //source.DataSource = oReply.Data;
            //dgAlumnos.DataSource = oReply.Data;
            //MessageBox.Show(oReply.Data.ToString());
            for (int i = 0; i < listAlumno.Count; i++)
            {
                dgAlumnos.Rows.Add(
                    listAlumno[i].Id,
                    listAlumno[i].Nombre,
                    listAlumno[i].ApPaterno,
                    listAlumno[i].ApMaterno,
                    listAlumno[i].Edad,
                    listAlumno[i].Grado,
                    listAlumno[i].Grupo,
                    listAlumno[i].Telefono
                    );
            }
            dgAlumnos.Refresh();
        }
        private void limpiar()
        {
            this.txtNombre.Clear();
            this.txtApellidoPaterno.Clear();
            this.txtApellidoMaterno.Clear();
            this.txtEdad.Clear();
            this.txtID.Clear();
            this.cmbGrado.SelectedIndex = -1;
            this.cmbGrupo.SelectedIndex = -1;
            this.txtTelefono.Clear();
            btnAgregar.Enabled = true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try{
                if (Convert.ToInt32(txtEdad.Text) != 0)
                {
                    negocio.insertar(
                    txtNombre.Text,
                    txtApellidoPaterno.Text,
                    txtApellidoMaterno.Text,
                    Convert.ToInt32(txtEdad.Text),
                    Convert.ToInt32(cmbGrado.Text),
                    Convert.ToInt32(cmbGrupo.Text),
                    txtTelefono.Text);
                    //conexApi.registrarDatos(
                    //txtNombre.Text,
                    //txtApellidoPaterno.Text,
                    //txtApellidoMaterno.Text,
                    //Convert.ToInt32(txtEdad.Text),
                    //Convert.ToInt32(cmbGrado.Text),
                    //Convert.ToInt32(cmbGrupo.Text),
                    //txtTelefono.Text);
                    //limpiar();
                    mostrar();
                    //conexApi.consultaDatos(dgAlumnos);
                }
                else
                {
                    MessageBox.Show("La edad ingresada no es valida");
                }
            }
            catch
            {
                MessageBox.Show("No llenaste todos los campos");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                negocio.eliminar(Convert.ToInt32(txtID.Text));
                //conexApi.eliminarDatos(Convert.ToInt32(txtID.Text));
                limpiar();
                //mostrar();
                //conexApi.consultaDatos(dgAlumnos);
            }
            catch
            {
                MessageBox.Show("No ingresaste un ID");
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try { 
            //{
            //    conexApi.modificarDatos(
            //    Convert.ToInt32(txtID.Text),
            //    txtNombre.Text,
            //    txtApellidoPaterno.Text,
            //    txtApellidoMaterno.Text,
            //    Convert.ToInt32(txtEdad.Text),
            //    Convert.ToInt32(cmbGrado.Text),
            //    Convert.ToInt32(cmbGrupo.Text),
            //    txtTelefono.Text);
                //btnAgregar.Enabled = true;
                //btnEliminar.Enabled = true;
            negocio.modificar(
            Convert.ToInt32(txtID.Text),
            txtNombre.Text,
            txtApellidoPaterno.Text,
            txtApellidoMaterno.Text,
            Convert.ToInt32(txtEdad.Text),
            Convert.ToInt32(cmbGrado.Text),
            Convert.ToInt32(cmbGrupo.Text),
            txtTelefono.Text);
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = true;
            mostrar();
            //conexApi.consultaDatos(dgAlumnos);
                limpiar();
            }
            catch
            {
                MessageBox.Show("No llenaste todos los campos");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //conexApi.consultaDatosID(dgAlumnos, Convert.ToInt32(txtID.Text));
                Alumno alumno = negocio.buscarAlumnoModificar(Convert.ToInt32(txtID.Text));
                if (alumno.Id != 0)
                {
                    this.txtNombre.Text = alumno.Nombre;
                    this.txtApellidoPaterno.Text = alumno.ApPaterno;
                    this.txtApellidoMaterno.Text = alumno.ApMaterno;
                    this.txtEdad.Text = Convert.ToString(alumno.Edad);
                    this.cmbGrado.Text = Convert.ToString(alumno.Grado);
                    this.cmbGrupo.Text = Convert.ToString(alumno.Grado);
                    this.txtTelefono.Text = alumno.Telefono;
                    btnAgregar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El usuario que ingresaste no existe");
                    txtID.Focus();
                }

            }
            catch
            {
                MessageBox.Show("No ingresaste un ID");
            }
        }

        private void dgAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtID.Text = dgAlumnos.CurrentRow.Cells[0].Value.ToString();
            this.txtNombre.Text = dgAlumnos.CurrentRow.Cells[1].Value.ToString();
            this.txtApellidoPaterno.Text = dgAlumnos.CurrentRow.Cells[2].Value.ToString();
            this.txtApellidoMaterno.Text = dgAlumnos.CurrentRow.Cells[3].Value.ToString();
            this.txtEdad.Text = dgAlumnos.CurrentRow.Cells[4].Value.ToString();
            this.cmbGrado.Text = dgAlumnos.CurrentRow.Cells[5].Value.ToString();
            this.cmbGrupo.Text = dgAlumnos.CurrentRow.Cells[6].Value.ToString();
            this.txtTelefono.Text = dgAlumnos.CurrentRow.Cells[7].Value.ToString();
            this.txtTelefono.Text = dgAlumnos.CurrentRow.Cells[8].Value.ToString();
            btnAgregar.Enabled = false;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar!=(char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtApellidoPaterno.Focus();
            }
        }

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtApellidoMaterno.Focus();
            }
        }

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEdad.Focus();
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void KeyUp_enterNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control con = (Control)sender;
                if (con.Text != string.Empty)
                {
                    SelectNextControl(con, true, false, true, false);
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
