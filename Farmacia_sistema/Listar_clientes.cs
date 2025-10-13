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
    public partial class Listar_clientes : Form
    {
        private DataGridViewRow filaSeleccionada = null;

        public Listar_clientes()
        {
            InitializeComponent();
        }

        private void Listar_clientes_Load(object sender, EventArgs e)
        {
            var clientes = new[]
            {
                new { Id = 1, Nombre = "Juan Perez", Email = "juan@example.com" },
                new { Id = 2, Nombre = "Maria Lopez", Email = "maria@example.com" },
                new { Id = 3, Nombre = "Carlos Gomez", Email = "carlos@example.com" },
                new { Id = 4, Nombre = "Ana Martinez", Email = "ana@example.com" },
                new { Id = 5, Nombre = "Luis Fernandez", Email = "luis@example.com" },
                new { Id = 6, Nombre = "Sofia Ramirez", Email = "sofia@example.com" },
                new { Id = 7, Nombre = "Pedro Castillo", Email = "pedro@example.com" },
                new { Id = 8, Nombre = "Laura Sanchez", Email = "laura@example.com" },
                new { Id = 9, Nombre = "Diego Morales", Email = "diego@example.com" },
                new { Id = 10, Nombre = "Marta Rios", Email = "marta@example.com" }
            };

            dataGridView1_LISTACLIENTES.DataSource = clientes;
        }

        private void dataGridView1_LISTACLIENTES_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filaSeleccionada = dataGridView1_LISTACLIENTES.Rows[e.RowIndex];
            }
        }
    }
}
