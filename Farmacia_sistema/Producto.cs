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
    public partial class Producto : Form
    {
        ConexionBD conexionbd = new ConexionBD();
        public Producto()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = conexionbd.AbrirConexion();
                //Consulta sql (asegurate de que la tabla se 'clientes' o ajustar el nombre)
                String consulta = "SELECT p.idproducto, p.nombre_producto, p.precio, p.stock, p.tipo_medicamento, p.instrucciones, p.fecha_vencimiento, p.fecha_ingreso, p.requiere_receta, pr.nombre_proveedor AS proveedor, " +
                    "c.nombre_categoria AS categoria, m.nombre_marca AS marca, mo.nombre_modelo AS modelo, um.nombre_unidad AS unidad_medidad, l.nombre_laboratorio AS laboratorio, lo.codigo_lote AS lote, a.nombre_almacen AS almacen " +
                    "FROM producto p JOIN marca m ON p.idmarca = m.idmarca JOIN modelo mo ON p.idmodelo = mo.idmodelo JOIN categoria c ON p.idcategoria = c.idcategoria JOIN unidad_medidad um ON p.idunidad_medidad = um.idunidad_medidad " +
                    "JOIN laboratorio l ON p.idlaboratorio = l.idlaboratorio JOIN proveedor pr ON p.idproveedor = pr.idproveedor JOIN lote lo ON p.idlote = lo.idlote JOIN almacen a ON p.idalmacen = a.idalmacen;";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridView1.DataSource = tabla;

                dataGridView1.Columns["idproducto"].Visible = false;

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

        private void CargarProveedor()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idproveedor, nombre_proveedor FROM proveedor ORDER BY nombre_proveedor ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_proveedor"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idproveedor";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedor: " + ex.Message);
            }
        }

        private void CargarCategoria()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idcategoria, nombre_categoria FROM categoria ORDER BY nombre_categoria ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_categoria"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idcategoria";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categoria: " + ex.Message);
            }
        }

        private void CargarMarca()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idmarca, nombre_marca FROM marca ORDER BY nombre_marca ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_marca"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idmarca";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar marca: " + ex.Message);
            }
        }
        private void CargarModelo()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idmodelo, nombre_modelo FROM modelo ORDER BY nombre_modelo ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_modelo"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idmodelo";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar modelo: " + ex.Message);
            }
        }

        private void CargarUnidad_Medida()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idunidad_medidad, nombre_unidad FROM unidad_medidad ORDER BY nombre_unidad ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_unidad"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idunidad_medidad";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar unidad de medida: " + ex.Message);
            }
        }
        private void CargarLaboratorio()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idlaboratorio, nombre_laboratorio FROM laboratorio ORDER BY nombre_laboratorio ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_laboratorio"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idlaboratorio";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar laboratorio: " + ex.Message);
            }
        }
        private void CargarLote()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idlote, nombre_prdct FROM lote ORDER BY nombre_prdct ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_prdct"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idlote";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lote: " + ex.Message);
            }
        }
        private void CargarAlmacen()
        {
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                MySqlConnection conexion = conexionBD.AbrirConexion();

                string query = "SELECT idalmacen, nombre_almacen FROM almacen ORDER BY nombre_almacen ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxproveedor.DataSource = dt;             // Asigna los datos al ComboBox
                comboBoxproveedor.DisplayMember = "nombre_almacen"; // Lo que se mostrará
                comboBoxproveedor.ValueMember = "idalmacen";       // El valor interno (oculto)
                comboBoxproveedor.SelectedIndex = -1;            // Ningún ítem seleccionado al inicio

                conexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar almacen: " + ex.Message);
            }
        }
        private void Producto_Load(object sender, EventArgs e)
        {
            this.CargarAlmacen();
            this.CargarCategoria();
            this.CargarLaboratorio();
            this.CargarLote();
            this.CargarMarca();
            this.CargarModelo();
            this.CargarProveedor();
            this.CargarUnidad_Medida();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                //Asignamos los valores a las posiciones segun corresponda
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtprecio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtstock.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txttipo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtinstrucciones.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtreceta.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                comboBoxproveedor.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                comboBoxcategoria.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                comboBoxmarca.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                comboBoxmodelo.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                comboBoxunidadmedida.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                comboBoxlaboratorio.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                comboBoxlote.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                comboBoxalmacen.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            }

            var valorCelda = dataGridView1.CurrentRow.Cells[6].Value;

            if (DateTime.TryParse(valorCelda?.ToString(), out DateTime fecha))
            {
                txtfechaIngreso .Text = fecha.ToString("dd/MM/yyyy");
            }
            else
            {
                txtfechaIngreso.Text = ""; // O puedes poner "Fecha inválida"
            }

            var valorVencimiento = dataGridView1.CurrentRow.Cells[7].Value;

            if (DateTime.TryParse(valorVencimiento?.ToString(), out DateTime fechaV))
            {
                txtvencimiento.Text = fechaV.ToString("dd/MM/yyyy");
            }
            else
            {
                txtvencimiento.Text = ""; // O puedes poner "Fecha inválida"
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
