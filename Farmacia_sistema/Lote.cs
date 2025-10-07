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
    public partial class Lote: Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Lote()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Lote_Load(object sender, EventArgs e)
        {

        }

        private void btnlistaralmacen_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT * FROM lote";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                dataGridView1.Columns["idlote"].Visible = false;

                //Estilo de encabezado
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                conexionbd.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los lote: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtcodigolote.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtfabricacion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtvencimiento.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtcantidad.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtpreciounidad.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtpreciototal.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtfechaventa.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            }
        }
    }
}
