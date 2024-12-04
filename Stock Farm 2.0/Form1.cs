using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Stock_Farm_2._0.VACA;
using System.IO;
using Microsoft.Reporting.WinForms;


namespace Stock_Farm_2._0
{
    public partial class StockFarm : Form
    {
        // Lista para almacenar las vacas
        List<Vaca> vacas = new List<Vaca>() { };
        // Índice de la vaca seleccionada
        int VacaSeleccionada = -1;
        // Ruta al archivo de datos
        private readonly string archivoPath = "datos.dat";
        public StockFarm()
        {
            InitializeComponent();
            // Configurar el DateTimePicker sin fecha al iniciar
            dateTimePickerBorn.Format = DateTimePickerFormat.Custom;
            dateTimePickerBorn.CustomFormat = " "; // Espacio para simular que está vacío

            dateTimePickerVacuna.Visible = false;
            dateTimePickerDesparacitada.Visible = false;

            // Asociar eventos CheckedChanged a los CheckBox
            chkVacuna.CheckedChanged += chkVacuna_CheckedChanged;
            chkDesparacitada.CheckedChanged += chkDesparacitada_CheckedChanged;

            this.FormClosing += Form1_FormClosing;
        }
        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GestorDeDatos guardar = new GestorDeDatos();
            guardar.GuardarVacas(vacas, archivoPath);
        }

        // Manejador de evento para cargar datos
        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorDeDatos cargar = new GestorDeDatos();
            vacas = cargar.LeerArchivo(archivoPath);

