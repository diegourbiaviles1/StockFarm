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
            dataGridView1.DataSource = vacas;
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

            // Agregar vaca a la lista y resetear campos del formulario
            vacas.Add(vaca);
            txtArete.Text = "";
            cmbRaza.Text = "";
            chkVacuna.Checked = false;
            chkDesparacitada.Checked = false;
            rdMacho.Checked = false;
            rdHembra.Checked = false;
            txtPeso.Text = "";

            ActualizarGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VacaSeleccionada == -1)
            {
                MessageBox.Show("¡No hay ninguna vaca seleccionada!", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar a '" + vacas[VacaSeleccionada].Arete + "'?", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    vacas.RemoveAt(VacaSeleccionada);
                    ActualizarGridView();
                }
            }
        }

                private void btnEditar_Click(object sender, EventArgs e)
                {
                    if (VacaSeleccionada == -1)
                    {
                        MessageBox.Show("¡No hay ninguna vaca seleccionada!", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Vaca vaca = new Vaca();

                        // Validar campo 'Arete'
                        if (txtArete.Text == "")
                {
                            MessageBox.Show("El campo 'Arete' está vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                // Asignar propiedades de la vaca
                vaca.Arete = txtArete.Text;
                vaca.Raza = cmbRaza.Text;
                vaca.ControlPeso = new List<Decimal>() { };
                vaca.FechaNacimiento = dateTimePickerBorn.Value;
                vaca.ControlVacuna = chkVacuna.Checked;
                vaca.FechaVacuna = chkVacuna.Checked ? dateTimePickerVacuna.Value : DateTime.MinValue;
                vaca.FechaDesparacitada = chkDesparacitada.Checked ? dateTimePickerDesparacitada.Value : DateTime.MinValue;
                vaca.ControlDesparasitante = chkVacuna.Checked;

                // Validar campo 'Sexo'
                char Sexo = ' ';
                        if (!rdMacho.Checked && !rdHembra.Checked)
                {
                            MessageBox.Show("El campo 'Sexo' está vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (rdMacho.Checked) Sexo = 'M';
                else if (rdHembra.Checked) Sexo = 'F';

                vaca.Sexo = Sexo;

                        // Procesar datos de control de peso
                        string[] pesos = txtPeso.Text.Split('\n');

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

                        // Actualizar vaca en la lista y resetear campos del formulario
                            vacas[VacaSeleccionada] = vaca;
                            txtArete.Text = "\n";
                            cmbRaza.Text = "\n";
                            txtPeso.Text = "\n";
                            chkVacuna.Checked = false;
                            chkDesparacitada.Checked = false;
                            rdMacho.Checked = false;
                            rdHembra.Checked = false;   
                            txtPeso.Text = "\n";
                            VacaSeleccionada = -1;

                        ActualizarGridView();
                    }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    Vaca vacaRow = (Vaca)dataGridView1.CurrentRow.DataBoundItem;
                    VacaSeleccionada = vacaRow.Id;

                    int index = -1;
                    for (int i = 0; i < vacas.Count; i++)
                    {
                        if (vacas[i].Id == VacaSeleccionada) index = i;
                    }

                    if (index != -1)
                    {
                        // Llenar campos del formulario con los datos de la vaca seleccionada
                        txtArete.Text = vacas[index].Arete;
                        cmbRaza.Text = vacas[index].Raza;
                        txtPeso.Text = vacas[index].ControlPeso.ToString();
                        dateTimePickerBorn.Value = vacas[index].FechaNacimiento;
                        chkVacuna.Checked = vacas[index].ControlVacuna;
                        chkDesparacitada.Checked = vacas[index].ControlDesparasitante;
                        dateTimePickerVacuna.Value = vacas[index].FechaVacuna;
                        dateTimePickerDesparacitada.Value = vacas[index].FechaDesparacitada;
                        rdMacho.Checked = false;
                        rdHembra.Checked = false;

                        if (vacas[index].Sexo == 'M') rdMacho.Checked = true;
                       
                        if (vacas[index].Sexo == 'F') rdHembra.Checked = true;

                        string pesos = "";
                        for (int i = 0; i < vacas[index].ControlPeso.Count; i++)
                        {
                            pesos += vacas[index].ControlPeso[i].ToString();
                            if (i < vacas[index].ControlPeso.Count - 1) pesos += '\n';
                        }

                        txtPeso.Text = pesos;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Error al seleccionar!\n" + ex, "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            // Crear una instancia del nuevo formulario
            FormBusqueda formBusqueda = new FormBusqueda();

            // Ocultar el formulario principal
            this.Hide();

            // Mostrar el nuevo formulario
            formBusqueda.Show();

            // Configurar evento para que, al cerrar el nuevo formulario, el formulario principal vuelva a mostrarse
            formBusqueda.FormClosed += (s, args) => this.Show();
        }
    }
}
