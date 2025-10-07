using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Farmacia_sistema
{
    internal class ConexionBD
    {
        //Campo de conexion
        private MySqlConnection conexion;
        //Cadena de conexion a MySql local (XAMPP)
        private String cadenaConexion = "Server=localhost;Port=3306;Database=bd_farmacia;Uid=root;Pwd=;";

        //Metodo para abrir la conexion
        public MySqlConnection AbrirConexion()
        {
            if (conexion == null)
                conexion = new MySqlConnection(cadenaConexion);
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }

        //Metodo para cerrar la conexion
        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
