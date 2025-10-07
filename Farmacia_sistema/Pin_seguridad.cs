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
    public partial class Pin_seguridad : Form
    {
        public Pin_seguridad()
        {
            InitializeComponent();
            //Establecer la posicion del formulario al centro de la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            progressBar1.Visible = false; //Oculto el progressbar

            this.BTNINGRESAR.Enabled = false;
        }

        private void Pin_seguridad_Load(object sender, EventArgs e)
        {

        }

        private void BTNINGRESAR_Click(object sender, EventArgs e)
        {
            String contraseña = "123456789";
            if (TXTPASSWORD.Text.Equals(contraseña))
            {
                MessageBox.Show("Datos correctos", "Bienvenidos!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Si las credenciales son correctas, mostrar ProgressBar
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;

                //Simula una tarea que toma algo de tiempo (puede ser la carga de otro formulario)
                Timer timer = new Timer();
                timer.Interval = 5000;
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    progressBar1.Visible = false;

                    //Si los datos son correctos, muestre el login
                    Login_seguridad a = new Login_seguridad();
                    a.Show();
                    this.Hide();
                };
                timer.Start();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN0_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "0";
        }

        private void BTN1_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "1";
        }

        private void BTN2_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "2";
        }

        private void BTN3_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "3";
        }

        private void BTN4_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "4";
        }

        private void BTN5_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "5";
        }

        private void BTN6_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "6";
        }

        private void BTN7_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "7";
        }

        private void BTN8_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "8";
        }

        private void BTN9_Click(object sender, EventArgs e)
        {
            TXTPASSWORD.SelectedText = "9";
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

        private void TXTPASSWORD_TextChanged(object sender, EventArgs e)
        {
            if (TXTPASSWORD.Text.Length >= 5)
            {
                this.BTNINGRESAR.Enabled = true;
            }
            else
            {
                this.BTNINGRESAR.Enabled = false;
            }
        }
    }
}
