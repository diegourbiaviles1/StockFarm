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
    public partial class FormBusqueda : Form
    {
        public FormBusqueda()
        {
            InitializeComponent();
        }

        private void gestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario principal
            StockFarm formPrincipal = Application.OpenForms.OfType<StockFarm>().FirstOrDefault();

            if (formPrincipal != null)
            {
                formPrincipal.Show(); // Mostrar el formulario principal si está disponible
                this.Close(); // Cerrar el formulario de búsqueda
            }
            else
            {
                MessageBox.Show("El formulario principal no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
