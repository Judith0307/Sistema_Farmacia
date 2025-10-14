using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Farmacia_sistema
{
    public partial class Empleado : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Empleado()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT e.idempleado, e.nombre_empleado, e.apellido_empleado, e.numero_documento, td.nombre_documento AS tipo_documento, e.telefono, e.correo, p.nombre_profesion AS profesion, " +
                    "g.nombre_genero AS genero, e.edad_actual, e.fecha_nacimiento, e.direccion_actual, d.nombre_distrito AS distrito, e.observaciones, e.estado " +
                    "FROM empleado e JOIN tipo_documento td ON e.idtipo_documento = td.idtipo_documento JOIN distrito d ON e.iddistrito = d.iddistrito JOIN profesion p ON e.idprofesion = p.idprofesion " +
                    "JOIN genero g ON e.idgenero = g.idgenero WHERE e.estado = 1;";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                dataGridView1.Columns["idempleado"].Visible = false;
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
                MessageBox.Show("Error al mostrar los empleado: " + ex.Message);
            }
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            this.CargarDistrito();
            this.CargarGenero();
            this.CargarProfesion();
            this.CargarTipo_documento();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtapellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdni.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBoxDocumento.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txttelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtcorreo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBoxprofesion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                comboBoxGenero.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtedad.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                comboBoxDistrito.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                txtobservacion.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();

                var valorCelda = dataGridView1.CurrentRow.Cells[10].Value;

                if (DateTime.TryParse(valorCelda?.ToString(), out DateTime fecha))
                {
                    comboBoxFecha.Text = fecha.ToString("dd/MM/yyyy");
                }
                else
                {
                    comboBoxFecha.Text = ""; // O puedes poner "Fecha inválida"
                }
            }
        }

            private void CargarTipo_documento()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idtipo_documento, nombre_documento FROM tipo_documento ORDER BY nombre_documento ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxDocumento.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxDocumento.DisplayMember = "nombre_documento"; // Lo que se mostrará
                comboBoxDocumento.ValueMember = "idtipo_documento";       // El valor interno (oculto)
                comboBoxDocumento.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void CargarProfesion()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idprofesion, nombre_profesion FROM profesion ORDER BY nombre_profesion ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxprofesion.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxprofesion.DisplayMember = "nombre_profesion"; // Lo que se mostrará
                comboBoxprofesion.ValueMember = "idprofesion";       // El valor interno (oculto)
                comboBoxprofesion.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar profesion: " + ex.Message);
            }
        }
        private void CargarGenero()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idgenero, nombre_genero FROM genero ORDER BY nombre_genero ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxDocumento.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxDocumento.DisplayMember = "nombre_genero"; // Lo que se mostrará
                comboBoxDocumento.ValueMember = "idgenero";       // El valor interno (oculto)
                comboBoxDocumento.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar genero: " + ex.Message);
            }
        }
        private void CargarDistrito()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT iddistrito, nombre_distrito FROM distrito ORDER BY nombre_distrito ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxDocumento.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxDocumento.DisplayMember = "nombre_distrito"; // Lo que se mostrará
                comboBoxDocumento.ValueMember = "iddistrito";       // El valor interno (oculto)
                comboBoxDocumento.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar distritos: " + ex.Message);
            }
        }
    }
}

