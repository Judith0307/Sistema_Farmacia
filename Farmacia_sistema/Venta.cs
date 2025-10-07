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
    public partial class Venta : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Venta()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBoxempleado.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txttotal.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBoxTipoPago.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                var valorCelda = dataGridView1.CurrentRow.Cells[3].Value;

                if (DateTime.TryParse(valorCelda?.ToString(), out DateTime fecha))
                {
                    txtfechaventa.Text = fecha.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtfechaventa.Text = ""; // O puedes poner "Fecha inválida"
                }
            }
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            this.CargarCliente();
            this.CargarEmpleado();
            this.CargarTipoPago();
        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT * FROM venta";

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
                MessageBox.Show("Error al mostrar los venta: " + ex.Message);
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

                comboBoxempleado.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxempleado.DisplayMember = "nombre_empleado"; // Lo que se mostrará
                comboBoxempleado.ValueMember = "idempleado";       // El valor interno (oculto)
                comboBoxempleado.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleado: " + ex.Message);
            }
        }
        private void CargarCliente()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idcliente, nombre_cliente FROM cliente ORDER BY nombre_cliente ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxempleado.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxempleado.DisplayMember = "nombre_cliente"; // Lo que se mostrará
                comboBoxempleado.ValueMember = "idcliente";       // El valor interno (oculto)
                comboBoxempleado.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
        private void CargarTipoPago()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idtipo_pago, metodo_pago FROM tipo_pago ORDER BY metodo_pago ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxempleado.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxempleado.DisplayMember = "metodo_pago"; // Lo que se mostrará
                comboBoxempleado.ValueMember = "idtipo_pago";       // El valor interno (oculto)
                comboBoxempleado.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipo de pago: " + ex.Message);
            }
        }

    }
}
