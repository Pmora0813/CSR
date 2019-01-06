using CSR_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Datos
{
    public class Datos_Login : I_CRUD<Login>
    {
        /// <summary>
        /// Insertamos un login en la Tabla
        /// de la BD
        /// </summary>
        /// <param name="log"></param>
        public void Insertar(Login log)
        {
            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {

                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion SP
                string sql = "SP_Login_Insert";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@usuario", log.usuario);
                comando.Parameters.AddWithValue("@contrasenna", log.contrasenna);
                comando.Parameters.AddWithValue("@tipo", log.tipo);

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
        /// <summary>
        /// Actualizamos un registro en la tabla Login
        /// en la BD
        /// </summary>
        /// <param name="log"></param>
        public void Actualizar(Login log)
        {
            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Login_Update";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@usuario", log.usuario);
                comando.Parameters.AddWithValue("@contrasenna", log.contrasenna);
                comando.Parameters.AddWithValue("@tipo", log.tipo);

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
        /// <summary>
        /// Eliminamos un Registro de la Tabla
        /// en la BD por el id 
        /// </summary>
        /// <param name="id"></param>
        /// 
        public void Eliminar(int Id)
        {

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Login_DeleteRow";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@Id", Id);
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

        /// <summary>
        /// Optenemos un Autor
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Login SeleccionarPorID(int Id)
        {
            Login log = null;

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Login_SelectRow";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@Id", Id);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando que permite obtener registros de la tabla
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    log = new Login
                    {
                        usuario = reader["usuario"].ToString(),
                        contrasenna = reader["contrasenna"].ToString(),
                        tipo = Convert.ToInt32(reader["tipo"].ToString())
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

            return log;

        }
        /// <summary>
        /// Optenemos una lista con todos los Autores
        /// que se encuentran en la BD
        /// </summary>
        /// <returns></returns>
        public List<Login> SeleccionarTodos()
        {
            List<Login> lista = new List<Login>();

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Login_SelectAll";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando que permite obtener registros de la tabla
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Login cat = new Login
                    {
                        usuario = reader["usuario"].ToString(),
                        contrasenna = reader["contrasenna"].ToString(),
                        tipo = Convert.ToInt32(reader["tipo"].ToString())
                    };

                    lista.Add(cat);

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
