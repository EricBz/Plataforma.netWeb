using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Neg
{
    public class Negocio
    {
		public List<Usuarios> listar()
		{
			List<Usuarios> lista = new List<Usuarios>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				conexion.ConnectionString = "data source= DESKTOP-IIATHCC; initial catalog= PRACTICA_ELT_WEB; integrated security=sspi";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "select * from usuarios";
				comando.Connection = conexion;

				conexion.Open();
				lector = comando.ExecuteReader();

				while (lector.Read())
				{
					Usuarios aux = new	Usuarios();
					aux.Id = lector.GetInt32(0);
					aux.Nombre = lector.GetString(1);
					aux.Apellido = lector.GetString(2);
					aux.Edad = lector.GetInt32(3);

					lista.Add(aux);

				}

				return lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (lector != null)
					lector.Close();
				conexion.Close();
			}


		}
	}
}
