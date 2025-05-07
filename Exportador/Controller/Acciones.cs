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
    }
}
