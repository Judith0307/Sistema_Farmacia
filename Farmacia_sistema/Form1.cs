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
    public partial class Form1 : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Form1()
        {
            InitializeComponent();
        }

        public void SetClienteDatos(int id, string nombre, string email)
        {
            txtcodigo.Text = id.ToString();
            txtnombres.Text = nombre;
            txtdireccion.Text = email;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT idcliente, nombre_cliente, apellido_cliente, t.nombre_documento AS tipo_documento, num_documento, direccion " +
                    "FROM cliente c JOIN tipo_documento t ON c.idtipo_documento = t.idtipo_documento;";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                //dataGridView1.Columns["codigo"].Visible = false;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtapellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtdni.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }
        private void CargarCargos()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idtipo_documento, nombre_documento FROM tipo_documento ORDER BY nombre_documento ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;             // Asigna los datos al ComboBox
                comboBox1.DisplayMember = "nombre_documento"; // Lo que se mostrará
                comboBox1.ValueMember = "idtipo_documento";       // El valor interno (oculto)
                comboBox1.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CargarCargos();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Listar_clientes a = new Listar_clientes();
            a.Show();
        }
    }
}
