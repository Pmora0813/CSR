using CSR_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Datos
{
    public class Datos_Arrendatario : I_CRUD<Arrendatario>
    {
        public void Actualizar(Arrendatario obj)
        {
            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Arrendatario_Update";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@cedula", obj.cedula);
                comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@p_Apellido", obj.p_Apellido);
                comando.Parameters.AddWithValue("@s_Apellido", obj.s_Apellido);
                comando.Parameters.AddWithValue("@telefono", obj.telefono);
                comando.Parameters.AddWithValue("@correo", obj.correo);
                comando.Parameters.AddWithValue("@direccion", obj.direccion);
                comando.Parameters.AddWithValue("@notas", obj.notas);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Este metodo no lo usamos en este caso
        //por que para elliminar un arrendatario 
        //recivimos un string y este un int
        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar_Arrendatario(string cedula)
        {

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Arrendatario_DeleteRow";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@cedula", cedula);
                //comando.Parameters.AddWithValue("@Nombre", cat.Nombre);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Insertar(Arrendatario obj)
        {

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {

                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion SP
                string sql = "SP_Arrendatario_Insert";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@cedula", obj.cedula);
                comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@p_Apellido", obj.p_Apellido);
                comando.Parameters.AddWithValue("@s_Apellido", obj.s_Apellido);
                comando.Parameters.AddWithValue("@telefono", obj.telefono);
                comando.Parameters.AddWithValue("@correo", obj.correo);
                comando.Parameters.AddWithValue("@direccion", obj.direccion);
                comando.Parameters.AddWithValue("@notas", obj.notas);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        //Este metodo no lo utilizamos por que recive un int
        //Utilizamos un string para seleccionar un Arrendatario
        public Arrendatario SeleccionarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Arrendatario SeleccionarPorID(string cedula)
        {
            Arrendatario arrendatario = null;

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Arrendatario_SelectRow";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@cedula", cedula);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando que permite obtener registros de la tabla
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                   arrendatario = new Arrendatario
                    {
                        cedula = reader["cedula"].ToString(),
                        nombre = reader["nombre"].ToString(),
                        p_Apellido = reader["p_Apellido"].ToString(),
                        s_Apellido = reader["s_Apellido"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        correo = reader["correo"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        notas = reader["notas"].ToString()
                    };


                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return arrendatario;
        }

        public List<Arrendatario> SeleccionarTodos()
        {
            List<Arrendatario> lista = new List<Arrendatario>();

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Arrendatario_SelectAll";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando que permite obtener registros de la tabla
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Arrendatario arrendatario = new Arrendatario
                    {
                        cedula = reader["cedula"].ToString(),
                        nombre = reader["nombre"].ToString(),
                        p_Apellido = reader["p_Apellido"].ToString(),
                        s_Apellido = reader["s_Apellido"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        correo = reader["correo"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        notas = reader["notas"].ToString()
                    };

                    lista.Add(arrendatario);

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return lista;

        }
    }
}
