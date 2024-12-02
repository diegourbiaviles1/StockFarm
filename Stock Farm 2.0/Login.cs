using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Farm_2._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text;
            string contraseñaIngresada = txtContraseña.Text;

            // Usuario y contraseña válidos
            string usuarioValido = "Pablo Escobar";
            string contraseñaValida = "2004";

            // Verificación de credenciales
            if (usuarioIngresado == usuarioValido && contraseñaIngresada == contraseñaValida)
            {
                // Mensaje de éxito
                MessageBox.Show("Ingreso exitoso. Bienvenido " + usuarioValido + "!", "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir Form1 y cerrar Login
                StockFarm formPrincipal = new StockFarm();
                formPrincipal.Show();
                this.Hide(); // Oculta el formulario actual (Login.cs)
            }
            else
            {
                // Mensaje de error
                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtalo de nuevo.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
