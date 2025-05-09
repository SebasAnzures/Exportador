using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Exportador.Context;
using Exportador.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exportador.Controller
{
    class Acciones
    {
        private readonly Conection conexion = new Conection();

        public List<EmpDep> ObtenerEmpDep()
        {
            var lista = new List<EmpDep>();
            string query = @"select e.nombre as NombreEmpleado, e.edad, d.nombre as NombreDepartamento
from empleados e
inner join Departamentos d on e.iddepartamento = d.id";
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EmpDep
                            {
                                NombreEmp = reader["NombreEmpleado"].ToString(),
                                Edad = Convert.ToInt32(reader["edad"]),
                                NombreDep = reader["NombreDepartamento"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public void ExportarAExcel(List<EmpDep> lista)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Personas");
                worksheet.Cell(1, 1).Value = "Nombre del Empleado";
                worksheet.Cell(1, 2).Value = "Edad";
                worksheet.Cell(1, 3).Value = "nombre del Departamento";
                

                for (int i = 0; i < lista.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = lista[i].NombreEmp;
                    worksheet.Cell(i + 2, 2).Value = lista[i].Edad;
                    worksheet.Cell(i + 2, 3).Value = lista[i].NombreDep;
                    
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    Title = "Guardar archivo Excel"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exportación completada con éxito.", "Éxito");
                }
            }
        }
        public List<EmpDep> ImportarDesdeExcel()
        {
            var Insertar = new List<EmpDep>();

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Seleccionar archivo Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook(openFileDialog.FileName))
                {
                    var worksheet = workbook.Worksheets.First();
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Saltar encabezado

                    foreach (var row in rows)
                    {
                        try
                        {
                            var NombreEmp = row.Cell(1).GetValue<string>();
                            var Edad = row.Cell(2).GetValue<int>();
                            var NombreDep = row.Cell(3).GetValue<string>();


                            Insertar.Add(new EmpDep
                            {
                                NombreEmp = NombreEmp,
                                Edad = Edad,
                                NombreDep = NombreDep
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error en la fila: {row.RowNumber()}.\n{ex.Message}", "Error al importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                    using (SqlConnection conn = conexion.GetConnection())
                    {
                        for (int i = 0; i < Insertar.Count; i++)
                        {
                            string query = "insert into empleados (nombre, edad) values (@NombreEmp, @Edad)";

                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@NombreEmp", Insertar[i].NombreEmp);
                            cmd.Parameters.AddWithValue("@Edad", Convert.ToInt32(Insertar[i].Edad));


                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }

                        for (int i = 0; i < Insertar.Count; i++)
                        {
                            string query = "insert into Departamentos (nombre) values (@NombreDep)";

                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@NombreDep", Insertar[i].NombreDep);
                            


                            
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
            }
                
                MessageBox.Show("Importación completada con éxito.", "Éxito");
            }

            return Insertar;
        }
    }
}
