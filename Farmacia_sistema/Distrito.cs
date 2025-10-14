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

namespace Farmacia_sistema
{
    public partial class Distrito : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Distrito()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtdistrito.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void Distrito_Load(object sender, EventArgs e)
        {
            this.CargarProvincia();
            this.CargarDepartamento();
        }

        private void btndistrito_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT d.iddistrito, d.nombre_distrito, p.nombre_provincia " +
                    "FROM distrito d JOIN provincia p ON d.idprovincia = p.idprovincia;";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                dataGridView1.Columns["iddistrito"].Visible = false;

                //Estilo de encabezado
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                conexionbd.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los clientes: " + ex.Message);
            }
        }
        private void CargarProvincia()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idprovincia, nombre_provincia FROM provincia ORDER BY nombre_provincia ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;             // Asigna los datos al ComboBox
                comboBox1.DisplayMember = "nombre_provincia"; // Lo que se mostrará
                comboBox1.ValueMember = "idprovincia";       // El valor interno (oculto)
                comboBox1.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincia: " + ex.Message);
            }
        }

        private void CargarDepartamento()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT iddepartamento, nombre_departamento FROM provincia ORDER BY nombre_departamento ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox3.DataSource = dt;             // Asigna los datos al ComboBox
                comboBox3.DisplayMember = "nombre_departamento"; // Lo que se mostrará
                comboBox3.ValueMember = "iddepartamento";       // El valor interno (oculto)
                comboBox3.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincia: " + ex.Message);
            }
        }
    }
}
