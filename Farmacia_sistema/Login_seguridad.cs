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
    public partial class Login_seguridad : Form
    {
        public Login_seguridad()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BTNINGRESAR.Enabled = false;
        }

        private void Login_seguridad_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("<<Selecionar Cargo>>");
            comboBox1.Items.Add("Administrador");
            comboBox1.Items.Add("Empleado");
            comboBox1.Items.Add("Supervisor");
            //Agregar mas segun lo necesitado
            comboBox1.SelectedIndex = 0; //Para que no tenga nada seleccionado al inicio
        }

        private void BTNSALIR_Click(object sender, EventArgs e)
        {
            //Mostrar un menssageBox con una pregunta
            DialogResult result = MessageBox.Show("¿Estas seguro de que deseas cerrar el formulario?",
                "Confimar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //Si el usuario elije 'si', cerrar el formulario
            if (result == DialogResult.Yes)
            {
                this.Close(); //Cerrar el formulario
            }
        }

        private void BTNINGRESAR_Click(object sender, EventArgs e)
        {
            string usuario = "Admin";
            string password = "123456";
            string cargoAdmin = "Administrador";
            string cargoEmpleado = "Empleado";

            String userInput = TXTCODIGO.Text;
            String pass = TXTPASSWORD.Text;
            String cargoSeleccionado = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(cargoSeleccionado))
            {
                MessageBox.Show("Por favor, seleccione un cargo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userInput.Equals(usuario) && pass.Equals(password) && cargoSeleccionado.Equals(cargoAdmin))
            {
                MessageBox.Show("Datos correctos", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Menu_principal a = new Menu_principal();
                a.Show();
                this.Hide();
            }
            else if (userInput.Equals(usuario) && pass.Equals(password) && cargoSeleccionado.Equals(cargoEmpleado))
            {
                MessageBox.Show("Datos correctos", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
               /* productos a = new productos();
                a.Show();
                this.Hide();*/
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TXTPASSWORD_TextChanged(object sender, EventArgs e)
        {
            if (TXTPASSWORD.Text.Length >= 4)
            {
                this.BTNINGRESAR.Enabled = true;
            }
        }
    }
}
