using CRUD_Alumnos.Datos;
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
    public partial class V_Presentacion : Form
    {
        ConexionPostgreSQL conexion = new ConexionPostgreSQL();
        public V_Presentacion()
        {
            InitializeComponent();
        }

        private void FormPanel(object segundaVentana)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form sv = segundaVentana as Form;
            sv.TopLevel = false;
            sv.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(sv);
            this.pnlContenedor.Tag = sv;
            sv.Show();
        }
        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            FormPanel(new Vistas.V_Alumnos());
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            FormPanel(new Vistas.V_Materias());
        }
    }
}
