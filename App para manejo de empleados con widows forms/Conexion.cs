using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TP_FINAL_Benitez_Eric
{
    internal class Conexion
    {
        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector = null;

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-IIATHCC\\; initial catalog=EMPLEADOS_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select * from Empleados";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Id = lector.GetInt32(0);
                    aux.NombreCompleto = lector.GetString(1);
                    aux.DNI = lector.GetString(2);
                    aux.Edad = lector.GetInt32(3);
                    aux.Casado = lector.GetBoolean(4);
                    aux.Salario = lector.GetDecimal(5);

                    lista.Add(aux);
                }
                lector.Close();
                conexion.Close();

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

        internal object FiltrarEmpleado(string buscar)
        {
            List<Empleado> Lista2 = new List<Empleado>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector = null;

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-IIATHCC\\; initial catalog=EMPLEADOS_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * from Empleados WHERE NombreCompleto = @nombre";
                comando.Parameters.AddWithValue("@nombre", buscar);
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Id = lector.GetInt32(0);
                    aux.NombreCompleto = lector.GetString(1);
                    aux.DNI = lector.GetString(2);
                    aux.Edad = lector.GetInt32(3);
                    aux.Casado = lector.GetBoolean(4);
                    aux.Salario = lector.GetDecimal(5);

                    Lista2.Add(aux);
                }
     
                return Lista2;

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

        internal void ModificarEmpleado(Empleado nuevo3)
        {
            SqlConnection conexion1 = new SqlConnection("data source=DESKTOP-IIATHCC\\; initial catalog=EMPLEADOS_DB; integrated security=sspi");
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion1;
                comando.CommandText = "UPDATE Empleados SET NombreCompleto =@nombre, DNI =@dni, Edad = @edad, Casado = @casado, Salario = @salario WHERE Id = @id";
                comando.Parameters.AddWithValue("@nombre", nuevo3.NombreCompleto);
                comando.Parameters.AddWithValue("@dni", nuevo3.DNI);
                comando.Parameters.AddWithValue("@edad", nuevo3.Edad);
                comando.Parameters.AddWithValue("@casado", nuevo3.Casado);
                comando.Parameters.AddWithValue("@salario", nuevo3.Salario);
                comando.Parameters.AddWithValue("@id", nuevo3.Id);

                conexion1.Open();
                comando.ExecuteNonQuery();
                conexion1.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }

        internal void Agregar(Empleado nuevo)
        {
            //Desde aca genero todas la conexiones y comandos necesarios.
            try
            {
                SqlConnection conexion1 = new SqlConnection("data source=DESKTOP-IIATHCC\\; initial catalog=EMPLEADOS_DB; integrated security=sspi");
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion1;
                comando.CommandText = "insert into Empleados values (@nombre, @dni, @edad, @casado, @salario)";
                comando.Parameters.AddWithValue("@nombre", nuevo.NombreCompleto);
                comando.Parameters.AddWithValue("@dni", nuevo.DNI);
                comando.Parameters.AddWithValue("@edad", nuevo.Edad);
                comando.Parameters.AddWithValue("@casado", nuevo.Casado);
                comando.Parameters.AddWithValue("@salario", nuevo.Salario);

                conexion1.Open();
                comando.ExecuteNonQuery();
                conexion1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        internal void EliminarProd(int Prod)
        {
            SqlConnection conexion2 = new SqlConnection("data source=DESKTOP-IIATHCC\\; initial catalog=EMPLEADOS_DB; integrated security=sspi");
            SqlCommand comando2 = new SqlCommand();
            try
            {
                comando2.CommandType = System.Data.CommandType.Text;
                comando2.Connection = conexion2;
                comando2.CommandText = "delete from Empleados where Id= @idpro";
                comando2.Parameters.AddWithValue("@idpro", Prod);

                conexion2.Open();
                comando2.ExecuteNonQuery();
                conexion2.Close();
            }
            catch   (Exception ex)
            {
                throw ex;
            }

        }
     
    }
}
