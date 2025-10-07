using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Farmacia_sistema
{
    public partial class Menu_principal : Form
    {
        public Menu_principal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmaximizar.Visible = false;
            btnrestaurar.Visible = true;
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnrestaurar.Visible = false;
            btnmaximizar.Visible = true;
        }

        private void Menu_principal_Load(object sender, EventArgs e)
        {
        }
        private void btndetalleProducto_Click(object sender, EventArgs e)
        {
            SubProducto.Visible = true;
        }

        private void btnproducto_Click(object sender, EventArgs e)
        {
            SubProducto.Visible = false;
            //AbrirFromHija(new Producto());
            Producto frm = new Producto();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubProducto.Visible = false;
            //AbrirFromHija(new Almacen());
            Almacen frm = new Almacen();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubProducto.Visible = false;
            //AbrirFromHija(new Lote());
            Lote frm = new Lote();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubProducto.Visible = false;
            //AbrirFromHija(new Laboratorio());
            Laboratorio frm = new Laboratorio();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SubEmpleado.Visible = true;
        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            SubEmpleado.Visible = false;
            //AbrirFromHija(new Empleado());
            Empleado frm = new Empleado();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void btncontrato_Click(object sender, EventArgs e)
        {
            SubEmpleado.Visible = false;
            //AbrirFromHija(new Contrato());
            Contrato frm = new Contrato();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void btnTipoContrato_Click(object sender, EventArgs e)
        {
            SubEmpleado.Visible = false;
            Tipo_Contrato frm = new Tipo_Contrato();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void btndistrito_Click(object sender, EventArgs e)
        {
            SubEmpleado.Visible = false;
            //AbrirFromHija(new Distrito());
            Distrito frm = new Distrito();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        [DllImportAttribute("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void Menu_principal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /*private void AbrirFromHija(object fromhija)
        {
            if (this.panelContenido.Controls.Count > 0)
                this.panelContenido.Controls.RemoveAt(0);
            Form fh = fromhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(fh);
            this.panelContenido.Tag = fh;
            fh.Show();
        }*/

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {
        }
        private void btninicio_Click(object sender, EventArgs e)
        {
        }

        private void btnventa_Click(object sender, EventArgs e)
        {
            //AbrirFromHija(new Venta());
            Venta frm = new Venta();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            //AbrirFromHija(new Form1());
            Form1 frm = new Form1();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void btnproveedor_Click(object sender, EventArgs e)
        {
            Proveedor frm = new Proveedor();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }

        private void btnusuario_Click(object sender, EventArgs e)
        {
            Usuario frm = new Usuario();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                this.Location.X + (this.Width - frm.Width) / 2,
                this.Location.Y + (this.Height - frm.Height) / 2
            );

            frm.Show();
        }
    }
}
