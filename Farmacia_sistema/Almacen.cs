using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Farmacia_sistema
{
    public partial class Almacen : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Almacen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtstock.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txttelefono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtobservacion.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void Almacen_Load(object sender, EventArgs e)
        {
            this.CargarSucursar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT * FROM almacen";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                dataGridView1.Columns["idalmacen"].Visible = false;

                //Estilo de encabezado
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                conexionbd.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los almacen: " + ex.Message);
            }
        }
        private void CargarSucursar()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idsucursal, nombre_sucursal FROM sucursal ORDER BY nombre_sucursal ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;             // Asigna los datos al ComboBox
                comboBox1.DisplayMember = "nombre_sucursal"; // Lo que se mostrará
                comboBox1.ValueMember = "idsucursal";       // El valor interno (oculto)
                comboBox1.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursal: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
