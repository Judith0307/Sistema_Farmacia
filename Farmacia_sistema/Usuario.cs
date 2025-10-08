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
    public partial class Usuario : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            this.CargarCargos();
        }

        private void btnusuario_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT u.idusuario, u.codigo, u.contraseña, u.estado_usuario, c.nombre_cargo FROM usuario u JOIN cargo c ON u.idcargo = c.idcargo;";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                dataGridView1.Columns["idusuario"].Visible = false;
                dataGridView1.Columns["estado_usuario"].Visible = false;

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
                txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtcontraseña.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
        }
        private void CargarCargos()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idcargo, nombre_cargo FROM cargo ORDER BY nombre_cargo ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;             // Asigna los datos al ComboBox
                comboBox1.DisplayMember = "nombre_cargo"; // Lo que se mostrará
                comboBox1.ValueMember = "idcargo";       // El valor interno (oculto)
                comboBox1.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
    }
}
