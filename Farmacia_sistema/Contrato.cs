using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Farmacia_sistema
{
    public partial class Contrato : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Contrato()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Contrato_Load(object sender, EventArgs e)
        {
            this.CargarCargo();
            this.CargarTContrato();
            this.CargarEmpleado();
        }

        private void btncontrato_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT c.idcontrato, e.nombre_empleado, tc.nombre_tipo, ca.nombre_cargo, c.fecha_inicio, c.fecha_fin, c.detalles, c.observaciones_contrato, c.estado FROM contrato c JOIN empleado e ON c.idempleado = e.idempleado JOIN tipo_contrato tc ON c.idtipo_contrato = tc.idtipo_contrato JOIN cargo ca ON c.idcargo = ca.idcargo;";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                dataGridView1.Columns["idcontrato"].Visible = false;
                dataGridView1.Columns["estado"].Visible = false;

                //Estilo de encabezado
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                conexionbd.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los contrato: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxEmpleado.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBoxTContrato.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBoxCargo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtdetalles.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtobservacion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


                var valorCelda = dataGridView1.CurrentRow.Cells[4].Value;

                if (DateTime.TryParse(valorCelda?.ToString(), out DateTime fecha))
                {
                    comboBoxFInicio.Text = fecha.ToString("dd/MM/yyyy");
                }
                else
                {
                    comboBoxFInicio.Text = ""; // O puedes poner "Fecha inválida"
                }
                var valorCeldaFecha = dataGridView1.CurrentRow.Cells[5].Value;

                if (DateTime.TryParse(valorCeldaFecha?.ToString(), out DateTime fechafinal))
                {
                    comboBoxFFinal.Text = fechafinal.ToString("dd/MM/yyyy");
                }
                else
                {
                    comboBoxFFinal.Text = ""; // O puedes poner "Fecha inválida"
                }
            }
        }
            private void CargarEmpleado()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idempleado, nombre_empleado FROM empleado ORDER BY nombre_empleado ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxEmpleado.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxEmpleado.DisplayMember = "nombre_empleado"; // Lo que se mostrará
                comboBoxEmpleado.ValueMember = "idempleado";       // El valor interno (oculto)
                comboBoxEmpleado.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void CargarTContrato()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idtipo_contrato, nombre_tipo FROM tipo_contrato ORDER BY nombre_tipo ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxTContrato.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxTContrato.DisplayMember = "nombre_tipo"; // Lo que se mostrará
                comboBoxTContrato.ValueMember = "idtipo_contrato";       // El valor interno (oculto)
                comboBoxTContrato.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
        private void CargarCargo()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idcargo, nombre_cargo FROM cargo ORDER BY nombre_cargo ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxCargo.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxCargo.DisplayMember = "nombre_cargo"; // Lo que se mostrará
                comboBoxCargo.ValueMember = "idcargo";       // El valor interno (oculto)
                comboBoxCargo.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
    }
}