            ActualizarGridView();
        }

        // Método para actualizar el DataGridView
        private void ActualizarGridView()
        {
            dataGridView1.DataSource = null;

            // Crear una lista de datos para mostrar en el DataGridView
            var vacasData = vacas.Select((v, index) => new
            {
                ID = v.Id,
                Arete = v.Arete,
                Raza = v.Raza,
                Sexo = v.Sexo,
                Nacimiento = v.FechaNacimiento.ToShortDateString(),
                Vacuna = v.ControlVacuna ? v.FechaVacuna.ToShortDateString() : "N/A",
                Desparasitante = v.ControlDesparasitante ? v.FechaDesparacitada.ToShortDateString() : "N/A",
                Pesos = string.Join(", ", v.ControlPeso),
                Imagen = v.Imagen != null ? ConvertirBytesAImagen(v.Imagen) : null,
            }).ToList();

            dataGridView1.DataSource = vacasData;

            // Configuración de columnas
            if (dataGridView1.Columns["Imagen"] == null)
            {
                var imageColumn = new DataGridViewImageColumn
                {
                    DataPropertyName = "Imagen",
                    HeaderText = "Imagen",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridView1.Columns.Add(imageColumn);
            }

        }
        private void chkVacuna_CheckedChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar el DateTimePicker de vacuna según el estado del CheckBox
            dateTimePickerVacuna.Visible = chkVacuna.Checked;
        }
        private void chkDesparacitada_CheckedChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar el DateTimePicker de desparacitada según el estado del CheckBox
            dateTimePickerDesparacitada.Visible = chkDesparacitada.Checked;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Cambiar el formato para mostrar la fecha seleccionada
            dateTimePickerBorn.Format = DateTimePickerFormat.Short;
        }

        private void rdMacho_CheckedChanged(object sender, EventArgs e)
        {

        }
        private Image ConvertirBytesAImagen(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }


        private void txtArete_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                string text = textBox.Text;
                textBox.Text = new string(text.Where(c => char.IsDigit(c)).ToArray());
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                string text = textBox.Text;
                textBox.Text = new string(text.Where(c => char.IsDigit(c)).ToArray());
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Vaca vaca = new Vaca();

            // Validar campo 'Arete'
            if (txtArete.Text == "")
            {
                MessageBox.Show("El campo 'Arete' está vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            vaca.Id = vacas.Count;

            // Asignar propiedades de la vaca
            vaca.Arete = txtArete.Text;
            vaca.FechaNacimiento = dateTimePickerBorn.Value;
            vaca.Raza = cmbRaza.Text;

            vaca.FechaVacuna = chkVacuna.Checked ? dateTimePickerVacuna.Value : DateTime.MinValue;
            vaca.FechaDesparacitada = chkDesparacitada.Checked ? dateTimePickerDesparacitada.Value : DateTime.MinValue;

            vaca.ControlVacuna = chkVacuna.Checked;
            vaca.ControlDesparasitante = chkDesparacitada.Checked;

            // Validar campo 'Sexo'
            char Sexo = ' ';
            if (!rdMacho.Checked && !rdHembra.Checked)
            {
                MessageBox.Show("El campo 'Sexo' está vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Asignar el Sexo a la vaca dependiendo del radio button
            if (rdMacho.Checked) Sexo = 'M';
            else if (rdHembra.Checked) Sexo = 'F';

            vaca.Sexo = Sexo;

            // Procesar datos de control de peso
            string[] pesos = txtPeso.Text.Split(',');

            List<Decimal> controlPesos = new List<Decimal>() { };
            foreach (string peso in pesos)
            {
                Decimal pesoDecimal;
                if (!Decimal.TryParse(peso, out pesoDecimal))
                {
                    MessageBox.Show("Control de Peso: El texto '" + peso + "' no se pudo convertir a decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                controlPesos.Add(pesoDecimal);
            }

            vaca.ControlPeso = controlPesos;
            // Convertir imagen si existe
            if (pictureBox1.Image != null)
            {
                vaca.Imagen = ConvertirBytesAImagen(pictureBox1.Image);
            }
            else
            {
                vaca.Imagen = null; // No hay imagen
            }


            // Agregar vaca a la lista y resetear campos del formulario
            vacas.Add(vaca);
            txtArete.Text = "";
            cmbRaza.Text = "";
            chkVacuna.Checked = false;
            chkDesparacitada.Checked = false;
            rdMacho.Checked = false;
            rdHembra.Checked = false;
            txtPeso.Text = "";
            pictureBox1.Image = null;


            ActualizarGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VacaSeleccionada == -1)
            {
                MessageBox.Show("¡No hay ninguna vaca seleccionada!", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var vacaAEliminar = vacas[VacaSeleccionada];
                if (MessageBox.Show($"¿Está seguro de que desea eliminar a la vaca con arete '{vacaAEliminar.Arete}'?", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    vacas.RemoveAt(VacaSeleccionada);
                    ActualizarGridView();
                    MessageBox.Show("Vaca eliminada correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    VacaSeleccionada = -1; // Limpiar selección
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la vaca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (VacaSeleccionada == -1)
            {
                MessageBox.Show("¡No hay ninguna vaca seleccionada!", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Validar campos antes de editar
                if (string.IsNullOrWhiteSpace(txtArete.Text))
                {
                    MessageBox.Show("El campo 'Arete' no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbRaza.Text))
                {
                    MessageBox.Show("Debe seleccionar una raza.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!rdMacho.Checked && !rdHembra.Checked)
                {
                    MessageBox.Show("Debe seleccionar un sexo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Modificar los datos de la vaca seleccionada
                var vaca = vacas[VacaSeleccionada];
                vaca.Arete = txtArete.Text;
                vaca.Raza = cmbRaza.Text;
                vaca.FechaNacimiento = dateTimePickerBorn.Value;
                vaca.ControlVacuna = chkVacuna.Checked;
                vaca.FechaVacuna = chkVacuna.Checked ? dateTimePickerVacuna.Value : DateTime.MinValue;
                vaca.ControlDesparasitante = chkDesparacitada.Checked;
                vaca.FechaDesparacitada = chkDesparacitada.Checked ? dateTimePickerDesparacitada.Value : DateTime.MinValue;
                vaca.Sexo = rdMacho.Checked ? 'M' : 'F';

                // Procesar control de pesos
                var pesos = txtPeso.Text.Split(',');
                vaca.ControlPeso = pesos
                    .Select(p => decimal.TryParse(p.Trim(), out var peso) ? peso : 0)
                    .Where(p => p > 0) // Ignorar pesos no válidos
                    .ToList();

                // Procesar imagen si existe
                if (pictureBox1.Image != null)
                {
                    vaca.Imagen = ConvertirBytesAImagen(pictureBox1.Image);
                }

                // Actualizar el DataGridView
                ActualizarGridView();
                MessageBox.Show("Datos de la vaca editados correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                VacaSeleccionada = -1; // Limpiar selección
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo Binario (*.bin)|*.bin",
                Title = "Guardar Inventario de Vacas"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                GestorDeDatos gestor = new GestorDeDatos();
                gestor.GuardarVacas(vacas, rutaArchivo);
            }

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivo Binario (*.bin)|*.bin",
                Title = "Cargar Inventario de Vacas"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                GestorDeDatos gestor = new GestorDeDatos();
                vacas = gestor.LeerArchivo(rutaArchivo);
                ActualizarGridView();
            }
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDataSource dataSource = new ReportDataSource("DsDatos", vacas);

            Reporte formReporte = new Reporte();
            formReporte.reportViewer1.LocalReport.DataSources.Clear();
            formReporte.reportViewer1.LocalReport.DataSources.Add(dataSource);

            //Configurar archivo del reporte
            formReporte.reportViewer1.LocalReport.ReportEmbeddedResource = "Stock_Farm_2._0.Reportes.RptGanado.rdlc";
            //Refrescar el reporte
            formReporte.reportViewer1.RefreshReport();

            //Visualizar el formulario
            formReporte.ShowDialog();
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog
            {
                Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.gif"
            };

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                Image imagen = Image.FromFile(archivo.FileName);
                pictureBox1.Image = imagen;

                // Si se está editando o agregando, asigna la imagen
                if (VacaSeleccionada >= 0)
                {
                    vacas[VacaSeleccionada].Imagen = ConvertirBytesAImagen(imagen);
                }
            }
        }

        private byte[] ConvertirBytesAImagen(Image imagen)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imagen.Save(ms, imagen.RawFormat);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al convertir la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            // Configurar la fuente de datos para el reporte
            ReportDataSource dataSource = new ReportDataSource("DsDatos", vacas);

            // Crear una instancia del formulario del reporte
            Reporte formReporte = new Reporte();
            formReporte.reportViewer1.LocalReport.DataSources.Clear();
            formReporte.reportViewer1.LocalReport.DataSources.Add(dataSource);

            // Configurar el archivo del reporte
            formReporte.reportViewer1.LocalReport.ReportEmbeddedResource = "Stock_Farm_2._0.Reportes.RptGanado.rdlc";

            // Refrescar y mostrar el reporte
            formReporte.reportViewer1.RefreshReport();
            formReporte.ShowDialog();
        }

        private int? filaSeleccionada = null; // Variable para almacenar la fila seleccionada previamente
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Validar que el clic es en una fila válida
            {
                try
                {
                    // Si la fila seleccionada es la misma, limpiar selección y campos
                    if (filaSeleccionada == e.RowIndex)
                    {
                        filaSeleccionada = null; // Limpiar selección
                        dataGridView1.ClearSelection(); // Deseleccionar la fila
                        LimpiarCampos(); // Método para limpiar los campos del formulario
                        VacaSeleccionada = -1; // Restablecer la variable de selección
                        return; // Salir del evento
                    }

                    // Guardar el índice de la nueva fila seleccionada
                    filaSeleccionada = e.RowIndex;
                    VacaSeleccionada = e.RowIndex; // Actualizar índice global para edición/eliminación

                    // Seleccionar toda la fila
                    dataGridView1.Rows[e.RowIndex].Selected = true;

                    // Validar que la lista tiene datos y el índice está dentro del rango
                    if (vacas == null || VacaSeleccionada < 0 || VacaSeleccionada >= vacas.Count)
                    {
                        MessageBox.Show("La lista de vacas está vacía o el índice está fuera de rango.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Recuperar la vaca seleccionada
                    Vaca vacaRow = vacas[VacaSeleccionada];

                    // Llenar los campos del formulario con los datos de la vaca seleccionada
                    txtArete.Text = vacaRow.Arete;
                    cmbRaza.Text = vacaRow.Raza;
                    txtPeso.Text = string.Join(",", vacaRow.ControlPeso);
                    dateTimePickerBorn.Value = vacaRow.FechaNacimiento != DateTime.MinValue ? vacaRow.FechaNacimiento : DateTime.Now;

                    chkVacuna.Checked = vacaRow.ControlVacuna;
                    dateTimePickerVacuna.Value = vacaRow.FechaVacuna != DateTime.MinValue ? vacaRow.FechaVacuna : DateTime.Now;

                    chkDesparacitada.Checked = vacaRow.ControlDesparasitante;
                    dateTimePickerDesparacitada.Value = vacaRow.FechaDesparacitada != DateTime.MinValue ? vacaRow.FechaDesparacitada : DateTime.Now;

                    rdMacho.Checked = vacaRow.Sexo == 'M';
                    rdHembra.Checked = vacaRow.Sexo == 'F';

                    pictureBox1.Image = vacaRow.Imagen != null && vacaRow.Imagen.Length > 0
                        ? Image.FromStream(new MemoryStream(vacaRow.Imagen))
                        : null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"¡Error al cargar la vaca seleccionada: {ex.Message}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtArete.Text = "";
            cmbRaza.Text = "";
            txtPeso.Text = "";
            chkVacuna.Checked = false;
            chkDesparacitada.Checked = false;
            rdMacho.Checked = false;
            rdHembra.Checked = false;
            pictureBox1.Image = null;
            dateTimePickerBorn.Value = DateTime.Now;
            dateTimePickerVacuna.Value = DateTime.Now;
            dateTimePickerDesparacitada.Value = DateTime.Now;
        }

        //Evitar que se quede un proceso abierto en el administrador de tareas
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Reporte formReporte)
                {
                    formReporte.reportViewer1.LocalReport.ReleaseSandboxAppDomain();
                    formReporte.Dispose();
                }
            }

            Application.Exit(); // Finaliza la aplicación completamente
        }
    }
}
