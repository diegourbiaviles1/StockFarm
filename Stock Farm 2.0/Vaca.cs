using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Farm_2._0
{
    internal class VACA
    {
        public class Vaca
        {
            public int Id { get; set; }
            public string Arete { get; set; }

            public string Raza { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public DateTime FechaVacuna { get; set; }
            public DateTime FechaDesparacitada { get; set; }

            public bool ControlVacuna { get; set; }
            public bool ControlDesparasitante { get; set; }
            public char Sexo { get; set; }
            public List<Decimal> ControlPeso { get; set; } = new List<Decimal>() { };
            public string Peso
            {
                get
                {
                    // Convierte la lista de pesos en una cadena separada por comas
                    return string.Join(" , ", ControlPeso);
                }
            }

        }

        public class GestorDeDatos
            {
                public void GuardarVacas(List<Vaca> vacas, string archivoPath)
                {
                try
                {
                    using (FileStream archivo = new FileStream(archivoPath, FileMode.Create))
                    using (BinaryWriter escritor = new BinaryWriter(archivo))
                    {
                        // Escribir la cantidad de vacas
                        escritor.Write(vacas.Count);

                        foreach (Vaca vaca in vacas)
                        {
                            escritor.Write(vaca.Arete);
                            escritor.Write(vaca.Raza);

                            // Guardar fechas (Nacimiento, Desparasitada, Vacuna)
                            escritor.Write(vaca.FechaNacimiento.Day);
                            escritor.Write(vaca.FechaNacimiento.Month);
                            escritor.Write(vaca.FechaNacimiento.Year);

                            escritor.Write(vaca.FechaDesparacitada.Day);
                            escritor.Write(vaca.FechaDesparacitada.Month);
                            escritor.Write(vaca.FechaDesparacitada.Year);

                            escritor.Write(vaca.FechaVacuna.Day);
                            escritor.Write(vaca.FechaVacuna.Month);
                            escritor.Write(vaca.FechaVacuna.Year);

                            escritor.Write(vaca.ControlVacuna);
                            escritor.Write(vaca.ControlDesparasitante);
                            escritor.Write(vaca.Sexo);

                            // Guardar pesos
                            escritor.Write(vaca.ControlPeso.Count);
                            foreach (Decimal peso in vaca.ControlPeso)
                            {
                                escritor.Write(peso);
                            }
                        }
                    }

                    MessageBox.Show("Archivo guardado con éxito!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error guardando el archivo!\n" + ex.Message, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

                public List<Vaca> LeerArchivo(string archivoPath)
                {
                    if (!File.Exists(archivoPath))
                    {
                        MessageBox.Show("Error cargando el archivo!\n" + "El archivo no existe!", "Cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<Vaca>() { };
                    }

                    try
                    {
                        List<Vaca> ListaRetorno = new List<Vaca>() { };
                        FileStream archivo = new FileStream(archivoPath, FileMode.Open, FileAccess.Read);
                        BinaryReader lector = new BinaryReader(archivo);
                        int cantidadVacas = lector.ReadInt32();

                        for (int i = 0; i < cantidadVacas; i++)
                        {
                            Vaca vacaActual = new Vaca();
                            vacaActual.Id = i;
                            vacaActual.Arete = lector.ReadString();
                            vacaActual.Raza = lector.ReadString();

                            // Leer la fecha de nacimiento de la vaca
                            int diaNacimientoVaca = lector.ReadInt32();
                            int mesNacimientoVaca = lector.ReadInt32();
                            int añoNacimientoVaca = lector.ReadInt32();

                            // Leer la fecha de desparasitada de la vaca
                            int diaDesparasitadaVaca = lector.ReadInt32();
                            int mesDesparasitadaVaca = lector.ReadInt32();
                            int añoDesparasitadaVaca = lector.ReadInt32();


                            // Leer la fecha de vacuna de la vaca
                            int diaVacunaVaca = lector.ReadInt32();
                            int mesVacunaVaca = lector.ReadInt32();
                            int añoVacunaVaca = lector.ReadInt32();

                            vacaActual.FechaNacimiento = new DateTime(añoNacimientoVaca, mesNacimientoVaca, diaNacimientoVaca);
                            vacaActual.ControlVacuna = lector.ReadBoolean();
                            vacaActual.ControlDesparasitante = lector.ReadBoolean();
                            vacaActual.Sexo = lector.ReadChar();
                            int cantidadPesos = lector.ReadInt32();
                            List<Decimal> pesos = new List<Decimal>() { };

                            for (int j = 0; j < cantidadPesos; j++)
                            {
                                pesos.Add(lector.ReadDecimal());
                            }

                            vacaActual.ControlPeso = pesos;
                            ListaRetorno.Add(vacaActual);
                        }

                        MessageBox.Show("Archivo cargado con éxito!", "Cargar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lector.Close();
                        archivo.Close();

                        return ListaRetorno;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error cargando el archivo!\n" + ex, "Cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<Vaca>() { };
                    }
                }
            }
        }
    }
