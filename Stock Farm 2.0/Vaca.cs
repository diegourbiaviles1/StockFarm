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

            public byte[] Imagen { get; set; }


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
                        escritor.Write(vacas.Count); // Escribir la cantidad de vacas

                        foreach (Vaca vaca in vacas)
                        {
                            escritor.Write(vaca.Arete);
                            escritor.Write(vaca.Raza);

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

                            escritor.Write(vaca.ControlPeso.Count);
                            foreach (Decimal peso in vaca.ControlPeso)
                            {
                                escritor.Write(peso);
                            }

                            // Guardar la imagen
                            if (vaca.Imagen != null)
                            {
                                escritor.Write(vaca.Imagen.Length); // Escribir la longitud de la imagen
                                escritor.Write(vaca.Imagen);        // Escribir los bytes de la imagen
                            }
                            else
                            {
                                escritor.Write(0); // Si no hay imagen, escribir longitud 0
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
        MessageBox.Show("El archivo no existe!", "Cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return new List<Vaca>();
    }

    try
    {
        List<Vaca> vacas = new List<Vaca>();
        using (FileStream archivo = new FileStream(archivoPath, FileMode.Open, FileAccess.Read))
        using (BinaryReader lector = new BinaryReader(archivo))
        {
            int cantidadVacas = lector.ReadInt32();

            for (int i = 0; i < cantidadVacas; i++)
            {
                Vaca vaca = new Vaca();
                vaca.Id = i;
                vaca.Arete = lector.ReadString();
                vaca.Raza = lector.ReadString();

                int diaNacimiento = lector.ReadInt32();
                int mesNacimiento = lector.ReadInt32();
                int añoNacimiento = lector.ReadInt32();
                vaca.FechaNacimiento = new DateTime(añoNacimiento, mesNacimiento, diaNacimiento);

                int diaDesparacitada = lector.ReadInt32();
                int mesDesparacitada = lector.ReadInt32();
                int añoDesparacitada = lector.ReadInt32();
                vaca.FechaDesparacitada = new DateTime(añoDesparacitada, mesDesparacitada, diaDesparacitada);

                int diaVacuna = lector.ReadInt32();
                int mesVacuna = lector.ReadInt32();
                int añoVacuna = lector.ReadInt32();
                vaca.FechaVacuna = new DateTime(añoVacuna, mesVacuna, diaVacuna);

                vaca.ControlVacuna = lector.ReadBoolean();
                vaca.ControlDesparasitante = lector.ReadBoolean();
                vaca.Sexo = lector.ReadChar();

                int cantidadPesos = lector.ReadInt32();
                for (int j = 0; j < cantidadPesos; j++)
                {
                    vaca.ControlPeso.Add(lector.ReadDecimal());
                }

                // Leer la imagen
                int longitudImagen = lector.ReadInt32();
                if (longitudImagen > 0)
                {
                    vaca.Imagen = lector.ReadBytes(longitudImagen);
                }

                vacas.Add(vaca);
            }
        }

        MessageBox.Show("Archivo cargado con éxito!", "Cargar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return vacas;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error cargando el archivo!\n" + ex.Message, "Cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return new List<Vaca>();
    }
                }
            }
        }
    }
